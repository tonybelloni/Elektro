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
using Elektro.Dialogs;

namespace Elektro.Formularios
{
    public partial class frmEscalasCOD : Form
    {
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmEscalasCOD()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmImportarEscalaCOD frm = new frmImportarEscalaCOD();
            frm.Usuario = _usuario;
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLEscalaCOD bllEscala = new BLLEscalaCOD();
                List<ESCALA_COD> lista = new List<ESCALA_COD>();

                BLLEquipes bllEquipe = new BLLEquipes();
                BLLFuncionarios bllFuncionario = new BLLFuncionarios();

                lista = bllEscala.GetEscalas(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.SIGLA_EQUIPE,
                        ATUACAO = bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                        l.PRONTUARIO,
                        NOME_FUNCIONARIO = bllFuncionario.GetFuncionario(l.PRONTUARIO).nome_funcionario,
                        l.DATA_INICIO,
                        l.DATA_FIM
                    }).OrderBy(l => l.SIGLA_EQUIPE).AsQueryable().ToList();

                    dataGridView1.Columns[0].HeaderText = "Equipe";
                    dataGridView1.Columns[1].HeaderText = "Atuação";
                    dataGridView1.Columns[2].HeaderText = "Prontuário";
                    dataGridView1.Columns[3].HeaderText = "Funcionário";
                    dataGridView1.Columns[4].HeaderText = "Data Início";
                    dataGridView1.Columns[5].HeaderText = "Data Fim";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma escala encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dlgHelpEscalaCOD dlg = new dlgHelpEscalaCOD();
            dlg.ShowDialog();
        }
    }
}
