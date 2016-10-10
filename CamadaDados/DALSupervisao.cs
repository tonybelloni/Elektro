using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALSupervisao
    {
        private elektroEntities db;

        public DALSupervisao()
        {
            db = new elektroEntities();
        }

        public List<SUPERVISAO> GetSupervisoes()
        {
            try
            {
                return db.SUPERVISAO.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 001 - Erro ao recuperar supervisões - " + ex.Message);
            }
        }

        public List<SUPERVISAO> GetSupervisoes(string descricao)
        {
            try
            {
                var lista = db.SUPERVISAO.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 002 - Erro ao recuperar supervisões - " + ex.Message);
            }
        }

        public void InsertSupervisao(SUPERVISAO supervisao)
        {
            try
            {
                db.SUPERVISAO.Add(supervisao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 003 - Erro ao incluir supervisão - " + ex.Message);
            }
        }

        public void UpdateSupervisao(SUPERVISAO supervisao)
        {
            try
            {
                SUPERVISAO supervisaoU = db.SUPERVISAO.Where(g => g.CODIGO_SUPERVISAO == supervisao.CODIGO_SUPERVISAO).AsQueryable().FirstOrDefault();
                supervisaoU.DESCRICAO = supervisao.DESCRICAO;
                supervisaoU.CODIGO_GERENCIA = supervisao.CODIGO_GERENCIA;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 004 - Erro ao alterar supervisão - " + ex.Message);
            }
        }

        public List<SUPERVISAO> GetSupervisaoByGerencia(int codigo)
        {
            try
            {
                return db.SUPERVISAO.Where(g => g.CODIGO_GERENCIA == codigo).AsQueryable().ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 005 - Erro ao recuperar supervisão por gerência - " + ex.Message);
            }
        }

        public List<SUPERVISAO> GetSupervisaoByDescricao(string descricao)
        {
            try
            {
                return db.SUPERVISAO.Where(g => g.DESCRICAO == descricao).AsQueryable().ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 006 - Erro ao recuperar supervisões - " + ex.Message);
            }
        }

        public SUPERVISAO GetSupervisao(string descricao)
        {
            try
            {
                return db.SUPERVISAO.Where(g => g.DESCRICAO == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 007 - Erro ao recuperar supervisão - " + ex.Message);
            }
        }

        public SUPERVISAO GetSupervisao(int codigo)
        {
            try
            {
                return db.SUPERVISAO.Where(g => g.CODIGO_SUPERVISAO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSupervisao - 008 - Erro ao recuperar supervisão - " + ex.Message);
            }
        }
    }
}
