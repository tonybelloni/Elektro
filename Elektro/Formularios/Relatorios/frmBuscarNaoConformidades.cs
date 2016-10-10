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
    public partial class frmBuscarNaoConformidades : Form
    {
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmBuscarNaoConformidades()
        {
            InitializeComponent();
        }

        private void frmBuscarNaoConformidades_Load(object sender, EventArgs e)
        {
            CarregarAtividades();
            CarregarEquipes();
            CarregaRegioes();
            cmbLocalidade.SelectedIndex = 0;
            txtDataInicial.Text = "";
            txtDataFinal.Text = "";
        }

        public void CarregarAtividades()
        {
            BLLAtividades bllAtividade = new BLLAtividades();
            List<ATIVIDADES> atividades = bllAtividade.GetAtividades("").OrderBy(l => l.DESCRICAO).ToList();

            ATIVIDADES atividade = new ATIVIDADES();
            atividade.CODIGO_ATIVIDADE = 0;
            atividade.DESCRICAO = " Todas";
            atividades.Add(atividade);

            cmbAtividade.DataSource = null;
            cmbAtividade.DataSource = atividades;
            cmbAtividade.DisplayMember = "DESCRICAO";
            cmbAtividade.ValueMember = "CODIGO_ATIVIDADE";
            cmbAtividade.SelectedValue = 0;
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

        public void CarregaLocalidades(int codigo)
        {
            BLLLocalidade bllLocalidade = new BLLLocalidade();
            List<LOCALIDADE> localidades = new List<LOCALIDADE>();

            localidades = bllLocalidade.GetLocalidadesByRegiao(codigo);

            LOCALIDADE localidade = new LOCALIDADE();
            localidade.CODIGO_LOCALIDADE = 0;
            localidade.DESCRICAO = " Todas";
            localidades.Add(localidade);

            cmbLocalidade.DataSource = localidades.OrderBy(l => l.DESCRICAO).ToList();
            cmbLocalidade.DisplayMember = "DESCRICAO";
            cmbLocalidade.ValueMember = "CODIGO_LOCALIDADE";
            cmbLocalidade.SelectedValue = 0;
        }

        private void cmbRegiao_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbRegiao.SelectedIndex != -1)
            {
                CarregaLocalidades(Convert.ToInt32(cmbRegiao.SelectedValue));
            }
            else
            {
                cmbLocalidade.DataSource = null;
                cmbLocalidade.SelectedIndex = -1;
            }
        }

        public void LimparDados()
        {
            cmbAtividade.SelectedValue = 0;
            cmbEquipe.SelectedValue = " Todas";
            cmbRegiao.SelectedValue = 0;
            cmbLocalidade.SelectedValue = 0;
            txtDataInicial.Text = "";
            txtDataFinal.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparDados();
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
                int atividade = Convert.ToInt32(cmbAtividade.SelectedValue);
                DateTime? dataInicial = txtDataInicial.Text != "  /  /" ? Convert.ToDateTime(txtDataInicial.Text) : new Nullable<DateTime>();
                DateTime? dataFinal = txtDataFinal.Text != "  /  /" ? Convert.ToDateTime(txtDataFinal.Text) : new Nullable<DateTime>();

                if (dataInicial > dataFinal)
                    throw new Exception("Data inicial deve ser menor que data final");

                frmNaoConformidadesReport frm = new frmNaoConformidadesReport();
                frm.Usuario = _usuario;
                frm.Equipe = equipe;
                frm.Regiao = regiao;
                frm.Localidade = localidade;
                frm.Atividade = atividade;
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
