//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyecPOC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pymes
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_categoria { get; set; }
        public int id_subcategoria { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string dirección { get; set; }
        public string sitioweb { get; set; }
        public string redsocial1 { get; set; }
        public string redsocial2 { get; set; }
        public string redsocial3 { get; set; }
    
        public virtual categoria categoria { get; set; }
        public virtual sub_categoria sub_categoria { get; set; }
    }
}
