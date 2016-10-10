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

namespace Elektro.Formularios.Relatorios
{
    public partial class frmBuscarVideosAnalisados : Form
    {
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmBuscarVideosAnalisados()
        {
            InitializeComponent();
        }

        private void chkEquipe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEquipe.Checked)
            {
                cmbEquipe.Enabled = true;
                chkRegiao.Checked = false;
                cmbRegiao.Enabled = false;
                cmbRegiao.SelectedValue = 0;
                chkLocalidade.Checked = false;
                cmbLocalidade.Enabled = false;
                cmbLocalidade.SelectedValue = 0;
            }
        }

        private void chkRegiao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegiao.Checked)
            {
                cmbRegiao.Enabled = true;
                chkEquipe.Checked = false;
                cmbEquipe.Enabled = false;
                cmbEquipe.SelectedValue = " Todas";
                chkLocalidade.Checked = false;
                cmbLocalidade.Enabled = false;
                cmbLocalidade.SelectedValue = 0;
            }
        }

        private void chkLocalidade_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLocalidade.Checked)
            {
                cmbLocalidade.Enabled = true;
                chkEquipe.Checked = false;
                cmbEquipe.Enabled = false;
                cmbEquipe.SelectedValue = " Todas";
                chkRegiao.Checked = false;
                cmbRegiao.Enabled = false;
                cmbRegiao.SelectedValue = 0;
            }
        }

        public void CarregarEquipes()
        {
            BLLEquipes bllEquipes = new BLLEquipes();
            List<EQUIPES> equipes = bllEquipes.GetEquipes("");

            EQUIPES equipe = new EQUIPES();
            equipe.SIGLA_EQUIPE = " Todas";
            equipes.Add(equipe);

            cmbEquipe.DataSource = null;
            cmbEquipe.DataSource = equipes;
            cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
            cmbEquipe.ValueMember = "SIGLA_EQUIPE";
            cmbEquipe.SelectedValue = " Todas";
        }

        public void CarregaRegioes()
        {
            BLLRegiao bllRegiao = new BLLRegiao();
            List<REGIAO> regioes = new List<REGIAO>();

            regioes = bllRegiao.GetRegioes("");

            REGIAO regiao = new REGIAO();
            regiao.CODIGO_REGIAO = 0;
            regiao.DESCRICAO = " Todas";
            regioes.Add(regiao);

            cmbRegiao.DataSource = regioes.OrderBy(l => l.DESCRICAO).ToList();
            cmbRegiao.DisplayMember = "DESCRICAO";
            cmbRegiao.ValueMember = "CODIGO_REGIAO";
            cmbRegiao.SelectedValue = 0;
        }

        public void CarregaLocalidades()
        {
            BLLLocalidade bllLocalidade = new BLLLocalidade();
            List<LOCALIDADE> localidades = new List<LOCALIDADE>();

            localidades = bllLocalidade.GetLocalidades("");

            LOCALIDADE localidade = new LOCALIDADE();
            localidade.CODIGO_LOCALIDADE = 0;
            localidade.DESCRICAO = " Todas";
            localidades.Add(localidade);

            cmbLocalidade.DataSource = localidades.OrderBy(l => l.DESCRICAO).ToList();
            cmbLocalidade.DisplayMember = "DESCRICAO";
            cmbLocalidade.ValueMember = "CODIGO_LOCALIDADE";
            cmbLocalidade.SelectedValue = 0;
        }

        private void frmBuscarVideosFilmados_Load(object sender, EventArgs e)
        {
            chkEquipe.Checked = true;
            CarregaLocalidades();
            CarregaRegioes();
            CarregarEquipes();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        public void GerarRelatorio()
        {
            try
            {
                string equipe = cmbEquipe.SelectedValue.ToString();
                int regiao = Convert.ToInt32(cmbRegiao.SelectedValue);
                int localidade = Convert.ToInt32(cmbLocalidade.SelectedValue);
                DateTime? dataInicial = txtDataInicial.Text != "  /  /" ? Convert.ToDateTime(txtDataInicial.Text) : new Nullable<DateTime>();
                DateTime? dataFinal = txtDataFinal.Text != "  /  /" ? Convert.ToDateTime(txtDataFinal.Text) : new Nullable<DateTime>();

                frmVideosAnalisadosReport frm = new frmVideosAnalisadosReport();
                frm.Usuario = _usuario;
                frm.Equipe = equipe;
                frm.Regiao = regiao;
                frm.Localidade = localidade;
                frm.Tipo = chkEquipe.Checked ? 1 : chkRegiao.Checked ? 2 : 3;
                frm.DataInicial = dataInicial;
                frm.DataFinal = dataFinal;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
