using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string DUI { get; set; }
        public string ISSS { get; set; }
        public string Descripcion { get; set; }  
        public string Telefono { get; set; } 
        public string Cargo { get; set; }
        public string Direccion { get; set; }
    }
}
