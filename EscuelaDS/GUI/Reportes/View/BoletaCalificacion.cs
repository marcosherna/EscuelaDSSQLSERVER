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

namespace EscuelaDS.GUI.Reportes.View
{
    public partial class BoletaCalificacion : Form
    {
        private Grupo Grupo =  new Grupo();
        private int idEstudiante = 0;
        public BoletaCalificacion(Grupo grupo, int idEstudiante)
        {
            InitializeComponent();
            Grupo = grupo;
            this.idEstudiante = idEstudiante;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                CLS.Dtos.BoletaCalificaciones boletaCalificacion = await Grupo.GetBoletaCalificacionesAsync(this.idEstudiante);
                var reporte = new Reportes.rCalificacion();

                DataTable dataTable = new DataTable();

                if(boletaCalificacion.Calificaciones.Count > 0)
                {

                    dataTable.Columns.Add("Nombre");
                    dataTable.Columns.Add("Encargado");
                    dataTable.Columns.Add("Estado");

                    foreach (var item in boletaCalificacion.Calificaciones)
                    {
                        dataTable.Rows.Add(item.Materia, item.Calificacion.ToString("0.00"), item.Estado);
                    }
                
                }



               

                reporte.SetDataSource(dataTable);

                reporte.SetParameterValue("nie", boletaCalificacion.NIE);
                reporte.SetParameterValue("estudiante", boletaCalificacion.Estudiante);
                reporte.SetParameterValue("docente", boletaCalificacion.Docente);

                // tomar d
                reporte.SetParameterValue("promedioGeneral", (Convert.ToDecimal(boletaCalificacion.PromedioGeneral)).ToString("0.00"));
                reporte.SetParameterValue("grado", boletaCalificacion.Grado ?? "");
                reporte.SetParameterValue("seccion", boletaCalificacion.Seccion ?? "");


                crvBoletaCalificaciones.ReportSource = reporte;
            }
            catch (Exception exc)
            { 
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }
    }
}
