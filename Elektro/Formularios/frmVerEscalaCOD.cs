using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elektro.Formularios
{
    public partial class frmVerEscalaCOD : Form
    {
        public frmVerEscalaCOD()
        {
            InitializeComponent();
        }

        private void frmVerEscalaCOD_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Nenhuma escala encontrada para essa equipe no horário da ocorrência", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
