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
using Utilitarios;
using CamadaDados;

namespace Elektro.Formularios
{
    public partial class frmCadastroUsuarios : Form
    {
        private int _processo;
        private USUARIOS _usuario;

        public int Processo
        {
            set { _processo = value; }
        }

        public frmCadastroUsuarios()
        {
            InitializeComponent();
        }

        public frmCadastroUsuarios(USUARIOS usuario)
        {
            InitializeComponent();
            _usuario = new USUARIOS();
            _usuario = usuario;
        }

        private void frmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                BLLTiposUsuarios tipousuario = new BLLTiposUsuarios();
                List<Modelo.TipoUsuario> lista = new List<Modelo.TipoUsuario>();
                ClassesAuxiliares ca = new ClassesAuxiliares();

                lista.Clear();
                lista = tipousuario.GetTiposUsuarios();

                cmbTipo.DataSource = lista;
                cmbTipo.DisplayMember = "DescricaoTipoUsuario";
                cmbTipo.ValueMember = "IdTipoUsuario";
                cmbTipo.SelectedIndex = -1;

                CarregaFuncionarios();
            
                if (_processo == 0)
                {
                   txtProntuario.Focus();
                   cmbAtivo.SelectedIndex = -1;
                }
                else
                {
                   txtProntuario.Text = _usuario.prontuario_usuario;
                   txtNome.Text = _usuario.nome_usuario;
                   txtSenha.Text = ca.Descriptografar(_usuario.senha_usuario);
                   txtRSenha.Text = ca.Descriptografar(_usuario.senha_usuario);
                   txtEmail.Text = _usuario.email_usuario;
                   cmbTipo.SelectedValue = _usuario.id_tipo_usuario;
                   cmbAtivo.SelectedIndex = _usuario.ativo;
                   txtProntuario.Enabled = false;
                   toolStripButton2.Enabled = false;
                    if (_usuario.PRONTUARIO != null)
                    {
                        cmbFuncionario.SelectedValue = _usuario.PRONTUARIO;
                        cmbFuncionario.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtProntuario.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
            txtRSenha.Text = "";
            txtEmail.Text = "";
            cmbAtivo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbFuncionario.SelectedIndex = -1;
            txtProntuario.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private bool ValidaCampos()
        {
            if ((txtProntuario.Text == "") || (txtNome.Text == "") || (txtSenha.Text == "") || (txtRSenha.Text == "") || (txtEmail.Text == "") || (cmbAtivo.SelectedIndex == -1) || (cmbTipo.SelectedIndex == -1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                if (txtSenha.Text.Length >= 6)
                {
                    if (txtSenha.Text == txtRSenha.Text)
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
                        MessageBox.Show("As senhas devem ser iguais", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void Alterar()
        {
            try
            {
                BLLUsuarios usuarios = new BLLUsuarios();
                USUARIOS usuario = new USUARIOS();
                ClassesAuxiliares ca = new ClassesAuxiliares();

                usuario.prontuario_usuario = txtProntuario.Text;
                usuario.nome_usuario = txtNome.Text;
                usuario.senha_usuario = ca.Criptografar(txtSenha.Text);
                usuario.email_usuario = txtEmail.Text;

                if (cmbAtivo.SelectedText == "Sim")
                {
                    usuario.ativo = 1;
                }
                else
                {
                    usuario.ativo = 0;
                }
                usuario.id_tipo_usuario = Convert.ToInt16(cmbTipo.SelectedValue);

                if (cmbFuncionario.SelectedIndex != -1)
                    usuario.PRONTUARIO = cmbFuncionario.SelectedValue.ToString();

                usuarios.UpdateUsuario(usuario);

                MessageBox.Show("Usuário " + txtProntuario.Text + " alterado com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Incluir()
        {
            try
            {
                BLLUsuarios usuarios = new BLLUsuarios();
                USUARIOS usuario = new USUARIOS();
                ClassesAuxiliares ca = new ClassesAuxiliares();

                usuario.prontuario_usuario = txtProntuario.Text;
                usuario.nome_usuario = txtNome.Text;
                usuario.senha_usuario = ca.Criptografar(txtSenha.Text);
                usuario.email_usuario = txtEmail.Text;

                if (cmbAtivo.SelectedText == "Sim")
                {
                    usuario.ativo = 1;
                }
                else
                {
                    usuario.ativo = 0;
                }
                usuario.id_tipo_usuario = Convert.ToInt16(cmbTipo.SelectedValue);

                if (cmbFuncionario.SelectedIndex != -1)
                    usuario.PRONTUARIO = cmbFuncionario.SelectedValue.ToString();

                usuarios.InsertUsuario(usuario);
                MessageBox.Show("Usuário " + txtNome.Text + " incluído com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregaFuncionarios()
        {
            BLLFuncionarios bllFuncionario = new BLLFuncionarios();
            List<FUNCIONARIOS> funcionarios = new List<FUNCIONARIOS>();

            if (_processo == 0)
                funcionarios = bllFuncionario.GetFuncionarios("").Where(f => f.USUARIOS.Count() == 0).AsQueryable().ToList();
            else
                funcionarios = _usuario.PRONTUARIO != null ? bllFuncionario.GetFuncionarios("").Where(f => f.prontuario == _usuario.PRONTUARIO).AsQueryable().ToList() : bllFuncionario.GetFuncionarios("").Where(f => f.USUARIOS.Count() == 0).AsQueryable().ToList();

            cmbFuncionario.DataSource = funcionarios.OrderBy(l => l.nome_funcionario).ToList();
            cmbFuncionario.DisplayMember = "nome_funcionario";
            cmbFuncionario.ValueMember = "prontuario";
            cmbFuncionario.SelectedIndex = -1;
        }

        private void cmbFuncionario_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbFuncionario.SelectedIndex != -1)
            {
                if (_processo == 0)
                {
                    BLLFuncionarios bllFuncionario = new BLLFuncionarios();
                    FUNCIONARIOS funcionario = bllFuncionario.GetFuncionario(cmbFuncionario.SelectedValue.ToString());
                    txtProntuario.Text = cmbFuncionario.SelectedValue.ToString();
                    txtNome.Text = funcionario.nome_funcionario;
                }
            }
        }
    }
}
