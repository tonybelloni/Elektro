using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALPermissoesUsuario
    {
        private elektroEntities db;

        public DALPermissoesUsuario()
        {
            db = new elektroEntities();
        }

        public List<PERMISSOES_USUARIO> GetPermissoes(int codigoTipoUsuario)
        {
            try
            {
                return db.PERMISSOES_USUARIO.Where(l => l.ID_TIPO_USUARIO == codigoTipoUsuario).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALPermissoesUsuario - 001 - Erro ao recuperar permissões - " + ex.Message);
            }
        }

        public void InserirPermissao(PERMISSOES_USUARIO permissao)
        {
            try
            {
                db.PERMISSOES_USUARIO.Add(permissao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALPermissoesUsuario - 002 - Erro ao inserir permissões - " + ex.Message);
            }
        }

        public void RemoverPermissao(PERMISSOES_USUARIO permissao)
        {
            try
            {
                db.PERMISSOES_USUARIO.Remove(permissao);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALPermissoesUsuario - 003 - Erro ao remover permissões - " + ex.Message);
            }
        }

        public PERMISSOES_USUARIO GetPermissao(int codigoTipoUsuario, int codigoMenu, int codigoSubMenu)
        {
            try
            {
                return db.PERMISSOES_USUARIO.Where(l => l.ID_TIPO_USUARIO == codigoTipoUsuario && l.ID_MENU == codigoMenu && l.ID_SUBMENU == codigoSubMenu).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALPermissoesUsuario - 001 - Erro ao recuperar permissões - " + ex.Message);
            }
        }
    }
}
