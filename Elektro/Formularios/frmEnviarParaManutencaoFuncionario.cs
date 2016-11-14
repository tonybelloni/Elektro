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
    public partial class frmEnviarParaManutencaoFuncionario : Form
    {
        private CAMERAS _camera;

        public USUARIOS Usuario { get; set; }

        public frmEnviarParaManutencaoFuncionario()
        {
            InitializeComponent();
        }

        public frmEnviarParaManutencaoFuncionario(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void frmEnviarParaManutencaoFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarEmpresas();
                txtDataEnvio.Text = DateTime.Now.ToShortDateString();

                txtCamera.Text = _camera.codigo_camera;
                txtCamera.Enabled = false;
                cmbTipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        private void CarregarEmpresas()
        {
            BLLEmpresaManutencao bllEmpresa = new BLLEmpresaManutencao();
            List<EMPRESAS> empresas = bllEmpresa.GetEmpresas("");

            cmbEmpresa.DataSource = empresas.OrderBy(e => e.DESCRICAO).AsQueryable().ToList();
            cmbEmpresa.DisplayMember = "DESCRICAO";
            cmbEmpresa.ValueMember = "CODIGO_EMPRESA";
            cmbEmpresa.SelectedIndex = -1;
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 0)
            {
                cmbEmpresa.Enabled = true;
                txtNumeroProtocolo.Enabled = true;
            }
            else
            {
                cmbEmpresa.Enabled = false;
                txtNumeroProtocolo.Enabled = false;
            }
            cmbEmpresa.SelectedIndex = -1;
            txtNumeroProtocolo.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cmbEmpresa.SelectedIndex = -1;
            cmbTipo.SelectedIndex = 0;
            txtNumeroProtocolo.Text = "";
            txtObservacao.Text = "";
            cmbEmpresa.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string status;
                    BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                    HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                    if (cmbTipo.SelectedIndex == 0)
                        status = "MANUTENÇÃO";
                    else
                        status = "MANUTENÇÃO LOCAL";

                    DateTime dataEnvio = Convert.ToDateTime(txtDataEnvio.Text);

                    historico.TIPO = 3;
                    historico.CODIGO_CAMERA = txtCamera.Text;
                    
                    if (cmbTipo.SelectedIndex == 0)
                    {
                        historico.NUMERO_RASTREIO = txtNumeroProtocolo.Text;
                        historico.EMPRESA_MANUTENCAO = Convert.ToInt32(cmbEmpresa.SelectedValue.ToString());
                    }
                    
                    historico.PRONTUARIO = _camera.PRONTUARIO;
                    historico.OBSERVACAO = txtObservacao.Text;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.DATA_ENVIO = dataEnvio;
                    historico.USUARIO_REGISTRO = Usuario.prontuario_usuario;
                    historico.PRONTUARIO = _camera.PRONTUARIO;

                    bllHistorico.InserirHistoricoCamera(historico);

                    BLLCameras bllCamera = new BLLCameras();
                    bllCamera.UpdateStatusCamera(txtCamera.Text, status, _camera.PRONTUARIO);

                    MessageBox.Show("Envio de câmera para manutenção realizado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbTipo.SelectedIndex == 0)
            {
                if (cmbEmpresa.SelectedIndex == -1)
                    return false;

                if (String.IsNullOrEmpty(txtNumeroProtocolo.Text))
                    return false;
            }

            if (String.IsNullOrEmpty(txtDataEnvio.Text))
                return false;

            if (String.IsNullOrEmpty(txtObservacao.Text))
                return false;

            return true;
        }
    }
}
