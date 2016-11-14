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
    public partial class frmCadastroManualFuncionario : Form
    {
        private FUNCIONARIOS _funcionario;
        public int Processo { get; set; }

        public frmCadastroManualFuncionario()
        {
            InitializeComponent();
        }

        public frmCadastroManualFuncionario(FUNCIONARIOS funcionario)
        {
            InitializeComponent();
            _funcionario = new FUNCIONARIOS();
            _funcionario = funcionario;
        }

        private void frmCadastroManualFuncionario_Load(object sender, EventArgs e)
        {
            CarregaRegioes();
            CarregaFuncionarios();
            txtGestor.Enabled = false;

            if (this.Processo == 0)
            {
                LimparCampos();
                cmbGerencia.Enabled = false;
                cmbSupervisao.Enabled = false;
                cmbLocalidade.Enabled = false;
            }
            else
            {
                BLLFuncionarios bllFuncionario = new BLLFuncionarios();
                txtProntuario.Text = _funcionario.prontuario;
                txtNome.Text = _funcionario.nome_funcionario;
                txtFuncao.Text = _funcionario.funcao;
                cmbRegiao.SelectedValue = _funcionario.regiao;
                CarregaGerencias(_funcionario.regiao);
                cmbGerencia.SelectedValue = _funcionario.gerencia;
                CarregaSupervisoes(_funcionario.gerencia);
                cmbSupervisao.SelectedValue = _funcionario.supervisao;
                CarregaLocalidades(_funcionario.supervisao);
                cmbLocalidade.SelectedValue = _funcionario.localidade;
                cmbGestor.SelectedValue = _funcionario.prontuario_gestor != null ? _funcionario.prontuario_gestor : "";
                txtGestor.Text = _funcionario.prontuario_gestor != null ? bllFuncionario.GetFuncionario(_funcionario.prontuario_gestor).nome_funcionario : "";
                toolStripButton2.Enabled = false;
            }
        }

        private void LimparCampos()
        {
            txtProntuario.Text = "";
            txtNome.Text = "";
            txtFuncao.Text = "";
            cmbRegiao.SelectedIndex = -1;
            cmbGerencia.SelectedIndex = -1;
            cmbGerencia.Enabled = false;
            cmbSupervisao.SelectedIndex = -1;
            cmbSupervisao.Enabled = false;
            cmbLocalidade.SelectedIndex = -1;
            cmbLocalidade.Enabled = false;
            cmbGestor.SelectedIndex = -1;
            txtGestor.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private bool ValidaCampos()
        {
            if ((txtProntuario.Text == "") || (txtNome.Text == "") || (txtFuncao.Text == "") || (cmbRegiao.SelectedIndex == -1) || (cmbGerencia.SelectedIndex == -1) || (cmbSupervisao.SelectedIndex == -1) || (cmbLocalidade.SelectedIndex == -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CarregaRegioes()
        {
            BLLRegiao bllRegiao = new BLLRegiao();
            List<CamadaDados.REGIAO> regioes = new List<CamadaDados.REGIAO>();

            regioes = bllRegiao.GetRegioes("");

            cmbRegiao.DataSource = regioes.OrderBy(l => l.DESCRICAO).ToList();
            cmbRegiao.DisplayMember = "DESCRICAO";
            cmbRegiao.ValueMember = "CODIGO_REGIAO";
            cmbRegiao.SelectedIndex = -1;
        }

        public void CarregaGerencias(int codigo)
        {
            BLLGerencia bllGerencia = new BLLGerencia();
            List<CamadaDados.GERENCIA> gerencias = new List<CamadaDados.GERENCIA>();

            gerencias = bllGerencia.GetGerenciasByRegiao(codigo);

            cmbGerencia.DataSource = gerencias.OrderBy(l => l.DESCRICAO).ToList();
            cmbGerencia.DisplayMember = "DESCRICAO";
            cmbGerencia.ValueMember = "CODIGO_GERENCIA";
            cmbGerencia.SelectedIndex = -1;
        }

        public void CarregaSupervisoes(int codigo)
        {
            BLLSupervisao bllSupervisao = new BLLSupervisao();
            List<CamadaDados.SUPERVISAO> supervisoes = new List<CamadaDados.SUPERVISAO>();

            supervisoes = bllSupervisao.GetSupervisaoByGerencia(codigo);

            cmbSupervisao.DataSource = supervisoes.OrderBy(l => l.DESCRICAO).ToList();
            cmbSupervisao.DisplayMember = "DESCRICAO";
            cmbSupervisao.ValueMember = "CODIGO_SUPERVISAO";
            cmbSupervisao.SelectedIndex = -1;
        }

        public void CarregaLocalidades(int codigo)
        {
            BLLLocalidade bllLocalidade = new BLLLocalidade();
            List<CamadaDados.LOCALIDADE> localidades = new List<CamadaDados.LOCALIDADE>();

            localidades = bllLocalidade.GetLocalidadesBySupervisao(codigo);

            cmbLocalidade.DataSource = localidades.OrderBy(l => l.DESCRICAO).ToList();
            cmbLocalidade.DisplayMember = "DESCRICAO";
            cmbLocalidade.ValueMember = "CODIGO_LOCALIDADE";
            cmbLocalidade.SelectedIndex = -1;
        }

        public void CarregaFuncionarios()
        {
            BLLFuncionarios bllFuncionario = new BLLFuncionarios();
            List<FUNCIONARIOS> funcionarios = new List<FUNCIONARIOS>();

            funcionarios = bllFuncionario.GetFuncionarios("");

            cmbGestor.DataSource = funcionarios.OrderBy(l => l.prontuario).ToList();
            cmbGestor.DisplayMember = "prontuario";
            cmbGestor.ValueMember = "prontuario";
            cmbGestor.SelectedIndex = -1;
        }

        private void cmbRegiao_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbRegiao.SelectedIndex != -1)
            {
                cmbGerencia.Enabled = true;
                CarregaGerencias(Convert.ToInt32(cmbRegiao.SelectedValue.ToString()));
            }
            else
            {
                cmbGerencia.SelectedIndex = -1;
                cmbGerencia.Enabled = false;
                cmbSupervisao.SelectedIndex = -1;
                cmbSupervisao.Enabled = false;
                cmbLocalidade.SelectedIndex = -1;
                cmbLocalidade.Enabled = false;
            }
        }

        private void cmbGerencia_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbGerencia.SelectedIndex != -1)
            {
                cmbSupervisao.Enabled = true;
                CarregaSupervisoes(Convert.ToInt32(cmbGerencia.SelectedValue.ToString()));
            }
            else
            {
                cmbSupervisao.SelectedIndex = -1;
                cmbSupervisao.Enabled = false;
                cmbLocalidade.SelectedIndex = -1;
                cmbLocalidade.Enabled = false;
            }
        }

        private void cmbSupervisao_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSupervisao.SelectedIndex != -1)
            {
                cmbLocalidade.Enabled = true;
                CarregaLocalidades(Convert.ToInt32(cmbSupervisao.SelectedValue.ToString()));
            }
            else
            {
                cmbLocalidade.SelectedIndex = -1;
                cmbLocalidade.Enabled = false;
            }
        }

        private void Incluir()
        {
            try
            {
                BLLFuncionarios bllFuncionario = new BLLFuncionarios();
                FUNCIONARIOS funcionario = new FUNCIONARIOS();

                funcionario.prontuario = txtProntuario.Text;
                funcionario.nome_funcionario = txtNome.Text;
                funcionario.funcao = txtFuncao.Text;
                funcionario.localidade = Convert.ToInt32(cmbLocalidade.SelectedValue);
                funcionario.supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue);
                funcionario.gerencia = Convert.ToInt32(cmbGerencia.SelectedValue);
                funcionario.regiao = Convert.ToInt32(cmbRegiao.SelectedValue);
                if (cmbGestor.SelectedIndex != -1)
                {
                    funcionario.prontuario_gestor = cmbGestor.SelectedValue.ToString();
                    funcionario.nome_gestor = txtGestor.Text;
                }
           
                bllFuncionario.InsertFuncionario(funcionario);

                MessageBox.Show("Funcionário " + txtNome.Text + " incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregaFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Alterar()
        {
            try
            {
                BLLFuncionarios bllFuncionario = new BLLFuncionarios();
                FUNCIONARIOS funcionario = new FUNCIONARIOS();

                funcionario.prontuario = txtProntuario.Text;
                funcionario.nome_funcionario = txtNome.Text;
                funcionario.funcao = txtFuncao.Text;
                funcionario.localidade = Convert.ToInt32(cmbLocalidade.SelectedValue);
                funcionario.supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue);
                funcionario.gerencia = Convert.ToInt32(cmbGerencia.SelectedValue);
                funcionario.regiao = Convert.ToInt32(cmbRegiao.SelectedValue);

                if (cmbGestor.SelectedIndex > -1)
                {
                    funcionario.prontuario_gestor = cmbGestor.SelectedValue.ToString();
                    funcionario.nome_gestor = txtGestor.Text;
                }
           
                bllFuncionario.UpdateFuncionario(funcionario);

                MessageBox.Show("Funcionário " + txtNome.Text + " alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                if (this.Processo == 0)
                {
                    Incluir();
                }
                else
                {
                    Alterar();
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbGestor_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbGestor.SelectedIndex != -1 && cmbGestor.SelectedValue.ToString() != "")
            {
                BLLFuncionarios bllFuncionario = new BLLFuncionarios();
                FUNCIONARIOS funcionario = bllFuncionario.GetFuncionario(cmbGestor.SelectedValue.ToString());
                txtGestor.Text = funcionario.nome_funcionario;
            }
            else
            {
                txtGestor.Text = "";
            }
        }
    }
}
