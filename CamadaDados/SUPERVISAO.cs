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
    
    public partial class SUPERVISAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUPERVISAO()
        {
            this.LOCALIDADE = new HashSet<LOCALIDADE>();
            this.EQUIPES = new HashSet<EQUIPES>();
            this.FUNCIONARIOS = new HashSet<FUNCIONARIOS>();
        }
    
        public int CODIGO_SUPERVISAO { get; set; }
        public string DESCRICAO { get; set; }
        public Nullable<int> CODIGO_GERENCIA { get; set; }
    
        public virtual GERENCIA GERENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCALIDADE> LOCALIDADE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPES> EQUIPES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNCIONARIOS> FUNCIONARIOS { get; set; }
    }
}
