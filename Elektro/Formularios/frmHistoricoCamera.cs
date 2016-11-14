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
    public partial class frmHistoricoCamera : Form
    {
        private USUARIOS _usuario;
        private CAMERAS _camera;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmHistoricoCamera()
        {
            InitializeComponent();
        }

        public frmHistoricoCamera(CAMERAS camera)
        {
            _camera = camera;
            InitializeComponent();
        }

        private void frmHistoricoCamera_Load(object sender, EventArgs e)
        {
            try
            {
                BLLHistoricosCameras bllHistorico = new BLLHistoricosCameras();
                List<HISTORICOS_CAMERAS> historico = bllHistorico.GetHistoricosCameras(_camera.codigo_camera);

                dataGridView1.DataSource = historico.Select(l => new
                {
                    l.CODIGO_CAMERA,
                    SIGLA_EQUIPE = l.SIGLA_EQUIPE != null ? l.SIGLA_EQUIPE : "",
                    TIPO = l.TIPO == 1 ? "Alocada" : l.TIPO == 2 ? "Desvinculada" : l.TIPO == 3 ? "Envio Manutenção" : l.TIPO == 4 ? "Recebimento Manutenção" : l.TIPO == 5 ? "Envio Para Estoque" : l.TIPO == 6 ? "Retirada de Estoque" : "Inutilizada",
                    DATA_INICIO = l.TIPO == 1 || l.TIPO == 2 || l.TIPO == 5 || l.TIPO == 6 ? l.DATA_ALOCACAO.Value.ToShortDateString() : l.TIPO == 3 || l.TIPO == 4 ? l.DATA_ENVIO.Value.ToShortDateString() : l.DATA_BAIXA.HasValue ? l.DATA_BAIXA.Value.ToShortDateString() : "",
                    DATA_FIM = l.TIPO == 2 ? l.DATA_DESALOCAO.Value.ToShortDateString() : l.TIPO == 4 ? l.DATA_RECEBIMENTO.Value.ToShortDateString() : "",
                    DATA_BAIXA = l.DATA_BAIXA.HasValue ? l.DATA_BAIXA.Value.ToShortDateString() : "",
                    OBSERVACAO = l.OBSERVACAO != null ? l.OBSERVACAO : "",
                    NUMERO_RASTREIO = l.NUMERO_RASTREIO != null ? l.NUMERO_RASTREIO : "",
                    PRONTUARIO = l.PRONTUARIO != null ? l.PRONTUARIO : "",
                }).ToList();
                dataGridView1.Columns[0].HeaderText = "Código da Câmera";
                dataGridView1.Columns[1].HeaderText = "Equipe";
                dataGridView1.Columns[2].HeaderText = "Tipo";
                dataGridView1.Columns[3].HeaderText = "Data Envio/Alocação";
                dataGridView1.Columns[4].HeaderText = "Data Recebimento/Desvinculação";
                dataGridView1.Columns[5].HeaderText = "Data Baixa";
                dataGridView1.Columns[6].HeaderText = "Observação/Motivo Baixa";
                dataGridView1.Columns[7].HeaderText = "Número Rastreio";
                dataGridView1.Columns[8].HeaderText = "Funcionário";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
