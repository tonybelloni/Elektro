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
    public partial class frmBuscarAlocacoesVeiculo : Form
    {
        private DataGridView dgv;
        private CamadaDados.USUARIOS _usuario;

        public CamadaDados.USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmBuscarAlocacoesVeiculo()
        {
            InitializeComponent();
        }

        public frmBuscarAlocacoesVeiculo(DataGridView dgvForm)
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
            txtEquipe.Text = "";
            cmbStatus.SelectedIndex = 0;
        }

        private void frmBuscarAlocacoesVeiculo_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
        }

        public void Pesquisar()
        {
            try
            {
                BLLEquipes bllEquipe = new BLLEquipes();
                List<EQUIPES> lista = bllEquipe.GetEquipes("").OrderBy(l => l.SIGLA_EQUIPE).ToList();

                if (txtEquipe.Text.Trim() != "")
                    lista = lista.Where(l => l.SIGLA_EQUIPE.Contains(txtEquipe.Text)).AsQueryable().ToList();

                if (cmbStatus.SelectedIndex == 1)
                    lista = lista.Where(l => l.PLACA_VEICULO != null).AsQueryable().ToList();
                else if (cmbStatus.SelectedIndex == 2)
                    lista = lista.Where(l => l.PLACA_VEICULO == null).AsQueryable().ToList();

                BLLVeiculos bllVeiculo = new BLLVeiculos();

                if (Usuario.FUNCIONARIOS != null)
                {
                    if (Usuario.FUNCIONARIOS.funcao.Trim().Contains("gerente"))
                        lista = lista.Where(l => l.GERENCIA == Usuario.FUNCIONARIOS.gerencia).AsQueryable().ToList();
                    else if (Usuario.FUNCIONARIOS.funcao.Trim().Contains("supervisor"))
                        lista = lista.Where(l => l.SUPERVISAO == Usuario.FUNCIONARIOS.supervisao).AsQueryable().ToList();
                    else
                        lista = lista.Where(l => l.LOCALIDADE == Usuario.FUNCIONARIOS.localidade).AsQueryable().ToList();
                }

                if (lista.Count > 0)
                {
                    dgv.DataSource = lista.Select(l => new
                    {
                        l.SIGLA_EQUIPE,
                        l.NOME_EQUIPE,
                        l.TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                        l.REGIAO1.DESCRICAO,
                        GERENCIA = l.GERENCIA1.DESCRICAO,
                        SUPERVISAO = l.SUPERVISAO1.DESCRICAO,
                        LOCALIDADE = l.LOCALIDADE1.DESCRICAO,
                        l.CODIGO_CAMERA,
                        l.PLACA_VEICULO,
                        TIPO = l.PLACA_VEICULO != null ? bllVeiculo.GetVeiculo(l.PLACA_VEICULO).TIPOS_VEICULOS.DESCRICAO : ""
                    }).AsQueryable().ToList();
                    dgv.Columns[0].HeaderText = "Sigla";
                    dgv.Columns[1].HeaderText = "Nome";
                    dgv.Columns[2].HeaderText = "Atuação";
                    dgv.Columns[3].HeaderText = "Região";
                    dgv.Columns[4].HeaderText = "Gerência";
                    dgv.Columns[5].HeaderText = "Supervisão";
                    dgv.Columns[6].HeaderText = "Localidade";
                    dgv.Columns[7].HeaderText = "Câmera";
                    dgv.Columns[8].HeaderText = "Veículo";
                    dgv.Columns[9].HeaderText = "Tipo";
                }
                else
                {
                    MessageBox.Show("Não foi encontrado equipes", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Close();
        }
    }
}
