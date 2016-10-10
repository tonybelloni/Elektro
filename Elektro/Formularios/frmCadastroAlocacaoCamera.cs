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
    public partial class frmCadastroAlocacaoCamera : Form
    {
        private USUARIOS _usuario;
        private MOVIMENTACAO_CAMERA _movimentacao;
        private CAMERAS _camera;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmCadastroAlocacaoCamera()
        {
            InitializeComponent();
        }

        public frmCadastroAlocacaoCamera(MOVIMENTACAO_CAMERA movimentacao)
        {
            _movimentacao = movimentacao;
            InitializeComponent();
        }

        public frmCadastroAlocacaoCamera(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void frmCadastroMovimentacaoCamera_Load(object sender, EventArgs e)
        {
            txtDataAlocacao.Text = DateTime.Now.ToShortDateString();

            if (_camera.STATUS == "DISPONÍVEL")
            {
                CarregarCameras(1);
                CarregarEquipes(1);
                cmbNumeroCamera.SelectedValue = _camera.codigo_camera;
                cmbNumeroCamera.Enabled = false;
                label2.Text = "Data Alocação";
            }
            else
            {
                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                string siglaEquipe = bllHistorico.GetHistoricosCameras(_camera.codigo_camera).Where(l => l.TIPO == 1).LastOrDefault().SIGLA_EQUIPE;

                CarregarCameras(2);
                CarregarEquipes(2);
                cmbNumeroCamera.Enabled = false;
                cmbEquipe.Enabled = false;
                cmbNumeroCamera.SelectedValue = _camera.codigo_camera;
                cmbNumeroCamera.Enabled = false;
                cmbEquipe.SelectedValue = siglaEquipe;
                cmbEquipe.Enabled = false;

                label2.Text = "Data Desvinculação";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            cmbNumeroCamera.SelectedIndex = -1;
            cmbEquipe.SelectedIndex = -1;
            txtDataAlocacao.Text = DateTime.Now.ToShortDateString();
            txtObservacao.Text = "";
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

        private bool ValidarCampos()
        {
            if ((cmbNumeroCamera.SelectedIndex == -1) || (cmbEquipe.SelectedIndex == -1) || (txtDataAlocacao.Text.Trim() == "") || (txtObservacao.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Incluir()
        {
            try
            {
                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                if (_camera.STATUS == "DISPONÍVEL" || _camera.STATUS == "EM ESTOQUE")
                {
                    string numeroCamera = cmbNumeroCamera.SelectedValue.ToString();
                    string equipe = cmbEquipe.SelectedValue.ToString();
                    string observacao = txtObservacao.Text;
                    DateTime dataAlocacao = Convert.ToDateTime(txtDataAlocacao.Text);

                    historico.TIPO = 1;
                    historico.CODIGO_CAMERA = numeroCamera;
                    historico.SIGLA_EQUIPE = equipe;
                    historico.OBSERVACAO = observacao;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                    historico.DATA_ALOCACAO = dataAlocacao;

                    bllHistorico.InserirHistoricoCamera(historico);

                    BLLCameras bllCamera = new BLLCameras();
                    bllCamera.UpdateStatusCamera(numeroCamera, "ALOCADA", "");

                    BLLEquipes bllEquipe = new BLLEquipes();
                    bllEquipe.UpdateStatusEquipe(equipe, numeroCamera);

                    CarregarCameras(1);
                    CarregarEquipes(1);

                    MessageBox.Show("Alocação realizada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string numeroCamera = cmbNumeroCamera.SelectedValue.ToString();
                    string equipe = cmbEquipe.SelectedValue.ToString();
                    string observacao = txtObservacao.Text;
                    DateTime dataDesalocacao = Convert.ToDateTime(txtDataAlocacao.Text);
                    DateTime dataAlocacao = bllHistorico.GetHistoricosCameras(numeroCamera).Where(l => l.TIPO == 1).LastOrDefault().DATA_ALOCACAO.Value;

                    historico.TIPO = 2;
                    historico.CODIGO_CAMERA = numeroCamera;
                    historico.SIGLA_EQUIPE = equipe;
                    historico.OBSERVACAO = observacao;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                    historico.DATA_ALOCACAO = dataAlocacao; 
                    historico.DATA_DESALOCAO = dataDesalocacao;

                    bllHistorico.InserirHistoricoCamera(historico);

                    BLLCameras bllCamera = new BLLCameras();
                    bllCamera.UpdateStatusCamera(numeroCamera, "DISPONÍVEL", "");

                    BLLEquipes bllEquipe = new BLLEquipes();
                    bllEquipe.UpdateStatusEquipe(equipe, null);

                    CarregarCameras(2);
                    CarregarEquipes(2);

                    MessageBox.Show("Câmera desvinculada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimparCampos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarCameras(int tipo)
        {
            if (tipo == 1)
            {
                BLLCameras bllCamera = new BLLCameras();
                List<CAMERAS> cameras = bllCamera.GetCamerasDesalocadas();

                cmbNumeroCamera.DataSource = null;
                cmbNumeroCamera.DataSource = cameras;
                cmbNumeroCamera.DisplayMember = "codigo_camera";
                cmbNumeroCamera.ValueMember = "codigo_camera";
                cmbNumeroCamera.SelectedIndex = -1;
            }
            else
            {
                BLLCameras bllCamera = new BLLCameras();
                List<CAMERAS> cameras = bllCamera.GetCamerasAlocadas();

                cmbNumeroCamera.DataSource = null;
                cmbNumeroCamera.DataSource = cameras;
                cmbNumeroCamera.DisplayMember = "codigo_camera";
                cmbNumeroCamera.ValueMember = "codigo_camera";
                cmbNumeroCamera.SelectedIndex = -1;
            }
        }

        public void CarregarEquipes(int tipo)
        {
            if (tipo == 1)
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipesSemAlocacaoCamera();

                cmbEquipe.DataSource = null;
                cmbEquipe.DataSource = equipes;
                cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
                cmbEquipe.ValueMember = "SIGLA_EQUIPE";
                cmbEquipe.SelectedIndex = -1;
            }
            else
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipesComAlocacaoCamera();

                cmbEquipe.DataSource = null;
                cmbEquipe.DataSource = equipes;
                cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
                cmbEquipe.ValueMember = "SIGLA_EQUIPE";
                cmbEquipe.SelectedIndex = -1;
            }
        }
    }
}
