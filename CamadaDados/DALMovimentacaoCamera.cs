using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALMovimentacaoCamera
    {
        private elektroEntities db;

        public DALMovimentacaoCamera()
        {
            db = new elektroEntities();
        }

        public List<MOVIMENTACAO_CAMERA> GetMovimentacoesCamera()
        {
            try
            {
                return db.MOVIMENTACAO_CAMERA.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 001 - Erro ao recuperar movimentações das câmeras - " + ex.Message);
            }
        }

        public List<MOVIMENTACAO_CAMERA> GetMovimentacoesCamera(string numeroCamera, string equipe, int manutencao, int alocacoes)
        {
            try
            {
                var lista = db.MOVIMENTACAO_CAMERA.AsQueryable().ToList();
                if (numeroCamera != "")
                    lista = lista.Where(l => l.CODIGO_CAMERA == numeroCamera).AsQueryable().ToList();

                if (equipe != "")
                    lista = lista.Where(l => l.SIGLA_EQUIPE == equipe).AsQueryable().ToList();

                if (manutencao != 0)
                {
                    if (manutencao == 1)
                        lista = lista.Where(l => l.EMPRESA_MANUTENCAO != null && l.TIPO == "IDA").AsQueryable().ToList();
                    else if (manutencao == 2)
                        lista = lista.Where(l => l.EMPRESA_MANUTENCAO != null && l.TIPO == "VOLTA").AsQueryable().ToList();
                    else
                        lista = lista.Where(l => l.TIPO != "IDA" && l.TIPO != "VOLTA").AsQueryable().ToList();
                }

                if (alocacoes != 0)
                {
                    if (alocacoes == 1)
                        lista = lista.Where(l => l.SIGLA_EQUIPE != null && l.TIPO == "ALOCADA").AsQueryable().ToList();
                    else if (alocacoes == 2)
                        lista = lista.Where(l => l.SIGLA_EQUIPE != null && l.TIPO == "DESVINCULADA").AsQueryable().ToList();
                    else
                        lista = lista.Where(l => l.TIPO != "ALOCADA" && l.TIPO != "DESVINCULADA").AsQueryable().ToList();
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 002 - Erro ao recuperar movimentações das câmeras - " + ex.Message);
            }
        }

        public void InsertMovimentacaoCamera(MOVIMENTACAO_CAMERA movimentacao)
        {
            try
            {
                db.MOVIMENTACAO_CAMERA.Add(movimentacao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 003 - Erro ao incluir movimentação de câmera - " + ex.Message);
            }
        }

        public MOVIMENTACAO_CAMERA GetLastMovimentacaoCamera(string numeroCamera)
        {
            try
            {
                return db.MOVIMENTACAO_CAMERA.Where(c => c.CODIGO_CAMERA == numeroCamera).OrderByDescending(c => c.DATA_REGISTRO).AsQueryable().First();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 004 - Erro ao buscar última movimentação de câmera - " + ex.Message);
            }
        }

        public void InsertManutencaoCamera(MOVIMENTACAO_CAMERA movimentacao)
        {
            try
            {
                db.MOVIMENTACAO_CAMERA.Add(movimentacao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 005 - Erro ao incluir movimentação de manutenção de câmera - " + ex.Message);
            }
        }

        public MOVIMENTACAO_CAMERA GetMovimentacaoCamera(int numeroMovimentacao)
        {
            try
            {
                return db.MOVIMENTACAO_CAMERA.Where(l => l.NUMERO_MOVIMENTACAO == numeroMovimentacao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 006 - Erro ao buscar movimentação de câmera - " + ex.Message);
            }
        }

        public List<MOVIMENTACAO_CAMERA> GetAlocacoesCamera(string numeroCamera, string equipe, int alocacoes)
        {
            try
            {
                var lista = db.MOVIMENTACAO_CAMERA.Where(l => l.EMPRESA_MANUTENCAO == null).AsQueryable().ToList();
                if (numeroCamera != "")
                    lista = lista.Where(l => l.CODIGO_CAMERA == numeroCamera).AsQueryable().ToList();

                if (equipe != "")
                    lista = lista.Where(l => l.SIGLA_EQUIPE == equipe).AsQueryable().ToList();

                if (alocacoes != 0)
                {
                    if (alocacoes == 1)
                        lista = lista.Where(l => l.TIPO == "ALOCADA").AsQueryable().ToList();
                    else
                        lista = lista.Where(l => l.TIPO == "DESVINCULADA").AsQueryable().ToList();
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 007 - Erro ao recuperar alocações das câmeras - " + ex.Message);
            }
        }

        public void DesalocarCamera(int numeroMovimentacao, DateTime dataDesalocacao, string status, string usuario, string observacao)
        {
            try
            {
                MOVIMENTACAO_CAMERA mov = db.MOVIMENTACAO_CAMERA.Where(l => l.NUMERO_MOVIMENTACAO == numeroMovimentacao).AsQueryable().FirstOrDefault();
                mov.DATA_FIM = dataDesalocacao;
                mov.TIPO = status;
                mov.OBSERVACAO_DESVINCULAR = observacao;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 008 - Erro ao desalocar câmera - " + ex.Message);
            }
        }

        public List<MOVIMENTACAO_CAMERA> GetManutencoesCamera(string numeroCamera, int empresa, int manutencoes)
        {
            try
            {
                var lista = db.MOVIMENTACAO_CAMERA.Where(l => l.SIGLA_EQUIPE == null).AsQueryable().ToList();
                if (numeroCamera != "")
                    lista = lista.Where(l => l.CODIGO_CAMERA == numeroCamera).AsQueryable().ToList();

                if (empresa != 0)
                    lista = lista.Where(l => l.EMPRESA_MANUTENCAO == empresa).AsQueryable().ToList();

                if (manutencoes != 0)
                {
                    if (manutencoes == 1)
                        lista = lista.Where(l => l.TIPO == "IDA").AsQueryable().ToList();
                    else
                        lista = lista.Where(l => l.TIPO == "VOLTA").AsQueryable().ToList();
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 009 - Erro ao recuperar manutenções das câmeras - " + ex.Message);
            }
        }

        public void ReceberCamera(int numeroMovimentacao, DateTime dataRecebimento, string status, string usuario, string observacao)
        {
            try
            {
                MOVIMENTACAO_CAMERA mov = db.MOVIMENTACAO_CAMERA.Where(l => l.NUMERO_MOVIMENTACAO == numeroMovimentacao).AsQueryable().FirstOrDefault();
                mov.DATA_FIM = dataRecebimento;
                mov.TIPO = status;
                mov.OBSERVACAO += ". " + observacao;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoCamera - 010 - Erro ao receber câmera - " + ex.Message);
            }
        }
    }
}
