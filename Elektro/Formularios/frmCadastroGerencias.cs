using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados;
using CamadaControle;


namespace Elektro.Formularios
{
    public partial class frmCadastroGerencias : Form
    {
        private int _processo;
        private GERENCIA _gerencia;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroGerencias()
        {
            InitializeComponent();
        }

        public frmCadastroGerencias(GERENCIA gerencia)
        {
            InitializeComponent();
            _gerencia = new GERENCIA();
            _gerencia = gerencia;
        }

        private void frmCadastroGerencias_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            CarregarRegioes();

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
                cmbRegiao.SelectedIndex = -1;
            }
            else
            {
                txtCodigo.Text = _gerencia.CODIGO_GERENCIA.ToString();
                txtDescricao.Text = _gerencia.DESCRICAO;
                cmbRegiao.SelectedValue = _gerencia.CODIGO_REGIAO.Value;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            cmbRegiao.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (txtDescricao.Text == "" || cmbRegiao.SelectedIndex == -1)
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
                BLLGerencia bllGerencia = new BLLGerencia();
                GERENCIA gerencia = new GERENCIA();

                gerencia.DESCRICAO = txtDescricao.Text;
                gerencia.CODIGO_REGIAO = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());

                bllGerencia.InsertGerencia(gerencia);

                MessageBox.Show("Gerência " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLGerencia bllGerencia = new BLLGerencia();
                GERENCIA gerencia = new GERENCIA();

                gerencia.CODIGO_GERENCIA = Convert.ToInt32(txtCodigo.Text);
                gerencia.DESCRICAO = txtDescricao.Text;
                gerencia.CODIGO_REGIAO = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());

                bllGerencia.UpdateGerencia(gerencia);

                MessageBox.Show("Gerência " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (_processo == 0)
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
                MessageBox.Show("Os campos descrição e região devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarRegioes()
        {
            BLLRegiao bllRegiao = new BLLRegiao();
            List<REGIAO> regioes = bllRegiao.GetRegioes("");

            cmbRegiao.DataSource = null;
            cmbRegiao.DataSource = regioes.OrderBy(l => l.DESCRICAO).ToList();
            cmbRegiao.DisplayMember = "DESCRICAO";
            cmbRegiao.ValueMember = "CODIGO_REGIAO";
            cmbRegiao.SelectedIndex = -1;
        }
    }
}
