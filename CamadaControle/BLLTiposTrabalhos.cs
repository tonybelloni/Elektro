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
    public class BLLTiposTrabalhos
    {
        public List<TipoTrabalho> GetTiposTrabalhos(string valor)
        {
            try
            {
                List<TipoTrabalho> lista = new List<TipoTrabalho>();
                lista.Clear();
                DataSet _dset = null;
                DALTiposTrabalhos _obj = new DALTiposTrabalhos();

                if (valor == "")
                {
                    _dset = _obj.GetTiposTrabalhos();
                }
                else
                {
                    _dset = _obj.GetTiposTrabalhos(valor);
                }

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    TipoTrabalho trabalho = new TipoTrabalho();
                    trabalho.IdTipoTrabalho = Convert.ToInt16(_dset.Tables[0].Rows[i]["ID_TIPO_TRABALHO"]);
                    trabalho.DescricaoTipoTrabalho = _dset.Tables[0].Rows[i]["DESCRICAO_TIPO_TRABALHO"].ToString();

                    lista.Add(trabalho);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void InsertTipoTrabalho(TipoTrabalho trabalho)
        {
            try
            {
                DALTiposTrabalhos cameras = new DALTiposTrabalhos();
                cameras.InsertTipoTrabalho(trabalho);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateTipoTrabalho(TipoTrabalho trabalho)
        {
            try
            {
                DALTiposTrabalhos trabalhos = new DALTiposTrabalhos();
                trabalhos.UpdateTipoTrabalho(trabalho);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TIPOS_TRABALHOS GetTipoDeTrabalho(string descricao)
        {
            try
            {
                DALTiposTrabalhos dalTipoTrabalho = new DALTiposTrabalhos();
                return dalTipoTrabalho.GetTipoDeTrabalho(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
