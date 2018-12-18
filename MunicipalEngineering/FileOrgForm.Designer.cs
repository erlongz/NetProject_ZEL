namespace MunicipalEngineering
{
    partial class FileOrgForm
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
            this.YS_treeView = new System.Windows.Forms.TreeView();
            this.CG_treeView = new System.Windows.Forms.TreeView();
            this.Sort_button = new System.Windows.Forms.Button();
            this.Add_button = new System.Windows.Forms.Button();
            this.del_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YS_treeView
            // 
            this.YS_treeView.Location = new System.Drawing.Point(12, 3);
            this.YS_treeView.Name = "YS_treeView";
            this.YS_treeView.Size = new System.Drawing.Size(258, 381);
            this.YS_treeView.TabIndex = 0;
            // 
            // CG_treeView
            // 
            this.CG_treeView.Location = new System.Drawing.Point(357, 3);
            this.CG_treeView.Name = "CG_treeView";
            this.CG_treeView.Size = new System.Drawing.Size(272, 380);
            this.CG_treeView.TabIndex = 1;
            // 
            // Sort_button
            // 
            this.Sort_button.Location = new System.Drawing.Point(276, 390);
            this.Sort_button.Name = "Sort_button";
            this.Sort_button.Size = new System.Drawing.Size(75, 31);
            this.Sort_button.TabIndex = 2;
            this.Sort_button.Text = "整 理";
            this.Sort_button.UseVisualStyleBackColor = true;
            this.Sort_button.Click += new System.EventHandler(this.Sort_button_Click);
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(276, 117);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 29);
            this.Add_button.TabIndex = 3;
            this.Add_button.Text = "添 加";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(276, 183);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(75, 29);
            this.del_button.TabIndex = 4;
            this.del_button.Text = "删 除";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // FileOrgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 425);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.Sort_button);
            this.Controls.Add(this.CG_treeView);
            this.Controls.Add(this.YS_treeView);
            this.Name = "FileOrgForm";
            this.Text = "文件整理";
            this.Load += new System.EventHandler(this.FileOrgForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView YS_treeView;
        private System.Windows.Forms.TreeView CG_treeView;
        private System.Windows.Forms.Button Sort_button;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button del_button;
    }
}