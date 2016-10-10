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
    public partial class frmCamerasFuncionarioManutencao : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmCamerasFuncionarioManutencao()
        {
            InitializeComponent();
        }

        private void frmCamerasFuncionarioManutencao_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLCameras cameras = new BLLCameras();
                List<CAMERAS> lista = new List<CAMERAS>();

                lista = cameras.GetCameras("").Where(c => (c.STATUS == "DISPONÍVEL") || (c.STATUS == "MANUTENÇÃO LOCAL" && c.PRONTUARIO == Usuario.PRONTUARIO) || (c.STATUS == "EM ESTOQUE" && c.PRONTUARIO == Usuario.PRONTUARIO)).AsQueryable().ToList();

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
                        FORNECEDORA = l.CODIGO_EMPRESA.HasValue ? l.EMPRESAS.DESCRICAO : "",
                        FUNCIONARIO = l.PRONTUARIO != null ? l.PRONTUARIO : ""
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Código da Câmera";
                    dataGridView1.Columns[1].HeaderText = "BPM da Câmera";
                    dataGridView1.Columns[2].HeaderText = "Código de Barras";
                    dataGridView1.Columns[3].HeaderText = "Ativa";
                    dataGridView1.Columns[4].HeaderText = "Status";
                    dataGridView1.Columns[5].HeaderText = "Data Aquisição";
                    dataGridView1.Columns[6].HeaderText = "Fornecedora";
                    dataGridView1.Columns[7].HeaderText = "Funcionário";
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu m = new ContextMenu();
            m.Show(dataGridView1, new Point(e.X, e.Y));
            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            try
            {
                if (currentMouseOverRow >= 0)
                {
                    BLLCameras bllCameras = new BLLCameras();
                    CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

                    if (e.Button == MouseButtons.Right)
                    {
                        if (camera.STATUS == "EM ESTOQUE")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Alocar"));
                            m.MenuItems[0].Click += new EventHandler(AlocarCamera);
                            m.MenuItems.Add(new MenuItem("Retirar do Próprio Estoque"));
                            m.MenuItems[1].Click += new EventHandler(TirarAlmoxarifadoFuncionario);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        if (camera.STATUS == "DISPONÍVEL")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Receber câmera para manutenção"));
                            m.MenuItems[0].Click += new EventHandler(EnviarParaFuncionario);
                            m.MenuItems.Add(new MenuItem("Enviar para o próprio estoque"));
                            m.MenuItems[1].Click += new EventHandler(EnviarParaAlmoxarifadoFuncionario);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "MANUTENÇÃO LOCAL")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Informar conserto"));
                            m.MenuItems[0].Click += new EventHandler(ReceberManutencaoCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlocarCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroAlocacaoCamera frm = new frmCadastroAlocacaoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void ReceberManutencaoCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroManutencaoCamera frm = new frmCadastroManutencaoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void EnviarParaFuncionario(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroManutencaoCamera frm = new frmCadastroManutencaoCamera(camera);
            frm.Usuario = _usuario;
            frm.Tipo = 2;
            frm.ShowDialog();
            Pesquisar();
        }

        private void EnviarParaAlmoxarifadoFuncionario(object sender, EventArgs e)
        {
            try
            {
                BLLCameras bllCameras = new BLLCameras();
                CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

                if (_usuario.FUNCIONARIOS == null)
                    throw new Exception("Usuário não é funcionário");

                bllCameras.AlocarCameraFuncionario(camera, _usuario);

                MessageBox.Show("Câmera enviada para funcionário com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TirarAlmoxarifadoFuncionario(object sender, EventArgs e)
        {
            try
            {
                BLLCameras bllCameras = new BLLCameras();
                CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

                if (_usuario.FUNCIONARIOS == null)
                    throw new Exception("Usuário não é funcionário");

                bllCameras.DesalocarCameraFuncionario(camera);

                MessageBox.Show("Câmera recebida do funcionário com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pesquisar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarCamerasFuncionario frm = new frmBuscarCamerasFuncionario(Usuario, this.dataGridView1);
            frm.Show();
        }
    }
}
