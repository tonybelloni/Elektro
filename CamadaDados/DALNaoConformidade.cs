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
    public class DALNaoConformidade
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;
        private elektroEntities db;

        public DALNaoConformidade()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
            db = new elektroEntities();
        }

        public DataSet GetNaoConformidade()
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT [id_nao_conformidade], " +
                                       "       [tipo], " +
                                       "       [atividade], " +
                                       "       [nome], " +
                                       "       [descricao], " +
                                       "       [severidade] " +
                                       "  FROM [NAO_CONFORMIDADES] " +
                                       "ORDER BY [id_nao_conformidade]";

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALNaoConformidade - 001 - Erro ao recuperar não conformidades - " + ex.Message);
            }
        }
    
        public DataSet GetNaoConformidade(string valor)
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT [id_nao_conformidade], " +
                                       "       [tipo], " +
                                       "       [atividade], " +
                                       "       [nome], " +
                                       "       [descricao], " +
                                       "       [severidade] " +
                                       "  FROM [NAO_CONFORMIDADES] " +
                                       " WHERE ( (tipo like @VALOR) OR (atividade like @VALOR) OR (descricao like @VALOR) OR (nome like @VALOR) ) " +
                                       "ORDER BY [id_nao_conformidade]";

                _comando.Parameters.Add(new SqlParameter("VALOR", "%" + valor + "%"));

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALNaoConformidade - 002 - Erro ao recuperar não conformidades - " + ex.Message);
            }
        }

        public void InsertNaoConformidade(NaoConformidade rec)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "INSERT INTO [NAO_CONFORMIDADES] " +
                                       "([tipo],                 " +
                                       " [atividade],                    " +
                                       " [nome], " +
                                       " [descricao], " +
                                       " [severidade]) " +
                                       "VALUES                            " +
                                       "(@TIPO,                  " +
                                       " @ATIVIDADE,                     " +
                                       " @NOME, " +
                                       " @DESCRICAO, " +
                                       " @SEVERIDADE)";
                                         

                _comando.Parameters.Add(new SqlParameter("TIPO", rec.Tipo));
                _comando.Parameters.Add(new SqlParameter("ATIVIDADE", rec.Atividade));
                _comando.Parameters.Add(new SqlParameter("NOME", rec.Nome));
                _comando.Parameters.Add(new SqlParameter("DESCRICAO", rec.Descricao));
                _comando.Parameters.Add(new SqlParameter("SEVERIDADE", rec.Severidade));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALNaoConformidade - 003 - Erro ao incluir não conformidades - " + ex.Message);
            }
        }

        public void UpdateNaoConformidade(NaoConformidade rec)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "UPDATE [NAO_CONFORMIDADES] " +
                                       "   SET [tipo] = @TIPO, " +
                                       "       [atividade] = @ATIVIDADE, " +
                                       "       [nome] = @NOME, " +
                                       "       [descricao] = @DESCRICAO, " +
                                       "       [severidade] = @SEVERIDADE " +
                                       " WHERE [id_nao_conformidade] = @CODIGO";

                _comando.Parameters.Add(new SqlParameter("TIPO", rec.Tipo));
                _comando.Parameters.Add(new SqlParameter("ATIVIDADE", rec.Atividade));
                _comando.Parameters.Add(new SqlParameter("NOME", rec.Nome));
                _comando.Parameters.Add(new SqlParameter("DESCRICAO", rec.Descricao));
                _comando.Parameters.Add(new SqlParameter("SEVERIDADE", rec.Severidade));
                _comando.Parameters.Add(new SqlParameter("CODIGO", rec.IdNaoConformidade));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALNaoConforidade - 004 - Erro ao alterar não conformidades - " + ex.Message);
            }
        }

        public NAO_CONFORMIDADES GetNaoConformidade(int codigo)
        {
            try
            {
                return db.NAO_CONFORMIDADES.Where(l => l.id_nao_conformidade == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALNaoConformidade - 005 - Erro ao recuperar não conformidades - " + ex.Message);
            }
        }
    }
}
