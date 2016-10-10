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
    public partial class frmBuscarCamerasFuncionario : Form
    {
        private DataGridView dgv;
        private USUARIOS _usuario;

        public frmBuscarCamerasFuncionario()
        {
            InitializeComponent();
        }

        public frmBuscarCamerasFuncionario(USUARIOS Usuario, DataGridView DGV)
        {
            _usuario = Usuario;
            dgv = DGV;
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtNumeroCamera.Text = "";
            cmbStatus.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLCameras cameras = new BLLCameras();
                List<CAMERAS> lista = new List<CAMERAS>();

                lista = cameras.GetCameras("").Where(c => (c.STATUS == "DISPONÍVEL") || (c.STATUS == "MANUTENÇÃO LOCAL" && c.PRONTUARIO == _usuario.PRONTUARIO) || (c.STATUS == "EM ESTOQUE" && c.PRONTUARIO == _usuario.PRONTUARIO)).AsQueryable().ToList();

                if (txtNumeroCamera.Text.Trim() != "")
                    lista = lista.Where(l => l.codigo_camera == txtNumeroCamera.Text).AsQueryable().ToList();

                if (cmbStatus.SelectedIndex != 0)
                {
                    if (cmbStatus.SelectedIndex == 1)
                        lista = lista.Where(l => l.STATUS == "DISPONÍVEL").AsQueryable().ToList();
                    else if (cmbStatus.SelectedIndex == 2)
                        lista = lista.Where(l => l.STATUS == "EM ESTOQUE").AsQueryable().ToList();
                    else if (cmbStatus.SelectedIndex == 3)
                        lista = lista.Where(l => l.STATUS == "MANUTENÇÃO LOCAL").AsQueryable().ToList();
                }

                if (lista.Count > 0)
                {
                    dgv.DataSource = lista.Select(l => new
                    {
                        l.codigo_camera,
                        l.bpm_camera,
                        l.codigo_barra_camera,
                        ATIVA = l.ativo == 1 ? "Sim" : "Não",
                        l.STATUS,
                        DATA_AQUISICAO = l.DATA_AQUISICAO.HasValue ? l.DATA_AQUISICAO.Value.ToShortDateString() : "",
                        FORNECEDORA = l.CODIGO_EMPRESA.HasValue ? l.EMPRESAS.DESCRICAO : "",
                        FUNCIONARIO = l.PRONTUARIO != null ? l.PRONTUARIO : ""
                    }).AsQueryable().ToList();
                    dgv.Columns[0].HeaderText = "Código da Câmera";
                    dgv.Columns[1].HeaderText = "BPM da Câmera";
                    dgv.Columns[2].HeaderText = "Código de Barras";
                    dgv.Columns[3].HeaderText = "Ativa";
                    dgv.Columns[4].HeaderText = "Status";
                    dgv.Columns[5].HeaderText = "Data Aquisição";
                    dgv.Columns[6].HeaderText = "Fornecedora";
                    dgv.Columns[7].HeaderText = "Funcionário";

                    this.Close();
                }
                else
                {
                    dgv.DataSource = null;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBuscarCamerasFuncionario_Load(object sender, EventArgs e)
        {
            txtNumeroCamera.Text = "";
            cmbStatus.SelectedIndex = 0;
        }
    }
}
