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
    public partial class frmCadastroMovimentacaoHD : Form
    {
        private USUARIOS _usuario;
        private HD _hd;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmCadastroMovimentacaoHD()
        {
            InitializeComponent();
        }

        public frmCadastroMovimentacaoHD(HD hd)
        {
            InitializeComponent();
            _hd = hd;
        }

        private void frmCadastroMovimentacaoHD_Load(object sender, EventArgs e)
        {
            CarregaLocalidadesOrigem();
            CarregaLocalidadesDestino();
            CarregarHDs();

            txtNumeroProtocolo.Enabled = false;
            cmbResponsavel.Enabled = false;
            cmbNumeroHD.Enabled = false;

            if (_usuario.PRONTUARIO != null)
            {
                cmbOrigem.SelectedValue = _usuario.FUNCIONARIOS.localidade;
                cmbOrigem.Enabled = false;
                if (_usuario.FUNCIONARIOS.localidade != 92)
                {
                    cmbDestino.SelectedValue = 92;
                    cmbDestino.Enabled = false;
                }
            }

            if (_hd.STATUS != "ENVIADO")
            {
                cmbNumeroHD.SelectedValue = _hd.NUMERO_HD;
                txtDataEnvio.Text = DateTime.Now.ToShortDateString();
                txtProvavelDataRecebimento.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                BLLMovimentacaoHD bllMov = new BLLMovimentacaoHD();
                MOVIMENTACAO_HD mov = bllMov.GetMovimentacoesHD(_hd.NUMERO_HD, null, null, 0).Where(f => !f.DATA_CHEGADA.HasValue).FirstOrDefault();
                cmbNumeroHD.SelectedValue = _hd.NUMERO_HD;
                cmbOrigem.SelectedValue = mov.LOCAL_REGISTRO;
                cmbOrigem.Enabled = false;
                cmbDestino.SelectedValue = mov.LOCAL_DESTINO;
                cmbDestino.Enabled = false;
                txtNumeroProtocolo.Text = mov.NUMERO_PROTOCOLO;
                txtNumeroProtocolo.Enabled = false;
                cmbEnvio.SelectedIndex = mov.RESPONSAVEL == null ? 0 : 1;
                cmbEnvio.Enabled = false;
                cmbResponsavel.SelectedValue = mov.RESPONSAVEL;
                cmbResponsavel.Enabled = false;
                toolStripButton2.Enabled = false;
                txtDataEnvio.Text = mov.DATA_ENVIO.Value.ToShortDateString();
                txtDataEnvio.Enabled = false;
                txtProvavelDataRecebimento.Text = mov.DATA_PROVAVEL_RECEBIMENTO.Value.ToShortDateString();
                txtProvavelDataRecebimento.Enabled = false;
            }

            BLLFuncionarios bllFuncionario = new BLLFuncionarios();
            List<FUNCIONARIOS> funcionarios = bllFuncionario.GetFuncionarios("");

            cmbResponsavel.DataSource = funcionarios.OrderBy(f => f.nome_funcionario).ToList();
            cmbResponsavel.DisplayMember = "nome_funcionario";
            cmbResponsavel.ValueMember = "prontuario";
            cmbResponsavel.SelectedIndex = -1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            cmbOrigem.SelectedIndex = cmbOrigem.Enabled == true ? -1 : cmbOrigem.SelectedIndex;
            cmbDestino.SelectedIndex = cmbDestino.Enabled == true ? -1 : cmbDestino.SelectedIndex;
            cmbResponsavel.SelectedIndex = -1;
            txtNumeroProtocolo.Text = "Utilizado somente quando enviado pelos correios";
            txtObservacao.Text = "";
            cmbEnvio.SelectedIndex = -1;
            txtNumeroProtocolo.Enabled = false;
            cmbResponsavel.Enabled = false;
        }

        private void Incluir()
        {
            try
            {
                BLLMovimentacaoHD bllMovimentacao = new BLLMovimentacaoHD();
                MOVIMENTACAO_HD movimentacao = new MOVIMENTACAO_HD();

                if (_hd.STATUS != "ENVIADO")
                {
                    movimentacao.NUMERO_HD = cmbNumeroHD.SelectedValue.ToString();
                    movimentacao.LOCAL_REGISTRO = Convert.ToInt32(cmbOrigem.SelectedValue.ToString());
                    movimentacao.LOCAL_DESTINO = Convert.ToInt32(cmbDestino.SelectedValue.ToString());
                    movimentacao.OBSERVACAO = txtObservacao.Text;
                    movimentacao.DATA_REGISTRO = DateTime.Now;
                    movimentacao.DATA_ENVIO = Convert.ToDateTime(txtDataEnvio.Text);
                    movimentacao.DATA_PROVAVEL_RECEBIMENTO = Convert.ToDateTime(txtProvavelDataRecebimento.Text);
                    movimentacao.TIPO = "ENVIADO";
                    movimentacao.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                    if (cmbEnvio.SelectedIndex == 0)
                    {
                        movimentacao.NUMERO_PROTOCOLO = txtNumeroProtocolo.Text;
                    }
                    else
                    {
                        movimentacao.RESPONSAVEL = cmbResponsavel.SelectedValue.ToString();
                    }

                    bllMovimentacao.InsertMovimentacaoHD(movimentacao);
                }
                else
                {
                    movimentacao = bllMovimentacao.GetMovimentacoesHD(_hd.NUMERO_HD, null, null, 0).Where(f => !f.DATA_CHEGADA.HasValue).FirstOrDefault();
                    bllMovimentacao.UpdateMovimentacaoHD(movimentacao.NUMERO_MOVIMENTACAO, DateTime.Now, "RECEBIDO", null, _usuario.prontuario_usuario);
                }

                if (_hd.STATUS != "ENVIADO")
                {
                    BLLHD bllHD = new BLLHD();
                    bllHD.UpdateStatusHD(_hd.NUMERO_HD, "ENVIADO");
                }
                else
                {
                    BLLHD bllHD = new BLLHD();
                    bllHD.UpdateStatusHD(_hd.NUMERO_HD, "RECEBIDO");
                    bllHD.UpdateLocalidadeHD(_hd.NUMERO_HD, movimentacao.LOCAL_DESTINO.Value);
                }

                MessageBox.Show("Movimentação realizada com sucesso", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
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
                if (cmbOrigem.SelectedValue != cmbDestino.SelectedValue)
                {
                    Incluir();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Origem e destino não podem ser iguais", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser informados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if ((cmbEnvio.SelectedIndex == -1) || (cmbNumeroHD.SelectedIndex == -1) || (cmbOrigem.SelectedIndex == -1) || (cmbDestino.SelectedIndex == -1) || (txtObservacao.Text == ""))
            {
                return false;
            }
            else if (cmbEnvio.SelectedIndex == 0 && ((cmbNumeroHD.SelectedIndex == -1) || (cmbOrigem.SelectedIndex == -1) || (cmbDestino.SelectedIndex == -1) || (txtNumeroProtocolo.Text == "") || (txtObservacao.Text == "")))
            {
                return false;
            }
            else if (cmbEnvio.SelectedIndex == 1 && ((cmbNumeroHD.SelectedIndex == -1) || (cmbOrigem.SelectedIndex == -1) || (cmbDestino.SelectedIndex == -1) || (cmbResponsavel.SelectedIndex == -1) || (txtObservacao.Text == "")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CarregaLocalidadesOrigem()
        {
            BLLLocalidade bllLocalidade = new BLLLocalidade();
            List<CamadaDados.LOCALIDADE> localidades = new List<CamadaDados.LOCALIDADE>();

            localidades = bllLocalidade.GetLocalidades("").OrderBy(l => l.DESCRICAO).ToList();

            cmbOrigem.DataSource = localidades;
            cmbOrigem.DisplayMember = "DESCRICAO";
            cmbOrigem.ValueMember = "CODIGO_LOCALIDADE";
            cmbOrigem.SelectedIndex = -1;

            cmbDestino.DataSource = localidades;
            cmbDestino.DisplayMember = "DESCRICAO";
            cmbDestino.ValueMember = "CODIGO_LOCALIDADE";
            cmbDestino.SelectedIndex = -1;
        }

        public void CarregaLocalidadesDestino()
        {
            BLLLocalidade bllLocalidade = new BLLLocalidade();
            List<CamadaDados.LOCALIDADE> localidades = new List<CamadaDados.LOCALIDADE>();

            localidades = bllLocalidade.GetLocalidades("").OrderBy(l => l.DESCRICAO).ToList();

            cmbDestino.DataSource = localidades;
            cmbDestino.DisplayMember = "DESCRICAO";
            cmbDestino.ValueMember = "CODIGO_LOCALIDADE";
            cmbDestino.SelectedIndex = -1;
        }

        private void cmbEnvio_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbEnvio.SelectedIndex != -1)
            {
                if (cmbEnvio.SelectedIndex == 0)
                {
                    txtNumeroProtocolo.Text = "";
                    txtNumeroProtocolo.Enabled = true;
                    cmbResponsavel.Enabled = false;
                }
                else
                {
                    txtNumeroProtocolo.Text = "Utilizado somente quando enviado pelos correios";
                    txtNumeroProtocolo.Enabled = false;
                    cmbResponsavel.Enabled = true;
                }
            }
        }

        public void CarregarHDs()
        {
            BLLHD bllHD = new BLLHD();
            List<HD> hds = bllHD.GetHDs("");

            cmbNumeroHD.DataSource = hds;
            cmbNumeroHD.DisplayMember = "NUMERO_HD";
            cmbNumeroHD.ValueMember = "NUMERO_HD";
            cmbNumeroHD.SelectedIndex = -1;
        }
    }
}
