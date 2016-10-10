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
    public class DALArquivos
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;

        public DALArquivos()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
        }

        public DataSet GetArquivos()
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT DISTINCT [sigla_equipe], " +
                                       "       [data_carga], " +
                                       "       [codigo_camera], " +
                                       "       [numero_veiculo], " +
                                       "       [arquivo] " +
                                       "  FROM [ARQUIVOS] " +
                                       "ORDER BY [data_carga]";

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALCameras - 001 - Erro ao recuperar câmeras - " + ex.Message);
            }
        }

        public DataSet GetArquivos(string valor)
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT DISTINCT [sigla_equipe], " +
                                       "       [data_carga], " +
                                       "       [codigo_camera], " +
                                       "       [numero_veiculo], " +
                                       "       [arquivo] " +
                                       "  FROM [ARQUIVOS] " +
                                       " WHERE ( (codigo_camera LIKE @VALOR) OR (numero_veiculo LIKE @VALOR) OR (sigla_equipe LIKE @VALOR) ) " +
                                       "ORDER BY [data_carga]";

                _comando.Parameters.Add(new SqlParameter("VALOR", "%" + valor + "%"));

                _dataAdapter = new SqlDataAdapter(_comando);
                _dset = new DataSet();
                _dataAdapter.Fill(_dset);

                return _dset;
            }
            catch (Exception ex)
            {
                _dset = null;
                throw new Exception("DALCameras - 001 - Erro ao recuperar câmeras - " + ex.Message);
            }
        }
    }
}
