using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public class CalificacionRDto
    {
        public string Materia { get; set; }
        public decimal Calificacion { get; set; }
        public string Estado { get; set; }

        // tomar dos decimales
        public string CalificacionString
        {
            get
            {
                return Calificacion.ToString("0.00");
            }
        }
    }
}
