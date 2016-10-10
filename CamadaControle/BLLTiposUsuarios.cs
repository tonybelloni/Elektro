using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using CamadaDados;
using System.Data;

namespace CamadaControle
{
    public class BLLTiposUsuarios
    {
        public List<TipoUsuario> GetTiposUsuarios()
        {
            try
            {
                List<TipoUsuario> lista = new List<TipoUsuario>();
                lista.Clear();
                DataSet _dset = null;
                DALTiposUsuarios _obj = new DALTiposUsuarios();
                _dset = _obj.GetTiposUsuarios();

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    TipoUsuario tipousuario = new TipoUsuario();
                    tipousuario.IdTipoUsuario = Convert.ToInt32(_dset.Tables[0].Rows[i]["ID_TIPO_USUARIO"]);
                    tipousuario.DescricaoTipoUsuario = _dset.Tables[0].Rows[i]["DESCRICAO_TIPO_USUARIO"].ToString();
                    
                    lista.Add(tipousuario);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertTiposUsuarios(TipoUsuario tipousuario)
        {
            try
            {
                DALTiposUsuarios tiposusuarios = new DALTiposUsuarios();
                tiposusuarios.InsertTiposUsuarios(tipousuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoUsuario> GetTiposUsuarios(string valor)
        {
            try
            {
                List<TipoUsuario> lista = new List<TipoUsuario>();
                lista.Clear();
                DataSet _dset = null;
                DALTiposUsuarios _obj = new DALTiposUsuarios();
                _dset = _obj.GetTiposUsuarios(valor);

                for (int i = 0; i <= _dset.Tables[0].Rows.Count - 1; i++)
                {
                    TipoUsuario usuario = new TipoUsuario();
                    usuario.IdTipoUsuario = Convert.ToInt16(_dset.Tables[0].Rows[i]["ID_TIPO_USUARIO"]);
                    usuario.DescricaoTipoUsuario = _dset.Tables[0].Rows[i]["DESCRICAO_TIPO_USUARIO"].ToString();

                    lista.Add(usuario);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateTiposUsuarios(TipoUsuario tipousuario)
        {
            try
            {
                DALTiposUsuarios tiposusuarios = new DALTiposUsuarios();
                tiposusuarios.UpdateTiposUsuarios(tipousuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TIPOS_USUARIOS GetTipoUsuario(string descricao)
        {
            try
            {
                DALTiposUsuarios dalTipo = new DALTiposUsuarios();
                return dalTipo.GetTipoUsuario(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TIPOS_USUARIOS GetTipoUsuarioById(int id)
        {
            try
            {
                DALTiposUsuarios dalTipo = new DALTiposUsuarios();
                return dalTipo.GetTipoUsuarioById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
