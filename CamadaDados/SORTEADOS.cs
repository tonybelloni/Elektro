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
    
    public partial class SORTEADOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SORTEADOS()
        {
            this.REGISTRO_OCORRENCIAS = new HashSet<REGISTRO_OCORRENCIAS>();
        }
    
        public int COD_SORTEADOS { get; set; }
        public string SIGLA_EQUIPE { get; set; }
        public string VISUALIZADO { get; set; }
        public string NUMERO_HD { get; set; }
        public string USUARIO_VISUALIZACAO { get; set; }
        public Nullable<int> COD_SORTEIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRO_OCORRENCIAS> REGISTRO_OCORRENCIAS { get; set; }
        public virtual SORTEIOS SORTEIOS { get; set; }
    }
}