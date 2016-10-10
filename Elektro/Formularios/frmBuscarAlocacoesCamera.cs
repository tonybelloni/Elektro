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
    public partial class frmBuscarAlocacoesCamera : Form
    {
        private DataGridView dgv;

        public frmBuscarAlocacoesCamera()
        {
            InitializeComponent();
        }

        public frmBuscarAlocacoesCamera(DataGridView dgvForm)
        {
            dgv = dgvForm;
            InitializeComponent();
        }

        private void frmBuscarCamera_Load(object sender, EventArgs e)
        {
            cmbAlocada.SelectedIndex = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNumeroCamera.Text = "";
            txtEquipe.Text = "";
            cmbAlocada.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
            this.Close();
        }

        private void Pesquisar()
        {
            try
            {
                BLLMovimentacaoCamera bllMovimentacao = new BLLMovimentacaoCamera();
                List<MOVIMENTACAO_CAMERA> lista = new List<MOVIMENTACAO_CAMERA>();

                string numeroCamera = txtNumeroCamera.Text;
                string equipe = txtEquipe.Text;
                int alocacao = cmbAlocada.SelectedIndex;

                lista = bllMovimentacao.GetAlocacoesCamera(numeroCamera, equipe, alocacao);

                if (lista.Count > 0)
                {
                    dgv.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_MOVIMENTACAO,
                        l.TIPO,
                        l.CODIGO_CAMERA,
                        l.SIGLA_EQUIPE,
                        l.OBSERVACAO,
                        l.DATA_INICIO,
                        l.DATA_FIM
                    }).AsQueryable().ToList();
                    dgv.Columns[0].HeaderText = "N° Movimentação";
                    dgv.Columns[1].HeaderText = "Status";
                    dgv.Columns[2].HeaderText = "N° Câmera";
                    dgv.Columns[3].HeaderText = "Equipe";
                    dgv.Columns[4].HeaderText = "Observação";
                    dgv.Columns[5].HeaderText = "Data Alocação";
                    dgv.Columns[6].HeaderText = "Data Devolução";
                }
                else
                {
                    dgv.DataSource = null;
                    MessageBox.Show("Nenhuma movimentação de câmeras encontrada!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
