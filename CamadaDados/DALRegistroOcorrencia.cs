using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALRegistroOcorrencia
    {
        private elektroEntities db;

        public DALRegistroOcorrencia()
        {
            db = new elektroEntities();
        }

        public List<REGISTRO_OCORRENCIAS> GetRegistrosOcorrencias()
        {
            try
            {
                return db.REGISTRO_OCORRENCIAS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegistroOcorrencia - 001 - Erro ao recuperar registros de ocorrência - " + ex.Message);
            }
        }

        public List<REGISTRO_OCORRENCIAS> GetRegistrosOcorrenciasByHistorico(int codigo)
        {
            try
            {
                return db.REGISTRO_OCORRENCIAS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegistroOcorrencia - 002 - Erro ao recuperar registros de ocorrência - " + ex.Message);
            }
        }

        public void InserirRegistroOcorrencia(REGISTRO_OCORRENCIAS registro)
        {
            try
            {
                db.REGISTRO_OCORRENCIAS.Add(registro);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegistroOcorrencia - 003 - Erro ao inserir registro de ocorrência - " + ex.Message);
            }
        }

        public void ValidarRegistroOcorrencia(int codigo, int codigoOcorrencia, string usuario, string observacao)
        {
            try
            {
                REGISTRO_OCORRENCIAS registro = db.REGISTRO_OCORRENCIAS.Where(l => l.CODIGO_REGISTRO_OCORRENCIA == codigo).AsQueryable().FirstOrDefault();

                if (codigoOcorrencia != 0)
                    registro.CODIGO_VALIDACAO = codigoOcorrencia;

                registro.USUARIO_VALIDACAO = usuario;
                registro.OBSERVACAO_VALIDACAO = observacao;
                registro.DATA_VALIDACAO = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegistroOcorrencia - 004 - Erro ao validar registro de ocorrência - " + ex.Message);
            }
        }

        public REGISTRO_OCORRENCIAS GetRegistroOcorrencia(int codigo)
        {
            try
            {
                return db.REGISTRO_OCORRENCIAS.Where(l => l.CODIGO_REGISTRO_OCORRENCIA == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegistroOcorrencia - 005 - Erro ao recuperar registros de ocorrência - " + ex.Message);
            }
        }

        public List<REGISTRO_OCORRENCIAS> GetRegistrosOcorrencias(int codigoSorteio, string numeroHD, string equipe, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                List<REGISTRO_OCORRENCIAS> ocorrencias = db.REGISTRO_OCORRENCIAS.DefaultIfEmpty().AsQueryable().ToList();

                if (codigoSorteio != 0)
                    ocorrencias = ocorrencias.Where(l => l.SORTEADOS.COD_SORTEIO == codigoSorteio).DefaultIfEmpty().AsQueryable().ToList();

                if (numeroHD != "")
                    ocorrencias = ocorrencias.Where(l => l.NUMERO_HD == numeroHD).DefaultIfEmpty().AsQueryable().ToList();

                if (equipe != "")
                    ocorrencias = ocorrencias.Where(l => l.SIGLA_EQUIPE == equipe).DefaultIfEmpty().AsQueryable().ToList();

                if (dataInicial != null)
                    ocorrencias = ocorrencias.Where(l => l.DATA_INICIAL >= dataInicial).DefaultIfEmpty().AsQueryable().ToList();

                if (dataFinal != null)
                    ocorrencias = ocorrencias.Where(l => l.DATA_INICIAL <= dataFinal).DefaultIfEmpty().AsQueryable().ToList();

                return ocorrencias;
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegistroOcorrencia - 006 - Erro ao recuperar registros de ocorrência - " + ex.Message);
            }
        }
    }
}
