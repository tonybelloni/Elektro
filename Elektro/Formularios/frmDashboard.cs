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
    public partial class frmDashboard : Form
    {
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            CarregarStatusEquipes();
            CarregarGraficoCameras();
            CarregarLocalidades();
            if (_usuario.PRONTUARIO != null)
            {
                cmbLocalidade.SelectedValue = _usuario.FUNCIONARIOS.localidade;
                CarregarGraficoCamerasEquipes(_usuario.FUNCIONARIOS.localidade);
            }
            CarregarGraficoOcorrencias();
            CarregarAtuacao();
            CarregarRegiao();
            CarregarSupervisao(0);
            CarregarLocalidade(0);
            CarregarGerencia(0);
        }

        private void CarregarStatusEquipes()
        {
            try
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipes("");

                if (_usuario.PRONTUARIO != null)
                    equipes = equipes.Where(l => l.LOCALIDADE == _usuario.FUNCIONARIOS.localidade).AsQueryable().ToList();

                BLLVeiculos bllVeiculo = new BLLVeiculos();

                var lista = equipes.Select(l => new
                {
                    l.SIGLA_EQUIPE,
                    l.TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                    l.PLACA_VEICULO,
                    TIPO_VEICULO = l.PLACA_VEICULO != null ? bllVeiculo.GetVeiculo(l.PLACA_VEICULO).TIPOS_VEICULOS.DESCRICAO : "",
                    REGIAO = l.REGIAO1.DESCRICAO,
                    GERENCIA = l.GERENCIA1.DESCRICAO,
                    SUPERVISAO = l.SUPERVISAO1.DESCRICAO,
                    LOCALIDADE = l.LOCALIDADE1.DESCRICAO,
                    l.CODIGO_CAMERA
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Equipe";
                    dataGridView1.Columns[1].HeaderText = "Atuação";
                    dataGridView1.Columns[2].HeaderText = "Placa";
                    dataGridView1.Columns[3].HeaderText = "Tipo Veículo";
                    dataGridView1.Columns[4].HeaderText = "Região";
                    dataGridView1.Columns[5].HeaderText = "Gerência";
                    dataGridView1.Columns[6].HeaderText = "Supervisão";
                    dataGridView1.Columns[7].HeaderText = "Localidade";
                    dataGridView1.Columns[8].HeaderText = "Câmera";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar informações das equipes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pesquisar(int atuacao, int regiao, int gerencia, int supervisao, int localidade)
        {
            try
            {
                BLLEquipes bllEquipes = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipes.GetEquipes("");

                if (_usuario.PRONTUARIO != null)
                {
                    if (_usuario.FUNCIONARIOS.funcao.ToLower().Contains("gerente"))
                        equipes = equipes.Where(l => l.GERENCIA == _usuario.FUNCIONARIOS.gerencia).AsQueryable().ToList();
                    else if (_usuario.FUNCIONARIOS.funcao.ToLower().Contains("supervisor"))
                        equipes = equipes.Where(l => l.SUPERVISAO == _usuario.FUNCIONARIOS.supervisao).AsQueryable().ToList();
                    else
                        equipes = equipes.Where(l => l.LOCALIDADE == _usuario.FUNCIONARIOS.localidade).AsQueryable().ToList();
                }

                if (atuacao != 0)
                    equipes = equipes.Where(l => l.ID_TIPO_TRABALHO == atuacao).AsQueryable().ToList();

                if (regiao != 0)
                    equipes = equipes.Where(l => l.REGIAO == regiao).AsQueryable().ToList();

                if (gerencia != 0)
                    equipes = equipes.Where(l => l.GERENCIA == gerencia).AsQueryable().ToList();

                if (supervisao != 0)
                    equipes = equipes.Where(l => l.SUPERVISAO == supervisao).AsQueryable().ToList();

                if (localidade != 0)
                    equipes = equipes.Where(l => l.LOCALIDADE == localidade).AsQueryable().ToList();

                BLLVeiculos bllVeiculo = new BLLVeiculos();

                var lista = equipes.Select(l => new
                {
                    l.SIGLA_EQUIPE,
                    l.TIPOS_TRABALHOS.DESCRICAO_TIPO_TRABALHO,
                    l.PLACA_VEICULO,
                    TIPO_VEICULO = l.PLACA_VEICULO != null ? bllVeiculo.GetVeiculo(l.PLACA_VEICULO).TIPOS_VEICULOS.DESCRICAO : "",
                    REGIAO = l.REGIAO1.DESCRICAO,
                    GERENCIA = l.GERENCIA1.DESCRICAO,
                    SUPERVISAO = l.SUPERVISAO1.DESCRICAO,
                    LOCALIDADE = l.LOCALIDADE1.DESCRICAO,
                    l.CODIGO_CAMERA
                }).AsQueryable().ToList();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista;
                    dataGridView1.Columns[0].HeaderText = "Equipe";
                    dataGridView1.Columns[1].HeaderText = "Atuação";
                    dataGridView1.Columns[2].HeaderText = "Placa";
                    dataGridView1.Columns[3].HeaderText = "Tipo Veículo";
                    dataGridView1.Columns[4].HeaderText = "Região";
                    dataGridView1.Columns[5].HeaderText = "Gerência";
                    dataGridView1.Columns[6].HeaderText = "Supervisão";
                    dataGridView1.Columns[7].HeaderText = "Localidade";
                    dataGridView1.Columns[8].HeaderText = "Câmera";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar informações das equipes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[8].Value == null)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        public void CarregarGraficoCamerasEquipes(int localidade)
        {
            try
            {
                this.chart1.Series["Equipes com câmeras"].Points.Clear();
                this.chart1.Series["Equipes sem câmeras"].Points.Clear();

                BLLEquipes bllEquipe = new BLLEquipes();
                List<EQUIPES> equipes = bllEquipe.GetEquipesByLocalidade(localidade);

                double comCameras = equipes.Where(l => l.CODIGO_CAMERA != null).Count();
                double semCameras = equipes.Where(l => l.CODIGO_CAMERA == null).Count();
                double total = equipes.Count();
                comCameras = (comCameras / total) * 100;
                semCameras = (semCameras / total) * 100;
                this.chart1.Series["Equipes com câmeras"].Points.AddXY("", Math.Round(comCameras, 2));
                this.chart1.Series["Equipes sem câmeras"].Points.AddXY("", Math.Round(semCameras, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar gráfico de câmeras x equipe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarGraficoCameras()
        {
            try
            {
                BLLCameras bllCameras = new BLLCameras();
                var cameras = bllCameras.GetCameras("");

                double boas = cameras.Where(l => l.ativo == 1).Count();
                double manutencao = cameras.Where(l => (l.STATUS == "MANUTENÇÃO" || l.STATUS == "MANUTENÇÃO LOCAL") && l.ativo == 0).Count();
                double total = cameras.Count();
                boas = (boas / total) * 100;
                manutencao = (manutencao / total) * 100;
                this.chart2.Series["Boas"].Points.AddXY("", Math.Round(boas, 2));
                this.chart2.Series["Em manutenção"].Points.AddXY("", Math.Round(manutencao, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar gráfico de câmeras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarGraficoOcorrencias()
        {
            try
            {
                BLLRegistroOcorrencia bllRegistroOcorrencia = new BLLRegistroOcorrencia();
                var ocorrencias = bllRegistroOcorrencia.GetRegistrosOcorrencias();

                double naoConformidade = ocorrencias.Where(l => l.CODIGO_ATIVIDADE != 4).Count();
                double recPositivo = ocorrencias.Where(l => l.CODIGO_ATIVIDADE == 4).Count();
                double total = ocorrencias.Count();
                naoConformidade = (naoConformidade / total) * 100;
                recPositivo = (recPositivo / total) * 100;
                this.chart3.Series["Não conformidade"].Points.AddXY("", Math.Round(naoConformidade, 2));
                this.chart3.Series["Reconhecimento Positivo"].Points.AddXY("", Math.Round(recPositivo, 2));
                label10.Text = "Total de ocorrências: " + total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar gráfico de câmeras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarLocalidades()
        {
            try
            {
                BLLLocalidade bllLocalidade = new BLLLocalidade();
                List<LOCALIDADE> localidades = new List<LOCALIDADE>();

                localidades = bllLocalidade.GetLocalidades("");

                if (Usuario.FUNCIONARIOS != null)
                {
                    if (Usuario.FUNCIONARIOS.funcao.ToLower().Contains("gerente"))
                        localidades = localidades.Where(l => l.SUPERVISAO.CODIGO_GERENCIA == Usuario.FUNCIONARIOS.gerencia).AsQueryable().ToList();
                    else if (Usuario.FUNCIONARIOS.funcao.ToLower().Contains("supervisor"))
                        localidades = localidades.Where(l => l.CODIGO_SUPERVISAO == Usuario.FUNCIONARIOS.supervisao).AsQueryable().ToList();
                    else
                        localidades = localidades.Where(l => l.CODIGO_LOCALIDADE == Usuario.FUNCIONARIOS.localidade).AsQueryable().ToList();
                }

                LOCALIDADE localidade = new LOCALIDADE();
                localidade.CODIGO_LOCALIDADE = 0;
                localidade.DESCRICAO = "Todas";
                localidades.Add(localidade);

                if (localidades.Count > 0)
                {
                    cmbLocalidade.DataSource = localidades.OrderBy(l => l.DESCRICAO).ToList();
                    cmbLocalidade.DisplayMember = "DESCRICAO";
                    cmbLocalidade.ValueMember = "CODIGO_LOCALIDADE";
                    cmbLocalidade.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar localidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLocalidade_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbLocalidade.SelectedIndex != -1)
            {
                CarregarGraficoCamerasEquipes(Convert.ToInt32(cmbLocalidade.SelectedValue.ToString()));
            }
        }

        private void cmbAtuacao_DropDownClosed(object sender, EventArgs e)
        {
            int atuacao = Convert.ToInt32(cmbAtuacao.SelectedValue.ToString());
            int regiao = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
            int gerencia = Convert.ToInt32(cmbGerência.SelectedValue.ToString());
            int supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
            int localidade = Convert.ToInt32(cmbLocal.SelectedValue.ToString());

            Pesquisar(atuacao, regiao, gerencia, supervisao, localidade);
        }

        public void CarregarAtuacao()
        {
            try
            {
                BLLTiposTrabalhos bllTipoTrabalho = new BLLTiposTrabalhos();
                List<Modelo.TipoTrabalho> atuacoes = new List<Modelo.TipoTrabalho>();
                Modelo.TipoTrabalho tipo = new Modelo.TipoTrabalho();
                tipo.IdTipoTrabalho = 0;
                tipo.DescricaoTipoTrabalho = "Todas";
                atuacoes = bllTipoTrabalho.GetTiposTrabalhos("");
                atuacoes.Add(tipo);

                cmbAtuacao.DataSource = atuacoes.OrderBy(l => l.DescricaoTipoTrabalho).AsQueryable().ToList();
                cmbAtuacao.DisplayMember = "DescricaoTipoTrabalho";
                cmbAtuacao.ValueMember = "IdTipoTrabalho";
                cmbAtuacao.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar atuações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarRegiao()
        {
            try
            {
                BLLRegiao bllRegiao = new BLLRegiao();
                List<REGIAO> regioes = new List<REGIAO>();
                REGIAO regiao = new REGIAO();
                regiao.CODIGO_REGIAO = 0;
                regiao.DESCRICAO = "Todas";
                if (Usuario.FUNCIONARIOS != null)
                    regioes = bllRegiao.GetRegioes("").Where(l => l.CODIGO_REGIAO == Usuario.FUNCIONARIOS.regiao).ToList();
                else
                    regioes = bllRegiao.GetRegioes("");
                regioes.Add(regiao);

                cmbRegiao.DataSource = regioes.OrderBy(l => l.DESCRICAO).AsQueryable().ToList();
                cmbRegiao.DisplayMember = "DESCRICAO";
                cmbRegiao.ValueMember = "CODIGO_REGIAO";
                cmbRegiao.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar regiões", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarGerencia(int regiao)
        {
            try
            {
                BLLGerencia bllGerencia = new BLLGerencia();
                List<GERENCIA> gerencias = new List<GERENCIA>();

                if (regiao != 0)
                {
                    if (Usuario.FUNCIONARIOS != null)
                        gerencias = bllGerencia.GetGerenciasByRegiao(regiao).Where(l => l.CODIGO_GERENCIA == Usuario.FUNCIONARIOS.gerencia).ToList();
                    else
                        gerencias = bllGerencia.GetGerenciasByRegiao(regiao);
                }

                GERENCIA gerencia = new GERENCIA();
                gerencia.CODIGO_GERENCIA = 0;
                gerencia.DESCRICAO = "Todas";
                gerencias.Add(gerencia);

                cmbGerência.DataSource = gerencias.OrderBy(l => l.DESCRICAO).AsQueryable().ToList();
                cmbGerência.DisplayMember = "DESCRICAO";
                cmbGerência.ValueMember = "CODIGO_GERENCIA";
                cmbGerência.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar gerências", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarSupervisao(int ger)
        {
            try
            {
                BLLSupervisao bllSupervisao = new BLLSupervisao();
                List<SUPERVISAO> supervisoes = new List<SUPERVISAO>();

                if (ger != 0)
                {
                    if (Usuario.FUNCIONARIOS != null)
                    {
                        if (Usuario.FUNCIONARIOS.funcao.ToLower().Contains("gerente"))
                            supervisoes = bllSupervisao.GetSupervisaoByGerencia(ger);
                        else
                            supervisoes = bllSupervisao.GetSupervisaoByGerencia(ger).Where(l => l.CODIGO_SUPERVISAO == Usuario.FUNCIONARIOS.supervisao).ToList();
                    }
                    else
                    {
                        supervisoes = bllSupervisao.GetSupervisaoByGerencia(ger);
                    }
                }

                SUPERVISAO supervisao = new SUPERVISAO();
                supervisao.CODIGO_SUPERVISAO = 0;
                supervisao.DESCRICAO = "Todas";
                supervisoes.Add(supervisao);

                cmbSupervisao.DataSource = supervisoes.OrderBy(l => l.DESCRICAO).AsQueryable().ToList();
                cmbSupervisao.DisplayMember = "DESCRICAO";
                cmbSupervisao.ValueMember = "CODIGO_SUPERVISAO";
                cmbSupervisao.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar supervisões", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarLocalidade(int supervisao)
        {
            try
            {
                BLLLocalidade bllLocalidade = new BLLLocalidade();
                List<LOCALIDADE> localidades = new List<LOCALIDADE>();

                if (supervisao != 0)
                {
                    if (Usuario.FUNCIONARIOS != null)
                    {
                        if (Usuario.FUNCIONARIOS.funcao.ToLower().Contains("gerente"))
                            localidades = bllLocalidade.GetLocalidadesBySupervisao(supervisao).Where(l => l.SUPERVISAO.CODIGO_GERENCIA == Usuario.FUNCIONARIOS.gerencia).ToList();
                        else if (Usuario.FUNCIONARIOS.funcao.ToLower().Contains("supervisor"))
                            localidades = bllLocalidade.GetLocalidadesBySupervisao(supervisao);
                        else
                            localidades = bllLocalidade.GetLocalidadesBySupervisao(supervisao).Where(l => l.CODIGO_LOCALIDADE == Usuario.FUNCIONARIOS.localidade).ToList();
                    }
                    else
                    {
                        localidades = bllLocalidade.GetLocalidadesBySupervisao(supervisao);
                    }
                }

                LOCALIDADE localidade = new LOCALIDADE();
                localidade.CODIGO_LOCALIDADE = 0;
                localidade.DESCRICAO = "Todas";
                localidades.Add(localidade);

                cmbLocal.DataSource = localidades.OrderBy(l => l.DESCRICAO).AsQueryable().ToList();
                cmbLocal.DisplayMember = "DESCRICAO";
                cmbLocal.ValueMember = "CODIGO_LOCALIDADE";
                cmbLocal.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar localidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRegiao_DropDownClosed(object sender, EventArgs e)
        {
            int atuacao = Convert.ToInt32(cmbAtuacao.SelectedValue.ToString());
            int regiao = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
            int gerencia = Convert.ToInt32(cmbGerência.SelectedValue.ToString());
            int supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
            int localidade = Convert.ToInt32(cmbLocal.SelectedValue.ToString());

            CarregarGerencia(regiao);
            CarregarSupervisao(0);
            CarregarLocalidade(0);
            Pesquisar(atuacao, regiao, gerencia, supervisao, localidade);
        }

        private void cmbGerência_DropDownClosed(object sender, EventArgs e)
        {
            int atuacao = Convert.ToInt32(cmbAtuacao.SelectedValue.ToString());
            int regiao = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
            int gerencia = Convert.ToInt32(cmbGerência.SelectedValue.ToString());
            int supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
            int localidade = Convert.ToInt32(cmbLocal.SelectedValue.ToString());

            CarregarSupervisao(gerencia);
            CarregarLocalidade(0);
            Pesquisar(atuacao, regiao, gerencia, supervisao, localidade);
        }

        private void cmbSupervisao_DropDownClosed(object sender, EventArgs e)
        {
            int atuacao = Convert.ToInt32(cmbAtuacao.SelectedValue.ToString());
            int regiao = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
            int gerencia = Convert.ToInt32(cmbGerência.SelectedValue.ToString());
            int supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
            int localidade = Convert.ToInt32(cmbLocal.SelectedValue.ToString());

            CarregarLocalidade(supervisao);
            Pesquisar(atuacao, regiao, gerencia, supervisao, localidade);
        }

        private void cmbLocal_DropDownClosed(object sender, EventArgs e)
        {
            int atuacao = Convert.ToInt32(cmbAtuacao.SelectedValue.ToString());
            int regiao = Convert.ToInt32(cmbRegiao.SelectedValue.ToString());
            int gerencia = Convert.ToInt32(cmbGerência.SelectedValue.ToString());
            int supervisao = Convert.ToInt32(cmbSupervisao.SelectedValue.ToString());
            int localidade = Convert.ToInt32(cmbLocal.SelectedValue.ToString());

            Pesquisar(atuacao, regiao, gerencia, supervisao, localidade);
        }
    }

    public class GraficoCameras
    {
        public string descricao { get; set; }
        public int total { get; set; }
    }
}
