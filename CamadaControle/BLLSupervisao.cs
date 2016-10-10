using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLSupervisao
    {
        private DALSupervisao dalSupervisao = new DALSupervisao();

        public List<SUPERVISAO> GetSupervisoes(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalSupervisao.GetSupervisoes();
                }
                else
                {
                    return dalSupervisao.GetSupervisoes(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertSupervisao(SUPERVISAO supervisao)
        {
            try
            {
                var supervisoes = dalSupervisao.GetSupervisaoByDescricao(supervisao.DESCRICAO);

                if (supervisoes.Count() > 0)
                    throw new Exception("Já existe uma supervisão com essa descrição!");

                dalSupervisao.InsertSupervisao(supervisao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSupervisao(SUPERVISAO supervisao)
        {
            try
            {
                var supervisoes = dalSupervisao.GetSupervisaoByDescricao(supervisao.DESCRICAO);

                if (supervisoes.Count() > 1)
                    throw new Exception("Já existe uma supervisão com essa descrição!");

                dalSupervisao.UpdateSupervisao(supervisao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SUPERVISAO> GetSupervisaoByGerencia(int codigo)
        {
            try
            {
                return dalSupervisao.GetSupervisaoByGerencia(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SUPERVISAO GetSupervisao(string descricao)
        {
            try
            {
                return dalSupervisao.GetSupervisao(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SUPERVISAO GetSupervisao(int codigo)
        {
            try
            {
                return dalSupervisao.GetSupervisao(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
