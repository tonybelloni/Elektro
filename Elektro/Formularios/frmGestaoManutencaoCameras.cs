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
    public partial class frmGestaoManutencaoCameras : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmGestaoManutencaoCameras()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarManutencoesCamera frmBuscar = new frmBuscarManutencoesCamera(dataGridView1);
            frmBuscar.ShowDialog();
        }

        private void ReceberCamera(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                BLLMovimentacaoCamera bllMovimentacao = new BLLMovimentacaoCamera();
                MOVIMENTACAO_CAMERA movimentacao = bllMovimentacao.GetMovimentacaoCamera(Convert.ToInt32(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString()));

                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Receber"));
                    m.MenuItems[0].Click += new EventHandler(ReceberCamera);
                    currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Pesquisar()
        {
            try
            {
                BLLMovimentacaoCamera bllMovimentacao = new BLLMovimentacaoCamera();
                List<MOVIMENTACAO_CAMERA> lista = new List<MOVIMENTACAO_CAMERA>();

                lista = bllMovimentacao.GetManutencoesCamera("", 0, 0).Where(l => l.TIPO == "IDA").AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_MOVIMENTACAO,
                        l.TIPO,
                        l.CODIGO_CAMERA,
                        l.EMPRESA_MANUTENCAO,
                        l.OBSERVACAO,
                        l.DATA_INICIO,
                        l.DATA_FIM
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "N° Movimentação";
                    dataGridView1.Columns[1].HeaderText = "Status";
                    dataGridView1.Columns[2].HeaderText = "N° Câmera";
                    dataGridView1.Columns[3].HeaderText = "Empresa";
                    dataGridView1.Columns[4].HeaderText = "Observação";
                    dataGridView1.Columns[5].HeaderText = "Data Envio";
                    dataGridView1.Columns[6].HeaderText = "Data Recebimento";
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

        private void frmGestaoManutencaoCameras_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroManutencaoCamera frmEnviarManutencao = new frmCadastroManutencaoCamera();
            frmEnviarManutencao.Usuario = _usuario;
            frmEnviarManutencao.ShowDialog();
        }
    }
}
