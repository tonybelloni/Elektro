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

namespace Elektro.Formularios
{
    public partial class frmAnalisarOcorrencias : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmAnalisarOcorrencias()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarOcorrencias frmBuscar = new frmBuscarOcorrencias(dataGridView1);
            frmBuscar.ShowDialog();
        }

        public void Pesquisar()
        {
            try
            {
                BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                BLLEquipes bllEquipe = new BLLEquipes();
                var ocorrencias = bllRegistroOcorrencia.GetRegistrosOcorrencias().ToList();
                var lista = ocorrencias.Select(l => new
                {
                    l.SORTEADOS.COD_SORTEIO,
                    l.CODIGO_REGISTRO_OCORRENCIA,
                    bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).SUPERVISAO1.DESCRICAO,
                    l.SIGLA_EQUIPE,
                    l.SORTEADOS.USUARIO_VISUALIZACAO,
                    l.DATA_INICIAL,
                    l.DATA_FINAL,
                    VALIDADO = l.DATA_VALIDACAO.HasValue ? "S" : "N",
                    bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                    ATIVIDADE = l.ATIVIDADES.DESCRICAO,
                    TIPO_OCORRENCIA = l.TIPOS_OCORRENCIAS.DESCRICAO,
                    GRAVIDADE = l.CODIGO_SEVERIDADE == 1 ? "Moderado" : l.CODIGO_SEVERIDADE == 2 ? "Grave" : l.CODIGO_SEVERIDADE == 3 ? "Intolerável" : l.CODIGO_SEVERIDADE == 4 ? "Positivo" : "Não Posicionamento",
                    l.OBSERVACAO
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Sorteio";
                    dataGridView1.Columns[1].HeaderText = "Ocorrência";
                    dataGridView1.Columns[2].HeaderText = "Supervisão";
                    dataGridView1.Columns[3].HeaderText = "Equipe";
                    dataGridView1.Columns[4].HeaderText = "Técnico";
                    dataGridView1.Columns[5].HeaderText = "Data Inicial";
                    dataGridView1.Columns[6].HeaderText = "Data Final";
                    dataGridView1.Columns[7].HeaderText = "Validado";
                    dataGridView1.Columns[8].HeaderText = "Atividade";
                    dataGridView1.Columns[9].HeaderText = "Atividade Executada";
                    dataGridView1.Columns[10].HeaderText = "Classificação";
                    dataGridView1.Columns[11].HeaderText = "Gravidade";
                    dataGridView1.Columns[12].HeaderText = "Descrição";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma ocorrência encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (currentMouseOverRow >= 0)
            {
                if ( dataGridView1.Rows[currentMouseOverRow].Cells[13].Value.ToString() == "Operacional")
                {
                    int codigo = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString());
                    BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                    REGISTRO_OCORRENCIAS registro = bllRegistroOcorrencia.GetRegistroOcorrencia(codigo);

                    if (e.Button == MouseButtons.Right)
                    {
                        if (registro.DATA_VALIDACAO.HasValue)
                        {
                            ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Visualizar Ocorrência"));
                            m.MenuItems[0].Click += new EventHandler(DownloadVideo);
                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else
                        {
                            ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Visualizar Ocorrência"));
                            m.MenuItems.Add(new MenuItem("Validar"));
                            m.MenuItems[0].Click += new EventHandler(DownloadVideo);
                            m.MenuItems[1].Click += new EventHandler(Validar);
                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                    }
                }
            }
        }

        private void Validar(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString());
                BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                REGISTRO_OCORRENCIAS registro = bllRegistroOcorrencia.GetRegistroOcorrencia(codigo);

                frmValidarOcorrencia frm = new frmValidarOcorrencia(registro);
                frm.Usuario = _usuario;
                frm.ShowDialog();
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadVideo(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString());
                BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                REGISTRO_OCORRENCIAS registro = bllRegistroOcorrencia.GetRegistroOcorrencia(codigo);

                /*string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string pathDownload = System.IO.Path.Combine(pathUser, "Downloads");
                string path = pathDownload + "\\OcorrenciasVideos";
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                BLLParametros bllParametro = new BLLParametros();
                int numero = 1;
                foreach (VIDEOS v in historico.LISTA_VIDEOS.VIDEOS)
                {
                    byte[] video = v.VIDEO;
                    string nome = path + "\\Sorteio" + historico.CODIGO_SORTEIO + "_" + historico.SIGLA_EQUIPE + "_part" + numero + bllParametro.GetParametro().EXTENSAO_VIDEO;
                    System.IO.FileStream fs = new System.IO.FileStream(nome, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    fs.Write(video, 0, video.Length);
                    fs.Close();
                    numero += 1;
                }*/

                frmDownloadOcorrencia frmDownload = new frmDownloadOcorrencia(registro);
                frmDownload.Usuario = _usuario;
                frmDownload.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAnalisarOcorrencias_Load(object sender, EventArgs e)
        {

        }
    }
}