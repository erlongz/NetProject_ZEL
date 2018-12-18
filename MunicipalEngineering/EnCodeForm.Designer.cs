namespace MunicipalEngineering
{
    partial class EnCodeForm
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
            this.MCode_textBox = new System.Windows.Forms.TextBox();
            this.GenCode_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Reg_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码：";
            // 
            // MCode_textBox
            // 
            this.MCode_textBox.Location = new System.Drawing.Point(89, 29);
            this.MCode_textBox.Name = "MCode_textBox";
            this.MCode_textBox.ReadOnly = true;
            this.MCode_textBox.Size = new System.Drawing.Size(329, 25);
            this.MCode_textBox.TabIndex = 1;
            // 
            // GenCode_button
            // 
            this.GenCode_button.Location = new System.Drawing.Point(424, 29);
            this.GenCode_button.Name = "GenCode_button";
            this.GenCode_button.Size = new System.Drawing.Size(95, 26);
            this.GenCode_button.TabIndex = 2;
            this.GenCode_button.Text = "生成机器码";
            this.GenCode_button.UseVisualStyleBackColor = true;
            this.GenCode_button.Click += new System.EventHandler(this.GenCode_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "验证码：";
            // 
            // Reg_textBox
            // 
            this.Reg_textBox.Location = new System.Drawing.Point(89, 74);
            this.Reg_textBox.Name = "Reg_textBox";
            this.Reg_textBox.Size = new System.Drawing.Size(329, 25);
            this.Reg_textBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "验 证";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 154);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Reg_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GenCode_button);
            this.Controls.Add(this.MCode_textBox);
            this.Controls.Add(this.label1);
            this.Name = "EnCodeForm";
            this.Text = "市政工程软件验证";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MCode_textBox;
        private System.Windows.Forms.Button GenCode_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Reg_textBox;
        private System.Windows.Forms.Button button1;
    }
}