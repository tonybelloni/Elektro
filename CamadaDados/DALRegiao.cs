using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALRegiao
    {
        private elektroEntities db;

        public DALRegiao()
        {
            db = new elektroEntities();
        }

        public List<REGIAO> GetRegioes()
        {
            try
            {
                return db.REGIAO.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegiao - 001 - Erro ao recuperar regiões - " + ex.Message);
            }
        }

        public List<REGIAO> GetRegioes(string descricao)
        {
            try
            {
                var lista = db.REGIAO.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegiao - 002 - Erro ao recuperar regiões - " + ex.Message);
            }
        }

        public void InsertRegiao(REGIAO regiao)
        {
            try
            {
                db.REGIAO.Add(regiao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegiao - 003 - Erro ao incluir região - " + ex.Message);
            }
        }

        public void UpdateRegiao(REGIAO regiao)
        {
            try
            {
                REGIAO regiaoU = db.REGIAO.Where(e => e.CODIGO_REGIAO == regiao.CODIGO_REGIAO).AsQueryable().FirstOrDefault();
                regiaoU.DESCRICAO = regiao.DESCRICAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegiao - 004 - Erro ao alterar região - " + ex.Message);
            }
        }

        public REGIAO GetRegiao(string descricao)
        {
            try
            {
                return db.REGIAO.Where(l => l.DESCRICAO == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegiao - 005 - Erro ao recuperar região - " + ex.Message);
            }
        }

        public REGIAO GetRegiao(int codigo)
        {
            try
            {
                return db.REGIAO.Where(l => l.CODIGO_REGIAO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALRegiao - 006 - Erro ao recuperar região - " + ex.Message);
            }
        }
    }
}
