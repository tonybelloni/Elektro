namespace Elektro.Formularios
{
    partial class frmCadastroEquipes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroEquipes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLocalidade = new System.Windows.Forms.ComboBox();
            this.cmbSupervisao = new System.Windows.Forms.ComboBox();
            this.cmbGerencia = new System.Windows.Forms.ComboBox();
            this.cmbRegiao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoTrabalho = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(453, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Elektro.Properties.Resources.salvar_blue;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton1.Text = "Salvar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Elektro.Properties.Resources.limpar_32x32;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(111, 22);
            this.toolStripButton2.Text = "Limpar Campos";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLocalidade);
            this.groupBox1.Controls.Add(this.cmbSupervisao);
            this.groupBox1.Controls.Add(this.cmbGerencia);
            this.groupBox1.Controls.Add(this.cmbRegiao);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbTipoTrabalho);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.txtSigla);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Equipe";
            // 
            // cmbLocalidade
            // 
            this.cmbLocalidade.FormattingEnabled = true;
            this.cmbLocalidade.Location = new System.Drawing.Point(118, 174);
            this.cmbLocalidade.Name = "cmbLocalidade";
            this.cmbLocalidade.Size = new System.Drawing.Size(281, 24);
            this.cmbLocalidade.TabIndex = 12;
            // 
            // cmbSupervisao
            // 
            this.cmbSupervisao.FormattingEnabled = true;
            this.cmbSupervisao.Location = new System.Drawing.Point(118, 144);
            this.cmbSupervisao.Name = "cmbSupervisao";
            this.cmbSupervisao.Size = new System.Drawing.Size(281, 24);
            this.cmbSupervisao.TabIndex = 11;
            this.cmbSupervisao.DropDownClosed += new System.EventHandler(this.cmbSupervisao_DropDownClosed);
            // 
            // cmbGerencia
            // 
            this.cmbGerencia.FormattingEnabled = true;
            this.cmbGerencia.Location = new System.Drawing.Point(118, 114);
            this.cmbGerencia.Name = "cmbGerencia";
            this.cmbGerencia.Size = new System.Drawing.Size(281, 24);
            this.cmbGerencia.TabIndex = 10;
            this.cmbGerencia.DropDownClosed += new System.EventHandler(this.cmbGerencia_DropDownClosed);
            // 
            // cmbRegiao
            // 
            this.cmbRegiao.FormattingEnabled = true;
            this.cmbRegiao.Location = new System.Drawing.Point(118, 84);
            this.cmbRegiao.Name = "cmbRegiao";
            this.cmbRegiao.Size = new System.Drawing.Size(281, 24);
            this.cmbRegiao.TabIndex = 9;
            this.cmbRegiao.DropDownClosed += new System.EventHandler(this.cmbRegiao_DropDownClosed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo de Trabalho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Localidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Supervisão";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gerência";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Região";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome da Equipe";
            // 
            // cmbTipoTrabalho
            // 
            this.cmbTipoTrabalho.FormattingEnabled = true;
            this.cmbTipoTrabalho.Items.AddRange(new object[] {
            "Não",
            "Sim"});
            this.cmbTipoTrabalho.Location = new System.Drawing.Point(118, 204);
            this.cmbTipoTrabalho.Name = "cmbTipoTrabalho";
            this.cmbTipoTrabalho.Size = new System.Drawing.Size(281, 24);
            this.cmbTipoTrabalho.TabIndex = 13;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(118, 55);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(281, 23);
            this.txtNome.TabIndex = 8;
            // 
            // txtSigla
            // 
            this.txtSigla.Location = new System.Drawing.Point(118, 26);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Size = new System.Drawing.Size(65, 23);
            this.txtSigla.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sigla da Equipe";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCadastroEquipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmCadastroEquipes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Equipes";
            this.Load += new System.EventHandler(this.frmCadastroEquipes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoTrabalho;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbLocalidade;
        private System.Windows.Forms.ComboBox cmbSupervisao;
        private System.Windows.Forms.ComboBox cmbGerencia;
        private System.Windows.Forms.ComboBox cmbRegiao;
    }
}