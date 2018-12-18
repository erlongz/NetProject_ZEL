using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalEngineering
{
    public partial class ProjectSubmitForm : Form
    {
        public ProjectSubmitForm()
        {
            InitializeComponent();
        }

        private void Sumit_button_Click(object sender, EventArgs e)
        {


            if(prjSubmit_checkedListBox.SelectedItems.Count>0)
            {
                this.Close();
                UpFileClientForm upf = new UpFileClientForm();

                Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, upf, false);
            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请选择要提交的工程！");

            }
           
        }

        private void ProjectSubmitForm_Load(object sender, EventArgs e)
        {
            //需要提交的项目：
            prjSubmit_checkedListBox.Items.Add("chsy1708 - 0033-- - 盛庭丽景10kV电力电缆配套工程放线");
            prjSubmit_checkedListBox.Items.Add("chsy1708 - 0034-- - 盛庭丽景10kV电力电缆配套工程放线");
            prjSubmit_checkedListBox.Items.Add("chsy1708 - 0035-- - 盛庭丽景10kV电力电缆配套工程放线");
            prjSubmit_checkedListBox.Items.Add("chsy1708 - 0036-- - 盛庭丽景10kV电力电缆配套工程放线");
            prjSubmit_checkedListBox.Items.Add("chsy1708 - 0037-- - 盛庭丽景10kV电力电缆配套工程放线");
            
        }
    }
}
