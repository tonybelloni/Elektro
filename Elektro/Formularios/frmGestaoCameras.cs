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
    public partial class frmGestaoCameras : Form
    {
        private int currentMouseOverRow;
        private USUARIOS _usuario;

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmGestaoCameras()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu m = new ContextMenu();
            m.Show(dataGridView1, new Point(e.X, e.Y));
            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            try
            {
                if (currentMouseOverRow >= 0)
                {
                    BLLCameras bllCameras = new BLLCameras();
                    CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

                    if (e.Button == MouseButtons.Right)
                    {
                        if (camera.STATUS == "DISPONÍVEL")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Alocar"));
                            m.MenuItems[0].Click += new EventHandler(AlocarCamera);
                            m.MenuItems.Add(new MenuItem("Enviar para Manutenção"));
                            m.MenuItems[1].Click += new EventHandler(EnviarManutencaoCamera);
                            m.MenuItems.Add(new MenuItem("Realizar Baixa"));
                            m.MenuItems[2].Click += new EventHandler(RealizarBaixaCamera);
                            m.MenuItems.Add(new MenuItem("Ver Histórico"));
                            m.MenuItems[3].Click += new EventHandler(VerHistoricoCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "ALOCADA")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Desalocar"));
                            m.MenuItems[0].Click += new EventHandler(DesalocarCamera);
                            m.MenuItems.Add(new MenuItem("Ver Histórico"));
                            m.MenuItems[1].Click += new EventHandler(VerHistoricoCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else if (camera.STATUS == "MANUTENÇÃO")
                        {
                            //ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Receber da Manutenção"));
                            m.MenuItems[0].Click += new EventHandler(ReceberManutencaoCamera);
                            m.MenuItems.Add(new MenuItem("Realizar Baixa"));
                            m.MenuItems[1].Click += new EventHandler(RealizarBaixaCamera);
                            m.MenuItems.Add(new MenuItem("Ver Histórico"));
                            m.MenuItems[2].Click += new EventHandler(VerHistoricoCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                        else
                        {
                            m.MenuItems.Add(new MenuItem("Ver Histórico"));
                            m.MenuItems[0].Click += new EventHandler(VerHistoricoCamera);
                            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dataGridView1, new Point(e.X, e.Y));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlocarCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroAlocacaoCamera frm = new frmCadastroAlocacaoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void DesalocarCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroAlocacaoCamera frm = new frmCadastroAlocacaoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void EnviarManutencaoCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroManutencaoCamera frm = new frmCadastroManutencaoCamera(camera);
            frm.Usuario = _usuario;
            frm.Tipo = 1;
            frm.ShowDialog();
            Pesquisar();
        }

        private void ReceberManutencaoCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroManutencaoCamera frm = new frmCadastroManutencaoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void RealizarBaixaCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmCadastroBaixaCameras frm = new frmCadastroBaixaCameras(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
            Pesquisar();
        }

        private void VerHistoricoCamera(object sender, EventArgs e)
        {
            BLLCameras bllCameras = new BLLCameras();
            CAMERAS camera = bllCameras.GetCamera(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());

            frmHistoricoCamera frm = new frmHistoricoCamera(camera);
            frm.Usuario = _usuario;
            frm.ShowDialog();
        }

        private void Pesquisar()
        {
            try
            {
                BLLCameras cameras = new BLLCameras();
                List<CAMERAS> lista = new List<CAMERAS>();

                lista = cameras.GetCameras("");

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.codigo_camera,
                        l.bpm_camera,
                        l.codigo_barra_camera,
                        ATIVA = l.ativo == 1 ? "Sim" : "Não",
                        l.STATUS,
                        DATA_AQUISICAO = l.DATA_AQUISICAO.HasValue ? l.DATA_AQUISICAO.Value.ToShortDateString() : "",
                        FORNECEDORA = l.CODIGO_EMPRESA.HasValue ? l.EMPRESAS.DESCRICAO : "",
                        DATA_INUTILIZACAO = l.DATA_BAIXA.HasValue ? l.DATA_BAIXA.Value.ToShortDateString() : "",
                        l.MOTIVO_BAIXA
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Código da Câmera";
                    dataGridView1.Columns[1].HeaderText = "BPM da Câmera";
                    dataGridView1.Columns[2].HeaderText = "Código de Barras";
                    dataGridView1.Columns[3].HeaderText = "Ativa";
                    dataGridView1.Columns[4].HeaderText = "Status";
                    dataGridView1.Columns[5].HeaderText = "Data Aquisição";
                    dataGridView1.Columns[6].HeaderText = "Fornecedora";
                    dataGridView1.Columns[7].HeaderText = "Data Inutilização";
                    dataGridView1.Columns[8].HeaderText = "Motivo";
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
