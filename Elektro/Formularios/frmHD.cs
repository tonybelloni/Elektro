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
using Utilitarios;
using CamadaDados;

namespace Elektro.Formularios
{
    public partial class frmHD : Form
    {
        private int currentMouseOverRow;

        public frmHD()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroHD incluirhd = new frmCadastroHD();
            incluirhd.Processo = 0;
            incluirhd.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLHD hds = new BLLHD();
                List<HD> lista = new List<HD>();

                lista = hds.GetHDs(txtPesquisa.Text);

                var discos = lista.Select(l => new
                {
                    l.NUMERO_HD,
                    l.NUMERO_SERIE
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = discos;
                    dataGridView1.Columns[0].HeaderText = "Número HD";
                    dataGridView1.Columns[1].HeaderText = "Número de Série";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum HD Encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                m.MenuItems[0].Click += new EventHandler(EditarHD);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarHD(object sender, EventArgs e)
        {
            HD hd = new HD();
            hd.NUMERO_HD = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
            hd.NUMERO_SERIE = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();

            frmCadastroHD frm = new frmCadastroHD(hd);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
