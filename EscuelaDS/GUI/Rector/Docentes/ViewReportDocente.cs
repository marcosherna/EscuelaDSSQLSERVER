using EscuelaDS.CLS.Dtos;
using EscuelaDS.CLS.Secretaria;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EscuelaDS.GUI.Rector.Docentes
{
    public partial class ViewReportDocente : Form
    {
        List<EstudianteModelReportDto> estudientesMatriculados = new List<EstudianteModelReportDto>();
        Grupo grupo = new Grupo();
        DocenteDto docente= new DocenteDto();
        public ViewReportDocente(DocenteDto docente, Grupo grupo)
        {
            InitializeComponent();
            this.grupo = grupo;
            this.docente = docente;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarDatosReporte();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
            base.OnLoad(e); 
        }

        private async Task CargarDatosReporte()
        {
            try
            {
                estudientesMatriculados = await grupo.GetEstudianteModelReportDtoAsync();
                var reporte = new Reportes.rMatriculaGrupo();
                DataTable dataTable = new DataTable();
                if (estudientesMatriculados.Count > 0)
                { 
                    dataTable.Columns.Add("Id", typeof(int));
                    dataTable.Columns.Add("Nombre",typeof(string));
                    dataTable.Columns.Add("Edad", typeof(int));
                    dataTable.Columns.Add("Genero", typeof(string));
                    dataTable.Columns.Add("Seccion", typeof(string));
                    foreach (var estudiante in estudientesMatriculados)
                    {
                        dataTable.Rows.Add(
                            estudiante.Id, 
                            estudiante.Nombre, 
                            estudiante.Edad, 
                            estudiante.Genero,
                            estudiante.Seccion
                        );
                    }
                }
                reporte.SetDataSource(dataTable);
                reporte.SetParameterValue("docente", docente.Nombre);
                reporte.SetParameterValue("grupo", grupo.Grado + " " + grupo.Seccion);
                crvDocentes.ReportSource = reporte;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
