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
    public partial class frmConfirmarSorteio : Form
    {
        private List<EQUIPES> _preSorteadas;
        private List<EQUIPES> _naoSorteadas;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmConfirmarSorteio()
        {
            InitializeComponent();
        }

        public frmConfirmarSorteio(List<EQUIPES> preSorteadas, List<EQUIPES> naoSorteadas)
        {
            InitializeComponent();
            _preSorteadas = preSorteadas;
            _naoSorteadas = naoSorteadas;
        }

        private void frmConfirmarSorteio_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarListaDisponiveis();
                CarregarListaPreSorteados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarListaPreSorteados()
        {
            foreach (EQUIPES equipe in _preSorteadas)
            {
                lstPreSorteio.Items.Add(equipe);
            }
        }

        public void CarregarListaDisponiveis()
        {
            foreach (EQUIPES equipe in _naoSorteadas)
            {
                lstDisponiveis.Items.Add(equipe);
            }
        }

        private void btnRetirarPreSorteio_Click(object sender, EventArgs e)
        {
            if (lstPreSorteio.SelectedItem == null)
                throw new Exception("Escolha uma equipe na lista de pré-sorteados");

            EQUIPES equipe = (EQUIPES)lstPreSorteio.SelectedItem;
            lstPreSorteio.Items.Remove(equipe);
            lstDisponiveis.Items.Add(equipe);
            _preSorteadas.Remove(equipe);
            _naoSorteadas.Add(equipe);
        }

        private void btnInserirPreSorteio_Click(object sender, EventArgs e)
        {
            if (lstDisponiveis.SelectedItem == null)
                throw new Exception("Escolha uma equipe na lista de disponíveis");

            EQUIPES equipe = (EQUIPES)lstDisponiveis.SelectedItem;
            lstDisponiveis.Items.Remove(equipe);
            lstPreSorteio.Items.Add(equipe);
            _naoSorteadas.Remove(equipe);
            _preSorteadas.Add(equipe);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLSorteio bllSorteio = new BLLSorteio();
                SORTEIOS sorteio = new SORTEIOS();

                sorteio.DATA_REGISTRO = DateTime.Now;
                sorteio.USUARIO_REGISTRO = _usuario.prontuario_usuario;
                bllSorteio.InsereSorteio(sorteio);

                BLLSorteados bllSorteados = new BLLSorteados();
                SORTEADOS sorteado = new SORTEADOS();

                foreach (EQUIPES equipe in _preSorteadas)
                {
                    sorteado.COD_SORTEIO = sorteio.COD_SORTEIO;
                    sorteado.SIGLA_EQUIPE = equipe.SIGLA_EQUIPE;
                    sorteado.VISUALIZADO = "N";
                    bllSorteados.InsertSorteado(sorteado);
                    sorteado = new SORTEADOS();
                }

                MessageBox.Show("Sorteio realizado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
