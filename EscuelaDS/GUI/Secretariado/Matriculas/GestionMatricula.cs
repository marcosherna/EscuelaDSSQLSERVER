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

namespace EscuelaDS.GUI.Secretariado.Matriculas
{
    public partial class GestionMatricula : Form
    {
        Grupo grupoSeleccionado = null;
        List<EstudianteDto> estudiantes = new List<EstudianteDto>();
        List<GrupoDto> grupos = new List<GrupoDto>();
        public GestionMatricula(Grupo grupo = null)
        {
            InitializeComponent();
            this.grupoSeleccionado = grupo;
            this.txbBuscar.TextChanged += TxbBuscar_TextChanged;
        }

        private void TxbBuscar_TextChanged(object sender, EventArgs e)
        { 
            this.dtgEstudiantes.DataSource = estudiantes
                    .Where(estudiante => estudiante.Nombres.Contains(this.txbBuscar.Text) || 
                        estudiante.Apellidos.Contains(this.txbBuscar.Text))
                    .ToList();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarGrupos();
                await CargarEstudiantes();

                if(this.cmbGrupos.Items.Count > 0 && grupoSeleccionado != null)
                {
                    int index = this.grupos.IndexOf(this.grupos.Find(grupo => grupo.Id == this.grupoSeleccionado.Id));
                    this.cmbGrupos.SelectedIndex = index;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            base.OnLoad(e);
        }

        private async Task CargarEstudiantes()
        { 
            var estudiantes = await Estudiante.GeAsync(); 
            dtgEstudiantes.DataSource = estudiantes;
        }

        private async Task CargarGrupos()
        {
            var grupos = await Grupo.GetAsync();
            grupos.ForEach(grupo =>
            {
                this.cmbGrupos.Items.Add($"{grupo.Grado} { grupo.Seccion}");
            });
            this.grupos = grupos;
        }

        private async void btnMatricular_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.cmbGrupos.SelectedIndex < 0) throw new Exception("Seleccione un grupo");
                if (this.dtgEstudiantes.SelectedRows.Count < 0) throw new Exception("Seleccione un estudiante");

                var estudiante = (EstudianteDto)this.dtgEstudiantes.CurrentRow.DataBoundItem;
                Matricula matricula = new Matricula
                { 
                    NIE = estudiante.NIE,
                    IdGrupo = this.grupos[this.cmbGrupos.SelectedIndex].Id
                };

                matricula.Validate();   
                bool result = await matricula.SaveAsync();
                if (!result) throw new Exception(" no pudo ser matriculado");

                MessageBox.Show("Estudiante matriculado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grupoSeleccionado = null;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
