using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Ocorrencia
    {
        public string DataCarga {get;set;}
        public string SiglaEquipe {get;set;}
        public string CodigoCamera {get;set;}
        public string NumeroVeiculo {get;set;}
        public string NomeArquivo {get;set;}

        public string DataInclusao { get; set; }
        public string Usuario { get; set; }
        public int IdNaoConformidade { get; set; }
        public string DescricaoNaoConformidade { get; set; }
    }
}
