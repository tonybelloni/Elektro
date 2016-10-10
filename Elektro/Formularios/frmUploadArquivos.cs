using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Utilitarios;

namespace Elektro.Formularios
{
    public partial class frmUploadArquivos : Form
    {
        public frmUploadArquivos()
        {
            InitializeComponent();
        }

        private void frmUploadArquivos_Load(object sender, EventArgs e)
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            cmbOrigem.DataSource = ca.getAvailableDriveLetters();

            LimparCampos();

        }

        private void LimparCampos()
        {
            txtMensagem.Text = "";
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            cmbOrigem.SelectedIndex = -1;
            button1.Enabled = true;
            cmbOrigem.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
                txtMensagem.Text = "Carregando Arquivos. Aguarde....";
                button1.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbOrigem.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
              if ( File.Exists(cmbOrigem.SelectedItem.ToString() + "\\info.dat" ))
              {
                 for (int i=0; i <= 100; i++)
                 {
                    Thread.Sleep(100);
                 }
                 MessageBox.Show("Arquivos de vídeo carregados com sucesso !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
              else
              {
                  MessageBox.Show("Disco não contém imagens válidas !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro - Upload de Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LimparCampos();
        }
    }
}
