using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Rector;
using EscuelaDS.CLS.Secretaria;
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
    public partial class GestionCalificacion : Form
    {
        private Estudiante estudiante = null;
        private List<CalificacionMateriaDto> calificaciones = new List<CalificacionMateriaDto>();
        private DocenteDto docente = null;
        public GestionCalificacion(Estudiante estudiante, DocenteDto docente)
        {
            InitializeComponent();
            this.estudiante = estudiante;
            this.docente = docente;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarCalificaciones();
            }
            catch (Exception exc)
            { 
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarCalificaciones()
        {
            this.lblNombre.Text = estudiante.Nombres;
            var calificaciones = await estudiante.GetCalificacionesPorMateria();
            dtgCalificaciones.DataSource = calificaciones;
            this.calificaciones = calificaciones;
        }

        private async void pegarToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                var estudiante = new EstudianteCalificadoDto
                {
                    NIE =  this.estudiante.NIE,
                    Nombre = this.estudiante.Nombres
                };

               EdicionCalificacion edicionCalificacion = new EdicionCalificacion(estudiante, docente);
               var result = edicionCalificacion.ShowDialog();

                if (result == DialogResult.OK)
                {
                     await CargarCalificaciones();
                } 
            }
            catch (Exception exc)
            { 
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private async void copiarToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dtgCalificaciones.SelectedRows.Count < 0) throw new Exception("Debe seleccionar una fila");
                var dto = this.dtgCalificaciones.CurrentRow.DataBoundItem as CalificacionMateriaDto;
                if (dto != null)
                {
                    var calificacion = await Calificacion.GetAsync(dto.Id);

                    EdicionCalificacionMateria edicionCalificacion = new EdicionCalificacionMateria(calificacion);
                    var result = edicionCalificacion.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        await CargarCalificaciones();
                    }
                }
            }
            catch (Exception exc)
            { 
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
    }
}
