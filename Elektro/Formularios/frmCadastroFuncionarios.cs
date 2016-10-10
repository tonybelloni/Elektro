using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CamadaControle;
using CamadaDados;

namespace Elektro.Formularios
{
    public partial class frmCadastroFuncionarios : Form
    {
        public string FileName { get; set; }

        public frmCadastroFuncionarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroFuncionarios_Load(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;

                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripProgressBar1.MarqueeAnimationSpeed = 50;

                listBox1.Items.Add("Nome do Arquivo Para Carga : " + FileName);
                
                listBox1.Items.Add("Lendo Dados do Arquivo.... ");
                
                int total = 0;
                int rejeitados = 0;

                List<FUNCIONARIOS> lista = new List<FUNCIONARIOS>();
                lista.Clear();

                StreamReader sr = new StreamReader(FileName);
                string registro;
                
                while ( ( registro = sr.ReadLine() ) != null )
                {
                    List<string> campos = new List<string>();
                    campos.Clear();
                    campos = registro.Split(';').ToList<string>();
                    if ( (campos.Count != 10) )
                    {
                        rejeitados++;
                    }
                    else
                    {
                        FUNCIONARIOS f = new FUNCIONARIOS();
                        f.prontuario = campos[0];
                        f.nome_funcionario = campos[1];
                        f.funcao = campos[2];
                        f.localidade = Convert.ToInt32(campos[3]);
                        f.supervisao = Convert.ToInt32(campos[4]);
                        f.gerencia = Convert.ToInt32(campos[5]);
                        f.regiao = Convert.ToInt32(campos[6]);
                        f.prontuario_gestor = campos[7];
                        f.nome_gestor = campos[8];
                        f.periodo = campos[9];

                        lista.Add(f);

                        total++;
                    }
                }

                if ( lista.Count < 1 )
                {
                    toolStripProgressBar1.MarqueeAnimationSpeed = 0;
                    listBox1.Items.Add("Arquivo Está Vazio !!!");
                    listBox1.Items.Add("FIM DA CARGA");
                    button1.Enabled = true;
                }
                else
                {
                    listBox1.Items.Add(String.Format("Total de Registros Lidos : {0}", (total + rejeitados)));
                    listBox1.Items.Add(String.Format("Total de Registros Válidos : {0}", total)); 
                    listBox1.Items.Add(String.Format("Total de Registros Inválidos : {0}", rejeitados));
 
                    listBox1.Items.Add("Carregando Registros para Bancos de Dados......");

                    BLLFuncionarios func = new BLLFuncionarios();

                    func.DeleteAllFuncionarios();

                    int totalbd = 0;
                    foreach (FUNCIONARIOS fu in lista)
                    {
                        func.InsertFuncionario(fu);
                        totalbd++;
                    }

                    listBox1.Items.Add(String.Format("Total de Registros Carregados Para o Banco de Dados : {0}", totalbd));
                    listBox1.Items.Add("Carga Finalizada com Sucesso !!");
                     listBox1.Items.Add("FIM DA CARGA");
                    button1.Enabled = true;
                    toolStripProgressBar1.MarqueeAnimationSpeed = 0;
                 }
            }
            catch (Exception ex)
            {
                toolStripProgressBar1.MarqueeAnimationSpeed = 0;
                button1.Enabled = true;
                listBox1.Items.Add("ERRO : " + ex.Message);
                listBox1.Items.Add("FIM DA CARGA");
                button1.Enabled = true;
            }
        }
    }
}
