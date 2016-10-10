using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class NaoConformidade
    {
        public int IdNaoConformidade {get; set;}
        public string Tipo {get;set;}
        public string Atividade {get;set;}
        public string Nome {get;set;}
        public string Descricao {get;set;}
        public int Severidade {get;set;}
    }
}
