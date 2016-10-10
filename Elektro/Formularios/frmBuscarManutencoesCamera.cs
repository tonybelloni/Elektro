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
    public partial class frmBuscarManutencoesCamera : Form
    {
        private DataGridView dgv;

        public frmBuscarManutencoesCamera()
        {
            InitializeComponent();
        }

        public frmBuscarManutencoesCamera(DataGridView dgvForm)
        {
            dgv = dgvForm;
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNumeroCamera.Text = "";
            cmbEmpresa.SelectedIndex = -1;
            cmbManutencao.SelectedIndex = 0;
        }

        private void frmBuscarManutencoesCamera_Load(object sender, EventArgs e)
        {
            CarregarEmpresas();
            cmbManutencao.SelectedIndex = 0;
        }

        private void Pesquisar()
        {
            try
            {
                BLLMovimentacaoCamera bllMovimentacao = new BLLMovimentacaoCamera();
                List<MOVIMENTACAO_CAMERA> lista = new List<MOVIMENTACAO_CAMERA>();

                string numeroCamera = txtNumeroCamera.Text;
                int empresa = cmbEmpresa.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbEmpresa.SelectedValue.ToString());
                int manutencoes = cmbManutencao.SelectedIndex;

                lista = bllMovimentacao.GetManutencoesCamera(numeroCamera, empresa, manutencoes).Where(l => l.TIPO == "IDA").AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dgv.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_MOVIMENTACAO,
                        l.TIPO,
                        l.CODIGO_CAMERA,
                        l.EMPRESA_MANUTENCAO,
                        l.OBSERVACAO,
                        l.DATA_INICIO,
                        l.DATA_FIM
                    }).AsQueryable().ToList();
                    dgv.Columns[0].HeaderText = "N° Movimentação";
                    dgv.Columns[1].HeaderText = "Status";
                    dgv.Columns[2].HeaderText = "N° Câmera";
                    dgv.Columns[3].HeaderText = "Empresa";
                    dgv.Columns[4].HeaderText = "Observação";
                    dgv.Columns[5].HeaderText = "Data Envio";
                    dgv.Columns[6].HeaderText = "Data Recebimento";
                }
                else
                {
                    dgv.DataSource = null;
                    MessageBox.Show("Nenhuma manutenção de câmeras encontrada!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        public void CarregarEmpresas()
        {
            BLLEmpresaManutencao bllEmpresa = new BLLEmpresaManutencao();
            List<EMPRESAS> empresas = bllEmpresa.GetEmpresas("");

            cmbEmpresa.DataSource = empresas.OrderBy(e => e.DESCRICAO).AsQueryable().ToList();
            cmbEmpresa.DisplayMember = "DESCRICAO";
            cmbEmpresa.ValueMember = "CODIGO_EMPRESA";
            cmbEmpresa.SelectedIndex = -1;
        }
    }
}
