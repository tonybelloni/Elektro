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
using Utilitarios;

namespace Elektro.Formularios
{
    public partial class frmEquipes : Form
    {
        private int currentMouseOverRow;

        public frmEquipes()
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
                BLLEquipes equipes = new BLLEquipes();
                List<EQUIPES> lista = new List<EQUIPES>();

                lista = equipes.GetEquipes(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.SIGLA_EQUIPE,
                        l.NOME_EQUIPE,
                        REGIAO = l.REGIAO1.DESCRICAO,
                        GERENCIA = l.GERENCIA1.DESCRICAO,
                        SUPERVISAO = l.SUPERVISAO1.DESCRICAO,
                        LOCALIDADE = l.LOCALIDADE1.DESCRICAO,
                        l.TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO
                    }).OrderBy(l => l.SIGLA_EQUIPE).AsQueryable().ToList();

                    dataGridView1.Columns[0].HeaderText = "Sigla da Equipe";
                    dataGridView1.Columns[1].HeaderText = "Nome da Equipe";
                    dataGridView1.Columns[2].HeaderText = "Região";
                    dataGridView1.Columns[3].HeaderText = "Gerência";
                    dataGridView1.Columns[4].HeaderText = "Supervisão";
                    dataGridView1.Columns[5].HeaderText = "Localidade";
                    dataGridView1.Columns[6].HeaderText = "Tipo de Trabalho";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma equipe encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroEquipes frm = new frmCadastroEquipes();
            frm.Processo = 0;
            frm.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarEquipes);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarEquipes(object sender, EventArgs e)
        {
            DALRegiao dalRegiao = new DALRegiao();
            DALGerencia dalGerencia = new DALGerencia();
            DALSupervisao dalSupervisao = new DALSupervisao();
            DALLocalidade dalLocalidade = new DALLocalidade();
            DALTiposTrabalhos dalTipoTrabalho = new DALTiposTrabalhos();
            EQUIPES equipe = new EQUIPES();
            equipe.SIGLA_EQUIPE = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
            equipe.NOME_EQUIPE = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();
            equipe.REGIAO = dalRegiao.GetRegiao(dataGridView1.Rows[currentMouseOverRow].Cells[2].Value.ToString()).CODIGO_REGIAO;
            equipe.GERENCIA = dalGerencia.GetGerencia(dataGridView1.Rows[currentMouseOverRow].Cells[3].Value.ToString()).CODIGO_GERENCIA;
            equipe.SUPERVISAO = dalSupervisao.GetSupervisao(dataGridView1.Rows[currentMouseOverRow].Cells[4].Value.ToString()).CODIGO_SUPERVISAO;
            equipe.LOCALIDADE = dalLocalidade.GetLocalidade(dataGridView1.Rows[currentMouseOverRow].Cells[5].Value.ToString()).CODIGO_LOCALIDADE;
            equipe.ID_TIPO_TRABALHO = dalTipoTrabalho.GetTipoDeTrabalho(dataGridView1.Rows[currentMouseOverRow].Cells[6].Value.ToString()).ID_TIPO_TRABALHO;

            frmCadastroEquipes frm = new frmCadastroEquipes(equipe);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
