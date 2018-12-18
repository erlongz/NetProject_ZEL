namespace MunicipalEngineering
{
    partial class UpFileClientForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.sel_textBox = new System.Windows.Forms.TextBox();
            this.sel_button = new System.Windows.Forms.Button();
            this.upLoad_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labTime = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labState = new System.Windows.Forms.Label();
            this.labSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择工程：";
            // 
            // sel_textBox
            // 
            this.sel_textBox.Location = new System.Drawing.Point(111, 33);
            this.sel_textBox.Name = "sel_textBox";
            this.sel_textBox.Size = new System.Drawing.Size(179, 25);
            this.sel_textBox.TabIndex = 1;
            // 
            // sel_button
            // 
            this.sel_button.Location = new System.Drawing.Point(308, 34);
            this.sel_button.Name = "sel_button";
            this.sel_button.Size = new System.Drawing.Size(75, 23);
            this.sel_button.TabIndex = 2;
            this.sel_button.Text = "选择";
            this.sel_button.UseVisualStyleBackColor = true;
            this.sel_button.Click += new System.EventHandler(this.sel_button_Click);
            // 
            // upLoad_button
            // 
            this.upLoad_button.Location = new System.Drawing.Point(308, 87);
            this.upLoad_button.Name = "upLoad_button";
            this.upLoad_button.Size = new System.Drawing.Size(75, 23);
            this.upLoad_button.TabIndex = 3;
            this.upLoad_button.Text = "上传文件";
            this.upLoad_button.UseVisualStyleBackColor = true;
            this.upLoad_button.Click += new System.EventHandler(this.upLoad_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "上传进度：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(111, 127);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(238, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(111, 176);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(82, 15);
            this.labTime.TabIndex = 6;
            this.labTime.Text = "已用时间：";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Location = new System.Drawing.Point(234, 175);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(75, 15);
            this.labSpeed.TabIndex = 7;
            this.labSpeed.Text = "平均速度:";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(111, 223);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(82, 15);
            this.labState.TabIndex = 8;
            this.labState.Text = "上传状态：";
            // 
            // labSize
            // 
            this.labSize.AutoSize = true;
            this.labSize.Location = new System.Drawing.Point(237, 223);
            this.labSize.Name = "labSize";
            this.labSize.Size = new System.Drawing.Size(82, 15);
            this.labSize.TabIndex = 9;
            this.labSize.Text = "上传大小：";
            // 
            // UpFileClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 258);
            this.Controls.Add(this.labSize);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.upLoad_button);
            this.Controls.Add(this.sel_button);
            this.Controls.Add(this.sel_textBox);
            this.Controls.Add(this.label1);
            this.Name = "UpFileClientForm";
            this.Text = "成果回交";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sel_textBox;
        private System.Windows.Forms.Button sel_button;
        private System.Windows.Forms.Button upLoad_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Label labSize;
    }
}