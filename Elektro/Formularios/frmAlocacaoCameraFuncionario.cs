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
    public partial class frmAlocacaoCameraFuncionario : Form
    {
        public string Operacao { get; set; }
        public USUARIOS Usuario { get; set; }

        private CAMERAS _camera;

        public frmAlocacaoCameraFuncionario()
        {
            InitializeComponent();
        }

        public frmAlocacaoCameraFuncionario(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void frmAlocacaoCameraFuncionario_Load(object sender, EventArgs e)
        {
            txtDataAlocacao.Text = DateTime.Now.ToShortDateString();
            txtCamera.Text = _camera.codigo_camera.ToString();
            txtCamera.Enabled = false;

            if (Operacao == "ALOCAR")
            {
                CarregaEquipes();
            }
        }
        private void CarregaEquipes()
        {
            try
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipesSemAlocacaoCamera();

                cmbEquipe.DataSource = null;
                cmbEquipe.DataSource = equipes;
                cmbEquipe.DisplayMember = "SIGLA_EQUIPE";
                cmbEquipe.ValueMember = "SIGLA_EQUIPE";
                cmbEquipe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao recuperar equipes", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                    HISTORICOS_CAMERAS historico = new HISTORICOS_CAMERAS();

                    historico.TIPO = 1;
                    historico.CODIGO_CAMERA = txtCamera.Text;
                    historico.SIGLA_EQUIPE = cmbEquipe.SelectedValue.ToString();
                    historico.OBSERVACAO = txtObservacao.Text;
                    historico.DATA_REGISTRO = DateTime.Now;
                    historico.USUARIO_REGISTRO = Usuario.prontuario_usuario;
                    historico.DATA_ALOCACAO = Convert.ToDateTime(txtDataAlocacao.Text);
                    historico.PRONTUARIO = _camera.PRONTUARIO;

                    bllHistorico.InserirHistoricoCamera(historico);

                    BLLCameras bllCamera = new BLLCameras();
                    bllCamera.UpdateStatusCamera(txtCamera.Text, "ALOCADA", _camera.PRONTUARIO);

                    BLLEquipes bllEquipe = new BLLEquipes();
                    bllEquipe.UpdateStatusEquipe(cmbEquipe.SelectedValue.ToString(), txtCamera.Text);

                    MessageBox.Show("Alocação realizada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir alocacao de camera", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtCamera.Text))
                return false;

            if (String.IsNullOrEmpty(txtDataAlocacao.Text))
                return false;

            if (String.IsNullOrEmpty(txtObservacao.Text))
                return false;

            if (cmbEquipe.SelectedIndex == -1)
                return false;

            return true;    
        }
    }
}
