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
    public partial class frmCadastroManutencaoCamera : Form
    {
        private USUARIOS _usuario;
        private CAMERAS _camera;
        private int _tipo;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public frmCadastroManutencaoCamera()
        {
            InitializeComponent();
        }

        public frmCadastroManutencaoCamera(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Incluir();
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            cmbNumeroCamera.SelectedIndex = -1;
            cmbEmpresa.SelectedIndex = -1;
            txtObservacao.Text = "";
            txtNumeroProtocolo.Text = "";
            txtDataEnvio.Text = DateTime.Now.ToShortDateString();
            cmbFuncionario.SelectedIndex = -1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private bool ValidarCampos()
        {
            if ((cmbNumeroCamera.SelectedIndex == -1) || (cmbEmpresa.SelectedIndex == -1) || (txtNumeroProtocolo.Enabled == true && txtNumeroProtocolo.Text.Trim() == "") || (txtDataEnvio.Text.Trim() == "") || (txtObservacao.Text.Trim() == "") || (cmbFuncionario.Enabled == true && cmbFuncionario.SelectedIndex == -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmCadastroManutencaoCamera_Load(object sender, EventArgs e)
        {
            CarregarEmpresas();
            txtDataEnvio.Text = DateTime.Now.ToShortDateString();

            if (_camera.STATUS == "MANUTENÇÃO")
            {
                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();

                CarregarCameras(2);
                cmbNumeroCamera.SelectedValue = _camera.codigo_camera;
                cmbNumeroCamera.Enabled = false;
                cmbEmpresa.SelectedValue = _camera.CODIGO_EMPRESA;
                cmbEmpresa.Enabled = false;
                txtNumeroProtocolo.Text = bllHistorico.GetHistoricosCameras(_camera.codigo_camera).Where(l => l.TIPO == 3).LastOrDefault().NUMERO_RASTREIO;
                txtNumeroProtocolo.Enabled = false;
                label2.Text = "Data Recebimento";
                cmbFuncionario.Enabled = false;
            }
            else if (_camera.STATUS == "MANUTENÇÃO LOCAL")
            {
                CarregarCameras(3);
                CarregarFuncionarios();
                cmbNumeroCamera.SelectedValue = _camera.codigo_camera;
                cmbNumeroCamera.Enabled = false;
                cmbEmpresa.SelectedValue = _camera.CODIGO_EMPRESA;
                cmbEmpresa.Enabled = false;
                label2.Text = "Data Conserto";
                cmbFuncionario.Enabled = false;
                cmbFuncionario.SelectedValue = _camera.PRONTUARIO != null ? _camera.PRONTUARIO : "";
                txtNumeroProtocolo.Enabled = false;
            }
            else
            {
                CarregarCameras(1);
                cmbNumeroCamera.SelectedValue = _camera.codigo_camera;
                cmbNumeroCamera.Enabled = false;
                cmbEmpresa.SelectedValue = _camera.CODIGO_EMPRESA;
                cmbEmpresa.Enabled = false;
                label2.Text = "Data Envio";

                if (_tipo == 1)
                {
                    txtNumeroProtocolo.Enabled = true;
                    cmbFuncionario.Enabled = false;
                }
                else
                {
                    txtNumeroProtocolo.Enabled = false;
                    cmbFuncionario.Enabled = true;
                    CarregarFuncionarios();
                }
            }
            cmbFuncionario.Enabled = false;
        }

        public void CarregarCameras(int tipo)
        {
            if (tipo == 1)
            {
                BLLCameras bllCamera = new BLLCameras();
                List<CAMERAS> cameras = bllCamera.GetCamerasParaManutencao();

                cmbNumeroCamera.DataSource = null;
                cmbNumeroCamera.DataSource = cameras;
                cmbNumeroCamera.DisplayMember = "codigo_camera";
                cmbNumeroCamera.ValueMember = "codigo_camera";
                cmbNumeroCamera.SelectedIndex = -1;
            }
            else if (tipo == 2)
            {
                BLLCameras bllCamera = new BLLCameras();
                List<CAMERAS> cameras = bllCamera.GetCamerasEmManutencao();

                cmbNumeroCamera.DataSource = null;
                cmbNumeroCamera.DataSource = cameras;
                cmbNumeroCamera.DisplayMember = "codigo_camera";
                cmbNumeroCamera.ValueMember = "codigo_camera";
                cmbNumeroCamera.SelectedIndex = -1;
            }
            else
            {
                BLLCameras bllCamera = new BLLCameras();
                List<CAMERAS> cameras = bllCamera.GetCamerasEmManutencaoLocal();

                cmbNumeroCamera.DataSource = null;
                cmbNumeroCamera.DataSource = cameras;
                cmbNumeroCamera.DisplayMember = "codigo_camera";
                cmbNumeroCamera.ValueMember = "codigo_camera";
                cmbNumeroCamera.SelectedIndex = -1;
            }
        }

        public void CarregarFuncionarios()
        {
            BLLFuncionarios bllFuncionario = new BLLFuncionarios();
            List<FUNCIONARIOS> funcionarios = bllFuncionario.GetFuncionarios("");

            if (Usuario.FUNCIONARIOS != null)
            {
                if (Usuario.FUNCIONARIOS.funcao.Trim().Contains("gerente"))
                    funcionarios = funcionarios.Where(l => l.gerencia == Usuario.FUNCIONARIOS.gerencia).ToList();
                else if (Usuario.FUNCIONARIOS.funcao.Trim().Contains("supervisor"))
                    funcionarios = funcionarios.Where(l => l.supervisao == Usuario.FUNCIONARIOS.supervisao).ToList();
                else
                    funcionarios = funcionarios.Where(l => l.localidade == Usuario.FUNCIONARIOS.localidade).ToList();
            }

            cmbFuncionario.DataSource = null;
            cmbFuncionario.DataSource = funcionarios;
            cmbFuncionario.DisplayMember = "nome_funcionario";
            cmbFuncionario.ValueMember = "prontuario";
            cmbFuncionario.SelectedIndex = -1;
        }

        private void Incluir()
        {
            try
            {
                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                if (_camera.STATUS != "MANUTENÇÃO" && _camera.STATUS != "MANUTENÇÃO LOCAL")
                {
                    string numeroCamera = cmbNumeroCamera.SelectedValue.ToString();
                    int empresa = Convert.ToInt32(cmbEmpresa.SelectedValue.ToString());
                    string numeroRastreio = txtNumeroProtocolo.Text;
                    string observacao = txtObservacao.Text;
                    DateTime dataEnvio = Convert.ToDateTime(txtDataEnvio.Text);

                    historico.TIPO = 3;
                    historico.CODIGO_CAMERA = numeroCamera;
                    historico.EMPRESA_MANUTENCAO = empresa;
                    if (cmbFuncionario.SelectedIndex == -1)
                        historico.NUMERO_RASTREIO = numeroRastreio;
                    else
                        historico.PRONTUARIO = cmbFuncionario.SelectedValue.ToString();
                    historico.OBSERVACAO = observacao;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.DATA_ENVIO = dataEnvio;
                    historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;

                    bllHistorico.InserirHistoricoCamera(historico);

                    BLLCameras bllCamera = new BLLCameras();
                    //if (cmbFuncionario.SelectedIndex == -1)
                        bllCamera.UpdateStatusCamera(numeroCamera, "MANUTENÇÃO", "");
                    //else
                    //    bllCamera.UpdateStatusCamera(numeroCamera, "MANUTENÇÃO LOCAL", cmbFuncionario.SelectedValue.ToString());

                    MessageBox.Show("Envio de câmera para manutenção inserido com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string numeroCamera = cmbNumeroCamera.SelectedValue.ToString();
                    int empresa = Convert.ToInt32(cmbEmpresa.SelectedValue.ToString());
                    string numeroRastreio = txtNumeroProtocolo.Text;
                    string observacao = txtObservacao.Text;
                    DateTime dataEnvio = bllHistorico.GetHistoricosCameras(numeroCamera).Where(l => l.TIPO == 3).LastOrDefault().DATA_ENVIO.Value;
                    DateTime dataRecebimento = Convert.ToDateTime(txtDataEnvio.Text);

                    historico.TIPO = 4;
                    historico.CODIGO_CAMERA = numeroCamera;
                    historico.EMPRESA_MANUTENCAO = empresa;
                    historico.NUMERO_RASTREIO = numeroRastreio;
                    historico.OBSERVACAO = observacao;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.DATA_ENVIO = dataEnvio;
                    historico.DATA_RECEBIMENTO = dataRecebimento;
                    historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;

                    bllHistorico.InserirHistoricoCamera(historico);

                    BLLCameras bllCamera = new BLLCameras();
                    if (cmbFuncionario.SelectedIndex == -1)
                        bllCamera.UpdateStatusCamera(numeroCamera, "DISPONÍVEL", "");
                    else
                        bllCamera.UpdateStatusCamera(numeroCamera, "EM ESTOQUE", cmbFuncionario.SelectedValue.ToString());

                    MessageBox.Show("Recebimento de câmera em manutenção inserido com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimparCampos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarEmpresas()
        {
            BLLEmpresaManutencao bllEmpresa = new BLLEmpresaManutencao();
            List<EMPRESAS> empresas = bllEmpresa.GetEmpresas("");

            cmbEmpresa.DataSource = empresas.OrderBy(e => e.DESCRICAO).AsQueryable().ToList();
            cmbEmpresa.DisplayMember = "DESCRICAO";
            cmbEmpresa.ValueMember = "CODIGO_EMPRESA";
            cmbEmpresa.SelectedIndex = -1;
        }
    }
}
