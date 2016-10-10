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
    public class BLLOcorrencias
    {
        public List<Ocorrencia> GetOcorrencias(string valor)
        {
            try
            {
                List<Ocorrencia> lista = new List<Ocorrencia>();
                lista.Clear();
                DataSet _dset = null;
                DALOcorrencias _obj = new DALOcorrencias();

                if (valor == "")
                {
                    _dset = _obj.GetOcorrencias();
                }
                else
                {
                    // _dset = _obj.GetOcorrencias(valor);
                }

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    Ocorrencia ocorr = new Ocorrencia();
                    ocorr.DataCarga = _dset.Tables[0].Rows[i]["DATA"].ToString();
                    ocorr.SiglaEquipe = _dset.Tables[0].Rows[i]["SIGLA_EQUIPE"].ToString();
                    ocorr.CodigoCamera = _dset.Tables[0].Rows[i]["CODIGO_CAMERA"].ToString();
                    ocorr.NumeroVeiculo = _dset.Tables[0].Rows[i]["NUMERO_VEICULO"].ToString();
                    ocorr.NomeArquivo = _dset.Tables[0].Rows[i]["ARQUIVO"].ToString();
                    ocorr.DataInclusao = _dset.Tables[0].Rows[i]["DATA_INCLUSAO"].ToString();
                    ocorr.Usuario = _dset.Tables[0].Rows[i]["USUARIO"].ToString();
                    ocorr.IdNaoConformidade = Convert.ToInt16(_dset.Tables[0].Rows[i]["ID_NAO_CONFORMIDADE"]);
                    ocorr.DescricaoNaoConformidade = _dset.Tables[0].Rows[i]["DESCRICAO_NAO_CONFORMIDADE"].ToString();


                    lista.Add(ocorr);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertOcorrencia(Ocorrencia ocorr)
        {
            try
            {
                DALOcorrencias cameras = new DALOcorrencias();
                cameras.InsertOcorrencia(ocorr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
