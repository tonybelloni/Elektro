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
    public partial class frmBuscarOcorrencias : Form
    {
        private DataGridView dgv;

        public frmBuscarOcorrencias()
        {
            InitializeComponent();
        }

        public frmBuscarOcorrencias(DataGridView dataGrid)
        {
            InitializeComponent();
            dgv = dataGrid;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtSorteio.Text = "";
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
                int codigoSorteio = txtSorteio.Text != "" ? Convert.ToInt32(txtSorteio.Text) : 0;
                string numeroHD = cmbNumeroHD.SelectedIndex != -1 ? cmbNumeroHD.SelectedValue.ToString() : "";
                string equipe = cmbEquipe.SelectedIndex != -1 ? cmbEquipe.SelectedValue.ToString() : "";
                DateTime? dataInicial = txtDataInicial.Text != "  /  /" ? Convert.ToDateTime(txtDataInicial.Text) : new Nullable<DateTime>();
                DateTime? dataFinal = txtDataFinal.Text != "  /  /" ? Convert.ToDateTime(txtDataFinal.Text) : new Nullable<DateTime>();

                if (dataInicial > dataFinal)
                    throw new Exception("Data Inicial não pode ser maior que data final");

                BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                BLLEquipes bllEquipe = new BLLEquipes();
                BLLFalhasEventosProcessos bllFalha = new BLLFalhasEventosProcessos();
                var ocorrencias = bllRegistroOcorrencia.GetRegistrosOcorrencias(codigoSorteio, numeroHD, equipe, dataInicial, dataFinal).ToList();
                
                var lista = ocorrencias.Select(l => new
                {
                    l.SORTEADOS.COD_SORTEIO,
                    l.CODIGO_REGISTRO_OCORRENCIA,
                    bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).SUPERVISAO1.DESCRICAO,
                    l.SIGLA_EQUIPE,
                    l.SORTEADOS.USUARIO_VISUALIZACAO,
                    l.DATA_INICIAL,
                    l.DATA_FINAL,
                    VALIDADO = l.DATA_VALIDACAO.HasValue ? "S" : "N",
                    bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                    ATIVIDADE = l.tipo_ocorrencia == "Operacional" ? l.ATIVIDADES.DESCRICAO : "",
                    TIPO_OCORRENCIA = l.tipo_ocorrencia == " Operacional" ? l.TIPOS_OCORRENCIAS.DESCRICAO : "",
                    GRAVIDADE = l.tipo_ocorrencia == "Processo" ? "" : l.CODIGO_SEVERIDADE == 1 ? "Moderado" : l.CODIGO_SEVERIDADE == 2 ? "Grave" : l.CODIGO_SEVERIDADE == 3 ? "Intolerável" : l.CODIGO_SEVERIDADE == 4 ? "Positivo" : "Não Posicionamento",
                    l.OBSERVACAO,
                    l.tipo_ocorrencia,
                    FALHA = l.tipo_ocorrencia == "Processo" ? bllFalha.GetFalhaEvento((int)l.COD_FALHA_EVENTO).DESCRICAO : ""
                }).AsQueryable().ToList();
                
                if (lista.Count > 0)
                {
                    dgv.DataSource = lista;
                    dgv.Columns[0].HeaderText = "Sorteio";
                    dgv.Columns[1].HeaderText = "Ocorrência";
                    dgv.Columns[2].HeaderText = "Supervisão";
                    dgv.Columns[3].HeaderText = "Equipe";
                    dgv.Columns[4].HeaderText = "Técnico";
                    dgv.Columns[5].HeaderText = "Data Inicial";
                    dgv.Columns[6].HeaderText = "Data Final";
                    dgv.Columns[7].HeaderText = "Validado";
                    dgv.Columns[8].HeaderText = "Atividade";
                    dgv.Columns[9].HeaderText = "Atividade Executada";
                    dgv.Columns[10].HeaderText = "Classificação";
                    dgv.Columns[11].HeaderText = "Gravidade";
                    dgv.Columns[12].HeaderText = "Observação";
                    dgv.Columns[13].HeaderText = "Tipo Ocorrência";
                    dgv.Columns[14].HeaderText = "Descrição Ocorrência Processo";
                }
                else
                {
                    dgv.DataSource = null;
                    MessageBox.Show("Nenhuma ocorrência encontrada!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void frmBuscarOcorrencias_Load(object sender, EventArgs e)
        {
            CarregarEquipes();
            CarregarHDs();
        }
    }
}
