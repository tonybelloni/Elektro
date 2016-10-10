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
    public partial class frmEditarPermissoes : Form
    {
        private int _codigoTipoPermissao;

        public frmEditarPermissoes()
        {
            InitializeComponent();
        }

        public frmEditarPermissoes(int codigoTipoPermissao)
        {
            _codigoTipoPermissao = codigoTipoPermissao;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCadastro.Checked)
            {
                for (int i = 0; i < ckblCadastro.Items.Count; i++)
                {
                    ckblCadastro.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ckblCadastro.Items.Count; i++)
                {
                    ckblCadastro.SetItemChecked(i, false);
                }
            }
        }

        private void ckbOperacional_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbOperacional.Checked)
            {
                for (int i = 0; i < ckblOperacional.Items.Count; i++)
                {
                    ckblOperacional.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ckblOperacional.Items.Count; i++)
                {
                    ckblOperacional.SetItemChecked(i, false);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                BLLPermissoesUsuario bllPermissao = new BLLPermissoesUsuario();

                for(int i = 0; i < 18; i++)
                {
                    bllPermissao.EditarPermissao(_codigoTipoPermissao, 1, i + 1, ckblCadastro.GetItemChecked(i));
                }

                for (int i = 0; i < 3; i++)
                {
                    bllPermissao.EditarPermissao(_codigoTipoPermissao, 2, i + 1, ckblOperacional.GetItemChecked(i));
                }

                for (int i = 0; i < 5; i++)
                {
                    bllPermissao.EditarPermissao(_codigoTipoPermissao, 3, i + 1, ckblGestao.GetItemChecked(i));
                }

                for (int i = 0; i < 4; i++)
                {
                    bllPermissao.EditarPermissao(_codigoTipoPermissao, 4, i + 1, ckblGestao.GetItemChecked(i));
                }

                MessageBox.Show("Permissões editadas com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEditarPermissoes_Load(object sender, EventArgs e)
        {
            BLLTiposUsuarios bllTipoUsuario = new BLLTiposUsuarios();
            this.Text = "Editar Permissões de " + bllTipoUsuario.GetTipoUsuarioById(_codigoTipoPermissao).descricao_tipo_usuario;
            CarregaPermissoes();
        }

        private void ckbGestao_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbGestao.Checked)
            {
                for (int i = 0; i < ckblGestao.Items.Count; i++)
                {
                    ckblGestao.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ckblGestao.Items.Count; i++)
                {
                    ckblGestao.SetItemChecked(i, false);
                }
            }
        }

        public void CarregaPermissoes()
        {
            BLLPermissoesUsuario bllPermissao = new BLLPermissoesUsuario();
            List<PERMISSOES_USUARIO> permissoes = bllPermissao.GetPermissoes(_codigoTipoPermissao);

            if (permissoes.Count() > 0)
            {
                if (permissoes.Where(l => l.ID_MENU == 1).Count() == 18)
                {
                    ckbCadastro.Checked = true;
                }
                else
                {
                    var cadastros = permissoes.Where(l => l.ID_MENU == 1).AsQueryable().ToList();
                    foreach(PERMISSOES_USUARIO p in cadastros)
                    {
                        ckblCadastro.SetItemChecked(p.ID_SUBMENU - 1, true);
                    }
                }

                if (permissoes.Where(l => l.ID_MENU == 2).Count() == 3)
                {
                    ckbOperacional.Checked = true;
                }
                else
                {
                    var operacionais = permissoes.Where(l => l.ID_MENU == 2).AsQueryable().ToList();
                    foreach (PERMISSOES_USUARIO p in operacionais)
                    {
                        ckblOperacional.SetItemChecked(p.ID_SUBMENU - 1, true);
                    }
                }

                if (permissoes.Where(l => l.ID_MENU == 3).Count() == 5)
                {
                    ckbGestao.Checked = true;
                }
                else
                {
                    var gerenciais = permissoes.Where(l => l.ID_MENU == 3).AsQueryable().ToList();
                    foreach (PERMISSOES_USUARIO p in gerenciais)
                    {
                        ckblGestao.SetItemChecked(p.ID_SUBMENU - 1, true);
                    }
                }

                if (permissoes.Where(l => l.ID_MENU == 4).Count() == 4)
                {
                    ckbRelatorio.Checked = true;
                }
                else
                {
                    var relatorios = permissoes.Where(l => l.ID_MENU == 4).AsQueryable().ToList();
                    foreach (PERMISSOES_USUARIO p in relatorios)
                    {
                        ckblRelatorio.SetItemChecked(p.ID_SUBMENU - 1, true);
                    }
                }
            }
        }

        private void ckbRelatorio_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRelatorio.Checked)
            {
                for (int i = 0; i < ckblRelatorio.Items.Count; i++)
                {
                    ckblRelatorio.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ckblRelatorio.Items.Count; i++)
                {
                    ckblRelatorio.SetItemChecked(i, false);
                }
            }
        }
    }

    class Permissao
    {
        public int id { get; set; }
        public bool status { get; set; }
    }
}
