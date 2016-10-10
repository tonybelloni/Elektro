using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALLocalidade
    {
        private elektroEntities db;

        public DALLocalidade()
        {
            db = new elektroEntities();
        }

        public List<LOCALIDADE> GetLocalidades()
        {
            try
            {
                return db.LOCALIDADE.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 001 - Erro ao recuperar localidades - " + ex.Message);
            }
        }

        public List<LOCALIDADE> GetLocalidades(string descricao)
        {
            try
            {
                var lista = db.LOCALIDADE.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 002 - Erro ao recuperar localidades - " + ex.Message);
            }
        }

        public void InsertLocalidade(LOCALIDADE localidade)
        {
            try
            {
                db.LOCALIDADE.Add(localidade);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 003 - Erro ao incluir localidade - " + ex.Message);
            }
        }

        public void UpdateLocalidade(LOCALIDADE localidade)
        {
            try
            {
                LOCALIDADE localidadeU = db.LOCALIDADE.Where(g => g.CODIGO_LOCALIDADE == localidade.CODIGO_LOCALIDADE).AsQueryable().FirstOrDefault();
                localidadeU.DESCRICAO = localidade.DESCRICAO;
                localidadeU.CODIGO_SUPERVISAO = localidade.CODIGO_SUPERVISAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 004 - Erro ao alterar localidade - " + ex.Message);
            }
        }

        public List<LOCALIDADE> GetLocalidadesBySupervisao(int codigo)
        {
            try
            {
                return db.LOCALIDADE.Where(g => g.CODIGO_SUPERVISAO == codigo).AsQueryable().ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 005 - Erro ao recuperar localidade por supervisão - " + ex.Message);
            }
        }

        public List<LOCALIDADE> GetLocalidadesByDescricao(string descricao)
        {
            try
            {
                return db.LOCALIDADE.Where(g => g.DESCRICAO == descricao).AsQueryable().ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 006 - Erro ao recuperar localidades - " + ex.Message);
            }
        }

        public LOCALIDADE GetLocalidade(string descricao)
        {
            try
            {
                return db.LOCALIDADE.Where(g => g.DESCRICAO == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 007 - Erro ao recuperar localidade - " + ex.Message);
            }
        }

        public LOCALIDADE GetLocalidade(int codigo)
        {
            try
            {
                return db.LOCALIDADE.Where(g => g.CODIGO_LOCALIDADE == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 008 - Erro ao recuperar localidade - " + ex.Message);
            }
        }

        public List<LOCALIDADE> GetLocalidadesByRegiao(int codigo)
        {
            try
            {
                return db.LOCALIDADE.Where(g => g.SUPERVISAO.GERENCIA.CODIGO_REGIAO == codigo).AsQueryable().ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("DALLocalidade - 005 - Erro ao recuperar localidade por região - " + ex.Message);
            }
        }
    }
}
