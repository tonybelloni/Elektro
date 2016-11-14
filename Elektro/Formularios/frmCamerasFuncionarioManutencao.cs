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
            if (String.IsNullOrEmpty(Usuario.PRONTUARIO))
            {
                MessageBox.Show("Usuário não está associado a um funcionário", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
            else
            {
                Pesquisar();
            }
        }

        private void Pesquisar()
        {
            try
            {

                
                    BLLCameras cameras = new BLLCameras();
                    List<CAMERAS> lista = new List<CAMERAS>();

                    lista = cameras.GetCameras("").Where(c => c.PRONTUARIO == Usuario.PRONTUARIO).AsQueryable().ToList();

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
                        l.PRONTUARIO
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
                        MessageBox.Show("Funcionário não tem câmeras em seu estoque", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
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
                            m.MenuItems.Add(new MenuItem("Alocar"));
                            m.MenuItems[0].Click += new EventHandler(AlocarCamera);
                            m.MenuItems.Add(new MenuItem("Enviar para Manutenção"));
                            m.MenuItems[1].Click += new EventHandler(EnviarManutencaoCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "ALOCADA")
                        {
                            m.MenuItems.Add(new MenuItem("Desalocar"));
                            m.MenuItems[0].Click += new EventHandler(DesalocarCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "MANUTENÇÃO LOCAL" || camera.STATUS == "MANUTENÇÃO")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Retirar de Manutenção"));
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

        private void ReceberManutencaoCamera(object sender, EventArgs e)
        {
            try
            {
                BLLCameras bllCameras = new BLLCameras();
                CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                DateTime dataEnvio = bllHistorico.GetHistoricosCameras(camera.codigo_camera).Where(l => l.TIPO == 3).LastOrDefault().DATA_ENVIO.Value;

                historico.TIPO = 4;
                historico.CODIGO_CAMERA = camera.codigo_camera;
                historico.OBSERVACAO = "Recebimento de camera em manutencao pelo funcionario : " + _usuario.PRONTUARIO;
                historico.DATA_REGISTRO = DateTime.Now;
                historico.DATA_ENVIO = dataEnvio;
                historico.DATA_RECEBIMENTO = DateTime.Now;
                historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                historico.PRONTUARIO = camera.PRONTUARIO;

                bllHistorico.InserirHistoricoCamera(historico);

                BLLCameras bllCamera = new BLLCameras();
                bllCamera.UpdateStatusCamera(camera.codigo_camera, "EM ESTOQUE", camera.PRONTUARIO);

                MessageBox.Show("Recebimento de câmera em manutenção realizado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao receber câmera em manutenção", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EnviarManutencaoCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmEnviarParaManutencaoFuncionario frm = new frmEnviarParaManutencaoFuncionario(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void DesalocarCamera(object sender, EventArgs e)
        {
            try
            {
                string codCamera = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();

                BLLCameras bllCamera = new BLLCameras();
                CAMERAS camera = bllCamera.GetCamera(codCamera);

                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                string siglaEquipe = bllHistorico.GetHistoricosCameras(codCamera).Where(l => l.TIPO == 1).LastOrDefault().SIGLA_EQUIPE;
                HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                DateTime dataAlocacao = bllHistorico.GetHistoricosCameras(codCamera).Where(l => l.TIPO == 1).LastOrDefault().DATA_ALOCACAO.Value;

                historico.TIPO = 5;
                historico.CODIGO_CAMERA = codCamera;
                historico.SIGLA_EQUIPE = siglaEquipe;
                historico.OBSERVACAO = "Camera Desalocada por funcionario";
                historico.DATA_REGISTRO = DateTime.Now;
                historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                historico.DATA_ALOCACAO = dataAlocacao;
                historico.DATA_DESALOCAO = DateTime.Now;

                bllHistorico.InserirHistoricoCamera(historico);

                bllCamera.UpdateStatusCamera(codCamera, "EM ESTOQUE", camera.PRONTUARIO);

                BLLEquipes bllEquipe = new BLLEquipes();
                bllEquipe.UpdateStatusEquipe(siglaEquipe, null);
                
                MessageBox.Show("Câmera desvinculada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desalocar câmera", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AlocarCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmAlocacaoCameraFuncionario frm = new frmAlocacaoCameraFuncionario(camera);
            frm.Usuario = _usuario;
            frm.Operacao = "ALOCAR";
            frm.ShowDialog();
            Pesquisar();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarCamerasFuncionario frm = new frmBuscarCamerasFuncionario(Usuario, this.dataGridView1);
            frm.Show();
        }
    }
}
