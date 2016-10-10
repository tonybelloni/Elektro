using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALEmpresaManutencao
    {
        private elektroEntities db;

        public DALEmpresaManutencao()
        {
            db = new elektroEntities();
        }

        public List<EMPRESAS> GetEmpresas()
        {
            try
            {
                return db.EMPRESAS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEmpresas - 001 - Erro ao recuperar empresas de manutenção - " + ex.Message);
            }
        }

        public List<EMPRESAS> GetEmpresas(string descricao)
        {
            try
            {
                var lista = db.EMPRESAS.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALEmpresas - 002 - Erro ao recuperar empresas de manutenção - " + ex.Message);
            }
        }

        public void InsertEmpresa(EMPRESAS empresa)
        {
            try
            {
                db.EMPRESAS.Add(empresa);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEmpresas - 003 - Erro ao incluir empresa de manutenção - " + ex.Message);
            }
        }

        public void UpdateEmpresa(EMPRESAS empresa)
        {
            try
            {
                EMPRESAS empresaU = db.EMPRESAS.Where(e => e.CODIGO_EMPRESA == empresa.CODIGO_EMPRESA).AsQueryable().FirstOrDefault();
                empresaU.DESCRICAO = empresa.DESCRICAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEmpresas - 004 - Erro ao alterar empresa de manutenção - " + ex.Message);
            }
        }
    }
}
