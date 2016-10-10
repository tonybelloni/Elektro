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
    public partial class frmCadastroRegioes : Form
    {
        private int _processo;
        private REGIAO _regiao;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroRegioes()
        {
            InitializeComponent();
        }

        public frmCadastroRegioes(REGIAO regiao)
        {
            InitializeComponent();
            _regiao = new REGIAO();
            _regiao = regiao;
        }

        private void frmCadastroRegioes_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
            }
            else
            {
                txtCodigo.Text = _regiao.CODIGO_REGIAO.ToString();
                txtDescricao.Text = _regiao.DESCRICAO;
                toolStripButton2.Enabled = false;
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
        }

        private bool ValidarCampos()
        {
            if (txtDescricao.Text == "")
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
                BLLRegiao bllRegiao = new BLLRegiao();
                REGIAO regiao = new REGIAO();

                regiao.DESCRICAO = txtDescricao.Text;

                bllRegiao.InsertRegiao(regiao);

                MessageBox.Show("Região " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLRegiao bllRegiao = new BLLRegiao();
                REGIAO regiao = new REGIAO();

                regiao.CODIGO_REGIAO = Convert.ToInt32(txtCodigo.Text);
                regiao.DESCRICAO = txtDescricao.Text;

                bllRegiao.UpdateRegiao(regiao);

                MessageBox.Show("Região " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("O campo descrição deve ser informado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
