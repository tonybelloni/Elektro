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
    
    public partial class EQUIPES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EQUIPES()
        {
            this.HISTORICO_VEICULO = new HashSet<HISTORICO_VEICULO>();
            this.MOVIMENTACAO_CAMERA = new HashSet<MOVIMENTACAO_CAMERA>();
            this.REGISTRO_OCORRENCIAS = new HashSet<REGISTRO_OCORRENCIAS>();
            this.HISTORICOS_CAMERAS = new HashSet<HISTORICOS_CAMERAS>();
        }
    
        public string SIGLA_EQUIPE { get; set; }
        public string NOME_EQUIPE { get; set; }
        public Nullable<int> LOCALIDADE { get; set; }
        public Nullable<int> SUPERVISAO { get; set; }
        public Nullable<int> GERENCIA { get; set; }
        public Nullable<int> REGIAO { get; set; }
        public int ID_TIPO_TRABALHO { get; set; }
        public string CODIGO_CAMERA { get; set; }
        public string PLACA_VEICULO { get; set; }
    
        public virtual TIPOS_TRABALHOS TIPOS_TRABALHOS { get; set; }
        public virtual GERENCIA GERENCIA1 { get; set; }
        public virtual LOCALIDADE LOCALIDADE1 { get; set; }
        public virtual REGIAO REGIAO1 { get; set; }
        public virtual SUPERVISAO SUPERVISAO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO_VEICULO> HISTORICO_VEICULO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTACAO_CAMERA> MOVIMENTACAO_CAMERA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRO_OCORRENCIAS> REGISTRO_OCORRENCIAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICOS_CAMERAS> HISTORICOS_CAMERAS { get; set; }
    }
}
