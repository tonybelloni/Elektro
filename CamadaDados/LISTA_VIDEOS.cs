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
    
    public partial class LISTA_VIDEOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LISTA_VIDEOS()
        {
            this.REGISTRO_OCORRENCIAS = new HashSet<REGISTRO_OCORRENCIAS>();
            this.VIDEOS = new HashSet<VIDEOS>();
        }
    
        public int CODIGO_LISTA_VIDEOS { get; set; }
        public Nullable<double> TEMPO_TOTAL_VIDEOS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRO_OCORRENCIAS> REGISTRO_OCORRENCIAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIDEOS> VIDEOS { get; set; }
    }
}
