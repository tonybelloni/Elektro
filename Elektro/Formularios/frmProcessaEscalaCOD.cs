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
    public partial class frmProcessaEscalaCOD : Form
    {
        public string Arquivo { get; set; }
        public USUARIOS Usuario { get; set; }
        private StreamWriter log;
        private StreamReader arquivo;

        private string arquivoLog;

        public frmProcessaEscalaCOD()
        {
            InitializeComponent();
        }

        private void frmProcessaEscalaCOD_Load(object sender, EventArgs e)
        {
            arquivoLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\escalacod" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            log = new StreamWriter(arquivoLog);
            txtArquivoLog.Text = arquivoLog;
            txtArquivoLog.Enabled = false;
            label1.Text = "Processando arquivo de escalas. Aguarde...";
            btnFechar.Enabled = false;
            btnLog.Enabled = false;

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 10;

            backgroundWorker1.RunWorkerAsync();

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidaCampos(string registro, string[] campos, int contador)
        {
            if (campos.Length != 4)
            {
                log.WriteLine("ERRO - registro = " + contador.ToString() + " - " + registro + " - Formato Inválido");
                return false;
            }

            if (campos[0] == "" || campos[1] == "" || campos[2] == "" || campos[3] == "")
            {
                log.WriteLine("ERRO - registro = " + contador.ToString() + " - " + registro + " - Todos os campos devem ser informados");
                return false;
            }

            try
            {
                DateTime dtinicio = Convert.ToDateTime(campos[2]);
                DateTime dtfim = Convert.ToDateTime(campos[3]);
            }
            catch (Exception ex)
            {
                log.WriteLine("ERRO - registro = " + contador.ToString() + " - " + registro + " - Data Inválida");
                return false;
            }

            return true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            arquivo = new StreamReader(Arquivo);
            int contador = 0;
            int total = 0;

            try
            {
                string linha;

                log.WriteLine("Inicio do processo - Arquivo = " + Arquivo + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                while ((linha = arquivo.ReadLine()) != null)
                {
                    contador++;

                    string[] tokens = linha.Split(';');

                    if (ValidaCampos(linha, tokens, contador))
                    {
                        try
                        {
                            ESCALA_COD escala = new ESCALA_COD();

                            escala.SIGLA_EQUIPE = tokens[0];
                            escala.PRONTUARIO = tokens[1];
                            escala.DATA_INICIO = Convert.ToDateTime(tokens[2]);
                            escala.DATA_FIM = Convert.ToDateTime(tokens[3]);
                            escala.DATA_REGISTRO = DateTime.Now;
                            escala.USUARIO_REGISTRO = Usuario.prontuario_usuario;

                            BLLEscalaCOD bllEscala = new BLLEscalaCOD();
                            bllEscala.InsertEscala(escala);

                            total++;
                        }
                        catch (Exception ex)
                        {
                            log.WriteLine("ERRO - registro = " + contador.ToString() + " - " + linha + " - " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("ERRO - " + ex.Message);
            }
            finally
            {
                log.WriteLine("Arquivo = " + Arquivo + " - Total de Registros = " + contador.ToString() + "  - Registros carregados = " + total.ToString() + " - Registros rejeitados = " + (contador- total).ToString());
                log.WriteLine("Fim do processo - Arquivo = " + Arquivo + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                log.Close();
                arquivo.Close();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnFechar.Enabled = true;
            btnLog.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.MarqueeAnimationSpeed = 0;
            label1.Text = "Processamento do arquivo de escala terminado com sucesso";
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad", arquivoLog);
        }
    }
}
