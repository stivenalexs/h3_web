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
    
    public partial class Procedimiento
    {
        public string Cod_Procedimiento { get; set; }
        public string Tipo_P { get; set; }
        public Nullable<System.DateTime> Fecha_P { get; set; }
        public Nullable<System.TimeSpan> Hora_P { get; set; }
        public string Estado_P { get; set; }
        public string Pro_Asignado { get; set; }
    
        public virtual Orden Orden { get; set; }
        public virtual Profesional Profesional { get; set; }
    }
}
