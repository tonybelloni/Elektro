using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALAtividades
    {
        private elektroEntities db;

        public DALAtividades()
        {
            db = new elektroEntities();
        }

        public List<ATIVIDADES> GetAtividades()
        {
            try
            {
                return db.ATIVIDADES.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALAtividades - 001 - Erro ao recuperar atividades - " + ex.Message);
            }
        }

        public List<ATIVIDADES> GetAtividades(string descricao)
        {
            try
            {
                var lista = db.ATIVIDADES.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALAtividades - 002 - Erro ao recuperar atividades - " + ex.Message);
            }
        }

        public void InsertAtividade(ATIVIDADES atividade)
        {
            try
            {
                db.ATIVIDADES.Add(atividade);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALAtividades - 003 - Erro ao incluir atividade - " + ex.Message);
            }
        }

        public ATIVIDADES GetAtividade(int codigo)
        {
            try
            {
                return db.ATIVIDADES.Where(l => l.CODIGO_ATIVIDADE == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALAtividades - 004 - Erro ao recuperar atividade - " + ex.Message);
            }
        }

        public void UpdateAtividade(int codigo, string descricao)
        {
            try
            {
                ATIVIDADES atividade = db.ATIVIDADES.Where(l => l.CODIGO_ATIVIDADE == codigo).AsQueryable().FirstOrDefault();
                atividade.DESCRICAO = descricao;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALAtividades - 005 - Erro ao atualizar atividade - " + ex.Message);
            }
        }
    }
}
