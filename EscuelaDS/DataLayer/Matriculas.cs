//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EscuelaDS.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matriculas
    {
        public int ID_Matricula { get; set; }
        public int NIE { get; set; }
        public int ID_Grupo { get; set; }
    
        public virtual Estudiantes Estudiantes { get; set; }
        public virtual Grupos Grupos { get; set; }
    }
}
