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
    public partial class frmSupervisao : Form
    {
        private int currentMouseOverRow;

        public frmSupervisao()
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
                BLLSupervisao bllSupervisao = new BLLSupervisao();
                List<SUPERVISAO> supervisoes = new List<SUPERVISAO>();

                supervisoes = bllSupervisao.GetSupervisoes(txtPesquisa.Text);

                var lista = supervisoes.Select(l => new
                {
                    l.CODIGO_SUPERVISAO,
                    l.DESCRICAO,
                    GERENCIA = l.CODIGO_GERENCIA.HasValue ? l.GERENCIA.DESCRICAO : ""
                }).OrderBy(l => l.DESCRICAO).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                    dataGridView1.Columns[2].HeaderText = "Gerência";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma supervisão encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarSupervisao(object sender, EventArgs e)
        {
            BLLGerencia bllGerencia = new BLLGerencia();
            SUPERVISAO supervisao = new SUPERVISAO();
            supervisao.CODIGO_SUPERVISAO = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            supervisao.DESCRICAO = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();
            supervisao.CODIGO_GERENCIA = bllGerencia.GetGerencia(dataGridView1.Rows[currentMouseOverRow].Cells[2].Value.ToString()).CODIGO_GERENCIA;

            frmCadastroSupervisao frm = new frmCadastroSupervisao(supervisao);
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
                m.MenuItems[0].Click += new EventHandler(EditarSupervisao);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroSupervisao incluirSupervisao = new frmCadastroSupervisao();
            incluirSupervisao.Processo = 0;
            incluirSupervisao.ShowDialog();
        }
    }
}
