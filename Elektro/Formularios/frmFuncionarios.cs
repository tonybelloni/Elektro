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
using Elektro.Dialogs;

namespace Elektro.Formularios
{
    public partial class frmFuncionarios : Form
    {
        private int currentMouseOverRow;

        public frmFuncionarios()
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
                BLLRegiao bllRegiao = new BLLRegiao();
                BLLGerencia bllGerencia = new BLLGerencia();
                BLLSupervisao bllSupervisao = new BLLSupervisao();
                BLLLocalidade bllLocalidade = new BLLLocalidade();
                BLLFuncionarios bllFuncionario = new BLLFuncionarios();
                List<FUNCIONARIOS> lista = new List<FUNCIONARIOS>();

                lista = bllFuncionario.GetFuncionarios(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.prontuario,
                        l.nome_funcionario,
                        l.funcao,
                        LOCALIDADE = bllLocalidade.GetLocalidade(l.localidade).DESCRICAO,
                        SUPERVISAO = bllSupervisao.GetSupervisao(l.supervisao).DESCRICAO,
                        GERENCIA = bllGerencia.GetGerencia(l.gerencia).DESCRICAO,
                        REGIAO = bllRegiao.GetRegiao(l.regiao).DESCRICAO,
                        l.prontuario_gestor,
                        l.nome_gestor
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Prontuário";
                    dataGridView1.Columns[1].HeaderText = "Nome";
                    dataGridView1.Columns[2].HeaderText = "Função";
                    dataGridView1.Columns[3].HeaderText = "Localidade";
                    dataGridView1.Columns[4].HeaderText = "Supervisão";
                    dataGridView1.Columns[5].HeaderText = "Gerência";
                    dataGridView1.Columns[6].HeaderText = "Região";
                    dataGridView1.Columns[7].HeaderText = "Prontuário Gestor";
                    dataGridView1.Columns[8].HeaderText = "Nome do Gestor";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum funcionário encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {            
             frmCadastroFuncionarios frm = new frmCadastroFuncionarios();
             frm.ShowDialog();         
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmCadastroManualFuncionario frm = new frmCadastroManualFuncionario();
            frm.Processo = 0;
            frm.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarFuncionario);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarFuncionario(object sender, EventArgs e)
        {
            BLLLocalidade bllLocalidade = new BLLLocalidade();
            BLLSupervisao bllSupervisao = new BLLSupervisao();
            BLLGerencia bllGerencia = new BLLGerencia();
            BLLRegiao bllRegiao = new BLLRegiao();
            BLLFuncionarios bllFuncionario = new BLLFuncionarios();
            FUNCIONARIOS funcionario = new FUNCIONARIOS();
            funcionario.prontuario = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
            funcionario.nome_funcionario = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();
            funcionario.funcao = dataGridView1.Rows[currentMouseOverRow].Cells[2].Value.ToString();
            funcionario.localidade = bllLocalidade.GetLocalidade(dataGridView1.Rows[currentMouseOverRow].Cells[3].Value.ToString()).CODIGO_LOCALIDADE;
            funcionario.supervisao = bllSupervisao.GetSupervisao(dataGridView1.Rows[currentMouseOverRow].Cells[4].Value.ToString()).CODIGO_SUPERVISAO;
            funcionario.gerencia = bllGerencia.GetGerencia(dataGridView1.Rows[currentMouseOverRow].Cells[5].Value.ToString()).CODIGO_GERENCIA;
            funcionario.regiao = bllRegiao.GetRegiao(dataGridView1.Rows[currentMouseOverRow].Cells[6].Value.ToString()).CODIGO_REGIAO;
            funcionario.prontuario_gestor = dataGridView1.Rows[currentMouseOverRow].Cells[7].Value != null ? dataGridView1.Rows[currentMouseOverRow].Cells[7].Value.ToString() : null;
            funcionario.nome_gestor = dataGridView1.Rows[currentMouseOverRow].Cells[8].Value != null ? dataGridView1.Rows[currentMouseOverRow].Cells[8].Value.ToString() : null;

            frmCadastroManualFuncionario frm = new frmCadastroManualFuncionario(funcionario);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dlgHelpFuncionarios dlg = new dlgHelpFuncionarios();
            dlg.ShowDialog();
        }
    }
}
