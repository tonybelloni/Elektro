using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALFalhasEventosProcessos
    {
        private elektroEntities db;

        public DALFalhasEventosProcessos()
        {
            db = new elektroEntities();
        }

        public List<FALHAS_EVENTOS_PROCESSOS> GetFalhasEventos()
        {
            try
            {
                return db.FALHAS_EVENTOS_PROCESSOS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFalhasEventosProcessos - 001 - Erro ao recuperar falhas de eventos de processos - " + ex.Message);
            }
        }

        public List<FALHAS_EVENTOS_PROCESSOS> GetFalhasEventos(string valor)
        {
            try
            {
                return db.FALHAS_EVENTOS_PROCESSOS.Where(l => l.DESCRICAO.Contains(valor)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFalhasEventosProcessos - 002 - Erro ao recuperar falhas de eventos de processos - " + ex.Message);
            }
        }

        public void InsertFalhaEvento(FALHAS_EVENTOS_PROCESSOS falha)
        {
            try
            {
                db.FALHAS_EVENTOS_PROCESSOS.Add(falha);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFalhasEventosProcessos - 003 - Erro ao incluir falha de evento de processo - " + ex.Message);
            }
        }

        public void UpdateFalhaEvento(FALHAS_EVENTOS_PROCESSOS falha)
        {
            try
            {
                FALHAS_EVENTOS_PROCESSOS falhaU = db.FALHAS_EVENTOS_PROCESSOS.Where(l => l.COD_FALHA_EVENTO == falha.COD_FALHA_EVENTO).AsQueryable().FirstOrDefault();
                falhaU.DESCRICAO = falha.DESCRICAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFalhasEventosProcessos - 004 - Erro ao alterar falha de evento de processo - " + ex.Message);
            }
        }

        public FALHAS_EVENTOS_PROCESSOS GetFalhaEvento(int codigo)
        {
            try
            {

                return db.FALHAS_EVENTOS_PROCESSOS.Where(c => c.COD_FALHA_EVENTO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFalhasEventosProcessos - 005 - Erro ao recuperar falha de evento de processo - " + ex.Message);
            }
        }
    }
}
