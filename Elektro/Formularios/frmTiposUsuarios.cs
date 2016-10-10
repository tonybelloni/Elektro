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
    public partial class frmTiposUsuarios : Form
    {
        private int currentMouseOverRow;

        public frmTiposUsuarios()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCadastroTiposUsuarios frm = new frmCadastroTiposUsuarios();
            frm.Processo = 0;
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                BLLTiposUsuarios usuarios = new BLLTiposUsuarios();
                List<TipoUsuario> lista = new List<TipoUsuario>();

                if (txtPesquisa.Text == "")
                {
                    lista = usuarios.GetTiposUsuarios();
                }
                else
                {
                    lista = usuarios.GetTiposUsuarios(txtPesquisa.Text);
                }

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Código Perfil";
                    dataGridView1.Columns[1].HeaderText = "Descrição do Perfil";
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nenhum Perfil Encontrado", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Editar"));
                m.MenuItems.Add(new MenuItem("Permissões de Menu"));
                m.MenuItems[0].Click += new EventHandler(EditarTiposUsuarios);
                m.MenuItems[1].Click += new EventHandler(EditarPermissoes);
                currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        } 

        private void EditarTiposUsuarios(object sender, EventArgs e)
        {
            TipoUsuario perfil = new TipoUsuario();
            perfil.IdTipoUsuario = (int)dataGridView1.Rows[currentMouseOverRow].Cells[0].Value;
            perfil.DescricaoTipoUsuario = dataGridView1.Rows[currentMouseOverRow].Cells[1].Value.ToString();

            frmCadastroTiposUsuarios frm = new frmCadastroTiposUsuarios(perfil);
            frm.Processo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void EditarPermissoes(object sender, EventArgs e)
        {
            frmEditarPermissoes frm = new frmEditarPermissoes((int)dataGridView1.Rows[currentMouseOverRow].Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
