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
    
    public partial class SORTEIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SORTEIOS()
        {
            this.SORTEADOS = new HashSet<SORTEADOS>();
        }
    
        public int COD_SORTEIO { get; set; }
        public System.DateTime DATA_REGISTRO { get; set; }
        public string USUARIO_REGISTRO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SORTEADOS> SORTEADOS { get; set; }
    }
}