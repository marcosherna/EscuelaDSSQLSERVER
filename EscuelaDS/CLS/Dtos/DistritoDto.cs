using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public class DistritoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Municipio { get; set; }
        public string Departamenbto { get; set; }
        public string Pais { get; set; }

        
    }
}
