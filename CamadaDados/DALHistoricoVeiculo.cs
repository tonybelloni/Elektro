using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALHistoricoVeiculo
    {
        private elektroEntities db;

        public DALHistoricoVeiculo()
        {
            db = new elektroEntities();
        }

        public List<HISTORICO_VEICULO> GetHistoricosVeiculos()
        {
            try
            {
                return db.HISTORICO_VEICULO.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricoVeiculo - 001 - Erro ao recuperar históricos de veículos - " + ex.Message);
            }
        }

        public List<HISTORICO_VEICULO> GetHistoricosVeiculos(int numeroHistorico, string placa, int status)
        {
            try
            {
                var historicos = db.HISTORICO_VEICULO.AsQueryable().ToList();

                if (numeroHistorico != 0)
                    historicos = historicos.Where(l => l.NUMERO_HISTORICO == numeroHistorico).AsQueryable().ToList();

                if (placa != "")
                    historicos = historicos.Where(l => l.PLACA_VEICULO == placa).AsQueryable().ToList();

                if (status != 0)
                {
                    if (status == 1)
                        historicos = historicos.Where(l => l.DATA_DESVINCULAR == null).AsQueryable().ToList();
                    else
                        historicos = historicos.Where(l => l.DATA_DESVINCULAR != null).AsQueryable().ToList();
                }

                return historicos;
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricoVeiculo - 002 - Erro ao recuperar históricos de veículos - " + ex.Message);
            }
        }

        public void VincularVeiculoEquipe(HISTORICO_VEICULO historico)
        {
            try
            {
                db.HISTORICO_VEICULO.Add(historico);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricoVeiculo - 003 - Erro ao vincular veículo a equipe - " + ex.Message);
            }
        }

        public void DesvincularVeiculoEquipe(int numeroHistorico, string observacao, string usuario)
        {
            try
            {
                HISTORICO_VEICULO historico = db.HISTORICO_VEICULO.Where(l => l.NUMERO_HISTORICO == numeroHistorico).AsQueryable().FirstOrDefault();
                historico.OBSERVACAO_DESVINCULAR = observacao;
                historico.USUARIO_DESVINCULAR = usuario;
                historico.DATA_DESVINCULAR = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricoVeiculo - 004 - Erro ao desvincular veículo a equipe - " + ex.Message);
            }
        }

        public HISTORICO_VEICULO GetHistoricoVeiculo(int numeroHistorico)
        {
            try
            {
                return db.HISTORICO_VEICULO.Where(l => l.NUMERO_HISTORICO == numeroHistorico).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricoVeiculo - 005 - Erro ao recuperar histórico de veículo - " + ex.Message);
            }
        }
    }
}
