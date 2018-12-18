namespace MunicipalEngineering
{
    partial class SZFXUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SZFX_Button = new System.Windows.Forms.Button();
            this.MapTool_button = new System.Windows.Forms.Button();
            this.ToSHP_button = new System.Windows.Forms.Button();
            this.Word_button = new System.Windows.Forms.Button();
            this.FileSort_button = new System.Windows.Forms.Button();
            this.Upload_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SZFX_Button
            // 
            this.SZFX_Button.Location = new System.Drawing.Point(4, 0);
            this.SZFX_Button.Name = "SZFX_Button";
            this.SZFX_Button.Size = new System.Drawing.Size(220, 28);
            this.SZFX_Button.TabIndex = 0;
            this.SZFX_Button.Text = "市政放线测量系统";
            this.SZFX_Button.UseVisualStyleBackColor = true;
            this.SZFX_Button.Click += new System.EventHandler(this.SZFX_Button_Click);
            // 
            // MapTool_button
            // 
            this.MapTool_button.BackColor = System.Drawing.Color.Turquoise;
            this.MapTool_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapTool_button.Location = new System.Drawing.Point(3, 34);
            this.MapTool_button.Name = "MapTool_button";
            this.MapTool_button.Size = new System.Drawing.Size(221, 28);
            this.MapTool_button.TabIndex = 1;
            this.MapTool_button.Text = "图面处理";
            this.MapTool_button.UseVisualStyleBackColor = false;
            this.MapTool_button.Click += new System.EventHandler(this.MapTool_button_Click);
            // 
            // ToSHP_button
            // 
            this.ToSHP_button.BackColor = System.Drawing.Color.Turquoise;
            this.ToSHP_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToSHP_button.Location = new System.Drawing.Point(3, 68);
            this.ToSHP_button.Name = "ToSHP_button";
            this.ToSHP_button.Size = new System.Drawing.Size(221, 28);
            this.ToSHP_button.TabIndex = 2;
            this.ToSHP_button.Text = "DWG->SHP转换";
            this.ToSHP_button.UseVisualStyleBackColor = false;
            this.ToSHP_button.Click += new System.EventHandler(this.ToSHP_button_Click);
            // 
            // Word_button
            // 
            this.Word_button.BackColor = System.Drawing.Color.Turquoise;
            this.Word_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Word_button.Location = new System.Drawing.Point(3, 102);
            this.Word_button.Name = "Word_button";
            this.Word_button.Size = new System.Drawing.Size(221, 28);
            this.Word_button.TabIndex = 3;
            this.Word_button.Text = "报告生成";
            this.Word_button.UseVisualStyleBackColor = false;
            this.Word_button.Click += new System.EventHandler(this.Word_button_Click);
            // 
            // FileSort_button
            // 
            this.FileSort_button.BackColor = System.Drawing.Color.Turquoise;
            this.FileSort_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileSort_button.Location = new System.Drawing.Point(3, 136);
            this.FileSort_button.Name = "FileSort_button";
            this.FileSort_button.Size = new System.Drawing.Size(221, 28);
            this.FileSort_button.TabIndex = 4;
            this.FileSort_button.Text = "成果整理";
            this.FileSort_button.UseVisualStyleBackColor = false;
            this.FileSort_button.Click += new System.EventHandler(this.FileSort_button_Click);
            // 
            // Upload_button
            // 
            this.Upload_button.BackColor = System.Drawing.Color.Turquoise;
            this.Upload_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Upload_button.Location = new System.Drawing.Point(3, 170);
            this.Upload_button.Name = "Upload_button";
            this.Upload_button.Size = new System.Drawing.Size(221, 28);
            this.Upload_button.TabIndex = 5;
            this.Upload_button.Text = "本地上传";
            this.Upload_button.UseVisualStyleBackColor = false;
            this.Upload_button.Click += new System.EventHandler(this.Upload_button_Click);
            // 
            // SZFXUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Upload_button);
            this.Controls.Add(this.FileSort_button);
            this.Controls.Add(this.Word_button);
            this.Controls.Add(this.ToSHP_button);
            this.Controls.Add(this.MapTool_button);
            this.Controls.Add(this.SZFX_Button);
            this.Name = "SZFXUserControl";
            this.Size = new System.Drawing.Size(227, 203);
            this.ResumeLayout(false);

        }

        #endregion

       public System.Windows.Forms.Button SZFX_Button;
        public System.Windows.Forms.Button MapTool_button;
        public System.Windows.Forms.Button ToSHP_button;
        public System.Windows.Forms.Button Word_button;
        public System.Windows.Forms.Button FileSort_button;
        public System.Windows.Forms.Button Upload_button;
    }
}
