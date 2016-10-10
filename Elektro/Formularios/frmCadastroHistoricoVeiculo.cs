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
    public partial class frmCadastroHistoricoVeiculo : Form
    {
        private USUARIOS _usuario;
        private HISTORICO_VEICULO _historico;
        private EQUIPES _equipe;
        private int _tipo;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmCadastroHistoricoVeiculo()
        {
            InitializeComponent();
        }

        public frmCadastroHistoricoVeiculo(EQUIPES equipe, int tipo)
        {
            InitializeComponent();
            _equipe = equipe;
            _tipo = tipo;
        }

        public frmCadastroHistoricoVeiculo(HISTORICO_VEICULO historico)
        {
            _historico = historico;
            InitializeComponent();
        }

        private void frmCadastroHistoricoVeiculo_Load(object sender, EventArgs e)
        {
            if (_tipo == 1)
            {
                CarregarEquipes(1);
                CarregarVeiculos(1);

                cmbEquipe.SelectedValue = _equipe.SIGLA_EQUIPE;
                cmbEquipe.Enabled = false;
            }
            else
            {
                CarregarEquipes(2);
                CarregarVeiculos(2);

                cmbPlaca.SelectedValue = _equipe.PLACA_VEICULO;
                cmbPlaca.Enabled = false;
                cmbEquipe.SelectedValue = _equipe.SIGLA_EQUIPE;
                cmbEquipe.Enabled = false;

                toolStripButton2.Visible = false;
            }
        }

        private void LimparCampos()
        {
            cmbPlaca.SelectedIndex = -1;
            txtObservacao.Text = "";
        }

        private bool ValidarCampos()
        {
            if ((cmbPlaca.SelectedIndex == -1) || (cmbEquipe.SelectedIndex == -1) || (txtObservacao.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CarregarEquipes(int tipo)
        {
            if (tipo == 1)
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipesSemVeiculo();

                cmbEquipe.DataSource = null;
                cmbEquipe.DataSource = equipes;
                cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
                cmbEquipe.ValueMember = "SIGLA_EQUIPE";
                cmbEquipe.SelectedIndex = -1;
            }
            else
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipesComVeiculo();

                cmbEquipe.DataSource = null;
                cmbEquipe.DataSource = equipes;
                cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
                cmbEquipe.ValueMember = "SIGLA_EQUIPE";
                cmbEquipe.SelectedIndex = -1;
            }
        }

        public void CarregarVeiculos(int tipo)
        {
            if (tipo == 1)
            {
                BLLVeiculos bllVeiculo = new BLLVeiculos();
                List<VEICULOS> veiculos = bllVeiculo.GetVeiculosSemEquipes();

                cmbPlaca.DataSource = null;
                cmbPlaca.DataSource = veiculos;
                cmbPlaca.DisplayMember = "PLACA";
                cmbPlaca.ValueMember = "PLACA";
                cmbPlaca.SelectedIndex = -1;
            }
            else
            {
                BLLVeiculos bllVeiculo = new BLLVeiculos();
                List<VEICULOS> veiculos = bllVeiculo.GetVeiculosComEquipes();

                cmbPlaca.DataSource = null;
                cmbPlaca.DataSource = veiculos;
                cmbPlaca.DisplayMember = "PLACA";
                cmbPlaca.ValueMember = "PLACA";
                cmbPlaca.SelectedIndex = -1;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Incluir();
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Incluir()
        {
            try
            {
                BLLHistoricoVeiculo bllHistorico = new BLLHistoricoVeiculo();
                HISTORICO_VEICULO historico = new HISTORICO_VEICULO();

                if (_equipe.PLACA_VEICULO == null)
                {
                    string placa = cmbPlaca.SelectedValue.ToString();
                    string equipe = cmbEquipe.SelectedValue.ToString();
                    string observacao = txtObservacao.Text;

                    historico.PLACA_VEICULO = placa;
                    historico.SIGLA_EQUIPE = equipe;
                    historico.OBSERVACAO_VINCULAR = observacao;
                    historico.DATA_VINCULAR = DateTime.Now;
                    historico.USUARIO_VINCULAR = _usuario.prontuario_usuario;

                    bllHistorico.VincularVeiculoEquipe(historico);

                    BLLEquipes bllEquipe = new BLLEquipes();
                    bllEquipe.UpdateStatusVeiculoEquipe(historico.SIGLA_EQUIPE, historico.PLACA_VEICULO);

                    BLLVeiculos bllVeiculo = new BLLVeiculos();
                    bllVeiculo.UpdateEquipeVeiculo(historico.PLACA_VEICULO, historico.SIGLA_EQUIPE);

                    CarregarEquipes(1);
                    CarregarVeiculos(1);

                    MessageBox.Show("Veículo vinculado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    historico = bllHistorico.GetHistoricosVeiculos().Where(l => l.SIGLA_EQUIPE == _equipe.SIGLA_EQUIPE && !l.DATA_DESVINCULAR.HasValue).AsQueryable().LastOrDefault();
                    bllHistorico.DesvincularVeiculoEquipe(historico.NUMERO_HISTORICO, txtObservacao.Text, _usuario.prontuario_usuario);

                    BLLEquipes bllEquipe = new BLLEquipes();
                    bllEquipe.UpdateStatusVeiculoEquipe(historico.SIGLA_EQUIPE, null);

                    BLLVeiculos bllVeiculo = new BLLVeiculos();
                    bllVeiculo.UpdateEquipeVeiculo(historico.PLACA_VEICULO, null);

                    CarregarEquipes(2);
                    CarregarVeiculos(2);

                    MessageBox.Show("Veículo desvinculado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
