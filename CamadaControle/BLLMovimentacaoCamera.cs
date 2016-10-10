using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaControle
{
    public class BLLMovimentacaoCamera
    {
        private DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();

        public List<MOVIMENTACAO_CAMERA> GetMovimentacoesCamera()
        {
            try
            {
                var lista = dalMovimentacao.GetMovimentacoesCamera();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MovimentacaoCameraCustom> GetMovimentacoesCamera(string numeroCamera, string equipe, int manutencao, int alocacoes)
        {
            try
            {
                var movimentacoes = dalMovimentacao.GetMovimentacoesCamera(numeroCamera, equipe, manutencao, alocacoes);
                var lista = movimentacoes.Select(p => new MovimentacaoCameraCustom
                {
                    NUMERO_MOVIMENTACAO = p.NUMERO_MOVIMENTACAO,
                    TIPO = p.TIPO,
                    NUMERO_CAMERA = p.CODIGO_CAMERA,
                    EQUIPE = p.SIGLA_EQUIPE,
                    MANUTENCAO = p.EMPRESA_MANUTENCAO,
                    OBSERVACAO = p.OBSERVACAO,
                    RESPONSAVEL = p.USUARIO_REGISTRO,
                    DATA_REGISTRO = p.DATA_REGISTRO
                }).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertMovimentacaoCamera(MOVIMENTACAO_CAMERA movimentacao)
        {
            try
            {
                DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();
                dalMovimentacao.InsertMovimentacaoCamera(movimentacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MOVIMENTACAO_CAMERA GetLastMovimentacaoCamera(string numeroCamera)
        {
            try
            {
                DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();
                MOVIMENTACAO_CAMERA camera = dalMovimentacao.GetLastMovimentacaoCamera(numeroCamera);
                return camera;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertManutencaoCamera(MOVIMENTACAO_CAMERA movimentacao)
        {
            try
            {
                DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();
                dalMovimentacao.InsertManutencaoCamera(movimentacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MOVIMENTACAO_CAMERA GetMovimentacaoCamera(int numeroMovimentacao)
        {
            try
            {
                DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();
                MOVIMENTACAO_CAMERA camera = dalMovimentacao.GetMovimentacaoCamera(numeroMovimentacao);
                return camera;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MOVIMENTACAO_CAMERA> GetAlocacoesCamera(string numeroCamera, string equipe, int alocacoes)
        {
            try
            {
                return dalMovimentacao.GetAlocacoesCamera(numeroCamera, equipe, alocacoes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DesalocarCamera(int numeroMovimentacao, DateTime data, string status, string usuario, string observacao)
        {
            try
            {
                DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();
                dalMovimentacao.DesalocarCamera(numeroMovimentacao, data, status, usuario, observacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MOVIMENTACAO_CAMERA> GetManutencoesCamera(string numeroCamera, int empresa, int manutencoes)
        {
            try
            {
                return dalMovimentacao.GetManutencoesCamera(numeroCamera, empresa, manutencoes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ReceberCamera(int numeroMovimentacao, DateTime data, string status, string usuario, string observacao)
        {
            try
            {
                DALMovimentacaoCamera dalMovimentacao = new DALMovimentacaoCamera();
                dalMovimentacao.ReceberCamera(numeroMovimentacao, data, status, usuario, observacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class MovimentacaoCameraCustom
    {
        public int NUMERO_MOVIMENTACAO { get; set; }
        public string TIPO { get; set; }
        public string NUMERO_CAMERA { get; set; }
        public string EQUIPE { get; set; }
        public int? MANUTENCAO { get; set; }
        public string OBSERVACAO { get; set; }
        public string RESPONSAVEL { get; set; }
        public DateTime? DATA_REGISTRO { get; set; }
    }
}
