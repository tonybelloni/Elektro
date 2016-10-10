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
    public partial class frmLocalidades : Form
    {
        private int currentMouseOverRow;

        public frmLocalidades()
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
                BLLLocalidade bllLocalidade = new BLLLocalidade();
                List<LOCALIDADE> localidades = new List<LOCALIDADE>();

                localidades = bllLocalidade.GetLocalidades(txtPesquisa.Text);

                var lista = localidades.Select(l => new
                {
                    l.CODIGO_LOCALIDADE,
                    l.DESCRICAO,
                    SUPERVISAO = l.CODIGO_SUPERVISAO.HasValue ? l.SUPERVISAO.DESCRICAO : "",
                    GERENCIA = l.SUPERVISAO.CODIGO_GERENCIA.HasValue ? l.SUPERVISAO.GERENCIA.DESCRICAO : "",
                    REGIAO = l.SUPERVISAO.GERENCIA.CODIGO_REGIAO.HasValue ? l.SUPERVISAO.GERENCIA.REGIAO.DESCRICAO : ""
                }).OrderBy(l => l.DESCRICAO).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                    dataGridView1.Columns[2].HeaderText = "Supervisão";
                    dataGridView1.Columns[3].HeaderText = "Gerência";
                    dataGridView1.Columns[4].HeaderText = "Região";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma localidade encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarLocalidade(object sender, EventArgs e)
        {
            BLLSupervisao bllSupervisao = new BLLSupervisao();
            LOCALIDADE localidade = new LOCALIDADE();
            localidade.CODIGO_LOCALIDADE = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            localidade.DESCRICAO = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();
            localidade.CODIGO_SUPERVISAO = bllSupervisao.GetSupervisao(dataGridView1.Rows[currentMouseOverRow].Cells[2].Value.ToString()).CODIGO_SUPERVISAO;

            frmCadastroLocalidades frm = new frmCadastroLocalidades(localidade);
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
                m.MenuItems[0].Click += new EventHandler(EditarLocalidade);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroLocalidades incluirLocalidade = new frmCadastroLocalidades();
            incluirLocalidade.Processo = 0;
            incluirLocalidade.ShowDialog();
        }
    }
}
