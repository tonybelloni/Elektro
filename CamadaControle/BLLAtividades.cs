using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLAtividades
    {
        private DALAtividades dalAtividade = new DALAtividades();

        public List<ATIVIDADES> GetAtividades(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalAtividade.GetAtividades();
                }
                else
                {
                    return dalAtividade.GetAtividades(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertAtividade(ATIVIDADES atividade)
        {
            try
            {
                dalAtividade.InsertAtividade(atividade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ATIVIDADES GetAtividade(int codigo)
        {
            try
            {
                return dalAtividade.GetAtividade(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAtividade(int codigo, string descricao)
        {
            try
            {
                dalAtividade.UpdateAtividade(codigo, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
