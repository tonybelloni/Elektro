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
    public partial class frmCadastroCameras : Form
    {
        private int _processo;
        private CAMERAS _camera;
        private frmCameras _frm;
        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroCameras()
        {
            InitializeComponent();
        }

        public frmCadastroCameras(CAMERAS camera)
        {
            InitializeComponent();
            _camera = new CAMERAS();
            _camera = camera;
        }

        public frmCadastroCameras(CAMERAS camera, frmCameras frm)
        {
            InitializeComponent();
            _camera = new CAMERAS();
            _camera = camera;
            _frm = frm;
        }

        private void frmCadastroCameras_Load(object sender, EventArgs e)
        {
            CarregaEmpresas();

            if (_processo == 0)
            {
                txtCodigo.Text = "";
                txtBPM.Text = "";
                txtCodBarra.Text = "";
                cmbAtivo.SelectedIndex = -1;
            }
            else
            {
                txtCodigo.Text = _camera.codigo_camera;
                txtBPM.Text = _camera.bpm_camera;
                txtCodBarra.Text = _camera.codigo_barra_camera;
                cmbAtivo.SelectedIndex = _camera.ativo;
                
                if ( _camera.CODIGO_EMPRESA != null)
                {
                   cmbEmpresa.SelectedValue = _camera.CODIGO_EMPRESA;
                }
                else
                {
                    cmbEmpresa.SelectedValue = -1;
                }
                txtDataAquisicao.Text = _camera.DATA_AQUISICAO.HasValue ? _camera.DATA_AQUISICAO.Value.ToShortDateString() : "";
                txtCodigo.Enabled = false;
                toolStripButton2.Enabled = false;
            }
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtBPM.Text = "";
            txtCodBarra.Text = "";
            cmbAtivo.SelectedIndex = -1;
            cmbEmpresa.SelectedIndex = -1;
            txtDataAquisicao.Text = DateTime.Now.ToShortDateString();
            txtCodigo.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (_processo == 0)
                {
                    Incluir();
                }
                else
                {
                    Alterar();
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if ((txtCodigo.Text == "") || (txtCodBarra.Text == "") || (cmbAtivo.SelectedIndex < 0) )
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
                BLLCameras cameras = new BLLCameras();
                CAMERAS camera = new CAMERAS();

                camera.codigo_camera = txtCodigo.Text;
                camera.codigo_barra_camera = txtCodBarra.Text;
                if (txtBPM.Text.Trim() != "")
                    camera.bpm_camera = txtBPM.Text;
                camera.DATA_AQUISICAO = Convert.ToDateTime(txtDataAquisicao.Text);
                camera.STATUS = "DISPONÍVEL";
                if (cmbEmpresa.SelectedIndex != -1)
                    camera.CODIGO_EMPRESA = Convert.ToInt32(cmbEmpresa.SelectedValue);


                if (cmbAtivo.SelectedIndex == 1)
                {
                    camera.ativo = 1;
                }
                else
                {
                    camera.ativo = 0;
                }

                cameras.InsertCamera(camera);

                MessageBox.Show("Câmera " + txtCodigo.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Alterar()
        {
            try
            {
                BLLCameras cameras = new BLLCameras();
                CAMERAS camera = new CAMERAS();

                camera.codigo_camera = txtCodigo.Text;
                camera.codigo_barra_camera = txtCodBarra.Text;
                if (txtBPM.Text.Trim() != "")
                    camera.bpm_camera = txtBPM.Text;
                camera.DATA_AQUISICAO = Convert.ToDateTime(txtDataAquisicao.Text);
                if (cmbEmpresa.SelectedIndex != -1)
                    camera.CODIGO_EMPRESA = Convert.ToInt32(cmbEmpresa.SelectedValue);

                if (cmbAtivo.SelectedIndex == 1)
                {
                    camera.ativo = 1;
                }
                else
                {
                    camera.ativo = 0;
                }

                cameras.UpdateCamera(camera);

                MessageBox.Show("Câmera " + txtCodigo.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //_frm.Pesquisar();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregaEmpresas()
        {
            BLLEmpresaManutencao bllEmpresa = new BLLEmpresaManutencao();
            List<EMPRESAS> empresas = new List<EMPRESAS>();

            empresas = bllEmpresa.GetEmpresas("");

            cmbEmpresa.DataSource = empresas.OrderBy(l => l.DESCRICAO).ToList();
            cmbEmpresa.DisplayMember = "DESCRICAO";
            cmbEmpresa.ValueMember = "CODIGO_EMPRESA";
            cmbEmpresa.SelectedIndex = -1;
        }
    }
}
