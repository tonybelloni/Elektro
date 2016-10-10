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
    public partial class frmEmpresaManutencao : Form
    {
        private int currentMouseOverRow;

        public frmEmpresaManutencao()
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
                BLLEmpresaManutencao bllEmpresa = new BLLEmpresaManutencao();
                List<EMPRESAS> empresas = new List<EMPRESAS>();

                empresas = bllEmpresa.GetEmpresas(txtPesquisa.Text);

                var lista = empresas.Select(l => new
                {
                    l.CODIGO_EMPRESA,
                    l.DESCRICAO
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma empresa de manutenção encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                m.MenuItems[0].Click += new EventHandler(EditarEmpresa);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarEmpresa(object sender, EventArgs e)
        {
            EMPRESAS empresa = new EMPRESAS();
            empresa.CODIGO_EMPRESA = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            empresa.DESCRICAO = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();

            frmCadastroEmpresaManutencao frm = new frmCadastroEmpresaManutencao(empresa);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroEmpresaManutencao incluirEmpresa = new frmCadastroEmpresaManutencao();
            incluirEmpresa.Processo = 0;
            incluirEmpresa.ShowDialog();
        }
    }
}
