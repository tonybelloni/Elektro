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
    public partial class frmBuscaEscala : Form
    {
        public string Equipe { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set;  }

        public frmBuscaEscala()
        {
            InitializeComponent();
        }

        private void frmBuscaEscala_Load(object sender, EventArgs e)
        {
            try
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipes("");

                cmbEquipe.DataSource = equipes;
                cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
                cmbEquipe.ValueMember = "SIGLA_EQUIPE";
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na pesquisa - " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            cmbEquipe.SelectedIndex = -1;

            txtDataInicial.Text = "";
            txtDataFinal.Text = "";

            cmbEquipe.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (cmbEquipe.SelectedIndex > -1)
                    this.Equipe = cmbEquipe.SelectedValue.ToString();
                else
                    this.Equipe = "";

                if (txtDataInicial.MaskFull)
                    this.DataInicial = txtDataInicial.Text;
                else
                    this.DataInicial = "";

                if (txtDataFinal.MaskFull)
                    this.DataFinal = txtDataFinal.Text;
                else
                    this.DataFinal = "";

                this.Close();
            }
            else
            {
                cmbEquipe.Focus();
            }
        }

        private bool ValidarCampos()
        {
            if ( (cmbEquipe.SelectedIndex > -1 && (!txtDataInicial.MaskFull || !txtDataFinal.MaskFull)) ||
                 (txtDataInicial.MaskFull && (cmbEquipe.SelectedIndex == -1 || !txtDataFinal.MaskFull)) ||
                 (txtDataFinal.MaskFull && (cmbEquipe.SelectedIndex == -1 || !txtDataInicial.MaskFull))
                )
            {
                MessageBox.Show("Todos os campos devem ser informados !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
               
                if (txtDataInicial.MaskFull || txtDataFinal.MaskFull)
                {
                    DateTime dtinicio = Convert.ToDateTime(txtDataInicial.Text);
                    DateTime dtfim = Convert.ToDateTime(txtDataFinal.Text);
                    if (dtinicio > dtfim)
                    {
                        MessageBox.Show("Data final deve ser maior ou igual !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datas devem estar em um formato válido !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;

        }
    }
}
