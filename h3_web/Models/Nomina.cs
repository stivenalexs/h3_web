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
    
    public partial class Nomina
    {
        public int ID_Nomina { get; set; }
        public string Doc_Pro { get; set; }
        public decimal Salario { get; set; }
        public System.DateTime Fecha_Pago { get; set; }
        public string Estado { get; set; }
    
        public virtual Profesional Profesional { get; set; }
    }
}
