using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;
using Modelo;
using CamadaDados;

namespace CamadaDados
{
    public class DALTiposTrabalhos
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private SqlTransaction _transaction;
        private elektroEntities db;

        public DALTiposTrabalhos()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
            db = new elektroEntities();
        }

        public DataSet GetTiposTrabalhos()
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT [id_tipo_trabalho], " +
                                       "       [descricao_tipo_trabalho] " +
                                       "  FROM [TIPOS_TRABALHOS] " +
                                       "ORDER BY [id_tipo_trabalho]";

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALTipoTrabalho - 001 - Erro ao recuperar tipos de trabalhos - " + ex.Message);
            }
        }
    
        public DataSet GetTiposTrabalhos(string valor)
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT [id_tipo_trabalho], " +
                                       "       [descricao_tipo_trabalho] " +
                                       "  FROM [TIPOS_TRABALHOS] " +
                                       " WHERE descricao_tipo_trabalho LIKE @VALOR " +
                                       "ORDER BY [id_tipo_trabalho]";

                _comando.Parameters.Add(new SqlParameter("VALOR", "%" + valor + "%"));

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALTipoTrabalho - 002 - Erro ao recuperar tipos de trabalhos - " + ex.Message);
            }
        }

        public void InsertTipoTrabalho(TipoTrabalho trabalho)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "INSERT INTO [TIPOS_TRABALHOS] " +
                                       "([descricao_tipo_trabalho]) " +
                                       "VALUES                            " +
                                       "(@DESCRICAO)                ";

                _comando.Parameters.Add(new SqlParameter("DESCRICAO", trabalho.DescricaoTipoTrabalho));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALTipoTrabalho - 003 - Erro ao incluir câmera - " + ex.Message);
            }
        }

        public void UpdateTipoTrabalho(TipoTrabalho trabalho)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "UPDATE [TIPOS_TRABALHOS] " +
                                       "   SET [descricao_tipo_trabalho] = @DESCRICAO " +
                                       " WHERE [id_tipo_trabalho] = @CODIGO";

                _comando.Parameters.Add(new SqlParameter("DESCRICAO", trabalho.DescricaoTipoTrabalho));
                _comando.Parameters.Add(new SqlParameter("CODIGO", trabalho.IdTipoTrabalho));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALTipoTrabalho - 004 - Erro ao alterar câmera - " + ex.Message);
            }
        }

        public TIPOS_TRABALHOS GetTipoDeTrabalho(string descricao)
        {
            try
            {
                return db.TIPOS_TRABALHOS.Where(l => l.DESCRICAO_TIPO_TRABALHO == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTipoTrabalho - 005 - Erro ao buscar tipo de trabalho - " + ex.Message);
            }
        }
    }
}
