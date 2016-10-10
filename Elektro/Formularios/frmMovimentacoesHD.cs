using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaControle;
using CamadaDados;

namespace Elektro.Formularios
{
    public partial class frmMovimentacoesHD : Form
    {
        private string _numeroHD;

        public frmMovimentacoesHD()
        {
            InitializeComponent();
        }

        public frmMovimentacoesHD(string numeroHD)
        {
            InitializeComponent();
            _numeroHD = numeroHD;
        }

        private void frmMovimentacoesHD_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLMovimentacaoHD bllMovimentacao = new BLLMovimentacaoHD();
                List<MOVIMENTACAO_HD> lista = bllMovimentacao.GetMovimentacoesHD(_numeroHD, null, null, 0);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_HD,
                        DATA_ENVIO = l.DATA_ENVIO.Value.ToShortDateString(),
                        ORIGEM = l.LOCALIDADE1.DESCRICAO,
                        RESPONSAVEL_ENVIO = l.USUARIO_REGISTRO,
                        TIPO_ENVIO = l.NUMERO_PROTOCOLO != null ? "CORREIOS" : "ENVIO POR FUNCIONÁRIO",
                        RASTREIO = l.NUMERO_PROTOCOLO != null ? l.NUMERO_PROTOCOLO : l.RESPONSAVEL,
                        PROVAVEL_DATA_RECEBIMENTO = l.DATA_PROVAVEL_RECEBIMENTO.Value.ToShortDateString(),
                        DATA_RECEBIMENTO = l.DATA_CHEGADA.Value.ToShortDateString(),
                        DESTINO = l.LOCALIDADE.DESCRICAO,
                        RESPONSAVEL_RECEBIMENTO = l.USUARIO_REGISTRO_RECEBIMENTO
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "HD";
                    dataGridView1.Columns[1].HeaderText = "Data Envio";
                    dataGridView1.Columns[2].HeaderText = "Origem";
                    dataGridView1.Columns[3].HeaderText = "Responsável Envio";
                    dataGridView1.Columns[4].HeaderText = "Tipo de Envio";
                    dataGridView1.Columns[5].HeaderText = "Rastreio";
                    dataGridView1.Columns[6].HeaderText = "Provável Recebimento";
                    dataGridView1.Columns[7].HeaderText = "Data Recebimento";
                    dataGridView1.Columns[8].HeaderText = "Destino";
                    dataGridView1.Columns[9].HeaderText = "Responsável Recebimento";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
