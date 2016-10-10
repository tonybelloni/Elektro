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
using CamadaControle;
using CamadaDados;
using WMPLib;

namespace Elektro.Formularios
{
    public partial class frmCadastrarOcorrencias : Form
    {
        public int Processo { get; set; }
        private CamadaDados.USUARIOS _usuario;
        private string diretorio = "";
        private List<string> videos = new List<string>();
        private int erro = 0;
        private double tempoAnalisado = 0;
        private SORTEADOS _sorteado;
        private string siglaEquipe;
        private string numeroHD;
        private string tipoOcorrencia;

        public CamadaDados.USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmCadastrarOcorrencias()
        {
            InitializeComponent();
        }

        public frmCadastrarOcorrencias(string dir)
        {
            InitializeComponent();
            diretorio = dir;
        }

        public frmCadastrarOcorrencias(SORTEADOS sorteado)
        {
            InitializeComponent();
            _sorteado = sorteado;
        }

        private void frmCadastrarOcorrencias_Load(object sender, EventArgs e)
        {
            try
            {
                cmbNaoConformidade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
                cmbSeveridade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
                CarregarAtividades();
                CarregarNaoConformidades();
                CarregarSorteios();
                CarregarHDs();
                CarregarOcorrenciasProcesso();

                if (_sorteado == null)
                {
                    cmbEquipe.Enabled = false;
                    txtCamera.Enabled = false;
                    txtVeiculo.Enabled = false;
                    cmbHD.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtUsuario.Text = _usuario.prontuario_usuario;
                }
                else
                {
                    BLLEquipes bllEquipe = new BLLEquipes();
                    EQUIPES equipe = bllEquipe.GetEquipeBySigla(_sorteado.SIGLA_EQUIPE);
                    cmbSorteio.Enabled = false;
                    cmbSorteio.SelectedValue = _sorteado.COD_SORTEIO;
                    cmbEquipe.Enabled = false;
                    cmbEquipe.SelectedValue = _sorteado.SIGLA_EQUIPE;
                    txtCamera.Enabled = false;
                    txtCamera.Text = equipe.CODIGO_CAMERA;
                    txtVeiculo.Enabled = false;
                    txtVeiculo.Text = equipe.PLACA_VEICULO;
                    cmbHD.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtUsuario.Text = _usuario.prontuario_usuario;
                }

                //groupBox2.Visible = false;
                //this.Height = 490;

                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;

                btnDeletar.Enabled = false;
                grpProcesso.Enabled = false;
                grpOperacional.Enabled = false;
                lstOcorrencias.DisplayMember = "descricao";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tipoOcorrencia == "Operacional")
            {
                if (ValidarCampos())
                {
                    try
                    {
                        toolStripButton1.Enabled = false;
                        toolStripButton2.Enabled = false;
                        groupBox1.Enabled = false;
                        //        groupBox2.Visible = true;
                        //        this.Height = 567;
                        siglaEquipe = cmbEquipe.SelectedValue.ToString();
                        numeroHD = cmbHD.SelectedValue.ToString();

                        progressBar1.Style = ProgressBarStyle.Marquee;
                        progressBar1.MarqueeAnimationSpeed = 0;

                        backgroundWorker1.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {
                        toolStripButton1.Enabled = true;
                        toolStripButton2.Enabled = true;
                        groupBox1.Enabled = true;
                        //        groupBox2.Visible = false;
                        //this.Height = 490;
                        backgroundWorker1.CancelAsync();
                        progressBar1.Style = ProgressBarStyle.Continuous;
                        progressBar1.MarqueeAnimationSpeed = 0;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (erro == 1)
                        MessageBox.Show("Escolha a equipe para realizar o registro de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (erro == 2)
                        MessageBox.Show("Selecione os vídeos para realizar o registro de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (erro == 3)
                        MessageBox.Show("Selecione o HD para realizar o registro de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Insira ao menos um tipo de ocorrência para realizar o registro de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (ValidarCampos())
                {
                    try
                    {
                        BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                        REGISTRO_OCORRENCIAS registro = new REGISTRO_OCORRENCIAS();
                        registro.COD_SORTEADOS = Convert.ToInt32(txtCodSorteado.Text);
                        registro.SIGLA_EQUIPE = cmbEquipe.SelectedValue.ToString();
                        registro.NUMERO_HD = numeroHD;
                        registro.DATA_INICIAL = Convert.ToDateTime(txtDataInicial.Text);
                        registro.DATA_FINAL = Convert.ToDateTime(txtDataFinal.Text);
                        registro.CODIGO_SEVERIDADE = null;
                        registro.tipo_ocorrencia = tipoOcorrencia;
                        registro.COD_FALHA_EVENTO = (int)cmbOcorrenciasProcesso.SelectedValue;
                        bllRegistroOcorrencia.InserirRegistroOcorrencia(registro);

                        MessageBox.Show("Ocorrência de processo salva com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (erro == 1)
                         MessageBox.Show("Escolha a equipe para realizar o registro de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (erro == 3)
                         MessageBox.Show("Selecione o HD para realizar o registro de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (erro == 5)
                         MessageBox.Show("Selecione um tipo de ocorrência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            bool ret = true;

            if (cmbEquipe.SelectedIndex == -1)
            {
                erro = 1;
                ret = false;
            }
            else if (cmbHD.SelectedIndex == -1)
            {
                erro = 3;
                ret = false;
            }

            if ( tipoOcorrencia == "Processo")
            {
                if (cmbOcorrenciasProcesso.SelectedIndex == -1)
                {
                    erro = 5;
                    ret = false;
                }
            }
            else
            {
                if (lstOcorrencias.Items.Count == 0)
                {
                    erro = 4;
                    ret = false;
                }
                else if (txtVideos.Text == "")
                {
                    erro = 2;
                    ret = false;
                }
            }
            return ret;
        }

        public void LimparCampos()
        {
            cmbSorteio.SelectedIndex = -1;
            cmbEquipe.SelectedIndex = -1;
            cmbEquipe.Enabled = false;
            txtCamera.Text = "";
            txtCamera.Enabled = false;
            txtVeiculo.Text = "";
            txtVeiculo.Enabled = false;
            cmbHD.SelectedIndex = -1;
            cmbHD.Enabled = false;
            cmbNaoConformidade.SelectedIndex = -1;
            cmbAtividade.SelectedIndex = -1;
            lstOcorrencias.Items.Clear();
            txtVideos.Text = "";
            cmbOcorrenciasProcesso.SelectedIndex = -1;
        }

        public void CarregarEquipes(int codSorteio)
        {
            BLLSorteados bllSorteado = new BLLSorteados();
            List<SORTEADOS> equipes = bllSorteado.GetSorteados("").Where(l => l.COD_SORTEIO == codSorteio && l.VISUALIZADO == "N").AsQueryable().ToList();

            cmbEquipe.DataSource = null;
            cmbEquipe.DataSource = equipes;
            cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
            cmbEquipe.ValueMember = "SIGLA_EQUIPE";
            cmbEquipe.SelectedIndex = -1;
        }

        public void CarregarAtividades()
        {
            BLLAtividades bllAtividade = new BLLAtividades();
            List<ATIVIDADES> atividades = bllAtividade.GetAtividades("").OrderBy(l => l.DESCRICAO).ToList();

            cmbAtividade.DataSource = null;
            cmbAtividade.DataSource = atividades;
            cmbAtividade.DisplayMember = "DESCRICAO";
            cmbAtividade.ValueMember = "CODIGO_ATIVIDADE";
            cmbAtividade.SelectedIndex = -1;
        }

        public void CarregarNaoConformidades()
        {
            BLLTiposOcorrencia bllTipoOcorrencia = new BLLTiposOcorrencia();
            cmbNaoConformidade.DataSource = bllTipoOcorrencia.GetTiposOcorrencia("").OrderBy(l => l.DESCRICAO).ToList();
            cmbNaoConformidade.DisplayMember = "DESCRICAO";
            cmbNaoConformidade.ValueMember = "ID_TIPO";
            cmbNaoConformidade.SelectedIndex = -1;
        }

        public void CarregarSorteios()
        {
            BLLSorteio bllSorteio = new BLLSorteio();
            cmbSorteio.DataSource = bllSorteio.GetSorteios().Where(l => l.SORTEADOS.Where(k => k.VISUALIZADO == "N").Count() > 0).AsQueryable().ToList();
            cmbSorteio.DisplayMember = "COD_SORTEIO";
            cmbSorteio.ValueMember = "COD_SORTEIO";
            cmbSorteio.SelectedIndex = -1;
        }

        public void CarregarHDs()
        {
            BLLHD bllHD = new BLLHD();
            cmbHD.DataSource = bllHD.GetHDs("");
            cmbHD.DisplayMember = "NUMERO_HD";
            cmbHD.ValueMember = "NUMERO_HD";
            cmbHD.SelectedIndex = -1;
        }

        public void CarregarOcorrenciasProcesso()
        {
            BLLFalhasEventosProcessos bllFalha = new BLLFalhasEventosProcessos();
            cmbOcorrenciasProcesso.DataSource = bllFalha.GetFalhasEventos("");
            cmbOcorrenciasProcesso.DisplayMember = "DESCRICAO";
            cmbOcorrenciasProcesso.ValueMember = "COD_FALHA_EVENTO";
            cmbOcorrenciasProcesso.SelectedIndex = -1;
        }

        private void cmbEquipe_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbEquipe.SelectedIndex != -1)
            {
                BLLEquipes bllEquipe = new BLLEquipes();
                EQUIPES equipe = bllEquipe.GetEquipeBySigla(cmbEquipe.SelectedValue.ToString());

                txtCamera.Text = equipe.CODIGO_CAMERA;
                txtVeiculo.Text = equipe.PLACA_VEICULO;

                BLLSorteados bllSorteado = new BLLSorteados();
                int codigoSorteio = Convert.ToInt32(cmbSorteio.SelectedValue);
                txtCodSorteado.Text = bllSorteado.GetSorteados("").Where(l => l.COD_SORTEIO == codigoSorteio && l.SIGLA_EQUIPE == equipe.SIGLA_EQUIPE).AsQueryable().FirstOrDefault().COD_SORTEADOS.ToString();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (videos.Count() > 0)
            {
                BLLListaVideos bllLista = new BLLListaVideos();
                LISTA_VIDEOS lista = new LISTA_VIDEOS();
                bllLista.InserirListaVideos(lista);
                
                int i = 1;
                foreach (var v in videos)
                {
                    VIDEOS video;
                    System.IO.FileStream fStream = System.IO.File.OpenRead(v);

                    byte[] contents = new byte[fStream.Length];
                    fStream.Read(contents, 0, (int)fStream.Length);
                    fStream.Close();

                    BLLVideo bllVideo = new BLLVideo();
                    video = new VIDEOS();
                    video.VIDEO = contents;
                    video.CODIGO_LISTA_VIDEOS = lista.CODIGO_LISTA_VIDEOS;
                    bllVideo.InserirVideo(video);

                    System.IO.File.Delete(v);

                    double porcentagem = (i / videos.Count()) * 100;
                    i++;
                }

                foreach (var o in lstOcorrencias.Items)
                {
                    Ocorrencia oc = (Ocorrencia)o;
                    BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                    REGISTRO_OCORRENCIAS registro = new REGISTRO_OCORRENCIAS();
                    registro.COD_SORTEADOS = Convert.ToInt32(txtCodSorteado.Text);
                    registro.COD_LISTA_VIDEOS = lista.CODIGO_LISTA_VIDEOS;
                    registro.SIGLA_EQUIPE = siglaEquipe;
                    registro.NUMERO_HD = numeroHD;
                    registro.CODIGO_TIPO_OCORRENCIA = oc.codigo;
                    registro.CODIGO_ATIVIDADE = oc.atividade;
                    registro.CODIGO_SEVERIDADE = oc.severidade;
                    registro.OBSERVACAO = oc.observacao;
                    registro.DATA_INICIAL = Convert.ToDateTime(txtDataInicial.Text);
                    registro.DATA_FINAL = Convert.ToDateTime(txtDataFinal.Text);
                    registro.tipo_ocorrencia = tipoOcorrencia;
                    bllRegistroOcorrencia.InserirRegistroOcorrencia(registro);
                }

                BLLSorteados bllSorteado = new BLLSorteados();
                bllSorteado.AtualizaParaVisualizado(Convert.ToInt32(txtCodSorteado.Text), numeroHD, _usuario.prontuario_usuario);

                //groupBox2.Visible = false;
                //this.Height = 412;
            }
            else
            {
                throw new Exception("Não foi possível encontrar o vídeo");
            }
        }

        private void cmbNaoConformidade_DrawItem(object sender, DrawItemEventArgs e)
        {
            System.Drawing.Color cor = new System.Drawing.Color();
            Font fonte = cmbNaoConformidade.Font;
            if (e.Index != -1)
            {
                TIPOS_OCORRENCIAS tipo = (TIPOS_OCORRENCIAS)cmbNaoConformidade.Items[e.Index];
                if (tipo.ID_TIPO == 1)
                {
                    cor = Color.Yellow;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (tipo.ID_TIPO == 2)
                {
                    cor = Color.Orange;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (tipo.ID_TIPO == 3)
                {
                    cor = Color.OrangeRed;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (tipo.ID_TIPO == 4)
                {
                    cor = Color.Green;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (e.Index == 5)
                {
                    cor = Color.LightGray;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNaoConformidade.SelectedIndex == -1)
                    throw new Exception("Escolha um tipo de ocorrência");

                if (cmbSeveridade.SelectedIndex == -1)
                    throw new Exception("Escolha o nível de severidade");

                if (cmbAtividade.SelectedIndex == -1)
                    throw new Exception("Escolha uma atividade realizada pela equipe");

                if (txtObservacao.Text == "")
                    throw new Exception("Preencha o campo observação");

                BLLTiposOcorrencia bllTipoOcorrencia = new BLLTiposOcorrencia();
                TIPOS_OCORRENCIAS tipo = bllTipoOcorrencia.GetTipoOcorrencia(Convert.ToInt32(cmbNaoConformidade.SelectedValue));

                Ocorrencia o = new Ocorrencia();
                o.codigo = tipo.ID_TIPO;
                o.descricao = tipo.DESCRICAO;
                o.observacao = txtObservacao.Text;
                o.atividade = Convert.ToInt32(cmbAtividade.SelectedValue);
                o.severidade = Convert.ToInt32(cmbSeveridade.SelectedIndex);

                lstOcorrencias.Items.Add(o);

                cmbNaoConformidade.SelectedIndex = -1;
                cmbAtividade.SelectedIndex = -1;
                cmbSeveridade.SelectedIndex = -1;
                txtObservacao.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                Ocorrencia o = (Ocorrencia)lstOcorrencias.SelectedItem;
                lstOcorrencias.Items.Remove(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstOcorrencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Ocorrencia o = (Ocorrencia)lstOcorrencias.SelectedItem;
                btnDeletar.Enabled = true;
            }
            catch
            {
                btnDeletar.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Selecionar vídeos";
            openFileDialog1.Filter = "Video files |*.avi;";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            DialogResult dialog = openFileDialog1.ShowDialog();

            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string arquivo in openFileDialog1.FileNames)
                {
                    videos.Add(arquivo);
                    txtVideos.Text += arquivo + Environment.NewLine;

                    WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();
                    IWMPMedia mediainfo = wmp.newMedia(arquivo);
                    tempoAnalisado += mediainfo.duration;
                }
            }
        }

        private void cmbSeveridade_DrawItem(object sender, DrawItemEventArgs e)
        {
            System.Drawing.Color cor = new System.Drawing.Color();
            Font fonte = cmbSeveridade.Font;
            if (e.Index == 1)
            {
                cor = Color.Yellow;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Moderado", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 2)
            {
                cor = Color.Orange;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Grave", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 3)
            {
                cor = Color.OrangeRed;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Intolerável", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 4)
            {
                cor = Color.Green;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Positivo", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
        }

        private void cmbSorteio_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSorteio.SelectedIndex != -1)
            {
                CarregarEquipes(Convert.ToInt32(cmbSorteio.SelectedValue));
                cmbEquipe.Enabled = true;
                txtCamera.Text = "";
                txtVeiculo.Text = "";
                cmbHD.Enabled = true;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            MessageBox.Show("Registro de ocorrência salvo com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            grpProcesso.Enabled = false;
            grpOperacional.Enabled = true;
            tipoOcorrencia = "Operacional";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            grpOperacional.Enabled = false;
            grpProcesso.Enabled = true;
            tipoOcorrencia = "Processo";
        }
    }

    class Ocorrencia
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public string observacao { get; set; }
        public int atividade { get; set; }
        public int severidade { get; set; }
    }
}
