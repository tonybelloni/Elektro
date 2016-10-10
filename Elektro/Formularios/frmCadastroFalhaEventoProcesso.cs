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
    public partial class frmCadastroFalhaEventoProcesso : Form
    {
        public int Processo { get; set; }
        public FALHAS_EVENTOS_PROCESSOS _falha;

        public frmCadastroFalhaEventoProcesso()
        {
            InitializeComponent();
        }

        public frmCadastroFalhaEventoProcesso(FALHAS_EVENTOS_PROCESSOS falha)
        {
            InitializeComponent();
            _falha = falha;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
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

        private void LimparCampos()
        {
            txtDescricao.Text = "";
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
                string descricao = txtDescricao.Text;
                FALHAS_EVENTOS_PROCESSOS falha = new FALHAS_EVENTOS_PROCESSOS();
                falha.DESCRICAO = descricao;
                BLLFalhasEventosProcessos bllFalha = new BLLFalhasEventosProcessos();
                bllFalha.InsertFalhaEvento(falha);

                MessageBox.Show("Falha de Evento de Processo incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int codigo = Convert.ToInt32(txtCodigo.Text);
                string descricao = txtDescricao.Text;
                BLLFalhasEventosProcessos bllFalha = new BLLFalhasEventosProcessos();
                FALHAS_EVENTOS_PROCESSOS falha = bllFalha.GetFalhaEvento(codigo);
                falha.DESCRICAO = descricao;
                
                bllFalha.UpdateFalhaEvento(falha);

                MessageBox.Show("Falha de Evento de Processo atualizada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCadastroFalhaEventoProcesso_Load(object sender, EventArgs e)
        {
            if (this.Processo == 0)
            {
                txtDescricao.Text = "";
                txtCodigo.Enabled = false;
            }
            else
            {
                txtCodigo.Text = _falha.COD_FALHA_EVENTO.ToString();
                txtDescricao.Text = _falha.DESCRICAO;
                txtCodigo.Enabled = false;

                toolStripButton2.Enabled = false;
            }
        }
    }
}
