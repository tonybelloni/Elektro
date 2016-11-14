using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using CamadaControle;
using Utilitarios;

namespace Elektro.Formularios
{
    public partial class frmLogin : Form
    {
        private frmMain parent;

        public frmLogin(frmMain main)
        {
            InitializeComponent();
            parent = main;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                btnEntrar.Enabled = false;
                progressBar1.Value = 50;
                label3.Visible = true;
                BLLUsuarios usuarios = new BLLUsuarios();
                CamadaDados.USUARIOS usuario = new CamadaDados.USUARIOS();

                usuario = usuarios.GetUsuario(txtProntuario.Text);
                if (usuario != null)
                {
                    if (ValidarCampos())
                    {
                        progressBar1.Value = 75;
                        if (ValidarUsuario(usuario))
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            parent.Usuario = usuario;
                            this.Close();
                        }
                        else
                        {
                            btnEntrar.Enabled = true;
                            progressBar1.Value = 0;
                            label3.Visible = false;
                        }
                    }
                    else
                    {
                        btnEntrar.Enabled = true;
                        progressBar1.Value = 0;
                        label3.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário inválido !", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEntrar.Enabled = true;
                    progressBar1.Value = 0;
                    label3.Visible = false;
                    txtProntuario.Text = "";
                    txtSenha.Text = "";
                    txtProntuario.Focus();
                }
            }
            catch (Exception ex)
            {
                btnEntrar.Enabled = true;
                progressBar1.Value = 0;
                label3.Visible = false;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if ( ( txtProntuario.Text == "" ) || (txtSenha.Text == "") )
            {
                MessageBox.Show("Todos os campos devem ser informados", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProntuario.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidarUsuario(CamadaDados.USUARIOS usuario)
        {
           if (usuario.prontuario_usuario == null)
            {
                MessageBox.Show("Usuário não existe", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProntuario.Focus();
                return false;
            }
            else
            {
                ClassesAuxiliares ca = new ClassesAuxiliares();

                if (txtSenha.Text != ca.Descriptografar(usuario.senha_usuario))
                {
                    MessageBox.Show("Senha Inválida", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSenha.Focus();
                    return false;
                }

                if (usuario.ativo == 0)
                {
                    MessageBox.Show("Usuário desativado. Entre em contato com o administrador do sistema.", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtProntuario.Text = "";
            txtSenha.Text = "";
            txtProntuario.Focus();
            label3.Visible = false;
        }
    }
}
