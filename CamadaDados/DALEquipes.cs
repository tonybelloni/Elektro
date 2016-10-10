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
    public class DALEquipes
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;
        private elektroEntities db;

        public DALEquipes()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
            db = new elektroEntities();
        }

        public List<EQUIPES> GetEquipes()
        {
            try
            {
                return db.EQUIPES.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEquipes - 001 - Erro ao recuperar equipes - " + ex.Message);
            }
        }
    
        public List<EQUIPES> GetEquipes(string descricao)
        {
            try
            {
                var lista = db.EQUIPES.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.NOME_EQUIPE.Contains(descricao) || l.SIGLA_EQUIPE.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 002 - Erro ao recuperar equipes - " + ex.Message);
            }
        }

        public void InsertEquipe(EQUIPES equipe)
        {
            try
            {
                db.EQUIPES.Add(equipe);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 003 - Erro ao incluir câmera - " + ex.Message);
            }
        }

        public void UpdateEquipe(EQUIPES equipe)
        {
            try
            {
                EQUIPES equipeU = db.EQUIPES.Where(g => g.SIGLA_EQUIPE == equipe.SIGLA_EQUIPE).AsQueryable().FirstOrDefault();
                equipeU.NOME_EQUIPE = equipe.NOME_EQUIPE;
                equipeU.ID_TIPO_TRABALHO = equipe.ID_TIPO_TRABALHO;
                equipeU.GERENCIA = equipe.GERENCIA;
                equipeU.LOCALIDADE = equipe.LOCALIDADE;
                equipeU.REGIAO = equipe.REGIAO;
                equipeU.SUPERVISAO = equipe.SUPERVISAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 004 - Erro ao alterar câmera - " + ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesSemAlocacaoCamera()
        {
            try
            {
                var equipes = db.EQUIPES.Where(e => e.CODIGO_CAMERA == null).AsQueryable().ToList();
                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 005 - Erro ao buscar equipes sem câmeras - " + ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesComAlocacaoCamera()
        {
            try
            {
                var equipes = db.EQUIPES.Where(e => e.CODIGO_CAMERA != null).AsQueryable().ToList();
                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 006 - Erro ao buscar equipes com câmeras - " + ex.Message);
            }
        }

        public void UpdateStatusEquipe(string siglaEquipe, string codigoCamera)
        {
            try
            {
                EQUIPES equipe = db.EQUIPES.Where(e => e.SIGLA_EQUIPE == siglaEquipe).AsQueryable().FirstOrDefault();
                equipe.CODIGO_CAMERA = codigoCamera;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 007 - Erro ao atualizar status da equipe - " + ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesByNome(string nome)
        {
            try
            {
                return db.EQUIPES.Where(e => e.NOME_EQUIPE == nome).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 008 - Erro ao buscar equipes - " + ex.Message);
            }
        }

        public EQUIPES GetEquipeBySigla(string sigla)
        {
            try
            {
                return db.EQUIPES.Where(e => e.SIGLA_EQUIPE == sigla).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 008 - Erro ao buscar equipe - " + ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesSemVeiculo()
        {
            try
            {
                var equipes = db.EQUIPES.Where(e => e.PLACA_VEICULO == null).AsQueryable().ToList();
                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 009 - Erro ao buscar equipes sem veículos - " + ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesComVeiculo()
        {
            try
            {
                var equipes = db.EQUIPES.Where(e => e.PLACA_VEICULO != null).AsQueryable().ToList();
                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 010 - Erro ao buscar equipes com veículos - " + ex.Message);
            }
        }

        public void UpdateStatusVeiculoEquipe(string siglaEquipe, string placa)
        {
            try
            {
                EQUIPES equipe = db.EQUIPES.Where(e => e.SIGLA_EQUIPE == siglaEquipe).AsQueryable().FirstOrDefault();
                equipe.PLACA_VEICULO = placa;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 007 - Erro ao atualizar status da equipe - " + ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesByLocalidade(int localidade)
        {
            try
            {
                var equipes = db.EQUIPES.Where(e => e.LOCALIDADE == localidade).AsQueryable().ToList();
                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 009 - Erro ao buscar equipes por localidade - " + ex.Message);
            }
        }
    }
}
