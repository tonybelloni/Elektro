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
    public partial class frmCadastroHD : Form
    {
        private int _processo;
        private HD _hd;
        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroHD()
        {
            InitializeComponent();
        }

        public frmCadastroHD(HD hd)
        {
            InitializeComponent();
            _hd = new HD();
            _hd = hd;
        }

        private void frmCadastroHD_Load(object sender, EventArgs e)
        {
            if (_processo == 0)
            {
                txtNumeroHD.Text = "";
                txtNumeroSerie.Text = "";
            }
            else
            {
                txtNumeroHD.Text = _hd.NUMERO_HD;
                txtNumeroSerie.Text = _hd.NUMERO_SERIE;
                txtNumeroHD.Enabled = false;
                toolStripButton2.Enabled = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNumeroHD.Text = "";
            txtNumeroSerie.Text = "";
        }

        private bool ValidarCampos()
        {
            if ((txtNumeroHD.Text == "") || (txtNumeroSerie.Text == ""))
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
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Incluir()
        {
            try
            {
                BLLHD bllHD = new BLLHD();
                HD hd = new HD();

                hd.NUMERO_HD = txtNumeroHD.Text;
                hd.NUMERO_SERIE = txtNumeroSerie.Text;
                hd.STATUS = "ESTOQUE";

                bllHD.InsertHD(hd);

                MessageBox.Show("HD " + txtNumeroHD.Text + " incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLHD bllHD = new BLLHD();
                HD hd = new HD();

                hd.NUMERO_HD = txtNumeroHD.Text;
                hd.NUMERO_SERIE = txtNumeroSerie.Text;

                bllHD.UpdateHD(hd);

                MessageBox.Show("HD " + txtNumeroHD.Text + " alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
