using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public  class GrupoDto
    {
        public int Id { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; } 
        public string Turno { get; set; }
        public string Aula { get; set; }
        public string Docente { get; set; }
        public int Anio { get; set; }
    }
}
