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
using CamadaDados;

namespace Elektro.Formularios
{
    public partial class frmCadastroVeiculos : Form
    {
        private int _processo;
        private VEICULOS _veiculo;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroVeiculos()
        {
            InitializeComponent();
        }

        public frmCadastroVeiculos(VEICULOS veiculo)
        {
            InitializeComponent();
            _veiculo = veiculo;
        }

        private void frmCadastroVeiculos_Load(object sender, EventArgs e)
        {
            CarregarTiposVeiculos();

            try
            {
                if (_processo == 0)
                {
                    txtPlaca.Text = "";
                    txtObservacoes.Text = "";
                    cmbAtivo.SelectedIndex = -1;
                }
                else
                {
                    txtPlaca.Text = _veiculo.PLACA;
                    txtObservacoes.Text = _veiculo.observacao;
                    cmbTipo.SelectedValue = _veiculo.COD_TIPO;
                    cmbAtivo.SelectedIndex = _veiculo.ativo;
                    txtPlaca.Enabled = false;
                    toolStripButton2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtPlaca.Text = "";
            txtObservacoes.Text = "";
            cmbAtivo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            txtPlaca.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private bool ValidaCampos()
        {
            if ((txtPlaca.Text == "   -") ||  (cmbAtivo.SelectedIndex == -1) || (cmbTipo.SelectedIndex == -1))
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
            if (ValidaCampos())
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
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Incluir()
        {
            try
            {
                BLLVeiculos veiculos = new BLLVeiculos();
                VEICULOS veiculo = new VEICULOS();

                veiculo.PLACA = txtPlaca.Text;
                veiculo.observacao = txtObservacoes.Text;
                veiculo.COD_TIPO = Convert.ToInt32(cmbTipo.SelectedValue);

                if (cmbAtivo.SelectedText == "Sim")
                {
                    
                    veiculo.ativo = 1;
                }
                else
                {
                    veiculo.ativo = 0;
                }
                
                veiculos.InsertVeiculo(veiculo);
                MessageBox.Show("Veículo " + txtPlaca.Text + " incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLVeiculos veiculos = new BLLVeiculos();
                VEICULOS veiculo = new VEICULOS();

                veiculo.PLACA = txtPlaca.Text;
                veiculo.observacao = txtObservacoes.Text;
                veiculo.COD_TIPO = Convert.ToInt32(cmbTipo.SelectedValue);

                if (cmbAtivo.SelectedIndex == 1)
                {
                    veiculo.ativo = 1;
                }
                else
                {
                    veiculo.ativo = 0;
                }

                veiculos.UpdateVeiculo(veiculo);
                MessageBox.Show("Veículo " + txtPlaca.Text + " alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTiposVeiculos()
        {
            try
            {
                BLLTiposVeiculos bllTipo = new BLLTiposVeiculos();
                List<TIPOS_VEICULOS> lista = bllTipo.GetTiposVeiculos("");

                cmbTipo.DataSource = lista.OrderBy(l => l.DESCRICAO).ToList();
                cmbTipo.DisplayMember = "DESCRICAO";
                cmbTipo.ValueMember = "COD_TIPO_VEICULO";
                cmbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
