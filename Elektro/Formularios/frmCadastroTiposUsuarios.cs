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
using Modelo;

namespace Elektro.Formularios
{
    public partial class frmCadastroTiposUsuarios : Form
    {
        private int _processo;
        private TipoUsuario _perfil;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroTiposUsuarios()
        {
            InitializeComponent();
        }

        public frmCadastroTiposUsuarios(TipoUsuario perfil)
        {
            _perfil = new TipoUsuario();
            _perfil = perfil;
            InitializeComponent();
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void frmCadastroTiposUsuarios_Load(object sender, EventArgs e)
        {
            if (_processo == 0)
            {
                LimparCampos();
            }
            else
            {
                txtDescricao.Text = _perfil.DescricaoTipoUsuario;
                toolStripButton2.Enabled = false;
            }
        }

        private bool ValidaCampos()
        {
            if (txtDescricao.Text == "")
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
                BLLTiposUsuarios tiposusuarios = new BLLTiposUsuarios();
                TipoUsuario tipousuario = new TipoUsuario();
                tipousuario.DescricaoTipoUsuario = txtDescricao.Text;

                tiposusuarios.InsertTiposUsuarios(tipousuario);

                MessageBox.Show("Usuário " + txtDescricao.Text + " incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLTiposUsuarios tiposusuarios = new BLLTiposUsuarios();
                _perfil.DescricaoTipoUsuario = txtDescricao.Text;

                tiposusuarios.UpdateTiposUsuarios(_perfil);

                MessageBox.Show("Usuário " + txtDescricao.Text + " alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
