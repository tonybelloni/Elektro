using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLPermissoesUsuario
    {
        private DALPermissoesUsuario dalPermissao = new DALPermissoesUsuario();

        public List<PERMISSOES_USUARIO> GetPermissoes(int codigoTipoUsuario)
        {
            try
            {
                return dalPermissao.GetPermissoes(codigoTipoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InserirPermissao(int codigoTipoUsuario, int codigoMenu, int codigoSubMenu)
        {
            try
            {
                if (dalPermissao.GetPermissao(codigoTipoUsuario, codigoMenu, codigoSubMenu) == null)
                {
                    PERMISSOES_USUARIO permissao = new PERMISSOES_USUARIO();
                    permissao.ID_TIPO_USUARIO = codigoTipoUsuario;
                    permissao.ID_MENU = codigoMenu;
                    permissao.ID_SUBMENU = codigoSubMenu;
                    dalPermissao.InserirPermissao(permissao);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverPermissao(int codigoTipoUsuario, int codigoMenu, int codigoSubMenu)
        {
            try
            {
                if (dalPermissao.GetPermissao(codigoTipoUsuario, codigoMenu, codigoSubMenu) != null)
                {
                    PERMISSOES_USUARIO permissao = new PERMISSOES_USUARIO();
                    permissao.ID_TIPO_USUARIO = codigoTipoUsuario;
                    permissao.ID_MENU = codigoMenu;
                    permissao.ID_SUBMENU = codigoSubMenu;
                    dalPermissao.RemoverPermissao(permissao);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarPermissao(int codigoTipoUsuario, int codigoMenu, int codigoSubMenu, bool status)
        {
            try
            {
                PERMISSOES_USUARIO p = dalPermissao.GetPermissao(codigoTipoUsuario, codigoMenu, codigoSubMenu);
                if (status)
                {
                    if (p == null)
                    {
                        PERMISSOES_USUARIO permissao = new PERMISSOES_USUARIO();
                        permissao.ID_TIPO_USUARIO = codigoTipoUsuario;
                        permissao.ID_MENU = codigoMenu;
                        permissao.ID_SUBMENU = codigoSubMenu;
                        dalPermissao.InserirPermissao(permissao);
                    }
                }
                else
                {
                    if (p != null)
                    {
                        dalPermissao.RemoverPermissao(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
