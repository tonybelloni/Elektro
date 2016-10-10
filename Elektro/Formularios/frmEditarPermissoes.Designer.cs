namespace Elektro.Formularios
{
    partial class frmEditarPermissoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarPermissoes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ckblCadastro = new System.Windows.Forms.CheckedListBox();
            this.ckbCadastro = new System.Windows.Forms.CheckBox();
            this.ckbOperacional = new System.Windows.Forms.CheckBox();
            this.ckblOperacional = new System.Windows.Forms.CheckedListBox();
            this.ckbGestao = new System.Windows.Forms.CheckBox();
            this.ckblGestao = new System.Windows.Forms.CheckedListBox();
            this.ckbRelatorio = new System.Windows.Forms.CheckBox();
            this.ckblRelatorio = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(924, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Elektro.Properties.Resources.salvar_blue;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton2.Text = "Salvar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // ckblCadastro
            // 
            this.ckblCadastro.FormattingEnabled = true;
            this.ckblCadastro.Items.AddRange(new object[] {
            "Atividades",
            "Câmeras",
            "Empresas de Manutenção",
            "Equipes",
            "Escala COD",
            "Falhas de Eventos de Processos",
            "Funcionários",
            "Gerências",
            "HD",
            "Localidades",
            "Perfis",
            "Regiões",
            "Supervisões",
            "Tipos de Ocorrência",
            "Tipos de Trabalho",
            "Tipos de Veículo",
            "Usuários",
            "Veículos"});
            this.ckblCadastro.Location = new System.Drawing.Point(24, 62);
            this.ckblCadastro.Name = "ckblCadastro";
            this.ckblCadastro.Size = new System.Drawing.Size(211, 328);
            this.ckblCadastro.TabIndex = 10;
            // 
            // ckbCadastro
            // 
            this.ckbCadastro.AutoSize = true;
            this.ckbCadastro.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbCadastro.Location = new System.Drawing.Point(34, 36);
            this.ckbCadastro.Name = "ckbCadastro";
            this.ckbCadastro.Size = new System.Drawing.Size(86, 20);
            this.ckbCadastro.TabIndex = 11;
            this.ckbCadastro.Text = "Cadastro";
            this.ckbCadastro.UseVisualStyleBackColor = true;
            this.ckbCadastro.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ckbOperacional
            // 
            this.ckbOperacional.AutoSize = true;
            this.ckbOperacional.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbOperacional.Location = new System.Drawing.Point(259, 36);
            this.ckbOperacional.Name = "ckbOperacional";
            this.ckbOperacional.Size = new System.Drawing.Size(103, 20);
            this.ckbOperacional.TabIndex = 13;
            this.ckbOperacional.Text = "Operacional";
            this.ckbOperacional.UseVisualStyleBackColor = true;
            this.ckbOperacional.CheckedChanged += new System.EventHandler(this.ckbOperacional_CheckedChanged);
            // 
            // ckblOperacional
            // 
            this.ckblOperacional.FormattingEnabled = true;
            this.ckblOperacional.Items.AddRange(new object[] {
            "Gestão de HDs",
            "Registrar Ocorrências",
            "Manutenção de Câmeras"});
            this.ckblOperacional.Location = new System.Drawing.Point(249, 62);
            this.ckblOperacional.Name = "ckblOperacional";
            this.ckblOperacional.Size = new System.Drawing.Size(287, 58);
            this.ckblOperacional.TabIndex = 12;
            // 
            // ckbGestao
            // 
            this.ckbGestao.AutoSize = true;
            this.ckbGestao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbGestao.Location = new System.Drawing.Point(561, 36);
            this.ckbGestao.Name = "ckbGestao";
            this.ckbGestao.Size = new System.Drawing.Size(72, 20);
            this.ckbGestao.TabIndex = 15;
            this.ckbGestao.Text = "Gestão";
            this.ckbGestao.UseVisualStyleBackColor = true;
            this.ckbGestao.CheckedChanged += new System.EventHandler(this.ckbGestao_CheckedChanged);
            // 
            // ckblGestao
            // 
            this.ckblGestao.FormattingEnabled = true;
            this.ckblGestao.Items.AddRange(new object[] {
            "Analisar Ocorrências",
            "Câmeras",
            "Equipes",
            "Sorteios",
            "Dashboard"});
            this.ckblGestao.Location = new System.Drawing.Point(551, 62);
            this.ckblGestao.Name = "ckblGestao";
            this.ckblGestao.Size = new System.Drawing.Size(170, 94);
            this.ckblGestao.TabIndex = 14;
            // 
            // ckbRelatorio
            // 
            this.ckbRelatorio.AutoSize = true;
            this.ckbRelatorio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbRelatorio.Location = new System.Drawing.Point(751, 36);
            this.ckbRelatorio.Name = "ckbRelatorio";
            this.ckbRelatorio.Size = new System.Drawing.Size(93, 20);
            this.ckbRelatorio.TabIndex = 17;
            this.ckbRelatorio.Text = "Relatórios";
            this.ckbRelatorio.UseVisualStyleBackColor = true;
            this.ckbRelatorio.CheckedChanged += new System.EventHandler(this.ckbRelatorio_CheckedChanged);
            // 
            // ckblRelatorio
            // 
            this.ckblRelatorio.FormattingEnabled = true;
            this.ckblRelatorio.Items.AddRange(new object[] {
            "HD",
            "Não Conformidades",
            "Vídeos Analisados",
            "Vídeos Filmados"});
            this.ckblRelatorio.Location = new System.Drawing.Point(741, 62);
            this.ckblRelatorio.Name = "ckblRelatorio";
            this.ckblRelatorio.Size = new System.Drawing.Size(170, 76);
            this.ckblRelatorio.TabIndex = 16;
            // 
            // frmEditarPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 401);
            this.Controls.Add(this.ckbRelatorio);
            this.Controls.Add(this.ckblRelatorio);
            this.Controls.Add(this.ckbGestao);
            this.Controls.Add(this.ckblGestao);
            this.Controls.Add(this.ckbOperacional);
            this.Controls.Add(this.ckblOperacional);
            this.Controls.Add(this.ckbCadastro);
            this.Controls.Add(this.ckblCadastro);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmEditarPermissoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Permissões";
            this.Load += new System.EventHandler(this.frmEditarPermissoes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.CheckedListBox ckblCadastro;
        private System.Windows.Forms.CheckBox ckbCadastro;
        private System.Windows.Forms.CheckBox ckbOperacional;
        private System.Windows.Forms.CheckedListBox ckblOperacional;
        private System.Windows.Forms.CheckBox ckbGestao;
        private System.Windows.Forms.CheckedListBox ckblGestao;
        private System.Windows.Forms.CheckBox ckbRelatorio;
        private System.Windows.Forms.CheckedListBox ckblRelatorio;
    }
}