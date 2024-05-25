using EscuelaDS.CLS.Administracion;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.GUI.Secretariado.Estudiantes
{
    public partial class EdicionCalificacion : Form
    {
        EstudianteCalificadoDto estudiantes = null;
        Calificacion calificacion = null;
        DocenteDto docente = null;
        public EdicionCalificacion(EstudianteCalificadoDto estudiantes, DocenteDto docente)
        {
            InitializeComponent();
            this.estudiantes = estudiantes;
            this.docente = docente;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargoMaterias();
                await CargarNotas();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarNotas()
        {
            txbExamen1.Text = "0";
            txbExamen2.Text = "0";
            txbExamen3.Text = "0";
            txbExamenFinal.Text = "0";
            txbTareas.Text = "0";
            lblPromedio.Text = "0";

            if (estudiantes != null)
            {
                lblNie.Text = estudiantes.NIE.ToString();
                lblNombreEstudiante.Text = estudiantes.Nombre;

                calificacion = new Calificacion();
                calificacion.NIE = estudiantes.NIE;
                calificacion = await calificacion.GetCalificacionByIdEstudiante();
                if (calificacion != null)
                {
                    cmbMaterias.SelectedValue = calificacion.IdMateria;
                    txbExamen1.Text = calificacion.Examen1.ToString();
                    txbExamen2.Text = calificacion.Examen2.ToString();
                    txbExamen3.Text = calificacion.Examen3.ToString();
                    txbExamenFinal.Text = calificacion.ExamenFinal.ToString();
                    txbTareas.Text = calificacion.Tareas.ToString();
                    lblPromedio.Text = calificacion.Promedio.ToString(); 

                    cmbMaterias.Enabled = false;
                }
            }
        }

        private async Task CargoMaterias()
        {
            var materias = await Materia.GetAsync();
            cmbMaterias.DataSource = materias;
            cmbMaterias.DisplayMember = "Nombre";
            cmbMaterias.ValueMember = "Id";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal examen1 = Convert.ToDecimal(txbExamen1.Text);
                decimal examen2 = Convert.ToDecimal(txbExamen2.Text);
                decimal examen3 = Convert.ToDecimal(txbExamen3.Text);
                decimal examenFinal = Convert.ToDecimal(txbExamenFinal.Text);
                decimal tareas = Convert.ToDecimal(txbTareas.Text);

                decimal promedio = (examen1 + examen2 + examen3 + examenFinal + tareas) / 5;
                lblPromedio.Text = promedio.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (calificacion == null)
                {
                    calificacion = new Calificacion(); 
                }
                calificacion.NIE = estudiantes.NIE;
                calificacion.IdMateria = Convert.ToInt32(cmbMaterias.SelectedValue);
                calificacion.Examen1 = Convert.ToDecimal(txbExamen1.Text);
                calificacion.Examen2 = Convert.ToDecimal(txbExamen2.Text);
                calificacion.Examen3 = Convert.ToDecimal(txbExamen3.Text);
                calificacion.ExamenFinal = Convert.ToDecimal(txbExamenFinal.Text);
                calificacion.Tareas = Convert.ToDecimal(txbTareas.Text);
                calificacion.Promedio = Convert.ToDecimal(lblPromedio.Text);
                calificacion.IdDocente = docente.Id;
                calificacion.Estado = calificacion.Promedio >= 6 ? "1" : "0"; // 1 - aprovado , 0 - reprobado

                bool result = false;

                if (calificacion.Id <= 0)
                { 
                    result = await calificacion.SaveAsync();
                }else
                {
                    result = await calificacion.UpdateAsync();
                }

                if (result)
                {
                    MessageBox.Show("Calificación guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la calificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
