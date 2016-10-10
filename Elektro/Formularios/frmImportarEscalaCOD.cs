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
    public partial class frmImportarEscalaCOD : Form
    {
        private USUARIOS _usuario;
        List<ESCALA_COD> escalas = new List<ESCALA_COD>();

        public USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmImportarEscalaCOD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Selecionar vídeos";
            openFileDialog1.Filter = "Text files |*.txt;";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            DialogResult dialog = openFileDialog1.ShowDialog();

            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string line = "";
                    string path = openFileDialog1.FileName;
                    System.IO.StreamReader file = new System.IO.StreamReader(path);

                    while ((line = file.ReadLine()) != null)
                    {
                        ESCALA_COD escala = new ESCALA_COD();
                        escala.SIGLA_EQUIPE = line.Split(';')[0];
                        escala.PRONTUARIO = line.Split(';')[1];
                        escala.DATA_INICIO = Convert.ToDateTime(line.Split(';')[2]);
                        escala.DATA_FIM = Convert.ToDateTime(line.Split(';')[3]);
                        escala.USUARIO_REGISTRO = _usuario.PRONTUARIO;
                        escala.DATA_REGISTRO = DateTime.Now;

                        escalas.Add(escala);

                        listBox1.Items.Add(line);
                    }

                    file.Close();
                    button1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (escalas != null)
                {
                    BLLEscalaCOD bllEscala = new BLLEscalaCOD();

                    foreach (ESCALA_COD escala in escalas)
                    {
                        bllEscala.InsertEscala(escala);
                    }
                }
                MessageBox.Show("Escala importada com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox1.Items.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmImportarEscalaCOD_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
