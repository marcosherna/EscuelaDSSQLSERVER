using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public class BoletaCalificaciones
    {
        public int NIE { get; set; }
        public string Estudiante { get; set; }
        public string Docente { get; set; }
        public string PromedioGeneral { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public List<CalificacionRDto> Calificaciones { get; set; }

        public void CalcularPromedioGeneral()
        {
            decimal suma = 0;
            foreach (var item in Calificaciones)
            {
                suma += item.Calificacion;
            }
            PromedioGeneral = (suma / Calificaciones.Count).ToString();
        }
    }
}
