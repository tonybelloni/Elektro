using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALTiposUsuarios
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;
        private elektroEntities db;

        public DALTiposUsuarios()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
            db = new elektroEntities();
        }

        public DataSet GetTiposUsuarios()
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandTimeout = 10;
                _comando.CommandText = "SELECT  [id_tipo_usuario]" +
                                       "       ,[descricao_tipo_usuario]" +
                                       "   FROM [TIPOS_USUARIOS]" + 
                                       "ORDER BY [descricao_tipo_usuario]";

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset, "TIPOS_USUARIOS");

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALTiposUsuarios - 001 - Erro ao recuperar perfil - " + ex.Message);
            }
        }

        public void InsertTiposUsuarios(TipoUsuario tipousuario)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "INSERT INTO [TIPOS_USUARIOS] " +
                                       "([descricao_tipo_usuario]                  ) " +
                                       "VALUES                                       " +
                                       "(@DESCRICAO_TIPO_USUARIO)                    ";

                _comando.Parameters.Add(new SqlParameter("DESCRICAO_TIPO_USUARIO", tipousuario.DescricaoTipoUsuario));
                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALTiposUsuarios - 002 - Erro ao incluir perfil - " + ex.Message);
            }
        }

        public DataSet GetTiposUsuarios(string valor)
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandTimeout = 10;
                _comando.CommandText = "SELECT  [id_tipo_usuario]" +
                                       "       ,[descricao_tipo_usuario]" +
                                       "   FROM [TIPOS_USUARIOS] " +
                                       "  WHERE descricao_tipo_usuario like @VALOR " +
                                       "ORDER BY [descricao_tipo_usuario]";

                _comando.Parameters.Add(new SqlParameter("VALOR", "%" + valor + "%"));
                
                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset, "TIPOS_USUARIOS");

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALTiposUsuarios - 003 - Erro ao recuperar perfil - " + ex.Message);
            }
        }

        public void UpdateTiposUsuarios(TipoUsuario tipousuario)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "UPDATE [TIPOS_USUARIOS] " +
                                       "   SET [descricao_tipo_usuario] = @DESCRICAO_TIPO_USUARIO " +
                                       " WHERE [id_tipo_usuario] = @ID_TIPO_USUARIO ";

                _comando.Parameters.Add(new SqlParameter("DESCRICAO_TIPO_USUARIO", tipousuario.DescricaoTipoUsuario));
                _comando.Parameters.Add(new SqlParameter("ID_TIPO_USUARIO", tipousuario.IdTipoUsuario));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALTiposUsuarios - 004 - Erro ao alterar perfil - " + ex.Message);
            }
        }

        public TIPOS_USUARIOS GetTipoUsuario(string descricao)
        {
            try
            {
                return db.TIPOS_USUARIOS.Where(t => t.descricao_tipo_usuario == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposUsuarios - 005 - Erro ao buscar tipo de usuário - " + ex.Message);
            }
        }

        public TIPOS_USUARIOS GetTipoUsuarioById(int id)
        {
            try
            {
                return db.TIPOS_USUARIOS.Where(t => t.id_tipo_usuario == id).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposUsuarios - 006 - Erro ao buscar tipo de usuário - " + ex.Message);
            }
        }
    }
}
