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
    public partial class frmHistoricoVeiculo : Form
    {
        private string _sigla;

        public frmHistoricoVeiculo()
        {
            InitializeComponent();
        }

        public frmHistoricoVeiculo(string sigla)
        {
            InitializeComponent();
            _sigla = sigla;
        }

        private void Pesquisar()
        {
            try
            {
                BLLHistoricoVeiculo bllHistorico = new BLLHistoricoVeiculo();
                List<HISTORICO_VEICULO> lista = bllHistorico.GetHistoricosVeiculos().Where(l => l.SIGLA_EQUIPE == _sigla).ToList();

                BLLEquipes bllEquipe = new BLLEquipes();
                BLLVeiculos bllVeiculo = new BLLVeiculos();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.SIGLA_EQUIPE,
                        ATUACAO = bllEquipe.GetEquipeBySigla(l.SIGLA_EQUIPE).TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                        l.PLACA_VEICULO,
                        TIPO = bllVeiculo.GetVeiculo(l.PLACA_VEICULO).TIPOS_VEICULOS.DESCRICAO,
                        l.OBSERVACAO_VINCULAR,
                        l.DATA_VINCULAR,
                        l.OBSERVACAO_DESVINCULAR,
                        l.DATA_DESVINCULAR
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Equipe";
                    dataGridView1.Columns[1].HeaderText = "Atuação";
                    dataGridView1.Columns[2].HeaderText = "Veículo";
                    dataGridView1.Columns[3].HeaderText = "Tipo";
                    dataGridView1.Columns[4].HeaderText = "Observação Vincular";
                    dataGridView1.Columns[5].HeaderText = "Data Vinculação";
                    dataGridView1.Columns[6].HeaderText = "Observação Desvinculação";
                    dataGridView1.Columns[7].HeaderText = "Data Desvinculação";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHistoricoVeiculo_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
