namespace MunicipalEngineering
{
    partial class MainUserControl
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
            this.szfxUserControl1 = new MunicipalEngineering.SZFXUserControl();
            this.SuspendLayout();
            // 
            // szfxUserControl1
            // 
            this.szfxUserControl1.Location = new System.Drawing.Point(0, 0);
            this.szfxUserControl1.Name = "szfxUserControl1";
            this.szfxUserControl1.Size = new System.Drawing.Size(227, 202);
            this.szfxUserControl1.TabIndex = 1;
            this.szfxUserControl1.Load += new System.EventHandler(this.szfxUserControl1_Load_1);
            // 
            // MainUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.szfxUserControl1);
            this.Name = "MainUserControl";
            this.Size = new System.Drawing.Size(230, 205);
            this.Load += new System.EventHandler(this.MainUserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SZFXUserControl szfxUserControl1;
    }
}
