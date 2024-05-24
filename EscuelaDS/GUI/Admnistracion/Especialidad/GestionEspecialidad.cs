using EscuelaDS.CLS.Administracion;
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

namespace EscuelaDS.GUI.Admnistracion.Especialidad
{
    public partial class GestionEspecialidad : Form
    {
        private CLS.Administracion.Especialidad especialidadSeleccionada = null;
        public GestionEspecialidad()
        {
            InitializeComponent();

            this.btnOperaciones.Click += BtnOperaciones_Click;
            this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.dtgOpciones.SelectionChanged += LtbOpciones_SelectedValueChanged;
        }

        private void LtbOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    especialidadSeleccionada = (CLS.Administracion.Especialidad)this.dtgOpciones.CurrentRow.DataBoundItem; 

                    if (especialidadSeleccionada != null)
                    {
                        this.txbCarrera.Text = especialidadSeleccionada.Carrera;
                        this.txbEspecialidad.Text = especialidadSeleccionada.Nombre;
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.txbCarrera.Enabled = true;
                this.txbEspecialidad.Enabled = true;

                if (this.rbEliminar.Checked) 
                {
                    this.txbCarrera.Enabled = false;
                    this.txbEspecialidad.Enabled = false;
                }

                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    var items = (List<CLS.Administracion.Especialidad>)this.dtgOpciones.DataSource;
                    if (items.Count > 0)
                    {
                        especialidadSeleccionada = (CLS.Administracion.Especialidad)this.dtgOpciones.CurrentRow.DataBoundItem; 
                        this.txbCarrera.Text = especialidadSeleccionada.Carrera;
                        this.txbEspecialidad.Text = especialidadSeleccionada.Nombre;
                    }
                }

                if (this.rbNuevo.Checked)
                {
                    this.txbCarrera.Text = string.Empty;
                    this.txbEspecialidad.Text = string.Empty;
                }
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
            if (especialidadSeleccionada == null) throw new Exception("Debe seleccionar un país");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await especialidadSeleccionada.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbCarrera.Text = string.Empty;
                this.txbEspecialidad.Text = string.Empty;
                this.especialidadSeleccionada = null;
                await Cargar();
            }

        }

        private async Task Mdificar()
        {
            if (especialidadSeleccionada == null) throw new Exception("Debe seleccionar un país");
            especialidadSeleccionada.Nombre = this.txbEspecialidad.Text;
            especialidadSeleccionada.Carrera = this.txbCarrera.Text;

            especialidadSeleccionada.Validate();
            bool result = await especialidadSeleccionada.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbCarrera.Text = string.Empty;
            this.txbEspecialidad.Text = string.Empty;
            this.especialidadSeleccionada = null;
            await Cargar();
        }

        private async Task Guardar()
        {
            CLS.Administracion.Especialidad especialidad = new CLS.Administracion.Especialidad();
            especialidad.Nombre = this.txbEspecialidad.Text;
            especialidad.Carrera = this.txbCarrera.Text;

            especialidad.Validate();

            bool result = await especialidad.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbCarrera.Text = string.Empty;
            this.txbEspecialidad.Text = string.Empty;
            await Cargar();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            { 
                await Cargar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }
         
        private async Task Cargar()
        {
            List<CLS.Administracion.Especialidad> paises = await CLS.Administracion.Especialidad.GetAsync();
            this.dtgOpciones.DataSource = paises;
        }
    }
}
