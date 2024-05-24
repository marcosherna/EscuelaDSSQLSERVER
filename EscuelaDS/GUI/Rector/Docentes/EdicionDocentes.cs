using EscuelaDS.CLS.Administracion;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Rector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Rector.Docentes
{
    public partial class EdicionDocentes : Form
    {
        private Docente docenteSeleccionado = null;
        public EdicionDocentes(Docente docenteSeleccionado = null)
        {
            InitializeComponent();

            this.docenteSeleccionado = docenteSeleccionado;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                
                await CargarEspecialidades();
                await CargarEmpleados();
                CargarDocenteSeleccionado();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private void CargarDocenteSeleccionado()
        {
            if(docenteSeleccionado != null)
            {
                this.cmbEmpleados.SelectedValue = docenteSeleccionado.IdEmpleado;
                this.cmbEspecialidad.SelectedValue = docenteSeleccionado.IdEspecialidad;
                this.txbEscalafon.Text = docenteSeleccionado.Escalafon;
            }
        }

        private async Task CargarEspecialidades()
        {
            var especialidades = await Especialidad.GetAsync();
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "Id";  
        }

        internal class EmpleadoCMB
        {
            public int Id { get; set; }
            public int Nombre { get; set; }
        }

        private async Task CargarEmpleados()
        {
            List<EmpleadoDto> empleados = await Empleado.GeAsync(); 
            cmbEmpleados.DataSource = empleados;
            cmbEmpleados.DisplayMember = "Descripcion";
            cmbEmpleados.ValueMember = "Id";

        }
         

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (docenteSeleccionado == null) await Guardar();
                if (docenteSeleccionado != null) await Modificar();
                
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Modificar()
        {
            if (docenteSeleccionado == null) throw new Exception("Es imposible recuperar el registro, intentalo mas tarde");
            docenteSeleccionado.IdEmpleado = Convert.ToInt32(this.cmbEmpleados.SelectedValue);
            docenteSeleccionado.IdEspecialidad= Convert.ToInt32(this.cmbEspecialidad.SelectedValue);
            docenteSeleccionado.Escalafon = this.txbEscalafon.Text;

            docenteSeleccionado.Validate();

            bool result = await docenteSeleccionado.UpdateAsync();
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registro fue actualizado exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.docenteSeleccionado = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async Task Guardar()
        {
            Docente docente = new Docente
            {
                IdEmpleado = Convert.ToInt32(this.cmbEmpleados.SelectedValue),
                IdEspecialidad = Convert.ToInt32(this.cmbEspecialidad.SelectedValue),
                Escalafon = this.txbEscalafon.Text,
            };

            docente.Validate();

            bool result = await docente.SaveAsync();
            if (!result) throw new Exception("Ocurrio un problema interno, porfavor intentalo mas tarde");

            MessageBox.Show("El registro fue agreago exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
