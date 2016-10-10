namespace Elektro.Formularios
{
    partial class frmCadastrarOcorrencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastrarOcorrencias));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodSorteado = new System.Windows.Forms.TextBox();
            this.cmbSorteio = new System.Windows.Forms.ComboBox();
            this.txtDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbHD = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVideos = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEquipe = new System.Windows.Forms.ComboBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.txtCamera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNaoConformidade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpOperacional = new System.Windows.Forms.GroupBox();
            this.cmbSeveridade = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.lstOcorrencias = new System.Windows.Forms.ListBox();
            this.cmbAtividade = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.grpProcesso = new System.Windows.Forms.GroupBox();
            this.cmbOcorrenciasProcesso = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpOperacional.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpProcesso.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCodSorteado);
            this.groupBox1.Controls.Add(this.cmbSorteio);
            this.groupBox1.Controls.Add(this.txtDataInicial);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbHD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtVideos);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbEquipe);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtVeiculo);
            this.groupBox1.Controls.Add(this.txtCamera);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 432);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Ocorrência";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataFinal.Location = new System.Drawing.Point(137, 195);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(157, 23);
            this.txtDataFinal.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "Data Final";
            // 
            // txtCodSorteado
            // 
            this.txtCodSorteado.Location = new System.Drawing.Point(263, 48);
            this.txtCodSorteado.Name = "txtCodSorteado";
            this.txtCodSorteado.Size = new System.Drawing.Size(31, 23);
            this.txtCodSorteado.TabIndex = 25;
            this.txtCodSorteado.Visible = false;
            // 
            // cmbSorteio
            // 
            this.cmbSorteio.FormattingEnabled = true;
            this.cmbSorteio.Location = new System.Drawing.Point(137, 18);
            this.cmbSorteio.Name = "cmbSorteio";
            this.cmbSorteio.Size = new System.Drawing.Size(118, 24);
            this.cmbSorteio.TabIndex = 24;
            this.cmbSorteio.DropDownClosed += new System.EventHandler(this.cmbSorteio_DropDownClosed);
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataInicial.Location = new System.Drawing.Point(137, 166);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(157, 23);
            this.txtDataInicial.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "Data Inicial";
            // 
            // cmbHD
            // 
            this.cmbHD.FormattingEnabled = true;
            this.cmbHD.Location = new System.Drawing.Point(137, 136);
            this.cmbHD.Name = "cmbHD";
            this.cmbHD.Size = new System.Drawing.Size(118, 24);
            this.cmbHD.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "HD";
            // 
            // txtVideos
            // 
            this.txtVideos.Enabled = false;
            this.txtVideos.Location = new System.Drawing.Point(20, 283);
            this.txtVideos.Multiline = true;
            this.txtVideos.Name = "txtVideos";
            this.txtVideos.Size = new System.Drawing.Size(274, 143);
            this.txtVideos.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Elektro.Properties.Resources.lupa_32x32;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(137, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Procurar Vídeos";
            // 
            // cmbEquipe
            // 
            this.cmbEquipe.FormattingEnabled = true;
            this.cmbEquipe.Location = new System.Drawing.Point(137, 48);
            this.cmbEquipe.Name = "cmbEquipe";
            this.cmbEquipe.Size = new System.Drawing.Size(118, 24);
            this.cmbEquipe.TabIndex = 9;
            this.cmbEquipe.DropDownClosed += new System.EventHandler(this.cmbEquipe_DropDownClosed);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(137, 224);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(157, 23);
            this.txtUsuario.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Responsável";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sorteio";
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Location = new System.Drawing.Point(137, 107);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(118, 23);
            this.txtVeiculo.TabIndex = 11;
            // 
            // txtCamera
            // 
            this.txtCamera.Location = new System.Drawing.Point(137, 78);
            this.txtCamera.Name = "txtCamera";
            this.txtCamera.Size = new System.Drawing.Size(118, 23);
            this.txtCamera.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Veículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Câmera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sigla Equipe";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Elektro.Properties.Resources.incluir;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(620, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(20, 174);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(595, 58);
            this.txtObservacao.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Descrição";
            // 
            // cmbNaoConformidade
            // 
            this.cmbNaoConformidade.FormattingEnabled = true;
            this.cmbNaoConformidade.Location = new System.Drawing.Point(20, 40);
            this.cmbNaoConformidade.Name = "cmbNaoConformidade";
            this.cmbNaoConformidade.Size = new System.Drawing.Size(595, 24);
            this.cmbNaoConformidade.TabIndex = 15;
            this.cmbNaoConformidade.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbNaoConformidade_DrawItem);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tipo de Ocorrência";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1005, 25);
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
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Elektro.Properties.Resources.limpar_32x32;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton2.Text = "Limpar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Location = new System.Drawing.Point(13, 525);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(981, 67);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Salvando Ocorrência";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 28);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(950, 23);
            this.progressBar1.Step = 0;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // grpOperacional
            // 
            this.grpOperacional.Controls.Add(this.cmbSeveridade);
            this.grpOperacional.Controls.Add(this.label13);
            this.grpOperacional.Controls.Add(this.groupBox4);
            this.grpOperacional.Controls.Add(this.cmbAtividade);
            this.grpOperacional.Controls.Add(this.button1);
            this.grpOperacional.Controls.Add(this.label11);
            this.grpOperacional.Controls.Add(this.label8);
            this.grpOperacional.Controls.Add(this.txtObservacao);
            this.grpOperacional.Controls.Add(this.cmbNaoConformidade);
            this.grpOperacional.Controls.Add(this.label7);
            this.grpOperacional.Location = new System.Drawing.Point(338, 86);
            this.grpOperacional.Name = "grpOperacional";
            this.grpOperacional.Size = new System.Drawing.Size(656, 432);
            this.grpOperacional.TabIndex = 3;
            this.grpOperacional.TabStop = false;
            this.grpOperacional.Text = "Ocorrências Operacionais";
            // 
            // cmbSeveridade
            // 
            this.cmbSeveridade.FormattingEnabled = true;
            this.cmbSeveridade.Items.AddRange(new object[] {
            "Escolher",
            "Moderado",
            "Grave",
            "Intolerável",
            "Positivo"});
            this.cmbSeveridade.Location = new System.Drawing.Point(20, 85);
            this.cmbSeveridade.Name = "cmbSeveridade";
            this.cmbSeveridade.Size = new System.Drawing.Size(175, 24);
            this.cmbSeveridade.TabIndex = 23;
            this.cmbSeveridade.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbSeveridade_DrawItem);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Severidade";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeletar);
            this.groupBox4.Controls.Add(this.lstOcorrencias);
            this.groupBox4.Location = new System.Drawing.Point(20, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(595, 177);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ocorrências cadastradas";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(508, 148);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(76, 23);
            this.btnDeletar.TabIndex = 1;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // lstOcorrencias
            // 
            this.lstOcorrencias.FormattingEnabled = true;
            this.lstOcorrencias.ItemHeight = 16;
            this.lstOcorrencias.Location = new System.Drawing.Point(11, 22);
            this.lstOcorrencias.Name = "lstOcorrencias";
            this.lstOcorrencias.Size = new System.Drawing.Size(573, 116);
            this.lstOcorrencias.TabIndex = 0;
            this.lstOcorrencias.SelectedIndexChanged += new System.EventHandler(this.lstOcorrencias_SelectedIndexChanged);
            // 
            // cmbAtividade
            // 
            this.cmbAtividade.FormattingEnabled = true;
            this.cmbAtividade.Location = new System.Drawing.Point(20, 130);
            this.cmbAtividade.Name = "cmbAtividade";
            this.cmbAtividade.Size = new System.Drawing.Size(595, 24);
            this.cmbAtividade.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Atividade Realizada pela Equipe";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Location = new System.Drawing.Point(13, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(318, 53);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo de Ocorrência";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Operacional";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(229, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Processos";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // grpProcesso
            // 
            this.grpProcesso.Controls.Add(this.cmbOcorrenciasProcesso);
            this.grpProcesso.Location = new System.Drawing.Point(338, 28);
            this.grpProcesso.Name = "grpProcesso";
            this.grpProcesso.Size = new System.Drawing.Size(655, 53);
            this.grpProcesso.TabIndex = 5;
            this.grpProcesso.TabStop = false;
            this.grpProcesso.Text = "Ocorrências de Processo";
            // 
            // cmbOcorrenciasProcesso
            // 
            this.cmbOcorrenciasProcesso.FormattingEnabled = true;
            this.cmbOcorrenciasProcesso.Location = new System.Drawing.Point(20, 21);
            this.cmbOcorrenciasProcesso.Name = "cmbOcorrenciasProcesso";
            this.cmbOcorrenciasProcesso.Size = new System.Drawing.Size(595, 24);
            this.cmbOcorrenciasProcesso.TabIndex = 0;
            // 
            // frmCadastrarOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 603);
            this.Controls.Add(this.grpProcesso);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpOperacional);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmCadastrarOcorrencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Ocorrências";
            this.Load += new System.EventHandler(this.frmCadastrarOcorrencias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpOperacional.ResumeLayout(false);
            this.grpOperacional.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpProcesso.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ComboBox cmbNaoConformidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.TextBox txtCamera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEquipe;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpOperacional;
        private System.Windows.Forms.ListBox lstOcorrencias;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbAtividade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVideos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker txtDataInicial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSeveridade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbSorteio;
        private System.Windows.Forms.TextBox txtCodSorteado;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox grpProcesso;
        private System.Windows.Forms.ComboBox cmbOcorrenciasProcesso;
    }
}