using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Veiculo
    {
       private string placa;
       private string marcaveiculo;
       private string modeloveiculo;
       private string numero;
       private int ativo;

       public string Placa
       {
           get { return placa; }
           set { placa = value; }
       }

       public string MarcaVeiculo
       {
           get { return marcaveiculo; }
           set { marcaveiculo = value; }
       }

       public string ModeloVeiculo
       {
           get { return modeloveiculo; }
           set { modeloveiculo = value; }
       }

       public string Numero
       {
           get { return numero; }
           set { numero = value; }
       }

        public int Ativo
       {
           get { return ativo; }
           set { ativo = value; }
       }
    }
}
