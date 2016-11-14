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
    
    public partial class frmValidarOcorrencia : Form
    {
        private USUARIOS _usuario;
        private REGISTRO_OCORRENCIAS _registro;
        private int _tipoOcorrencia;

        public int TipoOcorrencia
        {
            get { return _tipoOcorrencia; }
            set { _tipoOcorrencia = value;  }
        }

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmValidarOcorrencia()
        {
            InitializeComponent();
        }

        public frmValidarOcorrencia(REGISTRO_OCORRENCIAS registro)
        {
            InitializeComponent();
            _registro = registro;
        }

        private bool ValidarCampos()
        {
            if (_tipoOcorrencia == 0)
            {
                if ((!chkProcede.Checked && !chkNaoProcede.Checked && !chkAnaliseInadequada.Checked) || (cmbNaoConformidade.SelectedIndex == -1) || (txtObservacaoValidacao.Text == ""))
                    return false;
                else
                    return true;
            }
            else
            {
                if ((!chkProcede.Checked && !chkNaoProcede.Checked && !chkAnaliseInadequada.Checked) || (txtObservacaoValidacao.Text == ""))
                    return false;
                else
                    return true;
            }
        }

        private void frmValidarOcorrencia_Load(object sender, EventArgs e)
        {
            try
            {
                cmbNaoConformidade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
                BLLTiposOcorrencia bllTipoOcorrencia = new BLLTiposOcorrencia();
                cmbNaoConformidade.DataSource = bllTipoOcorrencia.GetTiposOcorrencia("").OrderBy(l => l.DESCRICAO).ToList();
                cmbNaoConformidade.DisplayMember = "DESCRICAO";
                cmbNaoConformidade.ValueMember = "ID_TIPO";
                cmbNaoConformidade.SelectedIndex = -1;

                txtEquipe.Enabled = false;
                txtEquipe.Text = _registro.SIGLA_EQUIPE;
                txtCamera.Enabled = false;
                txtCamera.Text = _registro.EQUIPES.CODIGO_CAMERA;
                txtVeiculo.Enabled = false;
                txtVeiculo.Text = _registro.EQUIPES.PLACA_VEICULO;
                txtDataInicial.Enabled = false;
                txtDataInicial.Text = _registro.DATA_INICIAL.ToString();
                txtDataFinal.Enabled = false;
                txtDataFinal.Text = _registro.DATA_FINAL.ToString();
                txtUsuario.Enabled = false;
                if (_registro.SORTEADOS.USUARIO_VISUALIZACAO == null)
                {
                    txtUsuario.Text = "";
                }
                else
                {
                    txtUsuario.Text = _registro.SORTEADOS.USUARIO_VISUALIZACAO;
                }
                chkProcede.Checked = true;
                chkNaoProcede.Checked = false;
                chkAnaliseInadequada.Checked = false;
                cmbNaoConformidade.Enabled = false;
                if ( _registro.CODIGO_TIPO_OCORRENCIA == null )
                {
                    cmbNaoConformidade.SelectedIndex = -1;
                }
                else
                {
                    cmbNaoConformidade.SelectedValue = _registro.CODIGO_TIPO_OCORRENCIA;
                }
                txtObservacao.Enabled = false;
                if (_registro.OBSERVACAO == null)
                {
                    txtObservacao.Text = "";
                }
                else
                {
                    txtObservacao.Text = _registro.OBSERVACAO;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                    int codigo = chkNaoProcede.Checked ? 0 : Convert.ToInt32(cmbNaoConformidade.SelectedValue);
                    bllRegistroOcorrencia.ValidarRegistroOcorrencia(_registro.CODIGO_REGISTRO_OCORRENCIA, codigo, _usuario.prontuario_usuario, txtObservacaoValidacao.Text);

                    MessageBox.Show("Validação de ocorrência realizada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkProcede_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProcede.Checked)
            {
                chkNaoProcede.Checked = false;
                chkAnaliseInadequada.Checked = false;
                cmbNaoConformidade.Enabled = false;
                if (_registro.CODIGO_TIPO_OCORRENCIA == null)
                {
                    cmbNaoConformidade.SelectedIndex = -1;
                }
                else
                {
                    cmbNaoConformidade.SelectedValue = _registro.CODIGO_TIPO_OCORRENCIA;
                }
            }
        }

        private void chkNaoProcede_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNaoProcede.Checked)
            {
                chkProcede.Checked = false;
                chkAnaliseInadequada.Checked = false;
                cmbNaoConformidade.Enabled = true;
            }
        }

        private void chkAnaliseInadequada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnaliseInadequada.Checked)
            {
                chkProcede.Checked = false;
                chkNaoProcede.Checked = false;
                cmbNaoConformidade.Enabled = false;
            }
        }

        private void cmbNaoConformidade_DrawItem(object sender, DrawItemEventArgs e)
        {
            System.Drawing.Color cor = new System.Drawing.Color();
            Font fonte = cmbNaoConformidade.Font;
            if (e.Index != -1)
            {
                TIPOS_OCORRENCIAS tipo = (TIPOS_OCORRENCIAS)cmbNaoConformidade.Items[e.Index];
                if (tipo.ID_TIPO == 1)
                {
                    cor = Color.Yellow;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (tipo.ID_TIPO == 2)
                {
                    cor = Color.Orange;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (tipo.ID_TIPO == 3)
                {
                    cor = Color.OrangeRed;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
                else if (tipo.ID_TIPO == 4)
                {
                    cor = Color.Green;
                    e.DrawBackground();
                    Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
                    e.Graphics.FillRectangle(new SolidBrush(cor), rectangle);
                    e.Graphics.DrawString(" " + tipo.DESCRICAO, fonte, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    e.DrawFocusRectangle();
                }
            }
        }

        private void btiEquipe_Click(object sender, EventArgs e)
        {
            frmVerEscalaCOD frm = new frmVerEscalaCOD();
            frm.Equipe = txtEquipe.Text;
            frm.DataInicial = txtDataInicial.Text;
            frm.DataFinal = txtDataFinal.Text;
            frm.ShowDialog();
        }
    }
}
