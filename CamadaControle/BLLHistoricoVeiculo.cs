using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLHistoricoVeiculo
    {
        private DALHistoricoVeiculo dalHistoricoVeiculo = new DALHistoricoVeiculo();

        public List<HISTORICO_VEICULO> GetHistoricosVeiculos()
        {
            try
            {
                return dalHistoricoVeiculo.GetHistoricosVeiculos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HISTORICO_VEICULO> GetHistoricosVeiculos(int numeroHistorico, string placa, int status)
        {
            try
            {
                return dalHistoricoVeiculo.GetHistoricosVeiculos(numeroHistorico, placa, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void VincularVeiculoEquipe(HISTORICO_VEICULO historico)
        {
            try
            {
                dalHistoricoVeiculo.VincularVeiculoEquipe(historico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DesvincularVeiculoEquipe(int numeroHistorico, string observacao, string usuario)
        {
            try
            {
                dalHistoricoVeiculo.DesvincularVeiculoEquipe(numeroHistorico, observacao, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public HISTORICO_VEICULO GetHistoricoVeiculo(int numeroHistorico)
        {
            try
            {
                return dalHistoricoVeiculo.GetHistoricoVeiculo(numeroHistorico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
