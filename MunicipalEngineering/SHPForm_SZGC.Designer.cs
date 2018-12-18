namespace MunicipalEngineering
{
    partial class SHPForm_SZGC
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
            this.GCXMLJ_label = new System.Windows.Forms.Label();
            this.GCLJ_textBox = new System.Windows.Forms.TextBox();
            this.Browse_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.XMMC_textBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.CLNR_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.XMBH_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.GEN_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.QT_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GCXMLJ_label
            // 
            this.GCXMLJ_label.AutoSize = true;
            this.GCXMLJ_label.Location = new System.Drawing.Point(28, 30);
            this.GCXMLJ_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GCXMLJ_label.Name = "GCXMLJ_label";
            this.GCXMLJ_label.Size = new System.Drawing.Size(75, 15);
            this.GCXMLJ_label.TabIndex = 0;
            this.GCXMLJ_label.Text = "项目路径:";
            // 
            // GCLJ_textBox
            // 
            this.GCLJ_textBox.Location = new System.Drawing.Point(116, 25);
            this.GCLJ_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GCLJ_textBox.Name = "GCLJ_textBox";
            this.GCLJ_textBox.ReadOnly = true;
            this.GCLJ_textBox.Size = new System.Drawing.Size(251, 25);
            this.GCLJ_textBox.TabIndex = 1;
            this.GCLJ_textBox.TextChanged += new System.EventHandler(this.GCLJ_textBox_TextChanged);
            // 
            // Browse_button
            // 
            this.Browse_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Browse_button.Location = new System.Drawing.Point(399, 24);
            this.Browse_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(89, 29);
            this.Browse_button.TabIndex = 2;
            this.Browse_button.Text = "浏  览";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QT_textBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.XMMC_textBox);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.CLNR_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.XMBH_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(457, 197);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SHP字段信息：";
            // 
            // XMMC_textBox
            // 
            this.XMMC_textBox.Location = new System.Drawing.Point(103, 125);
            this.XMMC_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.XMMC_textBox.Name = "XMMC_textBox";
            this.XMMC_textBox.Size = new System.Drawing.Size(312, 25);
            this.XMMC_textBox.TabIndex = 5;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(8, 131);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 15);
            this.label.TabIndex = 4;
            this.label.Text = "项目名称:";
            // 
            // CLNR_textBox
            // 
            this.CLNR_textBox.Location = new System.Drawing.Point(103, 81);
            this.CLNR_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLNR_textBox.Name = "CLNR_textBox";
            this.CLNR_textBox.Size = new System.Drawing.Size(312, 25);
            this.CLNR_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "测量内容：";
            // 
            // XMBH_textBox
            // 
            this.XMBH_textBox.Location = new System.Drawing.Point(103, 38);
            this.XMBH_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.XMBH_textBox.Name = "XMBH_textBox";
            this.XMBH_textBox.Size = new System.Drawing.Size(312, 25);
            this.XMBH_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目编号：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(116, 276);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(275, 29);
            this.progressBar1.TabIndex = 4;
            // 
            // GEN_button
            // 
            this.GEN_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GEN_button.Location = new System.Drawing.Point(399, 276);
            this.GEN_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GEN_button.Name = "GEN_button";
            this.GEN_button.Size = new System.Drawing.Size(89, 29);
            this.GEN_button.TabIndex = 5;
            this.GEN_button.Text = "转 换";
            this.GEN_button.UseVisualStyleBackColor = true;
            this.GEN_button.Click += new System.EventHandler(this.GEN_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 285);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "处理进度：";
            // 
            // QT_textBox
            // 
            this.QT_textBox.Location = new System.Drawing.Point(103, 164);
            this.QT_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.QT_textBox.Name = "QT_textBox";
            this.QT_textBox.Size = new System.Drawing.Size(312, 25);
            this.QT_textBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "其他:";
            // 
            // SHPForm_SZGC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 318);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GEN_button);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.GCLJ_textBox);
            this.Controls.Add(this.GCXMLJ_label);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SHPForm_SZGC";
            this.Text = "市政工程转SHP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GCXMLJ_label;
        private System.Windows.Forms.TextBox GCLJ_textBox;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox XMMC_textBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox CLNR_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XMBH_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button GEN_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox QT_textBox;
        private System.Windows.Forms.Label label4;
    }
}