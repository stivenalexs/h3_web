//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace h3_web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesional
    {
        public Profesional()
        {
            this.Cita = new HashSet<Cita>();
            this.Nomina = new HashSet<Nomina>();
            this.Procedimiento = new HashSet<Procedimiento>();
        }
    
        public string Doc_Pro { get; set; }
        public string Horario { get; set; }
    
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual Horario Horario1 { get; set; }
        public virtual ICollection<Nomina> Nomina { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Procedimiento> Procedimiento { get; set; }
    }
}
