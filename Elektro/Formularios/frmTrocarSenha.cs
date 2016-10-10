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
using Utilitarios;

namespace Elektro.Formularios
{
    public partial class frmTrocarSenha : Form
    {
        private USUARIOS _usuario;

        public frmTrocarSenha()
        {
            InitializeComponent();
        }

        public frmTrocarSenha(USUARIOS usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtSenhaAntiga.Text = "";
            txtSenhaNova.Text = "";
            txtRepetirSenha.Text = "";
        }

        private void frmTrocarSenha_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = _usuario.prontuario_usuario;
            txtUsuario.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    if (txtSenhaNova.Text.Length >= 6)
                    {
                        ClassesAuxiliares ca = new ClassesAuxiliares();

                        if (txtSenhaAntiga.Text != ca.Descriptografar(_usuario.senha_usuario))
                            throw new Exception("Senha antiga está incorreta.");

                        if (txtSenhaNova.Text != txtRepetirSenha.Text)
                            throw new Exception("Confirmação de senha está incorreta.");

                        BLLUsuarios bllUsuario = new BLLUsuarios();
                        bllUsuario.TrocarSenha(_usuario.prontuario_usuario, ca.Criptografar(txtSenhaNova.Text));

                        MessageBox.Show("Senha alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A senha deve conter no mínimo 6 dígitos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidaCampos()
        {
            if ((txtSenhaAntiga.Text == "") || (txtSenhaNova.Text == "") || (txtRepetirSenha.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
