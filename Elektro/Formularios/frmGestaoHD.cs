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
    public partial class frmGestaoHD : Form
    {
        private int currentMouseOverRow;
        private CamadaDados.USUARIOS _usuario;

        public CamadaDados.USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmGestaoHD()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmBuscarMovimentacaoHD frmBuscar = new frmBuscarMovimentacaoHD(dataGridView1);
            frmBuscar.Usuario = _usuario;
            frmBuscar.ShowDialog();
        }

        private void Pesquisar()
        {
            try
            {
                BLLHD bllHD = new BLLHD();
                List<HD> lista = new List<HD>();

                if (_usuario.PRONTUARIO != null)
                {
                    int localidade = _usuario.PRONTUARIO != null ? _usuario.FUNCIONARIOS.localidade : 0;

                    lista = bllHD.GetHDs("").Where(l => (l.LOCAL == null || l.LOCAL.Value == localidade) || (l.MOVIMENTACAO_HD.Where(o => !o.DATA_CHEGADA.HasValue && o.LOCAL_DESTINO == localidade).Count() > 0)).AsQueryable().ToList();
                }
                else
                {
                    lista = bllHD.GetHDs("");
                }

                BLLMovimentacaoHD bllMovimentacao = new BLLMovimentacaoHD();

                if (lista.Count > 0)
                {
                    dataGridView1.DataSource = lista.Select(l => new
                    {
                        l.NUMERO_HD,
                        l.NUMERO_SERIE,
                        STATUS = l.STATUS == "ENVIADO" ? l.STATUS + " PARA " + bllMovimentacao.GetMovimentacoesHD(l.NUMERO_HD, null, null, 0).Where(k => !k.DATA_CHEGADA.HasValue).FirstOrDefault().LOCALIDADE.DESCRICAO : l.STATUS == "RECEBIDO" ? l.STATUS + " DE " + bllMovimentacao.GetMovimentacoesHD(l.NUMERO_HD, null, null, 0).Where(k => k.DATA_CHEGADA.HasValue).LastOrDefault().LOCALIDADE1.DESCRICAO : l.STATUS
                    }).AsQueryable().ToList();
                    dataGridView1.Columns[0].HeaderText = "Número do HD";
                    dataGridView1.Columns[1].HeaderText = "Número de Série";
                    dataGridView1.Columns[2].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGestaoHD_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void ReceberHD(object sender, EventArgs e)
        {
            try
            {
                BLLHD bllHD = new BLLHD();
                HD hd = bllHD.GetHD(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
                frmCadastroMovimentacaoHD frm = new frmCadastroMovimentacaoHD(hd);
                frm.Usuario = _usuario;
                frm.ShowDialog();
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviarHD(object sender, EventArgs e)
        {
            try
            {
                BLLHD bllHD = new BLLHD();
                HD hd = bllHD.GetHD(dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString());
                frmCadastroMovimentacaoHD frm = new frmCadastroMovimentacaoHD(hd);
                frm.Usuario = _usuario;
                frm.ShowDialog();
                Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HistoricoHD(object sender, EventArgs e)
        {
            try
            {
                string numeroHD = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                frmMovimentacoesHD frm = new frmMovimentacoesHD(numeroHD);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (currentMouseOverRow >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    BLLHD bllHD = new BLLHD();
                    HD hd = bllHD.GetHD(dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString());

                    if (hd.STATUS == "ENVIADO")
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Receber"));
                        m.MenuItems[0].Click += new EventHandler(ReceberHD);
                        m.MenuItems.Add(new MenuItem("Ver Histórico de Movimentações"));
                        m.MenuItems[1].Click += new EventHandler(HistoricoHD);
                        currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                    else if (hd.STATUS == "RECEBIDO" || hd.STATUS == null)
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Enviar"));
                        m.MenuItems[0].Click += new EventHandler(ReceberHD);
                        m.MenuItems.Add(new MenuItem("Ver Histórico de Movimentações"));
                        m.MenuItems[1].Click += new EventHandler(HistoricoHD);
                        currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                }
            }
        }
    }
}
