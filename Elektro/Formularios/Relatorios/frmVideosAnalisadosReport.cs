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
    public partial class frmVideosAnalisadosReport : Form
    {
        private USUARIOS _usuario;
        private string equipe;
        private int regiao;
        private int localidade;
        private int tipo;
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

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
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

        public frmVideosAnalisadosReport()
        {
            InitializeComponent();
        }

        private void frmVideosAnalisadosReport_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.SetParameters(new ReportParameter("prtUsuario", _usuario.prontuario_usuario));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("prtFiltro", tipo == 1 ? "Equipe" : tipo == 2 ? "Região" : "Localidade"));
                string periodoInicial = dataInicial != null ? dataInicial.Value.ToShortDateString() : "";
                string periodoFinal = dataFinal != null ? " até " + dataFinal.Value.ToShortDateString() : " até";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("prtPeriodo", periodoInicial + periodoFinal));

                BLLRegistroOcorrencia bllRegistro = new BLLRegistroOcorrencia();
                BLLEquipes bllEquipe = new BLLEquipes();
                var ocorrencias = bllRegistro.GetRegistrosOcorrencias();

                if (dataInicial != null)
                    ocorrencias = ocorrencias.Where(l => l.DATA_INICIAL.Value.Date >= dataInicial.Value.Date).AsQueryable().ToList();

                if (dataFinal != null)
                    ocorrencias = ocorrencias.Where(l => l.DATA_INICIAL.Value.Date <= dataFinal.Value.Date).AsQueryable().ToList();

                if (tipo == 1)
                {
                    if (equipe != " Todas")
                        ocorrencias = ocorrencias.Where(l => l.SIGLA_EQUIPE == equipe).AsQueryable().ToList();

                    var lista = ocorrencias.Select(l => new
                    {
                        FILTRO = l.SIGLA_EQUIPE,
                        HORAS = Math.Round((double)(l.LISTA_VIDEOS.CODIGO_LISTA_VIDEOS / 60 / 60), 2),
                        TOTAL = 0
                    }).OrderBy(l => l.FILTRO).AsQueryable().ToList();

                    ReportDataSource ds = new ReportDataSource("DSVideosAnalisadosReport", lista);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                }
                else if (tipo == 2)
                {
                    if (regiao != 0)
                    {
                        ocorrencias = (from equipes in bllEquipe.GetEquipes("")
                                       join o in ocorrencias on equipes.SIGLA_EQUIPE equals o.SIGLA_EQUIPE
                                       where equipes.REGIAO == regiao
                                       select o).AsQueryable().ToList();

                    }

                    var lista = (from o in ocorrencias
                            group o by o.EQUIPES.REGIAO into regiao1
                            select new { FILTRO = regiao1.FirstOrDefault().EQUIPES.REGIAO1.DESCRICAO, HORAS = Math.Round((double)(regiao1.Sum(l => l.LISTA_VIDEOS.TEMPO_TOTAL_VIDEOS) / 60 / 60), 2), TOTAL = 0 }).AsQueryable().ToList();

                    ReportDataSource ds = new ReportDataSource("DSVideosAnalisadosReport", lista);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                }
                else
                {
                    if (localidade != 0)
                    {
                        ocorrencias = (from equipes in bllEquipe.GetEquipes("")
                                       join o in ocorrencias on equipes.SIGLA_EQUIPE equals o.SIGLA_EQUIPE
                                       where equipes.LOCALIDADE == localidade
                                       select o).AsQueryable().ToList();
                    }

                    var lista = (from o in ocorrencias
                             group o by o.EQUIPES.LOCALIDADE into localidade1
                             select new { FILTRO = localidade1.FirstOrDefault().EQUIPES.LOCALIDADE1.DESCRICAO, HORAS = Math.Round((double)(localidade1.Sum(l => l.LISTA_VIDEOS.TEMPO_TOTAL_VIDEOS) / 60 / 60), 2), TOTAL = 0 }).AsQueryable().ToList();

                    ReportDataSource ds = new ReportDataSource("DSVideosAnalisadosReport", lista);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                }

                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
