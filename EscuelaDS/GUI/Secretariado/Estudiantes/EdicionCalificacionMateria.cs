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
    public partial class EdicionCalificacionMateria : Form
    {
        private Calificacion calificacion = null;
        private Estudiante estudiante = null;
        private DocenteDto docente = null;
        public EdicionCalificacionMateria(Calificacion calificacion)
        {
            InitializeComponent();
            this.calificacion = calificacion;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
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
            if (calificacion != null)
            { 
                txbExamen1.Text = calificacion.Examen1.ToString();
                txbExamen2.Text = calificacion.Examen2.ToString();
                txbExamen3.Text = calificacion.Examen3.ToString();
                txbExamenFinal.Text = calificacion.ExamenFinal.ToString();
                txbTareas.Text = calificacion.Tareas.ToString(); 
                lblPromedio.Text = ((calificacion.Examen1 + calificacion.Examen2 + calificacion.Examen3 + calificacion.ExamenFinal + calificacion.Tareas) / 5).ToString("0.0");
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            { 
                var promedio = (Convert.ToDecimal(txbExamen1.Text) + Convert.ToDecimal(txbExamen2.Text) + Convert.ToDecimal(txbExamen3.Text) + Convert.ToDecimal(txbExamenFinal.Text) + Convert.ToDecimal(txbTareas.Text)) / 5;
                calificacion.Examen1 = Convert.ToDecimal(txbExamen1.Text);
                calificacion.Examen2 = Convert.ToDecimal(txbExamen2.Text);
                calificacion.Examen3 = Convert.ToDecimal(txbExamen3.Text);
                calificacion.ExamenFinal = Convert.ToDecimal(txbExamenFinal.Text);
                calificacion.Tareas = Convert.ToDecimal(txbTareas.Text);
                calificacion.Promedio = Convert.ToDecimal(promedio);
                calificacion.Estado = calificacion.Promedio >= 6 ? "1" : "0";

                bool result = await calificacion.UpdateAsync();
                if(!result) throw new Exception("No se pudo actualizar la calificación");
                MessageBox.Show("Calificación actualizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
