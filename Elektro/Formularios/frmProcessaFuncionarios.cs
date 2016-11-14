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
    public partial class frmProcessaFuncionarios : Form
    {
        public string Arquivo { get; set; }
        private StreamWriter log;
        private StreamReader arquivo;
        private string arquivoLog;

        public frmProcessaFuncionarios()
        {
            InitializeComponent();
        }

        private void frmProcessaFuncionarios_Load(object sender, EventArgs e)
        {
            arquivoLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\funcionarios" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            log = new StreamWriter(arquivoLog);
            txtArquivoLog.Text = arquivoLog;
            txtArquivoLog.Enabled = false;
            label1.Text = "Processando arquivo de funcionários. Aguarde...";
            btnFechar.Enabled = false;
            btnLog.Enabled = false;

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 10;

            backgroundWorker1.RunWorkerAsync();
        }

        private bool ValidaCampos(string registro, string[] campos, int contador)
        {
            if (campos.Length != 9)
            {
                log.WriteLine("ERRO - registro = " + contador.ToString() + " - " + registro + " - Formato Inválido");
                return false;
            }

            if (campos[0] == "" || campos[1] == "" || campos[2] == "" || campos[3] == "" || campos[4] == "" || campos[5] == "" || campos[6] == "")
            {
                log.WriteLine("ERRO - registro = " + contador.ToString() + " - " + registro + " - Todos os campos devem ser informados");
                return false;
            }

            return true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            arquivo = new StreamReader(Arquivo);
            int contador = 0;
            int totalIncluido = 0;
            int totalAtualizado = 0;

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
                            BLLFuncionarios bllFunc = new BLLFuncionarios();
                            FUNCIONARIOS funcPesquisa = new FUNCIONARIOS();

                            funcPesquisa = bllFunc.GetFuncionario(tokens[0].Trim());

                            FUNCIONARIOS funcUpdate = new FUNCIONARIOS();
                            funcUpdate.prontuario = tokens[0];
                            funcUpdate.nome_funcionario = tokens[1];
                            funcUpdate.funcao = tokens[2];
                            funcUpdate.localidade = Convert.ToInt32(tokens[3]);
                            funcUpdate.supervisao = Convert.ToInt32(tokens[4]);
                            funcUpdate.gerencia = Convert.ToInt32(tokens[5]);
                            funcUpdate.regiao = Convert.ToInt32(tokens[6]);
                            funcUpdate.prontuario_gestor = tokens[7];
                            funcUpdate.nome_gestor = tokens[8];
                            funcUpdate.periodo = null;

                            if (funcPesquisa != null)
                            {
                                bllFunc.UpdateFuncionario(funcUpdate);
                                totalAtualizado++;
                            }
                            else
                            {
                                bllFunc.InsertFuncionario(funcUpdate);
                                totalIncluido++;
                            }
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
                log.WriteLine("Arquivo = " + Arquivo + " - Total de Registros = " + contador.ToString() + "  - Registros Incluídos = " + totalIncluido.ToString() + " - Registros Alterados = " + totalAtualizado.ToString() + " - Registros rejeitados = " + (contador - totalAtualizado - totalIncluido).ToString());
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
            label1.Text = "Processamento do arquivo de funcionários terminado com sucesso";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad", arquivoLog);
        }
    }
}
