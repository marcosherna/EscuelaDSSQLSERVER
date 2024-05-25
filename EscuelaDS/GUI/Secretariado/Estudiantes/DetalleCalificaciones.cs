using EscuelaDS.CLS.Dtos;
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
    public partial class DetalleCalificaciones : Form
    {
        private DocenteDto docente = null;
        private Grupo grupo = null;
        public DetalleCalificaciones(DocenteDto docente, Grupo grupo)
        {
            InitializeComponent();
            this.docente = docente;
            this.grupo = grupo;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarDatos();
            }
            catch (Exception exc)
            { 
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarDatos()
        {
            if(docente != null)
            { 
                lblDocente.Text = docente.Nombre;  
            }

            if(grupo != null)
            {
                var estudiantes = await grupo.GetEstudiantesAsync();
                dtgOpciones.DataSource = estudiantes;
            }
        }

        private void tsbCalificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtgOpciones.SelectedRows.Count >= 0)
                {
                    var estudiante = dtgOpciones.CurrentRow.DataBoundItem as EstudianteCalificadoDto;
                    if(estudiante != null)
                    {
                        var frm = new EdicionCalificacion(estudiante, docente);
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
