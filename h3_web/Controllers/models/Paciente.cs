//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace h3_web.Controllers.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente
    {
        public Paciente()
        {
            this.Cita = new HashSet<Cita>();
            this.Orden = new HashSet<Orden>();
        }
    
        public string Doc_Paciente { get; set; }
        public string Tipo_documento { get; set; }
    
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
