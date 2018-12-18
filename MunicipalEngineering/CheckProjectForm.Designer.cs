namespace MunicipalEngineering
{
    partial class CheckProjectForm
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
            this.Prj_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择要检查的工程：";
            // 
            // Prj_checkedListBox
            // 
            this.Prj_checkedListBox.CheckOnClick = true;
            this.Prj_checkedListBox.FormattingEnabled = true;
            this.Prj_checkedListBox.Location = new System.Drawing.Point(12, 41);
            this.Prj_checkedListBox.Name = "Prj_checkedListBox";
            this.Prj_checkedListBox.Size = new System.Drawing.Size(597, 284);
            this.Prj_checkedListBox.TabIndex = 1;
            this.Prj_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.Prj_checkedListBox_SelectedIndexChanged);
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(223, 331);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 32);
            this.OK_button.TabIndex = 2;
            this.OK_button.Text = "确 定";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(325, 331);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 32);
            this.Cancel_button.TabIndex = 3;
            this.Cancel_button.Text = "取 消";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // CheckProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 367);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.Prj_checkedListBox);
            this.Controls.Add(this.label1);
            this.Name = "CheckProjectForm";
            this.Text = "项目检查";
            this.Load += new System.EventHandler(this.CheckProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox Prj_checkedListBox;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button Cancel_button;
    }
}