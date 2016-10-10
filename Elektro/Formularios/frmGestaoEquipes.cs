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
    public partial class frmGestaoEquipes : Form
    {
        private int currentMouseOverRow;
        private CamadaDados.USUARIOS _usuario;

        public CamadaDados.USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmGestaoEquipes()
        {
            InitializeComponent();
        }

        private void frmGestaoVeiculo_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarAlocacoesVeiculo frmBuscar = new frmBuscarAlocacoesVeiculo(dataGridView1);
            frmBuscar.Usuario = _usuario;
            frmBuscar.ShowDialog();
        }

        private void Pesquisar()
        {
            try
            {
                BLLEquipes bllEquipe = new BLLEquipes();
                List<EQUIPES> lista = bllEquipe.GetEquipes("").OrderBy(l => l.SIGLA_EQUIPE).ToList();

                if (Usuario.FUNCIONARIOS != null)
                {
                    if (Usuario.FUNCIONARIOS.funcao.Trim().Contains("gerente"))
                        lista = lista.Where(l => l.GERENCIA == Usuario.FUNCIONARIOS.gerencia).AsQueryable().ToList();
                    else if (Usuario.FUNCIONARIOS.funcao.Trim().Contains("supervisor"))
                        lista = lista.Where(l => l.SUPERVISAO == Usuario.FUNCIONARIOS.supervisao).AsQueryable().ToList();
                    else
                        lista = lista.Where(l => l.LOCALIDADE == Usuario.FUNCIONARIOS.localidade).AsQueryable().ToList();
                }

                BLLVeiculos bllVeiculo = new BLLVeiculos();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.SIGLA_EQUIPE,
                        l.NOME_EQUIPE,
                        l.TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                        l.REGIAO1.DESCRICAO,
                        GERENCIA = l.GERENCIA1.DESCRICAO,
                        SUPERVISAO = l.SUPERVISAO1.DESCRICAO,
                        LOCALIDADE = l.LOCALIDADE1.DESCRICAO,
                        l.CODIGO_CAMERA,
                        l.PLACA_VEICULO,
                        TIPO = l.PLACA_VEICULO != null ? bllVeiculo.GetVeiculo(l.PLACA_VEICULO).TIPOS_VEICULOS.DESCRICAO : ""
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Sigla";
                    dataGridView1.Columns[1].HeaderText = "Nome";
                    dataGridView1.Columns[2].HeaderText = "Atuação";
                    dataGridView1.Columns[3].HeaderText = "Região";
                    dataGridView1.Columns[4].HeaderText = "Gerência";
                    dataGridView1.Columns[5].HeaderText = "Supervisão";
                    dataGridView1.Columns[6].HeaderText = "Localidade";
                    dataGridView1.Columns[7].HeaderText = "Câmera";
                    dataGridView1.Columns[8].HeaderText = "Veículo";
                    dataGridView1.Columns[9].HeaderText = "Tipo";
                }
                else
                {
                    MessageBox.Show("Não foi encontrado equipes", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (currentMouseOverRow >= 0)
            {
                BLLEquipes bllEquipe = new BLLEquipes();
                EQUIPES equipe = bllEquipe.GetEquipeBySigla(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

                if (e.Button == MouseButtons.Right)
                {
                    if (equipe.PLACA_VEICULO == null)
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Vincular veículo"));
                        m.MenuItems[0].Click += new EventHandler(VincularVeiculo);
                        m.MenuItems.Add(new MenuItem("Histórico de vinculações da equipe"));
                        m.MenuItems[1].Click += new EventHandler(VerHistorico);
                        currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                    else
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Desvincular veículo"));
                        m.MenuItems[0].Click += new EventHandler(DesvincularVeiculo);
                        m.MenuItems.Add(new MenuItem("Histórico de vinculações da equipe"));
                        m.MenuItems[1].Click += new EventHandler(VerHistorico);
                        currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void VincularVeiculo(object sender, EventArgs e)
        {
            BLLEquipes bllEquipe = new BLLEquipes();
            EQUIPES equipe = bllEquipe.GetEquipeBySigla(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroHistoricoVeiculo frm = new frmCadastroHistoricoVeiculo(equipe, 1);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void DesvincularVeiculo(object sender, EventArgs e)
        {
            BLLEquipes bllEquipe = new BLLEquipes();
            EQUIPES equipe = bllEquipe.GetEquipeBySigla(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroHistoricoVeiculo frm = new frmCadastroHistoricoVeiculo(equipe, 2);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void VerHistorico(object sender, EventArgs e)
        {
            frmHistoricoVeiculo frm = new frmHistoricoVeiculo(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
            frm.ShowDialog();
        }
    }
}
