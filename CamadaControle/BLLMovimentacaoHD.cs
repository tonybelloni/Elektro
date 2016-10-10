using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaControle
{
    public class BLLMovimentacaoHD
    {
        private DALMovimentacaoHD dalMovimentacao = new DALMovimentacaoHD();

        public List<MOVIMENTACAO_HD> GetMovimentacoesHD(string numeroHD, DateTime? dataInicial, DateTime? dataFinal, int codigoDestino)
        {
            try
            {
                if (dataInicial != null && dataFinal != null)
                {
                    if (dataInicial > dataFinal)
                        throw new Exception("Data inicial não pode ser maior que data final!");

                }

                var movimentacoes = dalMovimentacao.GetMovimentacoesHD(numeroHD, dataInicial, dataFinal, codigoDestino);
                return movimentacoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertMovimentacaoHD(MOVIMENTACAO_HD movimentacao)
        {
            try
            {
                DALMovimentacaoHD dalMovimentacao = new DALMovimentacaoHD();
                dalMovimentacao.InsertMovimentacaoHD(movimentacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MOVIMENTACAO_HD> GetMovimentacoesSaidaHD(int codigoDestino)
        {
            try
            {
                var movimentacoes = dalMovimentacao.GetMovimentacoesSaidaHD(codigoDestino);
                return movimentacoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MOVIMENTACAO_HD GetMovimentacaoHD(int codigo)
        {
            try
            {
                return dalMovimentacao.GetMovimentacaoHD(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMovimentacaoHD(int numeroMovimentecao, DateTime data, string status, string monitor, string recebedor)
        {
            try
            {
                dalMovimentacao.UpdateMovimentacaoHD(numeroMovimentecao, data, status, monitor, recebedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
