using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalEngineering
{
    public partial class MainUserControl : UserControl
    {
        public MainUserControl()
        {
            InitializeComponent();
        }

        private void szfxUserControl1_Load(object sender, EventArgs e)
        {
           // InitPanFun();
           // this.ucFile1.btnFile.Click += new EventHandler(btnFile_Click);

           // this.szfxUserControl1.SZFX_Button.Click += new EventHandler(SZFX_Button_Click);
        }



        private void InitPanFun()
        {

           // this.szfxUserControl1.setPanelHeight1();
           // this.szfxUserControl1.Dock = DockStyle.Top;

            this.szfxUserControl1.setPanelHeight1();
            this.szfxUserControl1.Dock = DockStyle.Top;


        }

        private void SZFX_Button_Click(object sender, EventArgs e)
        {

            

            if(this.szfxUserControl1.Dock==DockStyle.Fill)
            {
                this.szfxUserControl1.setPanelHeight1();
                this.szfxUserControl1.Dock = DockStyle.Top;

            }
            else if(this.szfxUserControl1.Dock == DockStyle.Top)
            {
                this.szfxUserControl1.setPanelHeight();
                this.szfxUserControl1.Dock = DockStyle.Fill;

            }
        }

        private void MainUserControl_Load(object sender, EventArgs e)
        {
          //  InitPanFun();
            // this.ucFile1.btnFile.Click += new EventHandler(btnFile_Click);

          //  this.szfxUserControl1.SZFX_Button.Click += new EventHandler(SZFX_Button_Click);
        }

        private void szfxUserControl1_Load_1(object sender, EventArgs e)
        {
            InitPanFun();
            // this.ucFile1.btnFile.Click += new EventHandler(btnFile_Click);

            this.szfxUserControl1.SZFX_Button.Click += new EventHandler(SZFX_Button_Click);
        }
    }
}
