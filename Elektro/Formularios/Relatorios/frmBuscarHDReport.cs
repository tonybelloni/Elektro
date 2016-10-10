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
    public partial class frmBuscarHDReport : Form
    {
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmBuscarHDReport()
        {
            InitializeComponent();
        }

        private void frmHDReport_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigoDescarga.Text = "";
            cmbStatus.SelectedIndex = 0;
        }

        public void GerarRelatorio()
        {
            try
            {
                int codigo = txtCodigoDescarga.Text != "" ? Convert.ToInt32(txtCodigoDescarga.Text) : 0;
                int status = cmbStatus.SelectedIndex;

                frmHDReport frm = new frmHDReport();
                frm.Usuario = _usuario;
                frm.Codigo = codigo;
                frm.Status = status;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }
    }
}
