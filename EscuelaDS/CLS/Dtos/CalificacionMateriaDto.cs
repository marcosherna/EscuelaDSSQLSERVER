using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public class CalificacionMateriaDto
    {
        public int Id { get; set; }
        public string Materia { get; set; } 
        public decimal Examen1 { get; set; }
        public decimal Examen2 { get; set; }
        public decimal Examen3 { get; set; }
        public decimal ExamenFinal { get; set; }
        public decimal Tareas { get; set; } 
        public string Estado { get; set; } //promedio = suma de examenes entre 5 y tarea  prmedio > 6 aprobado < 6 reprobado

        
    }
}
