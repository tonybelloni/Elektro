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
    public partial class frmCadastroEmpresaManutencao : Form
    {
        private int _processo;
        private EMPRESAS _empresa;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroEmpresaManutencao()
        {
            InitializeComponent();
        }

        public frmCadastroEmpresaManutencao(EMPRESAS empresa)
        {
            InitializeComponent();
            _empresa = new EMPRESAS();
            _empresa = empresa;
        }

        private void frmCadastroEmpresaManutencao_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
            }
            else
            {
                txtCodigo.Text = _empresa.CODIGO_EMPRESA.ToString();
                txtDescricao.Text = _empresa.DESCRICAO;
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

        private void Incluir()
        {
            try
            {
                BLLEmpresaManutencao bllManutencao = new BLLEmpresaManutencao();
                EMPRESAS empresa = new EMPRESAS();

                empresa.DESCRICAO = txtDescricao.Text;

                bllManutencao.InsertEmpresa(empresa);

                MessageBox.Show("Empresa " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLEmpresaManutencao bllManutencao = new BLLEmpresaManutencao();
                EMPRESAS empresa = new EMPRESAS();

                empresa.CODIGO_EMPRESA = Convert.ToInt32(txtCodigo.Text);
                empresa.DESCRICAO = txtDescricao.Text;

                bllManutencao.UpdateHD(empresa);

                MessageBox.Show("Empresa " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
