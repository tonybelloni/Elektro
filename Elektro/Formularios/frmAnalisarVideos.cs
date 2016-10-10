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
    public partial class frmAnalisarVideos : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmAnalisarVideos()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                /*BLLHistoricosDescargas bllHistorico = new BLLHistoricosDescargas();
                var historicos = bllHistorico.GetHistoricosDescargasSorteadosByUser(_usuario.prontuario_usuario);
                var lista = historicos.Select(l => new
                {
                    l.CODIGO_DESCARGA,
                    l.SIGLA_EQUIPE,
                    l.DESCARGAS.DATA_DESCARGA,
                    l.SORTEIOS.USUARIO_REGISTRO,
                    l.DESCARGAS.NUMERO_HD,
                    l.CAMINHO,
                    l.VISUALIZADO,
                    l.CODIGO_HISTORICO
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código Sorteio";
                    dataGridView1.Columns[1].HeaderText = "Equipe";
                    dataGridView1.Columns[2].HeaderText = "Data Descarregamento";
                    dataGridView1.Columns[3].HeaderText = "Usuário Responsável";
                    dataGridView1.Columns[4].HeaderText = "Número HD";
                    dataGridView1.Columns[5].HeaderText = "Diretório do Vídeo no HD";
                    dataGridView1.Columns[6].HeaderText = "Visualizado";
                    dataGridView1.Columns[7].HeaderText = "Código";
                    dataGridView1.Columns[7].Visible = false;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Não foi encontrado nenhum vídeo para análise", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Analisar"));
                m.MenuItems[0].Click += new EventHandler(AnalisarVideos);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void AnalisarVideos(object sender, EventArgs e)
        {
            frmCadastrarOcorrencias frm = new frmCadastrarOcorrencias();
            frm.Processo = 1;
            frm.Usuario = _usuario;
            frm.ShowDialog();
        }

        private void frmAnalisarVideos_Load(object sender, EventArgs e)
        {
            CarregarVideos();
        }

        public void CarregarVideos()
        {
            try
            {
                /*BLLHistoricosDescargas bllHistorico = new BLLHistoricosDescargas();
                var historicos = bllHistorico.GetHistoricosDescargasSorteadosByUser(_usuario.prontuario_usuario).Where(l => l.VISUALIZADO == "N").AsQueryable().ToList();
                var lista = historicos.Select(l => new
                {
                    l.CODIGO_DESCARGA,
                    l.SIGLA_EQUIPE,
                    l.DESCARGAS.DATA_DESCARGA,
                    l.SORTEIOS.USUARIO_REGISTRO,
                    l.DESCARGAS.NUMERO_HD,
                    l.CAMINHO,
                    l.VISUALIZADO,
                    l.CODIGO_HISTORICO
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código Sorteio";
                    dataGridView1.Columns[1].HeaderText = "Equipe";
                    dataGridView1.Columns[2].HeaderText = "Data Descarregamento";
                    dataGridView1.Columns[3].HeaderText = "Usuário Responsável";
                    dataGridView1.Columns[4].HeaderText = "Número HD";
                    dataGridView1.Columns[5].HeaderText = "Diretório do Vídeo no HD";
                    dataGridView1.Columns[6].HeaderText = "Visualizado";
                    dataGridView1.Columns[7].HeaderText = "Código";
                    dataGridView1.Columns[7].Visible = false;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Não foi encontrado nenhum vídeo para análise", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
