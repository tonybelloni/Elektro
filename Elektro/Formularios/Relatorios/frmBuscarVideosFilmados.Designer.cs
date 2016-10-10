namespace Elektro.Formularios.Relatorios
{
    partial class frmBuscarVideosFilmados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarVideosFilmados));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLocalidade = new System.Windows.Forms.CheckBox();
            this.chkRegiao = new System.Windows.Forms.CheckBox();
            this.chkEquipe = new System.Windows.Forms.CheckBox();
            this.cmbEquipe = new System.Windows.Forms.ComboBox();
            this.cmbLocalidade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRegiao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.txtDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(436, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Elektro.Properties.Resources.lupa_32x32;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton1.Text = "Buscar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDataInicial);
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.chkLocalidade);
            this.groupBox1.Controls.Add(this.chkRegiao);
            this.groupBox1.Controls.Add(this.chkEquipe);
            this.groupBox1.Controls.Add(this.cmbEquipe);
            this.groupBox1.Controls.Add(this.cmbLocalidade);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbRegiao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(412, 179);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Relatório";
            // 
            // chkLocalidade
            // 
            this.chkLocalidade.AutoSize = true;
            this.chkLocalidade.Location = new System.Drawing.Point(30, 85);
            this.chkLocalidade.Name = "chkLocalidade";
            this.chkLocalidade.Size = new System.Drawing.Size(15, 14);
            this.chkLocalidade.TabIndex = 13;
            this.chkLocalidade.UseVisualStyleBackColor = true;
            this.chkLocalidade.CheckedChanged += new System.EventHandler(this.chkLocalidade_CheckedChanged);
            // 
            // chkRegiao
            // 
            this.chkRegiao.AutoSize = true;
            this.chkRegiao.Location = new System.Drawing.Point(30, 55);
            this.chkRegiao.Name = "chkRegiao";
            this.chkRegiao.Size = new System.Drawing.Size(15, 14);
            this.chkRegiao.TabIndex = 12;
            this.chkRegiao.UseVisualStyleBackColor = true;
            this.chkRegiao.CheckedChanged += new System.EventHandler(this.chkRegiao_CheckedChanged);
            // 
            // chkEquipe
            // 
            this.chkEquipe.AutoSize = true;
            this.chkEquipe.Location = new System.Drawing.Point(30, 26);
            this.chkEquipe.Name = "chkEquipe";
            this.chkEquipe.Size = new System.Drawing.Size(15, 14);
            this.chkEquipe.TabIndex = 11;
            this.chkEquipe.UseVisualStyleBackColor = true;
            this.chkEquipe.CheckedChanged += new System.EventHandler(this.chkEquipe_CheckedChanged);
            // 
            // cmbEquipe
            // 
            this.cmbEquipe.FormattingEnabled = true;
            this.cmbEquipe.Location = new System.Drawing.Point(154, 21);
            this.cmbEquipe.Name = "cmbEquipe";
            this.cmbEquipe.Size = new System.Drawing.Size(240, 24);
            this.cmbEquipe.TabIndex = 10;
            // 
            // cmbLocalidade
            // 
            this.cmbLocalidade.FormattingEnabled = true;
            this.cmbLocalidade.Items.AddRange(new object[] {
            " Todas"});
            this.cmbLocalidade.Location = new System.Drawing.Point(154, 81);
            this.cmbLocalidade.Name = "cmbLocalidade";
            this.cmbLocalidade.Size = new System.Drawing.Size(240, 24);
            this.cmbLocalidade.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Localidade";
            // 
            // cmbRegiao
            // 
            this.cmbRegiao.FormattingEnabled = true;
            this.cmbRegiao.Location = new System.Drawing.Point(154, 51);
            this.cmbRegiao.Name = "cmbRegiao";
            this.cmbRegiao.Size = new System.Drawing.Size(240, 24);
            this.cmbRegiao.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Região";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Período Final";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Período Inicial";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(154, 111);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(240, 23);
            this.txtDataInicial.TabIndex = 18;
            this.txtDataInicial.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(154, 140);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(240, 23);
            this.txtDataFinal.TabIndex = 19;
            this.txtDataFinal.ValidatingType = typeof(System.DateTime);
            // 
            // frmBuscarVideosFilmados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 217);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBuscarVideosFilmados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vídeos Filmados";
            this.Load += new System.EventHandler(this.frmBuscarVideosFilmados_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLocalidade;
        private System.Windows.Forms.CheckBox chkRegiao;
        private System.Windows.Forms.CheckBox chkEquipe;
        private System.Windows.Forms.ComboBox cmbEquipe;
        private System.Windows.Forms.ComboBox cmbLocalidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRegiao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtDataInicial;
        private System.Windows.Forms.MaskedTextBox txtDataFinal;
    }
}