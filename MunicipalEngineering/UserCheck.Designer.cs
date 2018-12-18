namespace MunicipalEngineering
{
    partial class UserCheck
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
            this.UserName_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PassWord_textBox = new System.Windows.Forms.TextBox();
            this.logIn_button = new System.Windows.Forms.Button();
            this.Quit_button = new System.Windows.Forms.Button();
            this.ShowPSW_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // UserName_textBox
            // 
            this.UserName_textBox.Location = new System.Drawing.Point(116, 21);
            this.UserName_textBox.Name = "UserName_textBox";
            this.UserName_textBox.Size = new System.Drawing.Size(132, 25);
            this.UserName_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            // 
            // PassWord_textBox
            // 
            this.PassWord_textBox.Location = new System.Drawing.Point(116, 68);
            this.PassWord_textBox.Name = "PassWord_textBox";
            this.PassWord_textBox.ShortcutsEnabled = false;
            this.PassWord_textBox.Size = new System.Drawing.Size(132, 25);
            this.PassWord_textBox.TabIndex = 3;
            this.PassWord_textBox.UseSystemPasswordChar = true;
            // 
            // logIn_button
            // 
            this.logIn_button.Location = new System.Drawing.Point(36, 147);
            this.logIn_button.Name = "logIn_button";
            this.logIn_button.Size = new System.Drawing.Size(75, 31);
            this.logIn_button.TabIndex = 4;
            this.logIn_button.Text = "登  录";
            this.logIn_button.UseVisualStyleBackColor = true;
            this.logIn_button.Click += new System.EventHandler(this.logIn_button_Click);
            // 
            // Quit_button
            // 
            this.Quit_button.Location = new System.Drawing.Point(159, 147);
            this.Quit_button.Name = "Quit_button";
            this.Quit_button.Size = new System.Drawing.Size(75, 31);
            this.Quit_button.TabIndex = 5;
            this.Quit_button.Text = "退  出";
            this.Quit_button.UseVisualStyleBackColor = true;
            this.Quit_button.Click += new System.EventHandler(this.Quit_button_Click);
            // 
            // ShowPSW_checkBox
            // 
            this.ShowPSW_checkBox.AutoSize = true;
            this.ShowPSW_checkBox.Location = new System.Drawing.Point(26, 115);
            this.ShowPSW_checkBox.Name = "ShowPSW_checkBox";
            this.ShowPSW_checkBox.Size = new System.Drawing.Size(89, 19);
            this.ShowPSW_checkBox.TabIndex = 6;
            this.ShowPSW_checkBox.Text = "显示密码";
            this.ShowPSW_checkBox.UseVisualStyleBackColor = true;
            this.ShowPSW_checkBox.CheckedChanged += new System.EventHandler(this.ShowPSW_checkBox_CheckedChanged);
            // 
            // UserCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 185);
            this.Controls.Add(this.ShowPSW_checkBox);
            this.Controls.Add(this.Quit_button);
            this.Controls.Add(this.logIn_button);
            this.Controls.Add(this.PassWord_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserName_textBox);
            this.Controls.Add(this.label1);
            this.Name = "UserCheck";
            this.Text = "用户登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserName_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PassWord_textBox;
        private System.Windows.Forms.Button logIn_button;
        private System.Windows.Forms.Button Quit_button;
        private System.Windows.Forms.CheckBox ShowPSW_checkBox;
    }
}