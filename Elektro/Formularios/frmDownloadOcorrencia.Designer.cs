﻿namespace Elektro.Formularios
{
    partial class frmDownloadOcorrencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadOcorrencia));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTempoTotal = new System.Windows.Forms.Label();
            this.lblQuantidadeVideos = new System.Windows.Forms.Label();
            this.lblSorteio = new System.Windows.Forms.Label();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPorcentagem = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTempoTotal);
            this.groupBox1.Controls.Add(this.lblQuantidadeVideos);
            this.groupBox1.Controls.Add(this.lblSorteio);
            this.groupBox1.Controls.Add(this.lblEquipe);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblTempoTotal
            // 
            this.lblTempoTotal.AutoSize = true;
            this.lblTempoTotal.Location = new System.Drawing.Point(16, 96);
            this.lblTempoTotal.Name = "lblTempoTotal";
            this.lblTempoTotal.Size = new System.Drawing.Size(42, 16);
            this.lblTempoTotal.TabIndex = 3;
            this.lblTempoTotal.Text = "label1";
            // 
            // lblQuantidadeVideos
            // 
            this.lblQuantidadeVideos.AutoSize = true;
            this.lblQuantidadeVideos.Location = new System.Drawing.Point(16, 74);
            this.lblQuantidadeVideos.Name = "lblQuantidadeVideos";
            this.lblQuantidadeVideos.Size = new System.Drawing.Size(42, 16);
            this.lblQuantidadeVideos.TabIndex = 2;
            this.lblQuantidadeVideos.Text = "label1";
            // 
            // lblSorteio
            // 
            this.lblSorteio.AutoSize = true;
            this.lblSorteio.Location = new System.Drawing.Point(16, 52);
            this.lblSorteio.Name = "lblSorteio";
            this.lblSorteio.Size = new System.Drawing.Size(42, 16);
            this.lblSorteio.TabIndex = 1;
            this.lblSorteio.Text = "label1";
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Location = new System.Drawing.Point(16, 29);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(42, 16);
            this.lblEquipe.TabIndex = 0;
            this.lblEquipe.Text = "label1";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(50, 149);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(209, 149);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblPorcentagem);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(13, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 45);
            this.panel1.TabIndex = 3;
            // 
            // lblPorcentagem
            // 
            this.lblPorcentagem.AutoSize = true;
            this.lblPorcentagem.Location = new System.Drawing.Point(258, 14);
            this.lblPorcentagem.Name = "lblPorcentagem";
            this.lblPorcentagem.Size = new System.Drawing.Size(42, 16);
            this.lblPorcentagem.TabIndex = 4;
            this.lblPorcentagem.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Realizando download...";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // frmDownloadOcorrencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDownloadOcorrencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações da Ocorrência";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDownloadOcorrencia_FormClosed);
            this.Load += new System.EventHandler(this.frmDownloadOcorrencia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTempoTotal;
        private System.Windows.Forms.Label lblQuantidadeVideos;
        private System.Windows.Forms.Label lblSorteio;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPorcentagem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}