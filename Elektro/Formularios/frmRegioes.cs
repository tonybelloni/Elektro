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
    public partial class frmRegioes : Form
    {
        private int currentMouseOverRow;

        public frmRegioes()
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
                BLLRegiao bllRegiao = new BLLRegiao();
                List<REGIAO> regioes = new List<REGIAO>();

                regioes = bllRegiao.GetRegioes(txtPesquisa.Text);

                var lista = regioes.Select(l => new
                {
                    l.CODIGO_REGIAO,
                    l.DESCRICAO
                }).OrderBy(l => l.DESCRICAO).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma região encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarRegiao);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarRegiao(object sender, EventArgs e)
        {
            REGIAO regiao = new REGIAO();
            regiao.CODIGO_REGIAO = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            regiao.DESCRICAO = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();

            frmCadastroRegioes frm = new frmCadastroRegioes(regiao);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroRegioes incluirRegiao = new frmCadastroRegioes();
            incluirRegiao.Processo = 0;
            incluirRegiao.ShowDialog();
        }
    }
}
