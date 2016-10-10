using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;
using Modelo;

namespace CamadaControle
{
    public class BLLArquivos
    {
        public List<Arquivo> GetArquivos(string valor)
        {
            try
            {
                List<Arquivo> lista = new List<Arquivo>();
                lista.Clear();
                DataSet _dset = null;
                DALArquivos _obj = new DALArquivos();

                if (valor == "")
                {
                    _dset = _obj.GetArquivos();
                }
                else
                {
                    _dset = _obj.GetArquivos(valor);
                }

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    Arquivo camera = new Arquivo();
                    camera.DataCarga = _dset.Tables[0].Rows[i]["DATA_CARGA"].ToString();
                    camera.SiglaEquipe = _dset.Tables[0].Rows[i]["SIGLA_EQUIPE"].ToString();
                    camera.CodigoCamera = _dset.Tables[0].Rows[i]["CODIGO_CAMERA"].ToString();
                    camera.NumeroVeiculo = _dset.Tables[0].Rows[i]["NUMERO_VEICULO"].ToString();
                    camera.NomeArquivo = _dset.Tables[0].Rows[i]["ARQUIVO"].ToString();

                    lista.Add(camera);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
