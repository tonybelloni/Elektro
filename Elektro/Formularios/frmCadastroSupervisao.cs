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
    public partial class frmCadastroSupervisao : Form
    {
        private int _processo;
        private SUPERVISAO _supervisao;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroSupervisao()
        {
            InitializeComponent();
        }

        public frmCadastroSupervisao(SUPERVISAO supervisao)
        {
            InitializeComponent();
            _supervisao = new SUPERVISAO();
            _supervisao = supervisao;
        }

        private void frmCadastroSupervisao_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            CarregarGerencias();

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
                cmbGerente.SelectedIndex = -1;
            }
            else
            {
                txtCodigo.Text = _supervisao.CODIGO_SUPERVISAO.ToString();
                txtDescricao.Text = _supervisao.DESCRICAO;
                cmbGerente.SelectedValue = _supervisao.CODIGO_GERENCIA.Value;
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
            cmbGerente.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (txtDescricao.Text == "" || cmbGerente.SelectedIndex == -1)
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
                BLLSupervisao bllSupervisao = new BLLSupervisao();
                SUPERVISAO supervisao = new SUPERVISAO();

                supervisao.DESCRICAO = txtDescricao.Text;
                supervisao.CODIGO_GERENCIA = Convert.ToInt32(cmbGerente.SelectedValue.ToString());

                bllSupervisao.InsertSupervisao(supervisao);

                MessageBox.Show("Supervisão " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLSupervisao bllSupervisao = new BLLSupervisao();
                SUPERVISAO supervisao = new SUPERVISAO();

                supervisao.CODIGO_SUPERVISAO = Convert.ToInt32(txtCodigo.Text);
                supervisao.DESCRICAO = txtDescricao.Text;
                supervisao.CODIGO_GERENCIA = Convert.ToInt32(cmbGerente.SelectedValue.ToString());

                bllSupervisao.UpdateSupervisao(supervisao);

                MessageBox.Show("Supervisão " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarGerencias()
        {
            BLLGerencia bllGerencia = new BLLGerencia();
            List<GERENCIA> gerencias = bllGerencia.GetGerencias("");

            cmbGerente.DataSource = null;
            cmbGerente.DataSource = gerencias.OrderBy(l => l.DESCRICAO).ToList();
            cmbGerente.DisplayMember = "DESCRICAO";
            cmbGerente.ValueMember = "CODIGO_GERENCIA";
            cmbGerente.SelectedIndex = -1;
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
    }
}
