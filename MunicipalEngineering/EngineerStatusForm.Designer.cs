namespace MunicipalEngineering
{
    partial class EngineerStatusForm
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
            this.NewProject_radioButton = new System.Windows.Forms.RadioButton();
            this.EditProject_radioButton = new System.Windows.Forms.RadioButton();
            this.CheckProject_radioButton = new System.Windows.Forms.RadioButton();
            this.SubmitProject_radioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewProject_radioButton
            // 
            this.NewProject_radioButton.AutoSize = true;
            this.NewProject_radioButton.Location = new System.Drawing.Point(84, 23);
            this.NewProject_radioButton.Name = "NewProject_radioButton";
            this.NewProject_radioButton.Size = new System.Drawing.Size(88, 19);
            this.NewProject_radioButton.TabIndex = 0;
            this.NewProject_radioButton.TabStop = true;
            this.NewProject_radioButton.Text = "新建工程";
            this.NewProject_radioButton.UseVisualStyleBackColor = true;
            // 
            // EditProject_radioButton
            // 
            this.EditProject_radioButton.AutoSize = true;
            this.EditProject_radioButton.Location = new System.Drawing.Point(84, 48);
            this.EditProject_radioButton.Name = "EditProject_radioButton";
            this.EditProject_radioButton.Size = new System.Drawing.Size(88, 19);
            this.EditProject_radioButton.TabIndex = 1;
            this.EditProject_radioButton.TabStop = true;
            this.EditProject_radioButton.Text = "编辑工程";
            this.EditProject_radioButton.UseVisualStyleBackColor = true;
            // 
            // CheckProject_radioButton
            // 
            this.CheckProject_radioButton.AutoSize = true;
            this.CheckProject_radioButton.Location = new System.Drawing.Point(84, 75);
            this.CheckProject_radioButton.Name = "CheckProject_radioButton";
            this.CheckProject_radioButton.Size = new System.Drawing.Size(88, 19);
            this.CheckProject_radioButton.TabIndex = 2;
            this.CheckProject_radioButton.TabStop = true;
            this.CheckProject_radioButton.Text = "检查工程";
            this.CheckProject_radioButton.UseVisualStyleBackColor = true;
            // 
            // SubmitProject_radioButton
            // 
            this.SubmitProject_radioButton.AutoSize = true;
            this.SubmitProject_radioButton.Location = new System.Drawing.Point(84, 100);
            this.SubmitProject_radioButton.Name = "SubmitProject_radioButton";
            this.SubmitProject_radioButton.Size = new System.Drawing.Size(88, 19);
            this.SubmitProject_radioButton.TabIndex = 3;
            this.SubmitProject_radioButton.TabStop = true;
            this.SubmitProject_radioButton.Text = "提交工程";
            this.SubmitProject_radioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckProject_radioButton);
            this.groupBox1.Controls.Add(this.SubmitProject_radioButton);
            this.groupBox1.Controls.Add(this.EditProject_radioButton);
            this.groupBox1.Controls.Add(this.NewProject_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "确 定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EngineerStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 177);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "EngineerStatusForm";
            this.Text = "工程状态";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton NewProject_radioButton;
        private System.Windows.Forms.RadioButton EditProject_radioButton;
        private System.Windows.Forms.RadioButton CheckProject_radioButton;
        private System.Windows.Forms.RadioButton SubmitProject_radioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}