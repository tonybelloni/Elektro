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
    public class BLLNaoConformidade
    {
        public List<NaoConformidade> GetNaoConformidade(string valor)
        {
            try
            {
                List<NaoConformidade> lista = new List<NaoConformidade>();
                lista.Clear();
                DataSet _dset = null;
                DALNaoConformidade _obj = new DALNaoConformidade();

                if (valor == "")
                {
                    _dset = _obj.GetNaoConformidade();
                }
                else
                {
                    _dset = _obj.GetNaoConformidade(valor);
                }

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    NaoConformidade rec = new NaoConformidade();
                    rec.IdNaoConformidade = Convert.ToInt16(_dset.Tables[0].Rows[i]["ID_NAO_CONFORMIDADE"]);
                    rec.Tipo = _dset.Tables[0].Rows[i]["TIPO"].ToString();
                    rec.Atividade = _dset.Tables[0].Rows[i]["ATIVIDADE"].ToString();
                    rec.Nome = _dset.Tables[0].Rows[i]["NOME"].ToString();
                    rec.Descricao = _dset.Tables[0].Rows[i]["DESCRICAO"].ToString();
                    rec.Severidade = Convert.ToInt16(_dset.Tables[0].Rows[i]["SEVERIDADE"]);

                    lista.Add(rec);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NAO_CONFORMIDADES GetNaoConformidade(int codigo)
        {
            try
            {
                DALNaoConformidade cameras = new DALNaoConformidade();
                return cameras.GetNaoConformidade(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertNaoConformidade(NaoConformidade rec)
        {
            try
            {
                DALNaoConformidade cameras = new DALNaoConformidade();
                cameras.InsertNaoConformidade(rec);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateNaoConformidade(NaoConformidade rec)
        {
            try
            {
                DALNaoConformidade cameras = new DALNaoConformidade();
                cameras.UpdateNaoConformidade(rec);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
