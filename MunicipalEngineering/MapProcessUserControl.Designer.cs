namespace MunicipalEngineering
{
    partial class MapProcessUserControl
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
            this.MPP_button = new System.Windows.Forms.Button();
            this.SZCJ_button = new System.Windows.Forms.Button();
            this.ZDZB_button = new System.Windows.Forms.Button();
            this.CZB_button = new System.Windows.Forms.Button();
            this.DXT_button = new System.Windows.Forms.Button();
            this.ZT_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MPP_button
            // 
            this.MPP_button.Location = new System.Drawing.Point(24, 38);
            this.MPP_button.Name = "MPP_button";
            this.MPP_button.Size = new System.Drawing.Size(95, 23);
            this.MPP_button.TabIndex = 0;
            this.MPP_button.Text = "数据预处理";
            this.MPP_button.UseVisualStyleBackColor = true;
            this.MPP_button.Click += new System.EventHandler(this.MPP_button_Click);
            // 
            // SZCJ_button
            // 
            this.SZCJ_button.Location = new System.Drawing.Point(24, 67);
            this.SZCJ_button.Name = "SZCJ_button";
            this.SZCJ_button.Size = new System.Drawing.Size(95, 23);
            this.SZCJ_button.TabIndex = 1;
            this.SZCJ_button.Text = "十字裁剪";
            this.SZCJ_button.UseVisualStyleBackColor = true;
            this.SZCJ_button.Click += new System.EventHandler(this.SZCJ_button_Click);
            // 
            // ZDZB_button
            // 
            this.ZDZB_button.Location = new System.Drawing.Point(24, 98);
            this.ZDZB_button.Name = "ZDZB_button";
            this.ZDZB_button.Size = new System.Drawing.Size(95, 23);
            this.ZDZB_button.TabIndex = 2;
            this.ZDZB_button.Text = "自动扯坐标";
            this.ZDZB_button.UseVisualStyleBackColor = true;
            this.ZDZB_button.Click += new System.EventHandler(this.ZDZB_button_Click);
            // 
            // CZB_button
            // 
            this.CZB_button.Location = new System.Drawing.Point(24, 127);
            this.CZB_button.Name = "CZB_button";
            this.CZB_button.Size = new System.Drawing.Size(95, 23);
            this.CZB_button.TabIndex = 3;
            this.CZB_button.Text = "手动扯坐标";
            this.CZB_button.UseVisualStyleBackColor = true;
            this.CZB_button.Click += new System.EventHandler(this.CZB_button_Click);
            // 
            // DXT_button
            // 
            this.DXT_button.Location = new System.Drawing.Point(24, 156);
            this.DXT_button.Name = "DXT_button";
            this.DXT_button.Size = new System.Drawing.Size(95, 23);
            this.DXT_button.TabIndex = 4;
            this.DXT_button.Text = "详勘-定线";
            this.DXT_button.UseVisualStyleBackColor = true;
            this.DXT_button.Click += new System.EventHandler(this.DXT_button_Click);
            // 
            // ZT_button
            // 
            this.ZT_button.Location = new System.Drawing.Point(24, 185);
            this.ZT_button.Name = "ZT_button";
            this.ZT_button.Size = new System.Drawing.Size(95, 23);
            this.ZT_button.TabIndex = 5;
            this.ZT_button.Text = "分幅-总图";
            this.ZT_button.UseVisualStyleBackColor = true;
            this.ZT_button.Click += new System.EventHandler(this.ZT_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.ZT_button);
            this.groupBox1.Controls.Add(this.DXT_button);
            this.groupBox1.Controls.Add(this.CZB_button);
            this.groupBox1.Controls.Add(this.ZDZB_button);
            this.groupBox1.Controls.Add(this.SZCJ_button);
            this.groupBox1.Controls.Add(this.MPP_button);
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // MapProcessUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MapProcessUserControl";
            this.Size = new System.Drawing.Size(160, 244);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MPP_button;
        private System.Windows.Forms.Button SZCJ_button;
        private System.Windows.Forms.Button ZDZB_button;
        private System.Windows.Forms.Button CZB_button;
        private System.Windows.Forms.Button DXT_button;
        private System.Windows.Forms.Button ZT_button;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
