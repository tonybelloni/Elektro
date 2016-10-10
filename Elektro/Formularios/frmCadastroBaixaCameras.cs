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
    public partial class frmCadastroBaixaCameras : Form
    {
        private USUARIOS _usuario;
        private CAMERAS _camera;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmCadastroBaixaCameras()
        {
            InitializeComponent();
        }

        public frmCadastroBaixaCameras(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void frmCadastrarBaixaCameras_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCameras();
                txtDataBaixa.Text = DateTime.Now.ToShortDateString();
                cmbNumeroCamera.SelectedValue = _camera.codigo_camera;
                cmbNumeroCamera.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if ((cmbNumeroCamera.SelectedIndex == -1) || (txtDataBaixa.Text.Trim() == "") || (txtMotivo.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Incluir()
        {
            try
            {
                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                string numeroCamera = cmbNumeroCamera.SelectedValue.ToString();
                string motivo = txtMotivo.Text;
                DateTime dataBaixa = Convert.ToDateTime(txtDataBaixa.Text);

                historico.TIPO = 5;
                historico.CODIGO_CAMERA = numeroCamera;
                historico.OBSERVACAO = motivo;
                historico.DATA_REGISTRO = DateTime.Now;
                historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                historico.DATA_BAIXA = dataBaixa;

                bllHistorico.InserirHistoricoCamera(historico);

                BLLCameras bllCamera = new BLLCameras();
                bllCamera.UpdateStatusCamera(numeroCamera, "INUTILIZADA", "");

                MessageBox.Show("Inutilização de câmera realizada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarCameras()
        {
            BLLCameras bllCamera = new BLLCameras();
            List<CAMERAS> cameras = bllCamera.GetCamerasDesalocadas();
            List<CAMERAS> camerasManutencao = bllCamera.GetCamerasEmManutencao();
            cameras.AddRange(camerasManutencao);

            cmbNumeroCamera.DataSource = null;
            cmbNumeroCamera.DataSource = cameras;
            cmbNumeroCamera.DisplayMember = "codigo_camera";
            cmbNumeroCamera.ValueMember = "codigo_camera";
            cmbNumeroCamera.SelectedIndex = -1;
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
    }
}
