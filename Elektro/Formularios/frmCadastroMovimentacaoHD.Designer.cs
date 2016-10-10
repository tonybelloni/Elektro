namespace Elektro.Formularios
{
    partial class frmCadastroMovimentacaoHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroMovimentacaoHD));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEnvio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrigem = new System.Windows.Forms.ComboBox();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.cmbResponsavel = new System.Windows.Forms.ComboBox();
            this.cmbNumeroHD = new System.Windows.Forms.ComboBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroProtocolo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataEnvio = new System.Windows.Forms.DateTimePicker();
            this.txtProvavelDataRecebimento = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProvavelDataRecebimento);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDataEnvio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbEnvio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbOrigem);
            this.groupBox1.Controls.Add(this.cmbDestino);
            this.groupBox1.Controls.Add(this.cmbResponsavel);
            this.groupBox1.Controls.Add(this.cmbNumeroHD);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumeroProtocolo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(532, 401);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Movimentação";
            // 
            // cmbEnvio
            // 
            this.cmbEnvio.FormattingEnabled = true;
            this.cmbEnvio.Items.AddRange(new object[] {
            "Correios",
            "Funcionário"});
            this.cmbEnvio.Location = new System.Drawing.Point(189, 204);
            this.cmbEnvio.Name = "cmbEnvio";
            this.cmbEnvio.Size = new System.Drawing.Size(327, 24);
            this.cmbEnvio.TabIndex = 10;
            this.cmbEnvio.DropDownClosed += new System.EventHandler(this.cmbEnvio_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modo de Envio";
            // 
            // cmbOrigem
            // 
            this.cmbOrigem.FormattingEnabled = true;
            this.cmbOrigem.Location = new System.Drawing.Point(189, 70);
            this.cmbOrigem.Name = "cmbOrigem";
            this.cmbOrigem.Size = new System.Drawing.Size(327, 24);
            this.cmbOrigem.TabIndex = 8;
            // 
            // cmbDestino
            // 
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Location = new System.Drawing.Point(189, 174);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(327, 24);
            this.cmbDestino.TabIndex = 9;
            // 
            // cmbResponsavel
            // 
            this.cmbResponsavel.FormattingEnabled = true;
            this.cmbResponsavel.Location = new System.Drawing.Point(189, 239);
            this.cmbResponsavel.Name = "cmbResponsavel";
            this.cmbResponsavel.Size = new System.Drawing.Size(327, 24);
            this.cmbResponsavel.TabIndex = 11;
            // 
            // cmbNumeroHD
            // 
            this.cmbNumeroHD.FormattingEnabled = true;
            this.cmbNumeroHD.Items.AddRange(new object[] {
            "Não",
            "Sim"});
            this.cmbNumeroHD.Location = new System.Drawing.Point(189, 33);
            this.cmbNumeroHD.Name = "cmbNumeroHD";
            this.cmbNumeroHD.Size = new System.Drawing.Size(327, 24);
            this.cmbNumeroHD.TabIndex = 7;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(189, 311);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(327, 79);
            this.txtObservacao.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Observação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Número de Rastreio";
            // 
            // txtNumeroProtocolo
            // 
            this.txtNumeroProtocolo.Location = new System.Drawing.Point(189, 274);
            this.txtNumeroProtocolo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumeroProtocolo.Name = "txtNumeroProtocolo";
            this.txtNumeroProtocolo.Size = new System.Drawing.Size(327, 23);
            this.txtNumeroProtocolo.TabIndex = 12;
            this.txtNumeroProtocolo.Text = "Utilizado somente quando enviado pelos correios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Portador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Origem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número do HD";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(552, 25);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Data de Envio";
            // 
            // txtDataEnvio
            // 
            this.txtDataEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataEnvio.Location = new System.Drawing.Point(189, 105);
            this.txtDataEnvio.Name = "txtDataEnvio";
            this.txtDataEnvio.Size = new System.Drawing.Size(110, 23);
            this.txtDataEnvio.TabIndex = 15;
            // 
            // txtProvavelDataRecebimento
            // 
            this.txtProvavelDataRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtProvavelDataRecebimento.Location = new System.Drawing.Point(189, 139);
            this.txtProvavelDataRecebimento.Name = "txtProvavelDataRecebimento";
            this.txtProvavelDataRecebimento.Size = new System.Drawing.Size(110, 23);
            this.txtProvavelDataRecebimento.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Possível Data de Recebimento";
            // 
            // frmCadastroMovimentacaoHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCadastroMovimentacaoHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Envio de HD";
            this.Load += new System.EventHandler(this.frmCadastroMovimentacaoHD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroProtocolo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.ComboBox cmbResponsavel;
        private System.Windows.Forms.ComboBox cmbNumeroHD;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbOrigem;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.ComboBox cmbEnvio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtProvavelDataRecebimento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtDataEnvio;
        private System.Windows.Forms.Label label8;
    }
}