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
    public partial class frmCadastroLocalidades : Form
    {
        private int _processo;
        private LOCALIDADE _localidade;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroLocalidades()
        {
            InitializeComponent();
        }

        public frmCadastroLocalidades(LOCALIDADE localidade)
        {
            InitializeComponent();
            _localidade = new LOCALIDADE();
            _localidade = localidade;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            cmbSupervisao.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            if (txtDescricao.Text == "" || cmbSupervisao.SelectedIndex == -1)
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
                BLLLocalidade bllLocalidade = new BLLLocalidade();
                LOCALIDADE localidade = new LOCALIDADE();

                localidade.DESCRICAO = txtDescricao.Text;
                localidade.CODIGO_SUPERVISAO = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());

                bllLocalidade.InsertLocalidade(localidade);

                MessageBox.Show("Localidade " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLLocalidade bllLocalidade = new BLLLocalidade();
                LOCALIDADE localidade = new LOCALIDADE();

                localidade.CODIGO_LOCALIDADE = Convert.ToInt32(txtCodigo.Text);
                localidade.DESCRICAO = txtDescricao.Text;
                localidade.CODIGO_SUPERVISAO = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());

                bllLocalidade.UpdateLocalidade(localidade);

                MessageBox.Show("Localidade " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarSupervisoes()
        {
            BLLSupervisao bllSupervisao = new BLLSupervisao();
            List<SUPERVISAO> supervisoes = bllSupervisao.GetSupervisoes("");

            cmbSupervisao.DataSource = null;
            cmbSupervisao.DataSource = supervisoes.OrderBy(l => l.DESCRICAO).ToList();
            cmbSupervisao.DisplayMember = "DESCRICAO";
            cmbSupervisao.ValueMember = "CODIGO_SUPERVISAO";
            cmbSupervisao.SelectedIndex = -1;
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

        private void frmCadastroLocalidades_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            CarregarSupervisoes();

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
                cmbSupervisao.SelectedIndex = -1;
            }
            else
            {
                txtCodigo.Text = _localidade.CODIGO_LOCALIDADE.ToString();
                txtDescricao.Text = _localidade.DESCRICAO;
                cmbSupervisao.SelectedValue = _localidade.CODIGO_SUPERVISAO.Value;
            }
        }
    }
}
