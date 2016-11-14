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
    public partial class frmFalhasEventosProcessos : Form
    {
        private int currentMouseOverRow;

        public frmFalhasEventosProcessos()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroFalhaEventoProcesso frm = new frmCadastroFalhaEventoProcesso();
            frm.Processo = 0;
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLFalhasEventosProcessos bllFalha = new BLLFalhasEventosProcessos();
                List<FALHAS_EVENTOS_PROCESSOS> lista = bllFalha.GetFalhasEventos(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                    dataGridView1.Columns[2].Visible = false;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma falha de evento de processo", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                m.MenuItems[0].Click += new EventHandler(EditarFalhaEventoProcesso);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarFalhaEventoProcesso(object sender, EventArgs e)
        {
            BLLFalhasEventosProcessos bllFalha = new BLLFalhasEventosProcessos();
            FALHAS_EVENTOS_PROCESSOS falha = bllFalha.GetFalhaEvento(Convert.ToInt16(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value));

            frmCadastroFalhaEventoProcesso frm = new frmCadastroFalhaEventoProcesso(falha);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
