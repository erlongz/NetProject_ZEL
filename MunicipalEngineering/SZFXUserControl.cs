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
    public partial class SZFXUserControl : UserControl
    {
        public SZFXUserControl()
        {
            InitializeComponent();
           

           
        }


        public void setPanelHeight()
        {
           // this.Height =this.SZFX_Button.Height;
            this.Height = this.Height;
        }

        public void setPanelHeight1()
        {
            this.Height =this.SZFX_Button.Height;

        }

        private void SZFX_Button_Click(object sender, EventArgs e)
        {
           
        }

        private void MapTool_button_Click(object sender, EventArgs e)
        {

        }

        private void ToSHP_button_Click(object sender, EventArgs e)
        {
            Form creatSHPForm = new SHPForm_SZGC();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, creatSHPForm, false);
        }

        private void Word_button_Click(object sender, EventArgs e)
        {
            Form GenReport = new ReportGenForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, GenReport, false);
        }

        private void FileSort_button_Click(object sender, EventArgs e)
        {
            Form OrgFile = new FileOrgForm();

            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, OrgFile, false);

        }

        private void Upload_button_Click(object sender, EventArgs e)
        {
            

            Form UpFile = new UpFileClientForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, UpFile, false);
        }
    }
}
