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
    public partial class frmGestaoAlocacaoCameras : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmGestaoAlocacaoCameras()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarAlocacoesCamera frmBusca = new frmBuscarAlocacoesCamera(dataGridView1);
            frmBusca.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroAlocacaoCamera frmAlocacao = new frmCadastroAlocacaoCamera();
            frmAlocacao.Usuario = _usuario;
            frmAlocacao.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmCadastroManutencaoCamera frmManutencao = new frmCadastroManutencaoCamera();
            frmManutencao.Usuario = _usuario;
            frmManutencao.ShowDialog();
        }

        private void DesalocarCamera(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString() == "DESVINCULADA")
            {
                MessageBox.Show("Movimentação já está com status de desvinculado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BLLMovimentacaoCamera bllMovimentacao = new BLLMovimentacaoCamera();
                MOVIMENTACAO_CAMERA movimentacao = bllMovimentacao.GetMovimentacaoCamera(Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString()));

                frmCadastroAlocacaoCamera frm = new frmCadastroAlocacaoCamera(movimentacao);
                frm.Usuario = _usuario;
                frm.ShowDialog();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Desvincular"));
                m.MenuItems[0].Click += new EventHandler(DesalocarCamera);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void Pesquisar()
        {
            try
            {
                BLLMovimentacaoCamera bllMovimentacao = new BLLMovimentacaoCamera();
                List<MOVIMENTACAO_CAMERA> lista = new List<MOVIMENTACAO_CAMERA>();

                lista = bllMovimentacao.GetAlocacoesCamera("", "", 0).Where(l => l.TIPO == "ALOCADA").AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_MOVIMENTACAO,
                        l.TIPO,
                        l.CODIGO_CAMERA,
                        l.SIGLA_EQUIPE,
                        l.OBSERVACAO,
                        l.DATA_INICIO,
                        l.DATA_FIM
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "N° Movimentação";
                    dataGridView1.Columns[1].HeaderText = "Status";
                    dataGridView1.Columns[2].HeaderText = "N° Câmera";
                    dataGridView1.Columns[3].HeaderText = "Equipe";
                    dataGridView1.Columns[4].HeaderText = "Observação";
                    dataGridView1.Columns[5].HeaderText = "Data Alocação";
                    dataGridView1.Columns[6].HeaderText = "Data Devolução";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGestaoAlocacaoCameras_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
