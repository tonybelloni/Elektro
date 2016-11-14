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
    public partial class frmVeiculos : Form
    {
        private int currentMouseOverRow;

        public frmVeiculos()
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
                BLLVeiculos bllVeiculo = new BLLVeiculos();
                List<VEICULOS> lista = new List<VEICULOS>();

                lista = bllVeiculo.GetVeiculos(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.PLACA,
                        l.TIPOS_VEICULOS.DESCRICAO,
                        ATIVO = l.ativo == 0 ? "Não" : "Sim",
                        l.observacao,
                        l.COD_TIPO
                    }).ToList();
                    dataGridView1.Columns[0].HeaderText = "Placa";
                    dataGridView1.Columns[1].HeaderText = "Tipo";
                    dataGridView1.Columns[2].HeaderText = "Ativo";
                    dataGridView1.Columns[3].HeaderText = "Observações";
                    dataGridView1.Columns[4].HeaderText = "CodTipo";
                    dataGridView1.Columns[4].Visible = false;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum Veículo Encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroVeiculos incluirveiculos = new frmCadastroVeiculos();
            incluirveiculos.Processo = 0;
            incluirveiculos.ShowDialog();
            Pesquisar();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarVeiculos);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarVeiculos(object sender, EventArgs e)
        {
            VEICULOS veiculo = new VEICULOS();
            veiculo.PLACA = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
            veiculo.COD_TIPO = Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[4].Value.ToString());

            if (dataGridView1.Rows[currentMouseOverRow].Cells[3].Value != null)
                veiculo.observacao = dataGridView1.Rows[currentMouseOverRow].Cells[3].Value.ToString();
            else
                veiculo.observacao = "";

            veiculo.ativo = dataGridView1.Rows[currentMouseOverRow].Cells[2].Value.ToString() == "Sim" ? 1 : 0;

            frmCadastroVeiculos frm = new frmCadastroVeiculos(veiculo);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
