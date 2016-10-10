using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLRegiao
    {
        private DALRegiao dalRegiao = new DALRegiao();

        public List<REGIAO> GetRegioes(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalRegiao.GetRegioes();
                }
                else
                {
                    return dalRegiao.GetRegioes(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertRegiao(REGIAO regiao)
        {
            try
            {
                dalRegiao.InsertRegiao(regiao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateRegiao(REGIAO regiao)
        {
            try
            {
                dalRegiao.UpdateRegiao(regiao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public REGIAO GetRegiao(string descricao)
        {
            try
            {
                return dalRegiao.GetRegiao(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public REGIAO GetRegiao(int codigo)
        {
            try
            {
                return dalRegiao.GetRegiao(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
