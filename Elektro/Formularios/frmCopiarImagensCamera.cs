using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios;
using System.IO;
using System.Xml;
using CamadaControle;
using CamadaDados;
using WMPLib;

namespace Elektro.Formularios
{
    public partial class frmCopiarImagensCamera : Form
    {
        private double tempoTotal = 0;
        public frmCopiarImagensCamera()
        {
            InitializeComponent();
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
            txtCamera.Text = "";
            txtVeiculo.Text = "";
            cmbEquipe.SelectedIndex = -1;
            button1.Enabled = true;
            cmbOrigem.Focus();
        }

        private void frmCopiarImagensCamera_Load(object sender, EventArgs e)
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();

            cmbOrigem.DataSource = ca.getAvailableDriveLetters();
            cmbDestino.DataSource = ca.getAvailableDriveLetters();
            cmbOrigem.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;

            txtCamera.Enabled = false;
            txtVeiculo.Enabled = false;
            
            CarregarEquipes();

            LimparCampos();
        }

        private bool ValidarCampos()
        {
            if ((cmbOrigem.SelectedIndex == -1) || (cmbDestino.SelectedIndex == -1) || (cmbEquipe.SelectedIndex == -1))
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
                double total = 0;
                
                foreach(string arquivo in arquivos)
                {
                    FileInfo tamanho = new FileInfo(arquivo);
                    total += tamanho.Length;
                }

                if (total != 0)
                    total = total / 1024 / 1024;

                if (arquivos.Count < 1)
                {
                    MessageBox.Show("Nenhum arquivo encontrado para cópia!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    double livre = GetEspacoEmDiscoDestino();
                    if (total > livre)
                    {
                        MessageBox.Show("Espaço insuficiente para cópia!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string dirdestino = String.Format("{0}\\{1}\\{2}\\{3}", cmbDestino.SelectedValue.ToString().Trim(), txtCamera.Text, txtVeiculo.Text, cmbEquipe.SelectedValue.ToString());
                        Directory.CreateDirectory(dirdestino);

                        for (int i = 0; i < arquivos.Count; i++)
                        {
                            string filedestino = String.Format("{0}\\{1}", dirdestino, Path.GetFileName(arquivos[i]));
                            File.Copy(arquivos[i], filedestino);

                            WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();
                            IWMPMedia mediainfo = wmp.newMedia(arquivos[i]);
                            tempoTotal += mediainfo.duration;
                        }
                        StreamWriter sw = new StreamWriter(cmbDestino.SelectedValue.ToString() + "\\info.dat");
                        sw.WriteLine(txtCamera.Text + ";" + txtVeiculo.Text + ";" + cmbEquipe.SelectedValue.ToString());
                        sw.Close();
                        CriarXML();
                        MessageBox.Show("Arquivos de vídeo carregados com sucesso !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro - Carga Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarXML()
        {
            int verifica = 0;
            List<Informacoes> informacoes = new List<Informacoes>();
            try
            {
                XmlTextReader arquivo = new XmlTextReader(string.Format("{0}\\info.xml", cmbDestino.SelectedValue.ToString()));
                informacoes = LerXML(arquivo);
                verifica = 1;
            }
            catch { }

            if (verifica == 0)
            {
                XmlTextWriter writer = new XmlTextWriter(string.Format("{0}\\info.xml", cmbDestino.SelectedValue.ToString()), null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("imagens");
                writer.WriteStartElement("imagem");
                writer.WriteElementString("camera", txtCamera.Text);
                writer.WriteElementString("equipe", cmbEquipe.SelectedValue.ToString());
                writer.WriteElementString("veiculo", txtVeiculo.Text);
                writer.WriteElementString("caminho", String.Format("{0}\\{1}\\{2}", txtCamera.Text, txtVeiculo.Text, cmbEquipe.SelectedValue.ToString()));
                writer.WriteElementString("tempoGravacao", tempoTotal.ToString());
                writer.WriteElementString("descarregado", "N");
                writer.WriteEndElement();
                writer.WriteFullEndElement();
                writer.Close();
            }
            else
            {
                XmlTextWriter writer = new XmlTextWriter(string.Format("{0}\\info.xml", cmbDestino.SelectedValue.ToString()), null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("imagens");
                writer.WriteStartElement("imagem");
                writer.WriteElementString("camera", txtCamera.Text);
                writer.WriteElementString("equipe", cmbEquipe.SelectedValue.ToString());
                writer.WriteElementString("veiculo", txtCamera.Text);
                writer.WriteElementString("caminho", String.Format("{0}\\{1}\\{2}", txtCamera.Text, txtVeiculo.Text, cmbEquipe.SelectedValue.ToString()));
                writer.WriteElementString("tempoGravacao", tempoTotal.ToString());
                writer.WriteElementString("descarregado", "N");
                writer.WriteEndElement();
                foreach(Informacoes info in informacoes)
                {
                    writer.WriteStartElement("imagem");
                    writer.WriteElementString("camera", info.camera);
                    writer.WriteElementString("equipe", info.equipe);
                    writer.WriteElementString("veiculo", info.veiculo);
                    writer.WriteElementString("caminho", info.caminho);
                    writer.WriteElementString("tempoGravacao", info.tempoGravacao.ToString());
                    writer.WriteElementString("descarregado", "N");
                    writer.WriteEndElement();
                }
                writer.WriteFullEndElement();
                writer.Close();
            }
        }

        public List<Informacoes> LerXML(XmlTextReader arquivo)
        {
            List<Informacoes> informacoes = new List<Informacoes>();
            Informacoes info = new Informacoes();
            while (arquivo.Read())
            {
                if (arquivo.NodeType == XmlNodeType.Element && arquivo.Name == "camera")
                {
                    info = new Informacoes();
                    info.camera = (arquivo.ReadString());
                }
                if (arquivo.NodeType == XmlNodeType.Element && arquivo.Name == "equipe")
                    info.equipe = (arquivo.ReadString());
                if (arquivo.NodeType == XmlNodeType.Element && arquivo.Name == "veiculo")
                {
                    info.veiculo = (arquivo.ReadString());
                }
                if (arquivo.NodeType == XmlNodeType.Element && arquivo.Name == "caminho")
                {
                    info.caminho = (arquivo.ReadString());
                }
                if (arquivo.NodeType == XmlNodeType.Element && arquivo.Name == "tempoGravacao")
                {
                    info.tempoGravacao = (Convert.ToInt32(arquivo.ReadString()));
                    informacoes.Add(info);
                }
            }
            arquivo.Close();
            return informacoes;
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

        private void CarregarEquipes()
        {
            BLLEquipes eq = new BLLEquipes();
            cmbEquipe.DataSource = eq.GetEquipesComAlocacaoCamera();
            cmbEquipe.ValueMember = "SIGLA_EQUIPE";
            cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
        }

        public double GetEspacoEmDiscoDestino()
        {
            string unidade = cmbDestino.SelectedValue.ToString().Split('\\')[0];
            ManagementObject disk = new ManagementObject(string.Format(@"win32_logicaldisk.deviceid=""{0}""", unidade));
            disk.Get();
            double livre = Convert.ToDouble(disk["FreeSpace"]);
            livre = livre / 1024 / 102;
            return livre;
        }

        private void cmbEquipe_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbEquipe.SelectedIndex != -1)
            {
                BLLEquipes bllEquipe = new BLLEquipes();
                EQUIPES equipe = bllEquipe.GetEquipeBySigla(cmbEquipe.SelectedValue.ToString());

                txtCamera.Text = equipe.MOVIMENTACAO_CAMERA.LastOrDefault().CODIGO_CAMERA;
                txtVeiculo.Text = equipe.PLACA_VEICULO;
            }
        }
    }

    public class Informacoes
    {
        public string camera { get; set; }
        public string equipe { get; set; }
        public string veiculo { get; set; }
        public string caminho { get; set; }
        public DateTime horarioInicial { get; set; }
        public DateTime horarioFinal { get; set; }
        public double tempoGravacao { get; set; }
    }
}
