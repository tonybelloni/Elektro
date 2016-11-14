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
    public partial class frmImportarEscalaCOD : Form
    {
        private USUARIOS _usuario;
        List<ESCALA_COD> escalas = new List<ESCALA_COD>();

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmImportarEscalaCOD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Selecionar vídeos";
            openFileDialog1.Filter = "Todos os arquivos |*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            DialogResult dialog = openFileDialog1.ShowDialog();

            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                txtArquivo.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtArquivo.Text == "")
            {
                MessageBox.Show("Selecione o arquivo de escalas para importação !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmProcessaEscalaCOD frm = new frmProcessaEscalaCOD();
                frm.Arquivo = txtArquivo.Text;
                frm.Usuario = Usuario;
                frm.ShowDialog();
            }

        }

        private void frmImportarEscalaCOD_Load(object sender, EventArgs e)
        {
            txtArquivo.Text = "";
            txtArquivo.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
