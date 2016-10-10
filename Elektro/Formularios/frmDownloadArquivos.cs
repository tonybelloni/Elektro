using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Utilitarios;
using CamadaControle;
using Modelo;

namespace Elektro.Formularios
{
    public partial class frmDownloadArquivos : Form
    {
        public frmDownloadArquivos()
        {
            InitializeComponent();
        }

        private void frmDownloadArquivos_Load(object sender, EventArgs e)
        {
            try
            {

                ClassesAuxiliares ca = new ClassesAuxiliares();

                cmbOrigem.DataSource = ca.getAvailableDriveLetters();
                cmbDestino.DataSource = ca.getAvailableDriveLetters();
  
                BLLEquipes eq = new BLLEquipes();
                cmbEquipe.DataSource = eq.GetEquipes(null);
                cmbEquipe.ValueMember = "SiglaEquipe";
                cmbEquipe.DisplayMember = "NomeEquipe";
  
                BLLCameras cam = new BLLCameras();
                cmbCamera.DataSource = cam.GetCameras(null);
                cmbCamera.ValueMember = "CodigoCamera";
                cmbCamera.DisplayMember = "CodigoCamera";
  
                BLLVeiculos veic = new BLLVeiculos();
                cmbVeiculo.DataSource = veic.GetVeiculos(null);
                cmbVeiculo.ValueMember = "Placa";
                cmbVeiculo.DisplayMember = "Numero";

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();   
        }

        private void LimparCampos()
        {
            txtMensagem.Text = "";
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            cmbOrigem.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;
            cmbEquipe.SelectedIndex = -1;
            cmbCamera.SelectedIndex = -1;
            cmbVeiculo.SelectedIndex = -1;
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
            if ( (cmbOrigem.SelectedIndex == -1) || (cmbDestino.SelectedIndex == -1) || (cmbEquipe.SelectedIndex == -1) || (cmbVeiculo.SelectedIndex == -1) || (cmbCamera.SelectedIndex == -1))
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
                List<string> arquivos = new List<string>();
                arquivos.Clear();

                arquivos = Directory.GetFiles(cmbOrigem.SelectedItem.ToString(), "*.avi", SearchOption.AllDirectories).ToList<string>();

                if (arquivos.Count < 1)
                {
                    MessageBox.Show("Nenhum arquivo encontrado para cópia!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string dirdestino = String.Format("{0}\\{1}\\{2}\\{3}", cmbDestino.SelectedValue.ToString().Trim(), cmbEquipe.SelectedValue.ToString(), cmbCamera.SelectedValue.ToString(), cmbVeiculo.SelectedValue.ToString());
                    Directory.CreateDirectory(dirdestino);
                    
                    for (int i=0; i < arquivos.Count; i++)
                    {
                       string filedestino = String.Format("{0}\\{1}", dirdestino, Path.GetFileName(arquivos[i]));
                       File.Copy(arquivos[i], filedestino);
                    }
                    StreamWriter sw = new StreamWriter(cmbDestino.SelectedValue.ToString() + "\\info.dat");
                    sw.WriteLine(cmbEquipe.SelectedValue.ToString() + ";" + cmbCamera.SelectedValue.ToString() + ";" + cmbVeiculo.SelectedValue.ToString());
                    sw.Close();
                    MessageBox.Show("Arquivos de vídeo carregados com sucesso !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro - Carga Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LimparCampos();
        }

    }
}
