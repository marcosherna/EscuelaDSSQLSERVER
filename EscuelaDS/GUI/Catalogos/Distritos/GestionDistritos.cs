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

namespace EscuelaDS.GUI.Catalogos.Distritos
{
    public partial class GestionDistritos : Form
    {
        private Distrito distritoSeleccionado = null;
        public GestionDistritos()
        {
            InitializeComponent();
            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.dtgOpciones.SelectionChanged += LtbOpciones_SelectedValueChanged;

            this.cmbPaises.SelectedValueChanged += CmbPaises_SelectedValueChanged;
            this.cmbDepartamentos.SelectedValueChanged += CmbDepartamentos_SelectedValueChanged;
        }

        private async void CmbDepartamentos_SelectedValueChanged(object sender, EventArgs e)
        { 
                await CargarMunicipios(); 
        }

        private async Task CargarMunicipios()
        {
            var item = (CLS.Catalogos.Departamento)this.cmbDepartamentos.SelectedItem;
            if (item != null)
            {
                var municipios = await Municipio.GetByIdDepartamentoAsync(item.Id);
                this.cmbMunicipios.DataSource = municipios;
                this.cmbMunicipios.DisplayMember = "Nombre";
                this.cmbMunicipios.ValueMember = "Id";
            }
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
            this.cmbDepartamentos.DataSource = await item.GetDepartamentosAsync( 
                    departamento => departamento.Municipios.Count > 0);

            this.cmbDepartamentos.DisplayMember = "Nombre";
            this.cmbDepartamentos.ValueMember = "Id";
        }

        private async void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var item = (DistritoDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                    distritoSeleccionado = await Distrito.GetByIdAsync(item.Id);

                    if (distritoSeleccionado != null)
                    {
                        await MostrardistritoSeleccionado();
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
                this.cmbMunicipios.Enabled = true;
                if (this.rbEliminar.Checked)
                {
                    this.txbNombre.Enabled = false;
                    this.cmbPaises.Enabled = false;
                    this.cmbDepartamentos.Enabled = false;
                    this.cmbMunicipios.Enabled = false; 
                }

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<DistritoDto>)this.dtgOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        var item = (DistritoDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                        distritoSeleccionado = await Distrito.GetByIdAsync(item.Id);

                        await MostrardistritoSeleccionado();

                    }
                }

                if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MostrardistritoSeleccionado()
        {
            this.cmbPaises.SelectedValue = distritoSeleccionado.IdPais;
            this.txbNombre.Text = distritoSeleccionado.Nombre;
            await CargarDepartamentos((Pais)(this.cmbPaises.SelectedItem));
            this.cmbDepartamentos.SelectedValue = distritoSeleccionado.IdDepartamento;
            await CargarMunicipios();
            this.cmbMunicipios.SelectedValue = distritoSeleccionado.IdMunicipio;
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
            if (distritoSeleccionado == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await distritoSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                this.distritoSeleccionado = null;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (distritoSeleccionado == null) throw new Exception("Debe seleccionar un país");
            distritoSeleccionado.Nombre = this.txbNombre.Text;
            distritoSeleccionado.IdMunicipio = (int)this.cmbMunicipios.SelectedValue;

            distritoSeleccionado.Validate();
            bool result = await distritoSeleccionado.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            this.distritoSeleccionado = null; 
            await Cargar();
        }

        private async Task Guardar()
        {
            Distrito distrito = new Distrito();
            distrito.Nombre = this.txbNombre.Text;
            distrito.IdMunicipio = (int)this.cmbMunicipios.SelectedValue;

            distrito.Validate();

            bool result = await distrito.SaveAsync();
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
            List<Pais> paises = await Pais.GetAsync(pais => pais.Departamentos.Count > 0 && 
            pais.Departamentos.Where(departamento => departamento.Municipios.Count > 0).Count() > 0);
            this.cmbPaises.DataSource = paises;
            this.cmbPaises.DisplayMember = "Nombre";
            this.cmbPaises.ValueMember = "Id";
        }

        private async Task Cargar()
        {
            List<DistritoDto> distritos = await Distrito.GetAsync();
            this.dtgOpciones.DataSource = distritos;
        }
    }
}
