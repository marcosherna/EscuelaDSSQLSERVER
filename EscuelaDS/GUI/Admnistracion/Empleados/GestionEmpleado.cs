using EscuelaDS.CLS.Administracion;
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

namespace EscuelaDS.GUI.Admnistracion.Empleados
{
    public partial class GestionEmpleado : Form
    {
        private Empleado empleadoSeleccionado = null;
        List<EmpleadoDto> empleados = new List<EmpleadoDto>();
        public GestionEmpleado()
        {
            InitializeComponent();
            this.dtgEmpleados.SelectionChanged += DtgEmpleados_SelectionChanged;
            this.txbSearch.TextChanged += TxbSearch_TextChanged;
        }

        private void TxbSearch_TextChanged(object sender, EventArgs e)
        {  
            if (empleados.Count > 0)
            {
                var filtro = this.empleados.Where(x => x.Descripcion.ToLower().Contains(this.txbSearch.Text.ToLower())).ToList();
                this.dtgEmpleados.DataSource = filtro;
            }

            if(this.txbSearch.Text.Length == 0)
            { 
                this.dtgEmpleados.DataSource = this.empleados;
            }
        }

        private async void DtgEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            var empleados = (List<EmpleadoDto>)this.dtgEmpleados.DataSource;
            if(empleados.Count > 0) 
            { 
                var dto = (EmpleadoDto)this.dtgEmpleados.CurrentRow.DataBoundItem;
                empleadoSeleccionado =await  Empleado.GeAsync(dto.Id);
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarEmpleados();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarEmpleados()
        { 
            this.empleados = await Empleado.GeAsync();
            dtgEmpleados.DataSource = this.empleados;
        }

        private async void tsbAgregar_Click(object sender, EventArgs e)
        {
            EdicionEmpleado edicionEmpleado = new EdicionEmpleado();
            var result = edicionEmpleado.ShowDialog();
            if (result == DialogResult.OK)
            {
                await CargarEmpleados();
            }
        }

        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgEmpleados.SelectedRows.Count < 0) throw new Exception("Porfavor Seleccione un registro antes de ejecutar la accion");

                var dto = (EmpleadoDto)this.dtgEmpleados.CurrentRow.DataBoundItem;
                var empleado = await Empleado.GeAsync(dto.Id);
                EdicionEmpleado edicionEmpleado = new EdicionEmpleado(empleado);
                var result = edicionEmpleado.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await CargarEmpleados();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgEmpleados.SelectedRows.Count < 0) throw new Exception("Porfavor Seleccione un registro antes de ejecutar la accion");

                var dto = (EmpleadoDto)this.dtgEmpleados.CurrentRow.DataBoundItem;
                var empleado = await Empleado.GeAsync(dto.Id);

                if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = await empleado.DeleteAsync();
                    if (!result) throw new Exception("El registro no pudo ser eliminado");

                    MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarEmpleados();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
