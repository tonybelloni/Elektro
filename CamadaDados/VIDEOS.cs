//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CamadaDados
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIDEOS
    {
        public int ID_VIDEO { get; set; }
        public byte[] VIDEO { get; set; }
        public Nullable<int> CODIGO_LISTA_VIDEOS { get; set; }
    
        public virtual LISTA_VIDEOS LISTA_VIDEOS { get; set; }
    }
}
