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
    public partial class frmGerencias : Form
    {
        private int currentMouseOverRow;

        public frmGerencias()
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
                BLLGerencia bllGerencia = new BLLGerencia();
                List<GERENCIA> gerencias = new List<GERENCIA>();

                gerencias = bllGerencia.GetGerencias(txtPesquisa.Text);

                var lista = gerencias.Select(l => new
                {
                    l.CODIGO_GERENCIA,
                    l.DESCRICAO,
                    REGIAO = l.CODIGO_REGIAO.HasValue ? l.REGIAO.DESCRICAO : ""
                }).OrderBy(l => l.DESCRICAO).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                    dataGridView1.Columns[2].HeaderText = "Região";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma gerência encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroGerencias incluirGerencia = new frmCadastroGerencias();
            incluirGerencia.Processo = 0;
            incluirGerencia.ShowDialog();
        }

        private void EditarGerencia(object sender, EventArgs e)
        {
            BLLRegiao bllRegiao = new BLLRegiao();
            GERENCIA gerencia = new GERENCIA();
            gerencia.CODIGO_GERENCIA = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            gerencia.DESCRICAO = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();
            gerencia.CODIGO_REGIAO = bllRegiao.GetRegiao(dataGridView1.Rows[currentMouseOverRow].Cells[2].Value.ToString()).CODIGO_REGIAO;

            frmCadastroGerencias frm = new frmCadastroGerencias(gerencia);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarGerencia);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }
    }
}
