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
    
    public partial class Municipios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Municipios()
        {
            this.Distritos = new HashSet<Distritos>();
        }
    
        public int ID_Municipio { get; set; }
        public string Municipio { get; set; }
        public int ID_Departamento { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Distritos> Distritos { get; set; }
    }
}
