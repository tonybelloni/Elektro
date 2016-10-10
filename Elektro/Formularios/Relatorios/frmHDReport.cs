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
    public partial class frmHDReport : Form
    {
        private USUARIOS _usuario;
        private int codigo;
        private int status;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public frmHDReport()
        {
            InitializeComponent();
        }

        private void frmHDReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.SetParameters(new ReportParameter("prtUsuario", _usuario.prontuario_usuario));

            BLLLocalidade bllLocalidade = new BLLLocalidade();
            BLLHD bllHD = new BLLHD();
            List<HD> hds = bllHD.GetHDs("");

            if (codigo != 0)
                hds = hds.Where(l => l.NUMERO_HD == codigo.ToString()).AsQueryable().ToList();

            if (status == 1)
                hds = hds.Where(l => l.STATUS == "ENVIADO").AsQueryable().ToList();
            else if (status == 2)
                hds = hds.Where(l => l.STATUS == "ESTOQUE").AsQueryable().ToList();
            else if (status == 3)
                hds = hds.Where(l => l.STATUS == "RECEBIDO").AsQueryable().ToList();

            var lista = hds.Select(l => new
            {
                NUMERO_HD = l.NUMERO_HD,
                STATUS = l.STATUS,
                LOCALIZACAO = l.LOCAL.HasValue ? bllLocalidade.GetLocalidade(l.LOCAL.Value).DESCRICAO : ""
            }).AsQueryable().ToList();

            ReportDataSource ds = new ReportDataSource("DSHDStatus", lista);
            reportViewer1.LocalReport.DataSources.Add(ds);

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
