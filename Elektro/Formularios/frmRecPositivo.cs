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
    public partial class frmRecPositivo : Form
    {
        private int currentMouseOverRow;

        public frmRecPositivo()
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
                BLLAtividades bllAtividade = new BLLAtividades();
                List<ATIVIDADES> atividades = bllAtividade.GetAtividades(txtPesquisa.Text);

                var lista = atividades.Select(l => new
                {
                    l.CODIGO_ATIVIDADE,
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
                    MessageBox.Show("Nenhuma atividade encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroRecPositivo frm = new frmCadastroRecPositivo();
            frm.Processo = 0;
            frm.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarRecPositivo);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarRecPositivo(object sender, EventArgs e)
        {
            BLLAtividades bllAtividade = new BLLAtividades();
            ATIVIDADES atividade = bllAtividade.GetAtividade(Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value));

            frmCadastroRecPositivo frm = new frmCadastroRecPositivo(atividade);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void frmRecPositivo_Load(object sender, EventArgs e)
        {

        }
    }
}
