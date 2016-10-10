namespace Elektro.Formularios
{
    partial class frmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocalidade = new System.Windows.Forms.ComboBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAtuacao = new System.Windows.Forms.ComboBox();
            this.cmbRegiao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGerência = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSupervisao = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1249, 232);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "% de equipes em campo com câmeras";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.ScrollBar;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(15, 57);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Equipes com câmeras";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Equipes sem câmeras";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(343, 226);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chartEquipesCameras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Localidade";
            // 
            // cmbLocalidade
            // 
            this.cmbLocalidade.FormattingEnabled = true;
            this.cmbLocalidade.Location = new System.Drawing.Point(126, 29);
            this.cmbLocalidade.Name = "cmbLocalidade";
            this.cmbLocalidade.Size = new System.Drawing.Size(183, 24);
            this.cmbLocalidade.TabIndex = 4;
            this.cmbLocalidade.DropDownClosed += new System.EventHandler(this.cmbLocalidade_DropDownClosed);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.SystemColors.ScrollBar;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(16, 46);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart2.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.SystemColors.Highlight,
        System.Drawing.Color.Red};
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Boas";
            series3.XValueMember = "descricao";
            series3.YValueMembers = "total";
            series4.ChartArea = "ChartArea1";
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Em manutenção";
            this.chart2.Series.Add(series3);
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(376, 237);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chartEquipesCameras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "% de câmeras boas x manutenção";
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.SystemColors.ScrollBar;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(13, 58);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart3.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Green};
            series5.ChartArea = "ChartArea1";
            series5.IsValueShownAsLabel = true;
            series5.Legend = "Legend1";
            series5.Name = "Não conformidade";
            series6.ChartArea = "ChartArea1";
            series6.IsValueShownAsLabel = true;
            series6.Legend = "Legend1";
            series6.Name = "Reconhecimento Positivo";
            this.chart3.Series.Add(series5);
            this.chart3.Series.Add(series6);
            this.chart3.Size = new System.Drawing.Size(359, 234);
            this.chart3.TabIndex = 8;
            this.chart3.Text = "chartEquipesCameras";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "% de vídeos com ocorrências";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Atuação";
            // 
            // cmbAtuacao
            // 
            this.cmbAtuacao.FormattingEnabled = true;
            this.cmbAtuacao.Location = new System.Drawing.Point(72, 6);
            this.cmbAtuacao.Name = "cmbAtuacao";
            this.cmbAtuacao.Size = new System.Drawing.Size(216, 24);
            this.cmbAtuacao.TabIndex = 10;
            this.cmbAtuacao.DropDownClosed += new System.EventHandler(this.cmbAtuacao_DropDownClosed);
            // 
            // cmbRegiao
            // 
            this.cmbRegiao.FormattingEnabled = true;
            this.cmbRegiao.Location = new System.Drawing.Point(72, 36);
            this.cmbRegiao.Name = "cmbRegiao";
            this.cmbRegiao.Size = new System.Drawing.Size(216, 24);
            this.cmbRegiao.TabIndex = 12;
            this.cmbRegiao.DropDownClosed += new System.EventHandler(this.cmbRegiao_DropDownClosed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Região";
            // 
            // cmbGerência
            // 
            this.cmbGerência.FormattingEnabled = true;
            this.cmbGerência.Location = new System.Drawing.Point(362, 36);
            this.cmbGerência.Name = "cmbGerência";
            this.cmbGerência.Size = new System.Drawing.Size(216, 24);
            this.cmbGerência.TabIndex = 14;
            this.cmbGerência.DropDownClosed += new System.EventHandler(this.cmbGerência_DropDownClosed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Gerência";
            // 
            // cmbSupervisao
            // 
            this.cmbSupervisao.FormattingEnabled = true;
            this.cmbSupervisao.Location = new System.Drawing.Point(671, 36);
            this.cmbSupervisao.Name = "cmbSupervisao";
            this.cmbSupervisao.Size = new System.Drawing.Size(216, 24);
            this.cmbSupervisao.TabIndex = 16;
            this.cmbSupervisao.DropDownClosed += new System.EventHandler(this.cmbSupervisao_DropDownClosed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(594, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Supervisão";
            // 
            // cmbLocal
            // 
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Location = new System.Drawing.Point(982, 36);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(216, 24);
            this.cmbLocal.TabIndex = 18;
            this.cmbLocal.DropDownClosed += new System.EventHandler(this.cmbLocal_DropDownClosed);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(905, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Localidade";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.chart3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(849, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 295);
            this.panel1.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 16);
            this.label10.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chart2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(418, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 291);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cmbLocalidade);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(13, 305);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 292);
            this.panel3.TabIndex = 21;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1244, 609);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSupervisao);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbGerência);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbRegiao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbAtuacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1260, 648);
            this.MinimizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLocalidade;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAtuacao;
        private System.Windows.Forms.ComboBox cmbRegiao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGerência;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSupervisao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLocal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
    }
}