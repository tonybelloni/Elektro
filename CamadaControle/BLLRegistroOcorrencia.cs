using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLRegistroOcorrencia
    {
        private DALRegistroOcorrencia dalRegistroOcorrencia = new DALRegistroOcorrencia();

        public List<REGISTRO_OCORRENCIAS> GetRegistrosOcorrencias()
        {
            try
            {
                return dalRegistroOcorrencia.GetRegistrosOcorrencias();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<REGISTRO_OCORRENCIAS> GetRegistrosOcorrenciasByHistorico(int codigo)
        {
            try
            {
                return dalRegistroOcorrencia.GetRegistrosOcorrenciasByHistorico(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InserirRegistroOcorrencia(REGISTRO_OCORRENCIAS registro)
        {
            try
            {
                dalRegistroOcorrencia.InserirRegistroOcorrencia(registro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ValidarRegistroOcorrencia(int codigo, int codigoOcorrencia, string usuario, string observacao)
        {
            try
            {
                dalRegistroOcorrencia.ValidarRegistroOcorrencia(codigo, codigoOcorrencia, usuario, observacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public REGISTRO_OCORRENCIAS GetRegistroOcorrencia(int codigo)
        {
            try
            {
                return dalRegistroOcorrencia.GetRegistroOcorrencia(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<REGISTRO_OCORRENCIAS> GetRegistrosOcorrencias(int codigoSorteio, string numeroHD, string equipe, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                return dalRegistroOcorrencia.GetRegistrosOcorrencias(codigoSorteio, numeroHD, equipe, dataInicial, dataFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
