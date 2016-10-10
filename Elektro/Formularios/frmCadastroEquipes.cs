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
using Utilitarios;
using Modelo;

namespace Elektro.Formularios
{
    public partial class frmCadastroEquipes : Form
    {
        private CamadaDados.EQUIPES _equipe;

        public int Processo { get; set; }
        
        public frmCadastroEquipes()
        {
            InitializeComponent();
        }

        public frmCadastroEquipes(CamadaDados.EQUIPES equipe)
        {
            InitializeComponent();
            _equipe = new CamadaDados.EQUIPES();
            _equipe = equipe;
        }

        private void frmCadastroEquipes_Load(object sender, EventArgs e)
        {
            BLLTiposTrabalhos trabalhos = new BLLTiposTrabalhos();
            List<TipoTrabalho> lista = new List<TipoTrabalho>();

            lista.Clear();
            lista = trabalhos.GetTiposTrabalhos(null);

            cmbTipoTrabalho.DataSource = lista;
            cmbTipoTrabalho.DisplayMember = "DescricaoTipoTrabalho";
            cmbTipoTrabalho.ValueMember = "IdTipoTrabalho";
            cmbTipoTrabalho.SelectedIndex = -1;

            CarregaRegioes();

            if (this.Processo == 0)
            {
                LimparCampos();
                cmbGerencia.Enabled = false;
                cmbSupervisao.Enabled = false;
                cmbLocalidade.Enabled = false;
            }
            else
            {
                txtSigla.Text = _equipe.SIGLA_EQUIPE;
                txtNome.Text = _equipe.NOME_EQUIPE;
                cmbRegiao.SelectedValue = _equipe.REGIAO;
                CarregaGerencias(_equipe.REGIAO.Value);
                cmbGerencia.SelectedValue = _equipe.GERENCIA;
                CarregaSupervisoes(_equipe.GERENCIA.Value);
                cmbSupervisao.SelectedValue = _equipe.SUPERVISAO;
                CarregaLocalidades(_equipe.SUPERVISAO.Value);
                cmbLocalidade.SelectedValue = _equipe.LOCALIDADE;
                cmbTipoTrabalho.SelectedValue = _equipe.ID_TIPO_TRABALHO;
                txtSigla.Focus();
                toolStripButton2.Enabled = false;
            }
        }

        private void LimparCampos()
        {
            txtSigla.Text = "";
            txtNome.Text = "";
            cmbTipoTrabalho.SelectedIndex = -1;
            txtSigla.Focus();
            cmbRegiao.SelectedIndex = -1;
            cmbGerencia.SelectedIndex = -1;
            cmbGerencia.Enabled = false;
            cmbSupervisao.SelectedIndex = -1;
            cmbSupervisao.Enabled = false;
            cmbLocalidade.SelectedIndex = -1;
            cmbLocalidade.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
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

        private bool ValidaCampos()
        {
            if ((txtSigla.Text == "") || (txtNome.Text == "") || (cmbRegiao.SelectedIndex == -1) || (cmbGerencia.SelectedIndex == -1) || (cmbSupervisao.SelectedIndex == -1) || (cmbLocalidade.SelectedIndex == -1) || (cmbTipoTrabalho.SelectedIndex == -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Incluir()
        {
            try
            {
                BLLEquipes equipes = new BLLEquipes();
                CamadaDados.EQUIPES equipe = new CamadaDados.EQUIPES();

                equipe.SIGLA_EQUIPE = txtSigla.Text;
                equipe.NOME_EQUIPE = txtNome.Text;
                equipe.ID_TIPO_TRABALHO = (int)cmbTipoTrabalho.SelectedValue;
                equipe.REGIAO = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
                equipe.GERENCIA = Convert.ToInt32(cmbGerencia.SelectedValue.ToString());
                equipe.SUPERVISAO = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
                equipe.LOCALIDADE = Convert.ToInt32(cmbLocalidade.SelectedValue.ToString());

                equipes.InsertEquipe(equipe);
                
                MessageBox.Show("Equipe " + txtSigla.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
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
                BLLEquipes equipes = new BLLEquipes();
                CamadaDados.EQUIPES equipe = new CamadaDados.EQUIPES();

                equipe.SIGLA_EQUIPE = txtSigla.Text;
                equipe.NOME_EQUIPE = txtNome.Text;
                equipe.ID_TIPO_TRABALHO = (int)cmbTipoTrabalho.SelectedValue;
                equipe.REGIAO = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
                equipe.GERENCIA = Convert.ToInt32(cmbGerencia.SelectedValue.ToString());
                equipe.SUPERVISAO = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
                equipe.LOCALIDADE = Convert.ToInt32(cmbLocalidade.SelectedValue.ToString());

                equipes.UpdateEquipe(equipe);

                MessageBox.Show("Equipe " + txtSigla.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
