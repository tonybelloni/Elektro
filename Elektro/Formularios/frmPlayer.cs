using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using WMPLib;

namespace Elektro.Formularios
{
    public partial class frmPlayer : Form
    {
        public frmPlayer()
        {
            InitializeComponent();
        }

        private void frmPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.DisplayMember = "nome";
                string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string pathDownload = System.IO.Path.Combine(pathUser, "Downloads");
                string path = pathDownload + "\\OcorrenciasVideos";
                if (!System.IO.Directory.Exists(path))
                    throw new Exception("Caminho dos vídeos não encontrado!");

                string[] videos = System.IO.Directory.GetFiles(path);
                if (videos.Count() == 0 || videos == null)
                    throw new Exception("Não há vídeos disponíveis para visualização!");

                for (int i = 0; i < videos.Length; i++)
                {
                    Video video = new Video();
                    video.nome = videos[i].Split('\\')[5];
                    video.path = videos[i];
                    listBox1.Items.Add(video);
                }

                listBox1.SelectedIndex = 0;
                Video v = (Video)listBox1.Items[0];
                axWindowsMediaPlayer1.URL = v.path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Video video = (Video)listBox1.SelectedItem;
            axWindowsMediaPlayer1.URL = video.path;
        }

        private void frmPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.close();
                string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string pathDownload = System.IO.Path.Combine(pathUser, "Downloads");
                string path = pathDownload + "\\OcorrenciasVideos";
                System.IO.Directory.Delete(path, true);
            }
            catch { }
        }
    }

    class Video
    {
        public string nome { get; set; }
        public string path { get; set; }
    }
}
