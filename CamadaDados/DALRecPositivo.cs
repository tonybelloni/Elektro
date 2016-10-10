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
    public class DALRecPositivo
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;

        public DALRecPositivo()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
        }

        public DataSet GetRecPositivo()
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT [id_rec_positivo], " +
                                       "       [tipo], " +
                                       "       [atividade], " +
                                       "       [descricao_rec_positivo] " +
                                       "  FROM [RECONHECIMENTOS_POSITIVOS] " +
                                       "ORDER BY [id_rec_positivo]";

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALRecPositivo - 001 - Erro ao recuperar reconhecimentos positivos - " + ex.Message);
            }
        }
    
        public DataSet GetRecPositivo(string valor)
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT [id_rec_positivo], " +
                                       "       [tipo], " +
                                       "       [atividade], " +
                                       "       [descricao_rec_positivo] " +
                                       "  FROM [RECONHECIMENTOS_POSITIVOS] " +
                                       " WHERE ( (tipo like @VALOR) OR (atividade like @VALOR) OR (descricao_rec_positivo like @VALOR) ) " +
                                       "ORDER BY [id_rec_positivo]";

                _comando.Parameters.Add(new SqlParameter("VALOR", "%" + valor + "%"));

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALRecPositivo - 002 - Erro ao recuperar reconhecimento positivo - " + ex.Message);
            }
        }

        public void InsertRecPositivo(ReconhecimentoPositivo rec)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "INSERT INTO [RECONHECIMENTOS_POSITIVOS] " +
                                       "([tipo],                 " +
                                       " [atividade],                    " +
                                       " [descricao_rec_positivo]) " +
                                       "VALUES                            " +
                                       "(@TIPO,                  " +
                                       " @ATIVIDADE,                     " +
                                       " @DESCRICAO) ";

                _comando.Parameters.Add(new SqlParameter("TIPO", rec.Tipo));
                _comando.Parameters.Add(new SqlParameter("ATIVIDADE", rec.Atividade));
                _comando.Parameters.Add(new SqlParameter("DESCRICAO", rec.DescricaoRecPositivo));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALRecPositivo - 003 - Erro ao incluir reconhecimento positivo - " + ex.Message);
            }
        }

        public void UpdateRecPositivo(ReconhecimentoPositivo rec)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "UPDATE [RECONHECIMENTOS_POSITIVOS] " +
                                       "   SET [tipo] = @TIPO, " +
                                       "       [atividade] = @ATIVIDADE, " +
                                       "       [descricao_rec_positivo] = @DESCRICAO " +
                                       " WHERE [id_rec_positivo] = @CODIGO";

                _comando.Parameters.Add(new SqlParameter("TIPO", rec.Tipo));
                _comando.Parameters.Add(new SqlParameter("ATIVIDADE", rec.Atividade));
                _comando.Parameters.Add(new SqlParameter("DESCRICAO", rec.DescricaoRecPositivo));
                _comando.Parameters.Add(new SqlParameter("CODIGO", rec.IdRecPositivo));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALCameras - 004 - Erro ao alterar câmera - " + ex.Message);
            }
        }
    }
}
