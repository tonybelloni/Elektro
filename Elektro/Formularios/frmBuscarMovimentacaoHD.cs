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
    public partial class frmBuscarMovimentacaoHD : Form
    {
        private DataGridView dgv;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmBuscarMovimentacaoHD()
        {
            InitializeComponent();
        }

        public frmBuscarMovimentacaoHD(DataGridView dgvFrm)
        {
            dgv = dgvFrm;
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
            this.Close();
        }

        private void LimparCampos()
        {
            cmbNumeroHD.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
        }

        private void Pesquisar()
        {
            try
            {
                string numeroHD = "";

                if (cmbNumeroHD.SelectedIndex != -1)
                    numeroHD = cmbNumeroHD.SelectedValue.ToString();

                BLLHD bllHD = new BLLHD();
                List<HD> lista = new List<HD>();

                if (_usuario.PRONTUARIO != null)
                {
                    int localidade = _usuario.PRONTUARIO != null ? _usuario.FUNCIONARIOS.localidade.Value : 0;

                    lista = bllHD.GetHDs("").Where(l => (l.LOCAL == null || l.LOCAL.Value == localidade) || (l.MOVIMENTACAO_HD.Where(o => !o.DATA_CHEGADA.HasValue && o.LOCAL_DESTINO == localidade).Count() > 0)).AsQueryable().ToList();
                }
                else
                {
                    lista = bllHD.GetHDs("");
                }

                if (numeroHD != "")
                    lista = lista.Where(l => l.NUMERO_HD == numeroHD).AsQueryable().ToList();

                if (cmbStatus.SelectedIndex != 0)
                {
                    string status = cmbStatus.SelectedIndex == 1 ? "ENVIADO" : "RECEBIDO";
                    lista = lista.Where(l => l.STATUS == status).AsQueryable().ToList();
                }

                BLLMovimentacaoHD bllMovimentacao = new BLLMovimentacaoHD();

                if (lista.Count > 0)
                {
                    dgv.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_HD,
                        l.NUMERO_SERIE,
                        STATUS = l.STATUS == "ENVIADO" ? l.STATUS + " PARA " + bllMovimentacao.GetMovimentacoesHD(l.NUMERO_HD, null, null, 0).Where(k => !k.DATA_CHEGADA.HasValue).FirstOrDefault().LOCALIDADE.DESCRICAO : l.STATUS == "RECEBIDO" ? l.STATUS + " DE " + bllMovimentacao.GetMovimentacoesHD(l.NUMERO_HD, null, null, 0).Where(k => k.DATA_CHEGADA.HasValue).LastOrDefault().LOCALIDADE1.DESCRICAO : l.STATUS
                    }).AsQueryable().ToList();
                    dgv.Columns[0].HeaderText = "Número do HD";
                    dgv.Columns[1].HeaderText = "Número de Série";
                    dgv.Columns[2].HeaderText = "Status";
                }
                else
                {
                    dgv.DataSource = null;
                    MessageBox.Show("Não há HDs para a pesquisa", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void frmBuscarMovimentacaoHD_Load(object sender, EventArgs e)
        {
            cmbNumeroHD.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
            CarregarHDs();
        }
    }
}
