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
    public partial class frmGestaoCameras : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;
        private bool isAdmin;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmGestaoCameras()
        {
            InitializeComponent();
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
                        if (camera.STATUS == "DISPONÍVEL")
                        {
                            m.MenuItems.Add(new MenuItem("Alocar"));
                            m.MenuItems[0].Click += new EventHandler(AlocarCamera);

                            if (isAdmin)
                            {
                                m.MenuItems.Add(new MenuItem("Alterar Responsável"));
                                m.MenuItems[1].Click += new EventHandler(EnviarFuncionario);
                                m.MenuItems.Add(new MenuItem("Enviar para Manutenção"));
                                m.MenuItems[2].Click += new EventHandler(EnviarManutencaoCamera);
                                m.MenuItems.Add(new MenuItem("Realizar Baixa"));
                                m.MenuItems[3].Click += new EventHandler(RealizarBaixaCamera);
                                m.MenuItems.Add(new MenuItem("Ver Histórico"));
                                m.MenuItems[4].Click += new EventHandler(VerHistoricoCamera);
                            }
                            else
                            {
                                m.MenuItems.Add(new MenuItem("Enviar para Manutenção"));
                                m.MenuItems[1].Click += new EventHandler(EnviarManutencaoCamera);
                                m.MenuItems.Add(new MenuItem("Ver Histórico"));
                                m.MenuItems[2].Click += new EventHandler(VerHistoricoCamera);
                            }

                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "ALOCADA")
                        {
                            m.MenuItems.Add(new MenuItem("Desalocar"));
                            m.MenuItems[0].Click += new EventHandler(DesalocarCamera);

                            if (isAdmin)
                            {
                                m.MenuItems.Add(new MenuItem("Alterar Responsável"));
                                m.MenuItems[1].Click += new EventHandler(EnviarFuncionario);
                                m.MenuItems.Add(new MenuItem("Ver Histórico"));
                                m.MenuItems[2].Click += new EventHandler(VerHistoricoCamera);
                            }
                            else
                            {
                                m.MenuItems.Add(new MenuItem("Ver Histórico"));
                                m.MenuItems[1].Click += new EventHandler(VerHistoricoCamera);
                            }
                       
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "MANUTENÇÃO" || camera.STATUS == "MANUTENÇÃO LOCAL")
                        {
                            if (isAdmin)
                            {
                                m.MenuItems.Add(new MenuItem("Alterar Responsável"));
                                m.MenuItems[0].Click += new EventHandler(EnviarFuncionario);
                                m.MenuItems.Add(new MenuItem("Receber da Manutenção"));
                                m.MenuItems[1].Click += new EventHandler(ReceberManutencaoCamera);
                                m.MenuItems.Add(new MenuItem("Realizar Baixa"));
                                m.MenuItems[2].Click += new EventHandler(RealizarBaixaCamera);
                                m.MenuItems.Add(new MenuItem("Ver Histórico"));
                                m.MenuItems[3].Click += new EventHandler(VerHistoricoCamera);
                            }
                            else
                            {
                                m.MenuItems.Add(new MenuItem("Receber da Manutenção"));
                                m.MenuItems[0].Click += new EventHandler(ReceberManutencaoCamera);
                                m.MenuItems.Add(new MenuItem("Ver Histórico"));
                                m.MenuItems[1].Click += new EventHandler(VerHistoricoCamera);
                            }

                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else
                        {
                            m.MenuItems.Add(new MenuItem("Ver Histórico"));
                            m.MenuItems[0].Click += new EventHandler(VerHistoricoCamera);
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

        private void EnviarFuncionario(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmEnviarCameraFuncionario frm = new frmEnviarCameraFuncionario(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
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

        private void DesalocarCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroAlocacaoCamera frm = new frmCadastroAlocacaoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
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
                bllCamera.UpdateStatusCamera(camera.codigo_camera, "DISPONÍVEL", camera.PRONTUARIO);

                MessageBox.Show("Recebimento de câmera em manutenção realizado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao receber câmera em manutenção", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RealizarBaixaCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroBaixaCameras frm = new frmCadastroBaixaCameras(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void VerHistoricoCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmHistoricoCamera frm = new frmHistoricoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
        }

        private void Pesquisar()
        {
            try
            {
                BLLCameras cameras = new BLLCameras();
                List<CAMERAS> lista = new List<CAMERAS>();

                if (_usuario.TIPOS_USUARIOS.descricao_tipo_usuario == "Administrador")
                {
                    lista = cameras.GetCameras("");
                    isAdmin = true;
                }
                else
                {
                    if (_usuario.FUNCIONARIOS != null)
                    {
                       lista = cameras.GetCamerasPorFuncionario(_usuario.FUNCIONARIOS.prontuario);
                    }
                    isAdmin = false;
                }

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
                        DATA_INUTILIZACAO = l.DATA_BAIXA.HasValue ? l.DATA_BAIXA.Value.ToShortDateString() : "",
                        l.MOTIVO_BAIXA,
                        l.PRONTUARIO
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Código da Câmera";
                    dataGridView1.Columns[1].HeaderText = "BPM da Câmera";
                    dataGridView1.Columns[2].HeaderText = "Código de Barras";
                    dataGridView1.Columns[3].HeaderText = "Ativa";
                    dataGridView1.Columns[4].HeaderText = "Status";
                    dataGridView1.Columns[5].HeaderText = "Data Aquisição";
                    dataGridView1.Columns[6].HeaderText = "Fornecedora";
                    dataGridView1.Columns[7].HeaderText = "Data Inutilização";
                    dataGridView1.Columns[8].HeaderText = "Motivo";
                    dataGridView1.Columns[9].HeaderText = "Funcionário";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhuma câmera encontrda", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
