//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog_Seminario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IMAGEN_POST
    {
        public int ID_IMAGEN { get; set; }
        public Nullable<int> ID_POST { get; set; }
        public string LINK_IMAGEN { get; set; }
    
        public virtual POST POST { get; set; }
    }
}
