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
using Modelo;

namespace Elektro.Formularios
{
    public partial class frmCadastroTiposTrabalhos : Form
    {
        private int _processo;
        private TipoTrabalho _tipotrabalho;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroTiposTrabalhos()
        {
            InitializeComponent();
        }

        public frmCadastroTiposTrabalhos(TipoTrabalho trabalho)
        {
            InitializeComponent();
            _tipotrabalho = new TipoTrabalho();
            _tipotrabalho = trabalho;
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
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                BLLTiposTrabalhos trabalhos = new BLLTiposTrabalhos();
                TipoTrabalho trabalho = new TipoTrabalho();

                trabalho.DescricaoTipoTrabalho = txtDescricao.Text;

                trabalhos.InsertTipoTrabalho(trabalho);

                MessageBox.Show("Tipo de Trabalho " + txtDescricao.Text + " incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLTiposTrabalhos trabalhos = new BLLTiposTrabalhos();
                TipoTrabalho trabalho = new TipoTrabalho();

                trabalho.IdTipoTrabalho = _tipotrabalho.IdTipoTrabalho;
                trabalho.DescricaoTipoTrabalho = txtDescricao.Text;

                trabalhos.UpdateTipoTrabalho(trabalho);

                MessageBox.Show("Tipo de Trabalho " + txtDescricao.Text + " alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void frmCadastroTiposTrabalhos_Load(object sender, EventArgs e)
        {
            if (_processo == 0)
            {
                LimparCampos();
            }
            else
            {
                txtDescricao.Text = _tipotrabalho.DescricaoTipoTrabalho;
                txtDescricao.Focus();
                toolStripButton2.Enabled = false;
            }
        }
    }
}
