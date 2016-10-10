namespace Elektro.Formularios
{
    partial class frmConfirmarSorteio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmarSorteio));
            this.lstPreSorteio = new System.Windows.Forms.ListBox();
            this.lstDisponiveis = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnInserirPreSorteio = new System.Windows.Forms.Button();
            this.btnRetirarPreSorteio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPreSorteio
            // 
            this.lstPreSorteio.DisplayMember = "SIGLA_EQUIPE";
            this.lstPreSorteio.FormattingEnabled = true;
            this.lstPreSorteio.ItemHeight = 16;
            this.lstPreSorteio.Location = new System.Drawing.Point(15, 28);
            this.lstPreSorteio.Name = "lstPreSorteio";
            this.lstPreSorteio.Size = new System.Drawing.Size(179, 372);
            this.lstPreSorteio.TabIndex = 0;
            // 
            // lstDisponiveis
            // 
            this.lstDisponiveis.DisplayMember = "SIGLA_EQUIPE";
            this.lstDisponiveis.FormattingEnabled = true;
            this.lstDisponiveis.ItemHeight = 16;
            this.lstDisponiveis.Location = new System.Drawing.Point(246, 28);
            this.lstDisponiveis.Name = "lstDisponiveis";
            this.lstDisponiveis.Size = new System.Drawing.Size(179, 372);
            this.lstDisponiveis.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Equipes pré-sorteadas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Equipes disponíveis";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(350, 406);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnInserirPreSorteio
            // 
            this.btnInserirPreSorteio.Image = global::Elektro.Properties.Resources.rr;
            this.btnInserirPreSorteio.Location = new System.Drawing.Point(200, 202);
            this.btnInserirPreSorteio.Name = "btnInserirPreSorteio";
            this.btnInserirPreSorteio.Size = new System.Drawing.Size(40, 41);
            this.btnInserirPreSorteio.TabIndex = 2;
            this.btnInserirPreSorteio.UseVisualStyleBackColor = true;
            this.btnInserirPreSorteio.Click += new System.EventHandler(this.btnInserirPreSorteio_Click);
            // 
            // btnRetirarPreSorteio
            // 
            this.btnRetirarPreSorteio.Image = global::Elektro.Properties.Resources.ff;
            this.btnRetirarPreSorteio.Location = new System.Drawing.Point(200, 155);
            this.btnRetirarPreSorteio.Name = "btnRetirarPreSorteio";
            this.btnRetirarPreSorteio.Size = new System.Drawing.Size(40, 41);
            this.btnRetirarPreSorteio.TabIndex = 1;
            this.btnRetirarPreSorteio.UseVisualStyleBackColor = true;
            this.btnRetirarPreSorteio.Click += new System.EventHandler(this.btnRetirarPreSorteio_Click);
            // 
            // frmConfirmarSorteio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 435);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDisponiveis);
            this.Controls.Add(this.btnInserirPreSorteio);
            this.Controls.Add(this.btnRetirarPreSorteio);
            this.Controls.Add(this.lstPreSorteio);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmConfirmarSorteio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmar Sorteio";
            this.Load += new System.EventHandler(this.frmConfirmarSorteio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPreSorteio;
        private System.Windows.Forms.Button btnRetirarPreSorteio;
        private System.Windows.Forms.Button btnInserirPreSorteio;
        private System.Windows.Forms.ListBox lstDisponiveis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmar;
    }
}