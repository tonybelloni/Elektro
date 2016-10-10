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
    public partial class frmCameras : Form  
    {
        private int currentMouseOverRow;

        public frmCameras()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        public void Pesquisar()
        {
            try
            {
                BLLCameras cameras = new BLLCameras();
                List<CAMERAS> lista = new List<CAMERAS>();

                lista = cameras.GetCameras(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.codigo_camera,
                        l.bpm_camera,
                        l.codigo_barra_camera,
                        ATIVA = l.ativo == 1 ? "Sim" : "Não",
                        l.STATUS,
                        DATA_AQUISICAO = l.DATA_AQUISICAO.HasValue ? l.DATA_AQUISICAO.Value.ToShortDateString() : "",
                        FORNECEDORA = l.CODIGO_EMPRESA.HasValue ? l.EMPRESAS.DESCRICAO : ""
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Código da Câmera";
                    dataGridView1.Columns[1].HeaderText = "BPM da Câmera";
                    dataGridView1.Columns[2].HeaderText = "Código de Barras";
                    dataGridView1.Columns[3].HeaderText = "Ativa";
                    dataGridView1.Columns[4].HeaderText = "Status";
                    dataGridView1.Columns[5].HeaderText = "Data Aquisição";
                    dataGridView1.Columns[6].HeaderText = "Fornecedora";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma Câmera Encontrada", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroCameras incluircameras = new frmCadastroCameras();
            incluircameras.Processo = 0;
            incluircameras.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Editar"));
                    m.MenuItems[0].Click += new EventHandler(EditarCamera);
                    currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = new CAMERAS();
            string codigo = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
            camera = bllCameras.GetCamera(codigo);
            
            frmCadastroCameras frm = new frmCadastroCameras(camera);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
