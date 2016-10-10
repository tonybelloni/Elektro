using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALGerencia
    {
        private elektroEntities db;

        public DALGerencia()
        {
            db = new elektroEntities();
        }

        public List<GERENCIA> GetGerencias()
        {
            try
            {
                return db.GERENCIA.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 001 - Erro ao recuperar gerências - " + ex.Message);
            }
        }

        public List<GERENCIA> GetGerencias(string descricao)
        {
            try
            {
                var lista = db.GERENCIA.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 002 - Erro ao recuperar gerências - " + ex.Message);
            }
        }

        public void InsertGerencia(GERENCIA gerencia)
        {
            try
            {
                db.GERENCIA.Add(gerencia);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 003 - Erro ao incluir gerência - " + ex.Message);
            }
        }

        public void UpdateGerencia(GERENCIA gerencia)
        {
            try
            {
                GERENCIA gerenciaU = db.GERENCIA.Where(g => g.CODIGO_GERENCIA == gerencia.CODIGO_GERENCIA).AsQueryable().FirstOrDefault();
                gerenciaU.DESCRICAO = gerencia.DESCRICAO;
                gerenciaU.CODIGO_REGIAO = gerencia.CODIGO_REGIAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 004 - Erro ao alterar gerência - " + ex.Message);
            }
        }

        public List<GERENCIA> GetGerenciasByRegiao(int codigo)
        {
            try
            {
                return db.GERENCIA.Where(g => g.CODIGO_REGIAO == codigo).AsQueryable().ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 005 - Erro ao recuperar gerências por região - " + ex.Message);
            }
        }

        public List<GERENCIA> GetGerenciasByDescricao(string descricao)
        {
            try
            {
                return db.GERENCIA.Where(g => g.DESCRICAO == descricao).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 006 - Erro ao recuperar gerências - " + ex.Message);
            }
        }

        public GERENCIA GetGerencia(string descricao)
        {
            try
            {
                return db.GERENCIA.Where(g => g.DESCRICAO == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 007 - Erro ao recuperar gerência - " + ex.Message);
            }
        }

        public GERENCIA GetGerencia(int codigo)
        {
            try
            {
                return db.GERENCIA.Where(g => g.CODIGO_GERENCIA == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALGerencia - 008 - Erro ao recuperar gerência - " + ex.Message);
            }
        }
    }
}
