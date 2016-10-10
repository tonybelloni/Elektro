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
    public class DALOcorrencias
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;

        public DALOcorrencias()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
        }

        public void InsertOcorrencia(Ocorrencia ocorr)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "INSERT INTO [OCORRENCIAS] " +
                                       " (           [data], " +
                                       "            [sigla_equipe], " +
                                       "            [codigo_camera], " +
                                       "            [numero_veiculo], " +
                                       "            [arquivo], " +
                                       "            [data_inclusao], " + 
                                       "            [usuario], " + 
                                       "            [id_nao_conformidade]) " +
                                       "VALUES                            " +
                                       "(@DATA,                  " +
                                       " @EQUIPE,                     " +
                                       " @CAMERA,            " +
                                       " @VEICULO,                " +
                                       " @ARQUIVO, " +
                                       " @INCLUSAO, " +
                                       " @USUARIO, " +
                                       " @IDCONF) ";

                _comando.Parameters.Add(new SqlParameter("DATA", ocorr.DataCarga));
                _comando.Parameters.Add(new SqlParameter("EQUIPE", ocorr.SiglaEquipe));
                _comando.Parameters.Add(new SqlParameter("CAMERA", ocorr.CodigoCamera));
                _comando.Parameters.Add(new SqlParameter("VEICULO", ocorr.NumeroVeiculo));
                _comando.Parameters.Add(new SqlParameter("ARQUIVO", ocorr.NomeArquivo));
                _comando.Parameters.Add(new SqlParameter("INCLUSAO", ocorr.DataInclusao));
                _comando.Parameters.Add(new SqlParameter("USUARIO", ocorr.Usuario));
                _comando.Parameters.Add(new SqlParameter("IDCONF", ocorr.IdNaoConformidade));

                _transaction = _connection.BeginTransaction();
                _comando.Transaction = _transaction;
                _comando.ExecuteNonQuery();
                _comando.Parameters.Clear();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("DALCameras - 003 - Erro ao incluir câmera - " + ex.Message);
            }
        }

        public DataSet GetOcorrencias()
        {
            try
            {
                _dset = null;
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _comando = new SqlCommand();

                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "SELECT a.[data] as data " +
                                       "      ,a.[sigla_equipe] as sigla_equipe " +
                                       "      ,a.[codigo_camera] as codigo_camera " +
                                       "      ,a.[numero_veiculo] as numero_veiculo " +
                                       "      ,a.[arquivo] as arquivo " +
                                       "      ,a.[data_inclusao] as data_inclusao " +
                                       "      ,a.[usuario] as usuario " +
                                       "      ,a.[id_nao_conformidade] as id_nao_conformidade " +
                                       "      ,b.[descricao] as descricao_nao_conformidade " +
                                       " FROM [OCORRENCIAS] a, " +
                                       "      [NAO_CONFORMIDADES] b " +
                                       "WHERE a.id_nao_conformidade = b.id_nao_conformidade " +
                                       "ORDER BY a.data ";

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
