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
    
    public partial class Administrador
    {
        public string ID_Persona { get; set; }
        public string Clave { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}
