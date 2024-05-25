using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Rector;
using EscuelaDS.CLS.Secretaria;
using EscuelaDS.DataLayer;
using EscuelaDS.GUI.Admnistracion;
using EscuelaDS.GUI.Admnistracion.Empleados;
using EscuelaDS.GUI.Admnistracion.Especialidad;
using EscuelaDS.GUI.Catalogos;
using EscuelaDS.GUI.Catalogos.Departamento;
using EscuelaDS.GUI.Catalogos.Distritos;
using EscuelaDS.GUI.Catalogos.Municipios;
using EscuelaDS.GUI.Rector.Aulas;
using EscuelaDS.GUI.Rector.Docentes;
using EscuelaDS.GUI.Rector.Materias;
using EscuelaDS.GUI.Rector.Turnos;
using EscuelaDS.GUI.Secretariado.Estudiantes;
using EscuelaDS.GUI.Secretariado.Grupos;
using EscuelaDS.GUI.Secretariado.Matriculas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await cargarGrupos();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }
        
        private async Task cargarGrupos()
        { 
            var gruposTree =  await Grupo.GetTreeAsync();
            TreeNode node = null;
            gruposTree.ForEach(grupo => {                 

                node = new TreeNode(grupo.Detalle);
                node.Tag = grupo.Id;

                var nodeProfesor = new TreeNode(grupo.Profesor.Detalle);
                nodeProfesor.Tag = grupo.Profesor.Id;  

                tvGrupos.Nodes[0].Nodes.Add(node);

                node.Nodes.Add(nodeProfesor);

                node.Nodes.Add("Estudiantes");
                node.ContextMenuStrip = cmsGrupos;

                grupo.Estudies.ForEach(estudiante => {
                    var nodeEstudiante = new TreeNode(estudiante.Detalle);
                    nodeEstudiante.Tag = estudiante.Id;

                    node.Nodes[1].Nodes.Add(nodeEstudiante);
                    nodeEstudiante.ContextMenuStrip = cmsEstudiantesC;
                });

            });  
        } 

        #region navegaciones
        private void gestionPaisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestionPais gestionPais = new GestionPais();    
            gestionPais.ShowDialog();
        }

        private void gestionDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionDepartamentos gestionDepartamentos = new GestionDepartamentos();
            gestionDepartamentos.ShowDialog();
        }

        private void gestionMunicipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionMunicipios gestionMunicipios = new GestionMunicipios();
            gestionMunicipios.ShowDialog();
        }

        private void gestionDistritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionDistritos gestionDistritos = new GestionDistritos();
            gestionDistritos.ShowDialog();
        }

        private void gestionCargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionCargos gestionCargos = new GestionCargos();
            gestionCargos.ShowDialog();
        }

        private void gestionEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GestionEmpleado gestionEmpleado = new GestionEmpleado();
            //gestionEmpleado.ShowDialog();

            ShowContent(new GestionEmpleado());
        }

        private void gestionEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionEspecialidad gestionEspecialidad = new GestionEspecialidad();
            gestionEspecialidad.ShowDialog();
        }

        private void gestionDeAulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionAulas gestionAulas = new GestionAulas();
            gestionAulas.ShowDialog();
        }

        private void gestionDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionTurnos gestionTurnos = new GestionTurnos();
            gestionTurnos.ShowDialog();
        }

        private void gestionDeMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionMaterias gestionMaterias = new GestionMaterias();
            gestionMaterias.ShowDialog();
        }

        private void gestionDeDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GestionDocentes gestionDocentes = new GestionDocentes();
            //gestionDocentes.ShowDialog();

            ShowContent(new GestionDocentes());
        }

        private void gestionDeEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GestionEstudiantes gestionEstudiantes = new GestionEstudiantes();   
            //gestionEstudiantes.ShowDialog();
            ShowContent(new GestionEstudiantes());
        }

        private void gestionDeGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionGrupos gestionGrupos = new GestionGrupos();
            gestionGrupos.ShowDialog();
        }

        

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            gestionDeGruposToolStripMenuItem_Click(sender, e);
        }
        #endregion

        private async void opToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var nodeGrupo = this.tvGrupos.SelectedNode;
                if (nodeGrupo == null) throw new Exception("Seleccione un grupo");

                if (MessageBox.Show("¿Desea quitar el grupo?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idGrupo = Convert.ToInt32(nodeGrupo.Tag);
                    int idEstudiante = Convert.ToInt32(this.tvGrupos.SelectedNode.Tag);

                    await Grupo.DeleteAsync(idGrupo);
                    this.tvGrupos.SelectedNode.Remove();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tsbRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                this.tvGrupos.Nodes[0].Nodes.Clear();
                await cargarGrupos();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void matricularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                var grupo = this.tvGrupos.SelectedNode;
                GestionMatricula gestionMatriculas = new GestionMatricula(new Grupo { Id = Convert.ToInt32(grupo.Tag) });
                var result = gestionMatriculas.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            try
            {
                var nodeGrupo = this.tvGrupos.SelectedNode.Parent.Parent;
                if (nodeGrupo == null) throw new Exception("Seleccione un estudiante");

                if (MessageBox.Show("¿Desea quitar al estudiante del grupo?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    int idGrupo = Convert.ToInt32(nodeGrupo.Tag);
                    int idEstudiante = Convert.ToInt32(this.tvGrupos.SelectedNode.Tag);

                    await Matricula.DeleteAsync(idGrupo, idEstudiante);
                    this.tvGrupos.SelectedNode.Remove();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private Form activeForm = null;
        private void ShowContent(Form content)
        {
            activeForm = content;
            content.TopLevel = false;
            content.FormBorderStyle = FormBorderStyle.None;
            content.Dock = DockStyle.Fill;
            ContentLayout.Controls.Add(content);
            ContentLayout.Tag = content;
            content.BringToFront();
            content.Show(); 
        }

        private async void asignarDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // validate node not null

                var nodeGrupo = this.tvGrupos.SelectedNode;
                var nodeDocente = this.tvGrupos.SelectedNode.Nodes[0];

                if (nodeDocente == null) throw new Exception("Seleccione un docente");
                if (nodeGrupo == null) throw new Exception("Seleccione un grupo");

                var dto = new DocenteDto
                {
                    Id = Convert.ToInt32(nodeDocente.Tag),
                    Nombre = nodeDocente.Text
                };

                var grupo = await Grupo.GetAsync(Convert.ToInt32(nodeGrupo.Tag));
                ShowContent(new DetalleCalificaciones(dto, grupo));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
