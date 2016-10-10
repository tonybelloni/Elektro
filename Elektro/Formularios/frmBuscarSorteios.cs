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
    public partial class frmBuscarSorteios : Form
    {
        private DataGridView dgv;

        public frmBuscarSorteios()
        {
            InitializeComponent();
        }

        public frmBuscarSorteios(DataGridView dataGrid)
        {
            dgv = dataGrid;
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void LimparCampos()
        {
            txtCodigoSorteio.Text = "";
            cmbNumeroHD.SelectedIndex = -1;
            cmbEquipe.SelectedIndex = -1;
            txtDataInicial.Text = "";
            txtDataFinal.Text = "";
        }

        public void CarregarHDs()
        {
            BLLHD bllHD = new BLLHD();
            List<HD> hds = bllHD.GetHDs("");

            cmbNumeroHD.DataSource = hds;
            cmbNumeroHD.DisplayMember = "NUMERO_HD";
            cmbNumeroHD.ValueMember = "NUMERO_HD";
            cmbNumeroHD.SelectedIndex = -1;
        }

        public void CarregarEquipes()
        {
            BLLEquipes bllEquipes = new BLLEquipes();
            List<EQUIPES> equipes = bllEquipes.GetEquipes("");

            cmbEquipe.DataSource = equipes;
            cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
            cmbEquipe.ValueMember = "SIGLA_EQUIPE";
            cmbEquipe.SelectedIndex = -1;
        }

        public void Pesquisar()
        {
            try
            {
                int codigoSorteio = txtCodigoSorteio.Text != "" ? Convert.ToInt32(txtCodigoSorteio.Text) : 0;
                string numeroHD = cmbNumeroHD.SelectedIndex != -1 ? cmbNumeroHD.SelectedValue.ToString() : "";
                string equipe = cmbEquipe.SelectedIndex != -1 ? cmbEquipe.SelectedValue.ToString() : "";
                DateTime? dataInicial = txtDataInicial.Text != "  /  /" ? Convert.ToDateTime(txtDataInicial.Text) : new Nullable<DateTime>();
                DateTime? dataFinal = txtDataFinal.Text != "  /  /" ? Convert.ToDateTime(txtDataFinal.Text) : new Nullable<DateTime>();

                if (dataInicial > dataFinal)
                    throw new Exception("Data Inicial não pode ser maior que data final");

                BLLSorteio bllSorteio = new BLLSorteio();
                var sorteios = bllSorteio.GetSorteios(codigoSorteio, numeroHD, equipe, dataInicial, dataFinal);
                var lista = sorteios.Select(l => new
                {
                    l.COD_SORTEIO,
                    l.DATA_REGISTRO,
                    l.USUARIO_REGISTRO,
                    l.SORTEADOS.Count
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dgv.DataSource = lista;
                    dgv.Columns[0].HeaderText = "Código Sorteio";
                    dgv.Columns[1].HeaderText = "Data Sorteio";
                    dgv.Columns[2].HeaderText = "Usuário Responsável";
                    dgv.Columns[3].HeaderText = "Quantidade de equipes sorteadas";
                }
                else
                {
                    dgv.DataSource = null;
                    MessageBox.Show("Nenhum sorteio encontrado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
