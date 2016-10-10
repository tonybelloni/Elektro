using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLLocalidade
    {
        private DALLocalidade dalLocalidade = new DALLocalidade();

        public List<LOCALIDADE> GetLocalidades(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalLocalidade.GetLocalidades();
                }
                else
                {
                    return dalLocalidade.GetLocalidades(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertLocalidade(LOCALIDADE localidade)
        {
            try
            {
                var localidades = dalLocalidade.GetLocalidadesByDescricao(localidade.DESCRICAO);

                if (localidades.Count() > 0)
                    throw new Exception("Já existe uma localidade com essa descrição!");

                dalLocalidade.InsertLocalidade(localidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateLocalidade(LOCALIDADE localidade)
        {
            try
            {
                var localidades = dalLocalidade.GetLocalidadesByDescricao(localidade.DESCRICAO);

                if (localidades.Count() > 1)
                    throw new Exception("Já existe uma localidade com essa descrição!");

                dalLocalidade.UpdateLocalidade(localidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LOCALIDADE> GetLocalidadesBySupervisao(int codigo)
        {
            try
            {
                return dalLocalidade.GetLocalidadesBySupervisao(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LOCALIDADE GetLocalidade(string descricao)
        {
            try
            {
                return dalLocalidade.GetLocalidade(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LOCALIDADE GetLocalidade(int codigo)
        {
            try
            {
                return dalLocalidade.GetLocalidade(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LOCALIDADE> GetLocalidadesByRegiao(int codigo)
        {
            try
            {
                return dalLocalidade.GetLocalidadesByRegiao(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
