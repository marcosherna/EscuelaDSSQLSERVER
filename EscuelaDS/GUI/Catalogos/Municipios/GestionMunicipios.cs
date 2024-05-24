using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EscuelaDS.GUI.Catalogos.Municipios
{
    public partial class GestionMunicipios : Form
    {
        private Municipio municipioSeleccionado = null;
        public GestionMunicipios()
        {
            InitializeComponent();
            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.dtgOpciones.SelectionChanged += LtbOpciones_SelectedValueChanged;

            this.cmbPaises.SelectedValueChanged += CmbPaises_SelectedValueChanged;
        }

        private async void CmbPaises_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            { 

                if (!this.rbEliminar.Checked)
                {
                    this.cmbPaises.Enabled = true;
                    this.cmbDepartamentos.Enabled = true;

                    var item = (Pais)this.cmbPaises.SelectedItem;
                    if (item != null)
                    {
                        await CargarDepartamentos(item);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDepartamentos(Pais item)
        {
            this.cmbDepartamentos.DataSource = await item.GetDepartamentosAsync();
            this.cmbDepartamentos.DisplayMember = "Nombre";
            this.cmbDepartamentos.ValueMember = "Id";
        }

        private async void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var item = (MunicipioDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                    municipioSeleccionado = await CLS.Catalogos.Municipio.GetByIdAsync(item.Id);

                    if (municipioSeleccionado != null)
                    {
                        await MostrarMunicipioSeleccionado();
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.txbNombre.Enabled = true;
                this.cmbPaises.Enabled = true;
                this.cmbDepartamentos.Enabled = true;
                if (this.rbEliminar.Checked)
                {
                    this.txbNombre.Enabled = false;
                    this.cmbPaises.Enabled = false;
                    this.cmbDepartamentos.Enabled = false;
                }

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<MunicipioDto>)this.dtgOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        var item = (MunicipioDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                        municipioSeleccionado = await CLS.Catalogos.Municipio.GetByIdAsync(item.Id);

                        await MostrarMunicipioSeleccionado();

                    }
                }

                if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MostrarMunicipioSeleccionado()
        {
            this.cmbPaises.SelectedValue = municipioSeleccionado.IdPais;
            this.txbNombre.Text = municipioSeleccionado.Nombre;
            await CargarDepartamentos((Pais)(this.cmbPaises.SelectedItem));
            this.cmbDepartamentos.SelectedValue = municipioSeleccionado.IdDepartamento;
        }

        private async void BtnOperaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbNuevo.Checked) await Guardar();
                if (this.rbModificar.Checked) await Mdificar();
                if (this.rbEliminar.Checked) await Eliminar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Eliminar()
        {
            if (municipioSeleccionado == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await municipioSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (municipioSeleccionado == null) throw new Exception("Debe seleccionar un país");
            municipioSeleccionado.Nombre = this.txbNombre.Text;
            municipioSeleccionado.IdDepartamento = (int)this.cmbDepartamentos.SelectedValue;

            municipioSeleccionado.Validate();
            bool result = await municipioSeleccionado.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            await Cargar();
        }

        private async Task Guardar()
        {
            CLS.Catalogos.Municipio municipio = new CLS.Catalogos.Municipio();
            municipio.Nombre = this.txbNombre.Text;
            municipio.IdDepartamento = (int)this.cmbDepartamentos.SelectedValue;

            municipio.Validate();

            bool result = await municipio.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            await Cargar();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarPaises();
                await Cargar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarPaises()
        {
            List<Pais> paises = await Pais.GetAsync( pais => pais.Departamentos.Count > 0);
            this.cmbPaises.DataSource = paises;
            this.cmbPaises.DisplayMember = "Nombre";
            this.cmbPaises.ValueMember = "Id";
        }

        private async Task Cargar()
        {
            List<MunicipioDto> paises = await CLS.Catalogos.Municipio.GetAsync();
            this.dtgOpciones.DataSource = paises;
        }
    }
}
