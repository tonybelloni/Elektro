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
    public partial class frmCadastroTipoVeiculo : Form
    {
        private int _processo;
        public TIPOS_VEICULOS _tipo;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroTipoVeiculo()
        {
            InitializeComponent();
        }

        public frmCadastroTipoVeiculo(TIPOS_VEICULOS tipo)
        {
            InitializeComponent();
            _tipo = tipo;
        }

        private void frmCadastroTipoVeiculo_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
            }
            else
            {
                txtCodigo.Text = _tipo.COD_TIPO_VEICULO.ToString();
                txtDescricao.Text = _tipo.DESCRICAO;
                toolStripButton2.Enabled = false;
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
                BLLTiposVeiculos bllTipo = new BLLTiposVeiculos();
                TIPOS_VEICULOS tipo = new TIPOS_VEICULOS();

                tipo.DESCRICAO = txtDescricao.Text;
                bllTipo.InsertTipoVeiculo(tipo);

                MessageBox.Show("Tipo de veículo incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLTiposVeiculos bllTipo = new BLLTiposVeiculos();
                TIPOS_VEICULOS tipo = new TIPOS_VEICULOS();

                tipo.COD_TIPO_VEICULO = Convert.ToInt32(txtCodigo.Text);
                tipo.DESCRICAO = txtDescricao.Text;
                bllTipo.UpdateTipoVeiculo(tipo);

                MessageBox.Show("Tipo de veículo alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
