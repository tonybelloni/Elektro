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
    
    public partial class ESCALA_COD
    {
        public string SIGLA_EQUIPE { get; set; }
        public string PRONTUARIO { get; set; }
        public System.DateTime DATA_INICIO { get; set; }
        public System.DateTime DATA_FIM { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public Nullable<System.DateTime> DATA_REGISTRO { get; set; }
    
        public virtual EQUIPES EQUIPES { get; set; }
        public virtual FUNCIONARIOS FUNCIONARIOS { get; set; }
    }
}
