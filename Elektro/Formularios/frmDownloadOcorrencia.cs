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
using WMPLib;

namespace Elektro.Formularios
{
    public partial class frmDownloadOcorrencia : Form
    {
        private USUARIOS _usuario;
        private REGISTRO_OCORRENCIAS _registro;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmDownloadOcorrencia()
        {
            InitializeComponent();
        }

        public frmDownloadOcorrencia(REGISTRO_OCORRENCIAS registro)
        {
            InitializeComponent();
            _registro = registro;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                backgroundWorker1.CancelAsync();
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDownloadOcorrencia_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            panel1.Visible = false;
            this.Height = 218;

            groupBox1.Text = "Ocorrência N° " + _registro.CODIGO_REGISTRO_OCORRENCIA;
            lblEquipe.Text = "Equipe: " + _registro.SIGLA_EQUIPE;
            lblSorteio.Text = "Sorteio: " + _registro.SORTEADOS.COD_SORTEIO;
            lblQuantidadeVideos.Text = "Quantidade de vídeos: " + _registro.LISTA_VIDEOS.VIDEOS.Count();

            double tamanho = 0;

            foreach (VIDEOS video in _registro.LISTA_VIDEOS.VIDEOS)
            {
                tamanho += video.VIDEO.Length;
            }

            tamanho = tamanho / 1024 / 1024;
            lblTempoTotal.Text = "Tamanho total: " + Math.Round(tamanho, 2) + " MB";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            label1.Visible = true;
            panel1.Visible = true;
            this.Height = 292;
            lblPorcentagem.Text = "0%";

            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = System.IO.Path.Combine(pathUser, "Downloads");
            string path = pathDownload + "\\OcorrenciasVideos";
            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
                System.IO.Directory.CreateDirectory(path);
            }
            else
                System.IO.Directory.CreateDirectory(path);
            
            int numero = 1;
            int total = _registro.LISTA_VIDEOS.VIDEOS.Count;
            foreach (VIDEOS v in _registro.LISTA_VIDEOS.VIDEOS)
            {
                byte[] video = v.VIDEO;
                string nome = path + "\\Sorteio" + _registro.SORTEADOS.COD_SORTEIO + "_" + _registro.SIGLA_EQUIPE + "_part" + numero + ".avi";
                System.IO.FileStream fs = new System.IO.FileStream(nome, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                fs.Write(video, 0, video.Length);
                fs.Close();

                double porcentagem = (numero / total) * 100;
                backgroundWorker1.ReportProgress((int)porcentagem);
                numero += 1;
            }

            backgroundWorker1.ReportProgress(100);
            this.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPorcentagem.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void frmDownloadOcorrencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = System.IO.Path.Combine(pathUser, "Downloads");
            string path = pathDownload + "\\OcorrenciasVideos";
            if (System.IO.Directory.Exists(path))
            {
                frmPlayer frm = new frmPlayer();
                frm.ShowDialog();
            }
        }
    }
}
