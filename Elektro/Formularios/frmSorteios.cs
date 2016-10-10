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
    public partial class frmSorteios : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmSorteios()
        {
            InitializeComponent();
        }

        private void frmSorteios_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        public void Pesquisar()
        {
            try
            {
                BLLSorteio bllSorteio = new BLLSorteio();
                BLLSorteados bllSorteados = new BLLSorteados();
                var sorteios = bllSorteio.GetSorteios();
                var lista = sorteios.Select(l => new
                {
                    l.COD_SORTEIO,
                    l.DATA_REGISTRO,
                    l.USUARIO_REGISTRO,
                    QUANTIDADE = l.SORTEADOS.Count
                }).AsQueryable().ToList();

                if (sorteios.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código Sorteio";
                    dataGridView1.Columns[1].HeaderText = "Data Sorteio";
                    dataGridView1.Columns[2].HeaderText = "Usuário Responsável";
                    dataGridView1.Columns[3].HeaderText = "Quantidade de equipes sorteadas";
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
            int codigo = 0;
            try { codigo = Convert.ToInt32(dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString()); } catch { };

            if (codigo != 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Listar Equipes Sorteadas"));
                    m.MenuItems[0].Click += new EventHandler(ListarVideos);
                    currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }

        private void ListarVideos(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            frmListarVideosSorteados frm = new frmListarVideosSorteados(codigo);
            frm.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente criar um sorteio?", "Sorteio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            try
            {
                if (result == DialogResult.Yes)
                {
                    BLLEquipes bllEquipe = new BLLEquipes();
                    List<EQUIPES> equipesDisponiveis = bllEquipe.GetEquipes("").Where(l => l.CODIGO_CAMERA != null && l.PLACA_VEICULO != null).AsQueryable().ToList();

                    if (equipesDisponiveis.Count == 0)
                        throw new Exception("Não existem equipes disponíveis para o sorteio");

                    List<EQUIPES> equipesLista1 = new List<EQUIPES>();
                    List<EQUIPES> equipesLista2 = new List<EQUIPES>();
                    List<EQUIPES> equipesLista3 = new List<EQUIPES>();
                    List<EQUIPES> equipesSorteadas = new List<EQUIPES>();

                    foreach (EQUIPES equipe in equipesDisponiveis)
                    {
                        if (equipe.REGISTRO_OCORRENCIAS.Count() > 0 && (equipe.REGISTRO_OCORRENCIAS.LastOrDefault().CODIGO_SEVERIDADE == 2 || equipe.REGISTRO_OCORRENCIAS.LastOrDefault().CODIGO_SEVERIDADE == 3))
                        {
                            equipesLista1.Add(equipe);
                            equipesDisponiveis.Remove(equipe);
                        }

                        if (equipesLista1.Count >= 30)
                            break;
                    }

                    foreach (EQUIPES equipe in equipesDisponiveis)
                    {
                        if (equipe.REGISTRO_OCORRENCIAS.Count() > 0 && equipe.REGISTRO_OCORRENCIAS.LastOrDefault().CODIGO_SEVERIDADE == 5)
                        {
                            equipesLista2.Add(equipe);
                            equipesDisponiveis.Remove(equipe);
                        }

                        if (equipesLista2.Count >= 30)
                            break;
                    }

                    int contador = equipesLista1.Count + equipesLista2.Count;
                    contador = 150 - contador;

                    equipesSorteadas.AddRange(equipesLista1);
                    equipesSorteadas.AddRange(equipesLista2);

                    equipesLista3.AddRange(equipesDisponiveis.Take(contador));
                    equipesSorteadas.AddRange(equipesLista3);

                    foreach (EQUIPES equipe in equipesLista3)
                    {
                        equipesDisponiveis.Remove(equipe);
                    }

                    frmConfirmarSorteio frm = new frmConfirmarSorteio(equipesSorteadas, equipesDisponiveis);
                    frm.Usuario = _usuario;
                    frm.ShowDialog();
                }
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarSorteios frmBuscar = new frmBuscarSorteios(dataGridView1);
            frmBuscar.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
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
