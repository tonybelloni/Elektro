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
    public partial class frmTiposVeiculos : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmTiposVeiculos()
        {
            InitializeComponent();
        }

        private void Pesquisar()
        {
            try
            {
                BLLTiposVeiculos bllTipoVeiculo = new BLLTiposVeiculos();
                List<TIPOS_VEICULOS> lista = bllTipoVeiculo.GetTiposVeiculos(txtPesquisa.Text);

                if (lista.Count() > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.COD_TIPO_VEICULO,
                        l.DESCRICAO
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                }
                else
                {
                    MessageBox.Show("Não foi encontrado nenhum veículo", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroTipoVeiculo frm = new frmCadastroTipoVeiculo();
            frm.Processo = 0;
            frm.ShowDialog();
            Pesquisar();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            try
            {
                if (currentMouseOverRow >= 0)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenu m = new ContextMenu();
                        m.Show(dataGridView1, new Point(e.X, e.Y));
                        m.MenuItems.Add(new MenuItem("Editar"));
                        m.MenuItems[0].Click += new EventHandler(EditarTipoVeiculo);
                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void EditarTipoVeiculo(object sender, EventArgs e)
        {
            BLLTiposVeiculos bllTipoVeiculo = new BLLTiposVeiculos();
            TIPOS_VEICULOS tipo = bllTipoVeiculo.GetTipoVeiculo(Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString()));

            frmCadastroTipoVeiculo frm = new frmCadastroTipoVeiculo(tipo);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
