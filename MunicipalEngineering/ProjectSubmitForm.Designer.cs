namespace MunicipalEngineering
{
    partial class ProjectSubmitForm
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
            this.prjSubmit_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.Sumit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择要提交的工程：";
            // 
            // prjSubmit_checkedListBox
            // 
            this.prjSubmit_checkedListBox.CheckOnClick = true;
            this.prjSubmit_checkedListBox.FormattingEnabled = true;
            this.prjSubmit_checkedListBox.Location = new System.Drawing.Point(5, 34);
            this.prjSubmit_checkedListBox.Name = "prjSubmit_checkedListBox";
            this.prjSubmit_checkedListBox.Size = new System.Drawing.Size(627, 244);
            this.prjSubmit_checkedListBox.TabIndex = 1;
            // 
            // Sumit_button
            // 
            this.Sumit_button.Location = new System.Drawing.Point(247, 284);
            this.Sumit_button.Name = "Sumit_button";
            this.Sumit_button.Size = new System.Drawing.Size(95, 37);
            this.Sumit_button.TabIndex = 2;
            this.Sumit_button.Text = "成果提交";
            this.Sumit_button.UseVisualStyleBackColor = true;
            this.Sumit_button.Click += new System.EventHandler(this.Sumit_button_Click);
            // 
            // ProjectSubmitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 320);
            this.Controls.Add(this.Sumit_button);
            this.Controls.Add(this.prjSubmit_checkedListBox);
            this.Controls.Add(this.label1);
            this.Name = "ProjectSubmitForm";
            this.Text = "成果回交";
            this.Load += new System.EventHandler(this.ProjectSubmitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox prjSubmit_checkedListBox;
        private System.Windows.Forms.Button Sumit_button;
    }
}