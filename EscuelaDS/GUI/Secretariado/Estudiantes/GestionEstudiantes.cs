using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Rector;
using EscuelaDS.CLS.Secretaria;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Secretariado.Estudiantes
{
    public partial class GestionEstudiantes : Form
    {
        private List<EstudianteDto> estudiantes =  new List<EstudianteDto>();
        public GestionEstudiantes()
        { 
            InitializeComponent();
            this.tsbSearch.TextChanged += TsbSearch_TextChanged;
        }
        private void TsbSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.tsbSearch.Text != null)
            {
                string query = this.tsbSearch.Text;
                var fillter = estudiantes.Where(
                    estudiante => estudiante.Nombres.ToLower().Contains(query) ||
                    estudiante.Apellidos.ToLower().Contains(query) ||
                    estudiante.Encargado.ToLower().Contains(query) ||
                    estudiante.NIE.ToString().Contains(query)).ToList();

                dtgEstudiantes.DataSource = fillter;
            }

            if (this.tsbSearch.Text == null)
                dtgEstudiantes.DataSource = estudiantes;
        }
        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await Cargar();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task Cargar()
        {
            this.estudiantes = await Estudiante.GeAsync();
            this.dtgEstudiantes.DataSource = this.estudiantes;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                EdicioEstudiantes edicioEstudiantes = new EdicioEstudiantes();
                var result = edicioEstudiantes.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await Cargar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void stnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgEstudiantes.SelectedRows.Count < 0) throw new Exception("Seleccione un registro primero");
                var dto = (EstudianteDto)this.dtgEstudiantes.CurrentRow.DataBoundItem;
                Estudiante estudiante = await Estudiante.GeAsync(dto.NIE);

                EdicioEstudiantes edicioEstudiantes = new EdicioEstudiantes(estudiante);
                var result = edicioEstudiantes.ShowDialog();
                
                if(result == DialogResult.OK)
                {
                    await Cargar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgEstudiantes.SelectedRows.Count < 0) throw new Exception("Seleccione un registro primero");
                var dto = (EstudianteDto)this.dtgEstudiantes.CurrentRow.DataBoundItem;
               

                if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Estudiante estudiante = await Estudiante.GeAsync(dto.NIE);
                    bool result = await estudiante.DeleteAsync();
                    if (!result) throw new Exception("El registro no pudo ser eliminado");

                    MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await Cargar();
                }
                 
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Ocurrio un problema: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
