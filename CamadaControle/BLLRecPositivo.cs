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
    public class BLLRecPositivo
    {
        public List<ReconhecimentoPositivo> GetRecPositivo(string valor)
        {
            try
            {
                List<ReconhecimentoPositivo> lista = new List<ReconhecimentoPositivo>();
                lista.Clear();
                DataSet _dset = null;
                DALRecPositivo _obj = new DALRecPositivo();

                if (valor == "")
                {
                    _dset = _obj.GetRecPositivo();
                }
                else
                {
                    _dset = _obj.GetRecPositivo(valor);
                }

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    ReconhecimentoPositivo rec = new ReconhecimentoPositivo();
                    rec.IdRecPositivo = Convert.ToInt16(_dset.Tables[0].Rows[i]["ID_REC_POSITIVO"]);
                    rec.Tipo = _dset.Tables[0].Rows[i]["TIPO"].ToString();
                    rec.Atividade = _dset.Tables[0].Rows[i]["ATIVIDADE"].ToString();
                    rec.DescricaoRecPositivo = _dset.Tables[0].Rows[i]["DESCRICAO_REC_POSITIVO"].ToString();

                    lista.Add(rec);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertRecPositivo(ReconhecimentoPositivo rec)
        {
            try
            {
                DALRecPositivo cameras = new DALRecPositivo();
                cameras.InsertRecPositivo(rec);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateRecPositivo(ReconhecimentoPositivo rec)
        {
            try
            {
                DALRecPositivo cameras = new DALRecPositivo();
                cameras.UpdateRecPositivo(rec);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
