using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLTiposOcorrencia
    {
        private DALTiposOcorrencia dalTiposOcorrencia = new DALTiposOcorrencia();

        public List<TIPOS_OCORRENCIAS> GetTiposOcorrencia(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalTiposOcorrencia.GetTiposOcorrencia();
                }
                else
                {
                    return dalTiposOcorrencia.GetTiposOcorrencia(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertTipoOcorrencia(TIPOS_OCORRENCIAS tipo)
        {
            try
            {
                if (dalTiposOcorrencia.GetTipoOcorrencia(tipo.DESCRICAO) != null)
                    throw new Exception("Já existe um tipo de ocorrência com essa descrição");

                dalTiposOcorrencia.InsertTipoOcorrencia(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TIPOS_OCORRENCIAS GetTipoOcorrencia(int codigo)
        {
            try
            {
                return dalTiposOcorrencia.GetTipoOcorrencia(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TIPOS_OCORRENCIAS GetTipoOcorrencia(string descricao)
        {
            try
            {
                return dalTiposOcorrencia.GetTipoOcorrencia(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAtividade(int codigo, int gravidade, string descricao)
        {
            try
            {
                dalTiposOcorrencia.UpdateTipoOcorrencia(codigo, gravidade, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
