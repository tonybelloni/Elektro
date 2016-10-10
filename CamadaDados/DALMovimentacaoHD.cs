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
    public class DALMovimentacaoHD
    {
        private elektroEntities db;

        public DALMovimentacaoHD()
        {
            db = new elektroEntities();
        }

        public List<MOVIMENTACAO_HD> GetMovimentacoesHD()
        {
            try
            {
                return db.MOVIMENTACAO_HD.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoHD - 001 - Erro ao recuperar movimentações dos HDs - " + ex.Message);
            }
        }

        public List<MOVIMENTACAO_HD> GetMovimentacoesHD(string numeroHD, DateTime? dataInicial, DateTime? dataFinal, int codigoDestino)
        {
            try
            {
                var lista = db.MOVIMENTACAO_HD.AsQueryable().ToList();

                if (codigoDestino != 0)
                    lista = lista.Where(l => l.LOCAL_DESTINO == codigoDestino).AsQueryable().ToList();
                
                if (numeroHD != "")
                    lista = lista.Where(l => l.NUMERO_HD == numeroHD).AsQueryable().ToList();

                if (dataInicial != null)
                    lista = lista.Where(l => l.DATA_REGISTRO >= dataInicial).AsQueryable().ToList();

                if (dataFinal != null)
                    lista = lista.Where(l => l.DATA_REGISTRO <= dataFinal).AsQueryable().ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoHD - 002 - Erro ao recuperar movimentações dos HDs - " + ex.Message);
            }
        }

        public void InsertMovimentacaoHD(MOVIMENTACAO_HD movimentacao)
        {
            try
            {
                db.MOVIMENTACAO_HD.Add(movimentacao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoHD - 003 - Erro ao incluir movimentação de HD - " + ex.Message);
            }
        }

        public List<MOVIMENTACAO_HD> GetMovimentacoesSaidaHD(int codigoDestino)
        {
            try
            {
                var lista = (from h in db.HD
                             from m in db.MOVIMENTACAO_HD
                             where m.NUMERO_HD == h.NUMERO_HD &&
                                   h.STATUS == "ENVIADO" &&
                                   m.TIPO == "ENVIADO"
                             select m).AsQueryable().ToList();

                if (codigoDestino != 0)
                    lista = lista.Where(l => l.LOCAL_DESTINO == codigoDestino).AsQueryable().ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoHD - 004 - Erro ao recuperar movimentações de saída dos HDs - " + ex.Message);
            }
        }

        public MOVIMENTACAO_HD GetMovimentacaoHD(int codigo)
        {
            try
            {
                return db.MOVIMENTACAO_HD.Where(l => l.NUMERO_MOVIMENTACAO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoHD - 005 - Erro ao recuperar movimentação de HD - " + ex.Message);
            }
        }

        public void UpdateMovimentacaoHD(int numeroMovimentecao, DateTime data, string status, string monitor, string recebedor)
        {
            try
            {
                MOVIMENTACAO_HD mov = db.MOVIMENTACAO_HD.Where(l => l.NUMERO_MOVIMENTACAO == numeroMovimentecao).AsQueryable().FirstOrDefault();
                mov.DATA_CHEGADA = data;
                mov.TIPO = status;
                if (monitor != null)
                    mov.MONITORIA = monitor;
                mov.USUARIO_REGISTRO_RECEBIMENTO = recebedor;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALMovimentacaoHD - 006 - Erro ao atualizar movimentação de HD - " + ex.Message);
            }
        }
    }
}
