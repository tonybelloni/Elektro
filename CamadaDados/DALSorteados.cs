using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALSorteados
    {
        private elektroEntities db;

        public DALSorteados()
        {
            db = new elektroEntities();
        }

        public List<SORTEADOS> GetSorteados()
        {
            try
            {
                return db.SORTEADOS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteados - 001 - Erro ao recuperar sorteados - " + ex.Message);
            }
        }

        public List<SORTEADOS> GetSorteados(string valor)
        {
            try
            {
                return db.SORTEADOS.Where(c => c.SIGLA_EQUIPE.Contains(valor) || c.NUMERO_HD.Contains(valor)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteados - 002 - Erro ao recuperar sorteados - " + ex.Message);
            }
        }

        public void InsertSorteado(SORTEADOS sorteado)
        {
            try
            {
                db.SORTEADOS.Add(sorteado);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteados - 003 - Erro ao incluir sorteado - " + ex.Message);
            }
        }

        public void UpdateSorteado(SORTEADOS sorteado)
        {
            try
            {
                SORTEADOS sorteadoU = db.SORTEADOS.Where(l => l.COD_SORTEIO == sorteado.COD_SORTEIO).AsQueryable().FirstOrDefault();
                sorteadoU.VISUALIZADO = "S";
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteados - 004 - Erro ao alterar sorteado - " + ex.Message);
            }
        }

        public SORTEADOS GetSorteado(int codigo)
        {
            try
            {
                return db.SORTEADOS.Where(c => c.COD_SORTEIO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteados - 005 - Erro ao recuperar sorteado - " + ex.Message);
            }
        }

        public void AtualizaParaVisualizado(int codigo, string numeroHD, string usuario)
        {
            try
            {
                SORTEADOS sorteado = db.SORTEADOS.Where(l => l.COD_SORTEIO == codigo).AsQueryable().FirstOrDefault();
                sorteado.VISUALIZADO = "S";
                sorteado.NUMERO_HD = numeroHD;
                sorteado.USUARIO_VISUALIZACAO = usuario;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteados - 006 - Erro ao atualizar status de sorteado para visualizado - " + ex.Message);
            }
        }
    }
}
