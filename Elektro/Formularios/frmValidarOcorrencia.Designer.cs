namespace Elektro.Formularios
{
    partial class frmValidarOcorrencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidarOcorrencia));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAnaliseInadequada = new System.Windows.Forms.CheckBox();
            this.chkNaoProcede = new System.Windows.Forms.CheckBox();
            this.chkProcede = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservacaoValidacao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEquipe = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNaoConformidade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataInicial = new System.Windows.Forms.TextBox();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.txtCamera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(577, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Elektro.Properties.Resources.salvar_blue;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripButton1.Text = "Salvar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.chkAnaliseInadequada);
            this.groupBox1.Controls.Add(this.chkNaoProcede);
            this.groupBox1.Controls.Add(this.chkProcede);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtObservacaoValidacao);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtEquipe);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbNaoConformidade);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDataInicial);
            this.groupBox1.Controls.Add(this.txtVeiculo);
            this.groupBox1.Controls.Add(this.txtCamera);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Ocorrência";
            // 
            // chkAnaliseInadequada
            // 
            this.chkAnaliseInadequada.AutoSize = true;
            this.chkAnaliseInadequada.Location = new System.Drawing.Point(310, 196);
            this.chkAnaliseInadequada.Name = "chkAnaliseInadequada";
            this.chkAnaliseInadequada.Size = new System.Drawing.Size(139, 20);
            this.chkAnaliseInadequada.TabIndex = 22;
            this.chkAnaliseInadequada.Text = "Análise Inadequada";
            this.chkAnaliseInadequada.UseVisualStyleBackColor = true;
            this.chkAnaliseInadequada.CheckedChanged += new System.EventHandler(this.chkAnaliseInadequada_CheckedChanged);
            // 
            // chkNaoProcede
            // 
            this.chkNaoProcede.AutoSize = true;
            this.chkNaoProcede.Location = new System.Drawing.Point(205, 196);
            this.chkNaoProcede.Name = "chkNaoProcede";
            this.chkNaoProcede.Size = new System.Drawing.Size(99, 20);
            this.chkNaoProcede.TabIndex = 21;
            this.chkNaoProcede.Text = "Não procede";
            this.chkNaoProcede.UseVisualStyleBackColor = true;
            this.chkNaoProcede.CheckedChanged += new System.EventHandler(this.chkNaoProcede_CheckedChanged);
            // 
            // chkProcede
            // 
            this.chkProcede.AutoSize = true;
            this.chkProcede.Location = new System.Drawing.Point(126, 196);
            this.chkProcede.Name = "chkProcede";
            this.chkProcede.Size = new System.Drawing.Size(73, 20);
            this.chkProcede.TabIndex = 20;
            this.chkProcede.Text = "Procede";
            this.chkProcede.UseVisualStyleBackColor = true;
            this.chkProcede.CheckedChanged += new System.EventHandler(this.chkProcede_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Validação";
            // 
            // txtObservacaoValidacao
            // 
            this.txtObservacaoValidacao.Location = new System.Drawing.Point(126, 222);
            this.txtObservacaoValidacao.Multiline = true;
            this.txtObservacaoValidacao.Name = "txtObservacaoValidacao";
            this.txtObservacaoValidacao.Size = new System.Drawing.Size(410, 78);
            this.txtObservacaoValidacao.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Observação";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ocorrência";
            // 
            // txtEquipe
            // 
            this.txtEquipe.Location = new System.Drawing.Point(126, 22);
            this.txtEquipe.Name = "txtEquipe";
            this.txtEquipe.Size = new System.Drawing.Size(118, 23);
            this.txtEquipe.TabIndex = 11;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(126, 112);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(410, 78);
            this.txtObservacao.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Observação";
            // 
            // cmbNaoConformidade
            // 
            this.cmbNaoConformidade.FormattingEnabled = true;
            this.cmbNaoConformidade.Location = new System.Drawing.Point(126, 306);
            this.cmbNaoConformidade.Name = "cmbNaoConformidade";
            this.cmbNaoConformidade.Size = new System.Drawing.Size(410, 24);
            this.cmbNaoConformidade.TabIndex = 17;
            this.cmbNaoConformidade.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbNaoConformidade_DrawItem);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tipo de Ocorrência";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(379, 80);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(157, 23);
            this.txtUsuario.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Responsável";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Data Inicial";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(379, 22);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(157, 23);
            this.txtDataInicial.TabIndex = 13;
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Location = new System.Drawing.Point(126, 80);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(118, 23);
            this.txtVeiculo.TabIndex = 14;
            // 
            // txtCamera
            // 
            this.txtCamera.Location = new System.Drawing.Point(126, 51);
            this.txtCamera.Name = "txtCamera";
            this.txtCamera.Size = new System.Drawing.Size(118, 23);
            this.txtCamera.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Veículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Câmera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sigla Equipe";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(379, 51);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(157, 23);
            this.txtDataFinal.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Data Final";
            // 
            // frmValidarOcorrencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 390);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmValidarOcorrencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validar Ocorrência";
            this.Load += new System.EventHandler(this.frmValidarOcorrencia_Load);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbNaoConformidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataInicial;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.TextBox txtCamera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtObservacaoValidacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEquipe;
        private System.Windows.Forms.CheckBox chkNaoProcede;
        private System.Windows.Forms.CheckBox chkProcede;
        private System.Windows.Forms.CheckBox chkAnaliseInadequada;
        private System.Windows.Forms.TextBox txtDataFinal;
        private System.Windows.Forms.Label label5;
    }
}