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
    public partial class frmCadastroRecPositivo : Form
    {
        private ATIVIDADES _atividade;
        public int Processo { get; set; }

        public frmCadastroRecPositivo()
        {
            InitializeComponent();
        }

        public frmCadastroRecPositivo(ATIVIDADES atividade)
        {
            _atividade = atividade;
            InitializeComponent();
        }

        private void frmCadastroRecPositivo_Load(object sender, EventArgs e)
        {
            if (this.Processo == 0)
            {
                txtDescricao.Text = "";
            }
            else
            {
                txtDescricao.Text = _atividade.DESCRICAO;
                toolStripButton2.Enabled = false;
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
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

        private bool ValidarCampos()
        {
            if ((txtDescricao.Text == ""))
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
                BLLAtividades bllAtividade = new BLLAtividades();
                ATIVIDADES atividade = new ATIVIDADES();

                atividade.DESCRICAO = txtDescricao.Text;
                bllAtividade.InsertAtividade(atividade);

                MessageBox.Show("Atividade " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLAtividades bllAtividade = new BLLAtividades();
                bllAtividade.UpdateAtividade(_atividade.CODIGO_ATIVIDADE, txtDescricao.Text);

                MessageBox.Show("Atividade " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
