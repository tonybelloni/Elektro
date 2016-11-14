using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;

namespace CamadaDados
{
    public class DALFuncionarios
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;
        private elektroEntities db;

        public DALFuncionarios()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
            db = new elektroEntities();
        }
        
        public List<FUNCIONARIOS> GetFuncionarios()
        {
            try
            {
                return db.FUNCIONARIOS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFuncionarios - 001 - Erro ao recuperar funcionários - " + ex.Message);
            }
        }
    
        public List<FUNCIONARIOS> GetFuncionarios(string valor)
        {
            try
            {
                return db.FUNCIONARIOS.Where(f => f.prontuario.Contains(valor) || f.nome_funcionario.Contains(valor)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFuncionarios - 002 - Erro ao recuperar funcionários - " + ex.Message);
            }
        }

        public void DeleteAllFuncionarios()
        {
            try
            {
                var lista = GetFuncionarios();
                db.FUNCIONARIOS.RemoveRange(lista);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFuncionarios - 003 - Erro ao remover funcionários - " + ex.Message);
            }
        }
        
        public void InsertFuncionario(FUNCIONARIOS funcionario)
        {
            try
            {
                db.FUNCIONARIOS.Add(funcionario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFuncionarios - 004 - Erro ao incluir funcionário - " + ex.Message);
            }
        }

        public void UpdateFuncionario(FUNCIONARIOS funcionario)
        {
            try
            {
                FUNCIONARIOS funcionarioU = db.FUNCIONARIOS.Where(f => f.prontuario == funcionario.prontuario).AsQueryable().FirstOrDefault();
                funcionarioU.nome_funcionario = funcionario.nome_funcionario;
                funcionarioU.funcao = funcionario.funcao;
                funcionarioU.regiao = funcionario.regiao;
                funcionarioU.gerencia = funcionario.gerencia;
                funcionarioU.supervisao = funcionario.supervisao;
                funcionarioU.localidade = funcionario.localidade;
                funcionarioU.prontuario_gestor = funcionario.prontuario_gestor;
                funcionarioU.nome_gestor = funcionario.nome_gestor;
                funcionarioU.periodo = funcionario.periodo;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFuncionarios - 004 - Erro ao incluir funcionário - " + ex.Message);
            }
        }

        public FUNCIONARIOS GetFuncionario(string prontuario)
        {
            try
            {
                return db.FUNCIONARIOS.Where(f => f.prontuario == prontuario).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALFuncionarios - 004 - Erro ao incluir funcionário - " + ex.Message);
            }
        }

        /*public void UpdateEquipe(Equipe eq)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(_connectionString);
                _connection.Open();

                _comando = new SqlCommand();
                _comando.Connection = _connection;
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = "UPDATE [elektro].[dbo].[EQUIPES] " +
                                       "   SET [nome_equipe] = @NOME, " +
                                       "       [localidade] = @LOCALIDADE, " +
                                       "       [supervisao] = @SUPERVISAO, " +
                                       "       [gerencia] = @GERENCIA, " +
                                       "       [regiao] = @REGIAO, " +
                                       "       [id_tipo_trabalho] = @TIPO " +
                                       " WHERE [sigla_equipe] = @SIGLA";

                _comando.Parameters.Add(new SqlParameter("NOME", eq.NomeEquipe));
                _comando.Parameters.Add(new SqlParameter("LOCALIDADE", eq.Localidade));
                _comando.Parameters.Add(new SqlParameter("SUPERVISAO", eq.Supervisao));
                _comando.Parameters.Add(new SqlParameter("GERENCIA", eq.Gerencia));
                _comando.Parameters.Add(new SqlParameter("REGIAO", eq.Regiao));
                _comando.Parameters.Add(new SqlParameter("TIPO", eq.IdTipoTrabalho));
                _comando.Parameters.Add(new SqlParameter("SIGLA", eq.SiglaEquipe));
                
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
        }*/
    }
}
