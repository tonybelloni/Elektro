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
    public partial class frmEnviarCameraFuncionario : Form
    {
        private USUARIOS _usuario;
        private MOVIMENTACAO_CAMERA _movimentacao;
        private CAMERAS _camera;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmEnviarCameraFuncionario()
        {
            InitializeComponent();
        }

        public frmEnviarCameraFuncionario(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void frmEnviarCameraFuncionario_Load(object sender, EventArgs e)
        {
            txtDataAlocacao.Text = DateTime.Now.ToShortDateString();

            CarregarFuncionarios();
            txtCamera.Text = _camera.codigo_camera.ToString();
            txtCamera.Enabled = false;
            label2.Text = "Data Alocação";
           
        }

        private void CarregarFuncionarios()
        {
            try
            {
                BLLFuncionarios func = new BLLFuncionarios();
                List<FUNCIONARIOS> funcionarios = func.GetFuncionarios("");

                if (funcionarios.Count > 1)
                {
                    cmbEquipe.DataSource = funcionarios;
                    cmbEquipe.DisplayMember = "prontuario";
                    cmbEquipe.ValueMember = "prontuario";
                    cmbEquipe.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao recuperar funcionários !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                { 
                   BLLCameras bllCameras = new BLLCameras();
                   CAMERAS camera = bllCameras.GetCamera(_camera.codigo_camera.ToString());
                
                   bllCameras.AlocarCameraFuncionario(camera, cmbEquipe.SelectedValue.ToString());

                    BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                    HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();
                    
                    historico.CODIGO_CAMERA = txtCamera.Text;
                    historico.OBSERVACAO = txtObservacao.Text;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                    historico.DATA_ALOCACAO = Convert.ToDateTime(txtDataAlocacao.Text);
                    historico.PRONTUARIO = cmbEquipe.SelectedValue.ToString();

                    bllHistorico.InserirHistoricoCamera(historico);

                    MessageBox.Show("Câmera enviada para funcionário com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbEquipe.SelectedIndex == -1)
                return false;

            if (String.IsNullOrEmpty(txtCamera.Text))
                return false;

            if (String.IsNullOrEmpty(txtDataAlocacao.Text))
                return false;

            if (String.IsNullOrEmpty(txtObservacao.Text))
                return false;

            return true;
        }
    }
}
