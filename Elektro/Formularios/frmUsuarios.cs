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
    public partial class frmUsuarios : Form
    {
        private int currentMouseOverRow;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLUsuarios bllUsuario = new BLLUsuarios();
                var lista = bllUsuario.GetUsuarios(txtPesquisa.Text);

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.prontuario_usuario,
                        l.nome_usuario,
                        l.senha_usuario,
                        l.email_usuario,
                        l.TIPOS_USUARIOS.descricao_tipo_usuario,
                        ATIVO = l.ativo == 1 ? "SIM" : "NÃO",
                        NOME_FUNCIONARIO = l.PRONTUARIO != null ? l.FUNCIONARIOS.nome_funcionario : ""
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Prontuário";
                    dataGridView1.Columns[1].HeaderText = "Nome";
                    dataGridView1.Columns[2].HeaderText = "Senha";
                    dataGridView1.Columns[3].HeaderText = "Email";
                    dataGridView1.Columns[4].HeaderText = "Perfil";
                    dataGridView1.Columns[5].HeaderText = "Ativo";
                    dataGridView1.Columns[6].HeaderText = "Funcionário";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum Usuário Encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroUsuarios incluirusuario = new frmCadastroUsuarios();
            incluirusuario.Processo = 0;
            incluirusuario.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems[0].Click += new EventHandler(EditarUsuarios);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        private void EditarUsuarios(object sender, EventArgs e)
        {
            BLLUsuarios bllUsuario = new BLLUsuarios();
            USUARIOS usuario = bllUsuario.GetUsuario(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroUsuarios frm = new frmCadastroUsuarios(usuario);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }
    }
}
