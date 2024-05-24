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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            GestionEmpleado gestionEmpleado = new GestionEmpleado();
            gestionEmpleado.ShowDialog();
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
            GestionDocentes gestionDocentes = new GestionDocentes();
            gestionDocentes.ShowDialog();
        }

        private void gestionDeEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionEstudiantes gestionEstudiantes = new GestionEstudiantes();   
            gestionEstudiantes.ShowDialog();
        }
    }
}
