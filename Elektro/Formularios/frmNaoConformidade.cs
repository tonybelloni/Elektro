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
    public partial class frmNaoConformidade : Form
    {
        private int currentMouseOverRow;

        public frmNaoConformidade()
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
                BLLTiposOcorrencia bllTipoOcorrencia = new BLLTiposOcorrencia();
                List<TIPOS_OCORRENCIAS> tipos = bllTipoOcorrencia.GetTiposOcorrencia(txtPesquisa.Text);

                var lista = tipos.Select(l => new
                {
                    l.ID_TIPO,
                    l.DESCRICAO,
                    TIPO = l.GRAVIDADE == 4 ? "Reconhecimento Positivo" : "Não Conformidade",
                    GRAVIDADE = l.GRAVIDADE == 1 ? "Moderado" : l.GRAVIDADE == 2 ? "Grave" : l.GRAVIDADE == 3 ? "Intolerável" : "Positivo"
                }).OrderBy(l => l.DESCRICAO).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código";
                    dataGridView1.Columns[1].HeaderText = "Descrição";
                    dataGridView1.Columns[2].HeaderText = "Tipo de Ocorrência";
                    dataGridView1.Columns[3].HeaderText = "Gravidade";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum tipo de ocorrência encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroNaoConformidade frm = new frmCadastroNaoConformidade();
            frm.Processo = 0;
            frm.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarNaoConformidade);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarNaoConformidade(object sender, EventArgs e)
        {
            BLLTiposOcorrencia bllTiposOcorrencia = new BLLTiposOcorrencia();
            TIPOS_OCORRENCIAS tipo = bllTiposOcorrencia.GetTipoOcorrencia(Convert.ToInt16(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value));

            frmCadastroNaoConformidade frm = new frmCadastroNaoConformidade(tipo);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
