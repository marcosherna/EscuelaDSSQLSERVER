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

namespace EscuelaDS.GUI.Catalogos.Departamento
{
    public partial class GestionDepartamentos : Form
    {
        public CLS.Catalogos.Departamento departamentoSeleccionado = null;
        public GestionDepartamentos()
        {
            InitializeComponent();

            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.dtgOpciones.SelectionChanged += LtbOpciones_SelectedValueChanged;
        }

        private async void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var item = (DepartamentoDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                    departamentoSeleccionado = await CLS.Catalogos.Departamento.GetAsync(item.Id);

                    if(departamentoSeleccionado != null)
                    {
                        this.txbNombre.Text = departamentoSeleccionado.Nombre;
                        this.cmbPaises.SelectedValue = departamentoSeleccionado.IdPais;
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
                if (this.rbEliminar.Checked) this.txbNombre.Enabled = false;

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<DepartamentoDto>)this.dtgOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        var item = (DepartamentoDto)this.dtgOpciones.CurrentRow.DataBoundItem;
                        departamentoSeleccionado = await CLS.Catalogos.Departamento.GetAsync(item.Id);
                        this.txbNombre.Text = departamentoSeleccionado.Nombre;
                        this.cmbPaises.SelectedValue = departamentoSeleccionado.IdPais;
                    }
                }

                if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
            }
            catch (Exception exc)
            { 
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (departamentoSeleccionado == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await departamentoSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                this.departamentoSeleccionado = null;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (departamentoSeleccionado == null) throw new Exception("Debe seleccionar un país");
            departamentoSeleccionado.Nombre = this.txbNombre.Text;
            departamentoSeleccionado.IdPais = (int)this.cmbPaises.SelectedValue;

            departamentoSeleccionado.Validate();
            bool result = await departamentoSeleccionado.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            this.departamentoSeleccionado = null; 
            await Cargar();
        }

        private async Task Guardar()
        { 
            CLS.Catalogos.Departamento departamento = new CLS.Catalogos.Departamento();
            departamento.Nombre = this.txbNombre.Text;
            departamento.IdPais = (int)this.cmbPaises.SelectedValue;
            departamento.Validate();

            bool result = await departamento.SaveAsync();
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
            List<Pais> paises = await Pais.GetAsync();
            this.cmbPaises.DataSource = paises;
            this.cmbPaises.DisplayMember = "Nombre";
            this.cmbPaises.ValueMember = "Id";
        }

        private async Task Cargar()
        {
            List<DepartamentoDto> paises = await CLS.Catalogos.Departamento.GetAsync();
            this.dtgOpciones.DataSource = paises; 
        }
    }
}
