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
    
    public partial class Encargados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Encargados()
        {
            this.Estudiantes = new HashSet<Estudiantes>();
        }
    
        public int ID_Encargado { get; set; }
        public string NombresEncargado { get; set; }
        public string ApellidosEncargado { get; set; }
        public string TelefonoEncargado { get; set; }
        public string DUI_Encargado { get; set; }
        public int ID_Direccion { get; set; }
    
        public virtual Direcciones Direcciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
    }
}