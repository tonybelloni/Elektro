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

                var sorteados = lista.Select(l => new
                {
                    l.SIGLA_EQUIPE,
                    VISUALIZADO = l.VISUALIZADO == "N" ? "Não" : "Sim",
                    QUANTIDADE_REGISTRO_OCORRENCIAS = l.REGISTRO_OCORRENCIAS.Count()
                }).AsQueryable().ToList();

                if (sorteados.Count > 0)
                {
                    dataGridView1.DataSource = sorteados;
                    dataGridView1.Columns[0].HeaderText = "Equipe";
                    dataGridView1.Columns[1].HeaderText = "Visualizado";
                    dataGridView1.Columns[2].HeaderText = "Registros de Ocorrência";
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

                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
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
