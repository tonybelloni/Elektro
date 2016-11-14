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
using Modelo;

namespace Elektro.Formularios
{
    public partial class frmListarVideosSorteados : Form
    {
        private int currentMouseOverRow;
        private int codigoSorteio;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmListarVideosSorteados()
        {
            InitializeComponent();
        }

        public frmListarVideosSorteados(int codigo)
        {
            codigoSorteio = codigo;
            InitializeComponent();
        }

        private void frmListarVideosSorteados_Load(object sender, EventArgs e)
        {
            BLLSorteio bllSorteio = new BLLSorteio();
            SORTEIOS sorteio = bllSorteio.GetSorteio(codigoSorteio);
            this.Text = "Sorteio " + codigoSorteio + " realizado em " + sorteio.DATA_REGISTRO.ToShortDateString() + " por " + sorteio.USUARIO_REGISTRO;
            CarregarListaVideos();
        }

        public void CarregarListaVideos()
        {
            try
            {
                BLLSorteados bllSorteado = new BLLSorteados();
                List<SORTEADOS> lista = bllSorteado.GetSorteados("").Where(l => l.COD_SORTEIO == codigoSorteio).AsQueryable().ToList();

                List<EquipeSorteio> equipes = new List<EquipeSorteio>();

                foreach(SORTEADOS sorteio in lista)
                {
                    EquipeSorteio es = new EquipeSorteio();
                    es.SiglaEquipe = sorteio.SIGLA_EQUIPE;
                    es.Visualizado = sorteio.VISUALIZADO == "N" ? "Não" : "Sim";
                    es.QuantidadeRegistro = sorteio.REGISTRO_OCORRENCIAS.Count();

                    BLLEquipes bllEquipes = new BLLEquipes();
                    EQUIPES eq = bllEquipes.GetEquipeBySigla(sorteio.SIGLA_EQUIPE);

                    es.DescricaoLocalidade = eq.LOCALIDADE1.DESCRICAO;
                    es.DescricaoGerencia = eq.GERENCIA1.DESCRICAO;
                    es.DescricaoRegiao = eq.REGIAO1.DESCRICAO;
                    es.DescricaoSupervisao = eq.SUPERVISAO1.DESCRICAO;

                    equipes.Add(es);
                }

                if (equipes.Count > 0)
                {
                    dataGridView1.DataSource = equipes;
                    dataGridView1.Columns[0].HeaderText = "Equipe";
                    dataGridView1.Columns[1].HeaderText = "Localidade";
                    dataGridView1.Columns[2].HeaderText = "Supervisão";
                    dataGridView1.Columns[3].HeaderText = "Gerência";
                    dataGridView1.Columns[4].HeaderText = "Região";
                    dataGridView1.Columns[5].HeaderText = "Visualizado";
                    dataGridView1.Columns[6].HeaderText = "Registros de Ocorrência";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            /*int codigo = 0;
            try { codigo = Convert.ToInt32(dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Cells[6].Value.ToString()); } catch { };

            if (codigo != 0)
            {
                BLLHistoricosDescargas bllHistorico = new BLLHistoricosDescargas();
                HISTORICOS_DESCARGAS historico = bllHistorico.GetHistoricoDescarga(codigo);

                if (e.Button == MouseButtons.Right)
                {
                    if (historico.VISUALIZADO == "N")
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Informar visualização do vídeo"));
                        m.MenuItems[0].Click += new EventHandler(InformarVisualizacao);
                        currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                }
            }*/
        }

        public void InformarVisualizacao(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Deseja realmente informar que esse vídeo foi visualizado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CarregarListaVideos();

                    MessageBox.Show("Informação de visualização salva com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application XcelApp = null;

            try { XcelApp = new Microsoft.Office.Interop.Excel.Application(); } catch { MessageBox.Show("É necessário ter o Microsoft Office Excel instalado no computador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (dataGridView1.Rows.Count > 0 && XcelApp != null)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    int row = 1;
                    int column = 1;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        XcelApp.Cells[row, column] = dataGridView1.Columns[i].HeaderText;
                        column++;
                    }

                    row = 2;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        column = 1;
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            XcelApp.Cells[row, column] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            column++;
                        }
                        row++;
                    }

                    XcelApp.Columns.AutoFit();
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    XcelApp.Quit();
                }
            }
        }
    }
}
