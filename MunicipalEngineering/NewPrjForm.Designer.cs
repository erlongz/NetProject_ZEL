namespace MunicipalEngineering
{
    partial class NewPrjForm
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
            this.PrjPath_textBox = new System.Windows.Forms.TextBox();
            this.Brw_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PrjName_textBox = new System.Windows.Forms.TextBox();
            this.CreatPrj_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "工程位置：";
            // 
            // PrjPath_textBox
            // 
            this.PrjPath_textBox.Location = new System.Drawing.Point(87, 10);
            this.PrjPath_textBox.Name = "PrjPath_textBox";
            this.PrjPath_textBox.ReadOnly = true;
            this.PrjPath_textBox.Size = new System.Drawing.Size(378, 25);
            this.PrjPath_textBox.TabIndex = 1;
            // 
            // Brw_button
            // 
            this.Brw_button.Location = new System.Drawing.Point(471, 10);
            this.Brw_button.Name = "Brw_button";
            this.Brw_button.Size = new System.Drawing.Size(94, 26);
            this.Brw_button.TabIndex = 2;
            this.Brw_button.Text = "浏 览";
            this.Brw_button.UseVisualStyleBackColor = true;
            this.Brw_button.Click += new System.EventHandler(this.Brw_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "工程名称：";
            // 
            // PrjName_textBox
            // 
            this.PrjName_textBox.Location = new System.Drawing.Point(87, 59);
            this.PrjName_textBox.Name = "PrjName_textBox";
            this.PrjName_textBox.Size = new System.Drawing.Size(378, 25);
            this.PrjName_textBox.TabIndex = 4;
            // 
            // CreatPrj_button
            // 
            this.CreatPrj_button.Location = new System.Drawing.Point(171, 108);
            this.CreatPrj_button.Name = "CreatPrj_button";
            this.CreatPrj_button.Size = new System.Drawing.Size(67, 29);
            this.CreatPrj_button.TabIndex = 5;
            this.CreatPrj_button.Text = "确定";
            this.CreatPrj_button.UseVisualStyleBackColor = true;
            this.CreatPrj_button.Click += new System.EventHandler(this.CreatPrj_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewPrjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreatPrj_button);
            this.Controls.Add(this.PrjName_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Brw_button);
            this.Controls.Add(this.PrjPath_textBox);
            this.Controls.Add(this.label1);
            this.Name = "NewPrjForm";
            this.Text = "新建工程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PrjPath_textBox;
        private System.Windows.Forms.Button Brw_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PrjName_textBox;
        private System.Windows.Forms.Button CreatPrj_button;
        private System.Windows.Forms.Button button1;
    }
}