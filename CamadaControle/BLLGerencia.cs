using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLGerencia
    {
        private DALGerencia dalGerencia = new DALGerencia();

        public List<GERENCIA> GetGerencias(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalGerencia.GetGerencias();
                }
                else
                {
                    return dalGerencia.GetGerencias(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertGerencia(GERENCIA gerencia)
        {
            try
            {
                var gerencias = dalGerencia.GetGerenciasByDescricao(gerencia.DESCRICAO);

                if (gerencias.Count() > 0)
                    throw new Exception("Já existe uma gerência com essa descrição!");

                dalGerencia.InsertGerencia(gerencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateGerencia(GERENCIA gerencia)
        {
            try
            {
                var gerencias = dalGerencia.GetGerenciasByDescricao(gerencia.DESCRICAO);

                if (gerencias.Count() > 1)
                    throw new Exception("Já existe uma gerência com essa descrição!");

                dalGerencia.UpdateGerencia(gerencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GERENCIA> GetGerenciasByRegiao(int codigo)
        {
            try
            {
                return dalGerencia.GetGerenciasByRegiao(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GERENCIA GetGerencia(string descricao)
        {
            try
            {
                return dalGerencia.GetGerencia(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GERENCIA GetGerencia(int codigo)
        {
            try
            {
                return dalGerencia.GetGerencia(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
