//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace h3_web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cita()
        {
            this.Orden = new HashSet<Orden>();
        }
    
        public int Cod_Cita { get; set; }
        public string Doc_Paciente { get; set; }
        public string Doc_Profesional { get; set; }
        public System.DateTime Fecha_Cita { get; set; }
        public System.TimeSpan Hora_Cita { get; set; }
        public string Estado { get; set; }
    
        public virtual Paciente Paciente { get; set; }
        public virtual Profesional Profesional { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
