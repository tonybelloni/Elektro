using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaControle
{
    public class BLLUsuarios
    {
        private DALUsuarios dalUsuario = new DALUsuarios();

        public List<USUARIOS> GetUsuarios(string valor)
        {
            try
            {
                if (valor == "")
                    return dalUsuario.GetUsuarios();
                else
                    return dalUsuario.GetUsuarios(valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public USUARIOS GetUsuario(string valor)
        {
            try
            {
                return dalUsuario.GetUsuario(valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertUsuario(USUARIOS usuario)
        {
            try
            {
                dalUsuario.InsertUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUsuario(USUARIOS usuario)
        {
            try
            {
                dalUsuario.UpdateUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void TrocarSenha(string prontuario, string senha)
        {
            try
            {
                dalUsuario.TrocarSenha(prontuario, senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
