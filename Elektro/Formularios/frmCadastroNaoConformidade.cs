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
    public partial class frmCadastroNaoConformidade : Form
    {
        public int Processo { get; set; }
        public TIPOS_OCORRENCIAS _tipo;

        public frmCadastroNaoConformidade()
        {
            InitializeComponent();
        }

        public frmCadastroNaoConformidade(TIPOS_OCORRENCIAS tipo)
        {
            _tipo = tipo;
            InitializeComponent();
        }

        private void frmCadastroNaoConformidade_Load(object sender, EventArgs e)
        {
            cmbSeveridade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;

            if (this.Processo == 0)
            {
                txtDescricao.Text = "";
                cmbSeveridade.SelectedIndex = 0;
            }
            else
            {
                txtDescricao.Text = _tipo.DESCRICAO;
                cmbSeveridade.SelectedIndex = _tipo.GRAVIDADE.Value;

                toolStripButton2.Enabled = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            cmbSeveridade.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if ((txtDescricao.Text == "") || (cmbSeveridade.SelectedIndex == 0) )
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
            if (ValidarCampos())
            {
                if (this.Processo == 0)
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

        private void Incluir()
        {
            try
            {
                BLLTiposOcorrencia bllTipoOcorrencia = new BLLTiposOcorrencia();
                TIPOS_OCORRENCIAS t = new TIPOS_OCORRENCIAS();

                t.DESCRICAO = txtDescricao.Text;
                t.GRAVIDADE = cmbSeveridade.SelectedIndex;

                bllTipoOcorrencia.InsertTipoOcorrencia(t);

                MessageBox.Show("Tipo de Ocorrência " + txtDescricao.Text + " incluída com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BLLTiposOcorrencia bllTipoOcorrencia = new BLLTiposOcorrencia();

                bllTipoOcorrencia.UpdateAtividade(_tipo.ID_TIPO, cmbSeveridade.SelectedIndex, txtDescricao.Text);

                MessageBox.Show("Tipo de Ocorrência " + txtDescricao.Text + " alterada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSeveridade_DrawItem(object sender, DrawItemEventArgs e)
        {
            System.Drawing.Color cor = new System.Drawing.Color();
            Font fonte = cmbSeveridade.Font;
            if (e.Index == 1)
            {
                cor = Color.Yellow;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Moderado", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 2)
            {
                cor = Color.Orange;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Grave", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 3)
            {
                cor = Color.OrangeRed;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Intolerável", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 4)
            {
                cor = Color.Green;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Positivo", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
            else if (e.Index == 5)
            {
                cor = Color.LightGray;
                e.DrawBackground();
                Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                e.Graphics.DrawString(" Não Posicionamento", fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
        }
    }
}
