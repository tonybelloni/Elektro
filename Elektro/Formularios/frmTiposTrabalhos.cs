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
using Modelo;
using Utilitarios;

namespace Elektro.Formularios
{
    public partial class frmTiposTrabalhos : Form
    {
        private int currentMouseOverRow;

        public frmTiposTrabalhos()
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
                BLLTiposTrabalhos trabalhos = new BLLTiposTrabalhos();
                List<TipoTrabalho> lista = new List<TipoTrabalho>();

                lista = trabalhos.GetTiposTrabalhos(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código do Tipo de Trabalho";
                    dataGridView1.Columns[1].HeaderText = "Descrição do Tipo de Trabalho";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum tipo de trabalho encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroTiposTrabalhos trabalhos = new frmCadastroTiposTrabalhos();
            trabalhos.Processo = 0;
            trabalhos.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarTiposTrabalho);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarTiposTrabalho(object sender, EventArgs e)
        {
            TipoTrabalho trabalho = new TipoTrabalho();
            trabalho.IdTipoTrabalho = Convert.ToInt16(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value);
            trabalho.DescricaoTipoTrabalho = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();

            frmCadastroTiposTrabalhos frm = new frmCadastroTiposTrabalhos(trabalho);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void frmTiposTrabalhos_Load(object sender, EventArgs e)
        {

        }
    }
}
