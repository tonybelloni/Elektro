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
using Microsoft.Reporting.WinForms;

namespace Elektro.Formularios.Relatorios
{
    public partial class frmNaoConformidadesReport : Form
    {
        private USUARIOS _usuario;
        private string equipe;
        private int regiao;
        private int localidade;
        private int atividade;
        private DateTime? dataInicial;
        private DateTime? dataFinal;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Equipe
        {
            get { return equipe; }
            set { equipe = value; }
        }

        public int Regiao
        {
            get { return regiao; }
            set { regiao = value; }
        }

        public int Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        public int Atividade
        {
            get { return atividade; }
            set { atividade = value; }
        }

        public DateTime? DataInicial
        {
            get { return dataInicial; }
            set { dataInicial = value; }
        }

        public DateTime? DataFinal
        {
            get { return dataFinal; }
            set { dataFinal = value; }
        }

        public frmNaoConformidadesReport()
        {
            InitializeComponent();
        }

        private void frmNaoConformidadesReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.SetParameters(new ReportParameter("prtUsuario", _usuario.prontuario_usuario));
            string periodoInicial = dataInicial != null ? dataInicial.Value.ToShortDateString() : "";
            string periodoFinal = dataFinal != null ? " até " + dataFinal.Value.ToShortDateString() : " até";
            reportViewer1.LocalReport.SetParameters(new ReportParameter("prtPeriodo", periodoInicial + periodoFinal));

            BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
            BLLEquipes bllEquipe = new BLLEquipes();
            List<REGISTRO_OCORRENCIAS> ocorrencias = bllRegistroOcorrencia.GetRegistrosOcorrencias().Where(l => l.CODIGO_ATIVIDADE != 4).AsQueryable().ToList();

            if (dataInicial != null)
                ocorrencias = ocorrencias.Where(l => l.DATA_INICIAL.Value.Date >= dataInicial.Value.Date).AsQueryable().ToList();

            if (dataFinal != null)
                ocorrencias = ocorrencias.Where(l => l.DATA_INICIAL.Value.Date <= dataFinal.Value.Date).AsQueryable().ToList();

            if (equipe != " Todas")
                ocorrencias = ocorrencias.Where(l => l.SIGLA_EQUIPE == equipe).AsQueryable().ToList();

            if (regiao != 0)
            {
                ocorrencias = (from equipes in bllEquipe.GetEquipes("")
                              join o in ocorrencias on equipes.SIGLA_EQUIPE equals o.SIGLA_EQUIPE
                              where equipes.REGIAO == regiao
                              select o).AsQueryable().ToList();

            }

            if (localidade != 0)
            {
                ocorrencias = (from equipes in bllEquipe.GetEquipes("")
                               join o in ocorrencias on equipes.SIGLA_EQUIPE equals o.SIGLA_EQUIPE
                               where equipes.LOCALIDADE == localidade
                               select o).AsQueryable().ToList();

            }

            if (atividade != 0)
                ocorrencias = ocorrencias.Where(l => l.CODIGO_ATIVIDADE == atividade).AsQueryable().ToList();

            var lista = ocorrencias.Select(l => new
            {
                EQUIPE = l.SIGLA_EQUIPE,
                LOCALIDADE = bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).LOCALIDADE1.DESCRICAO,
                REGIAO = bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).REGIAO1.DESCRICAO,
                DATA = l.DATA_INICIAL.Value.ToShortDateString(),
                NAO_CONFORMIDADE = l.TIPOS_OCORRENCIAS.DESCRICAO,
                ATIVIDADE = l.ATIVIDADES.DESCRICAO,
                DESCRICAO = l.OBSERVACAO,
                SEVERIDADE = l.TIPOS_OCORRENCIAS.GRAVIDADE == 1 ? "Moderado" : l.TIPOS_OCORRENCIAS.GRAVIDADE == 2 ? "Grave" : l.TIPOS_OCORRENCIAS.GRAVIDADE == 3 ? "Intolerável" : "Não Posicionamento"
            }).OrderBy(l => l.EQUIPE).AsQueryable().ToList();

            ReportDataSource ds = new ReportDataSource("DSNaoConformidadeReport", lista);
            reportViewer1.LocalReport.DataSources.Add(ds);

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
