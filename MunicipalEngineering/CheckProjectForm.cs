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
    public partial class CheckProjectForm : Form
    {
        public CheckProjectForm()
        {
            InitializeComponent();

            
        }

        private void CheckProjectForm_Load(object sender, EventArgs e)
        {

            //读取元数据模板---加载未检查的项目：
            Prj_checkedListBox.Items.Add("chsy1708 - 0033-- - 盛庭丽景10kV电力电缆配套工程放线");
            Prj_checkedListBox.Items.Add("chsy1708 - 0034-- - 盛庭丽景10kV电力电缆配套工程放线");
            Prj_checkedListBox.Items.Add("chsy1708 - 0035-- - 盛庭丽景10kV电力电缆配套工程放线");
            Prj_checkedListBox.Items.Add("chsy1708 - 0036-- - 盛庭丽景10kV电力电缆配套工程放线");
            Prj_checkedListBox.Items.Add("chsy1708 - 0037-- - 盛庭丽景10kV电力电缆配套工程放线");
        }





        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void OK_button_Click(object sender, EventArgs e)
        {
            //检查工程：选择完成后，弹出检查工程面板，能够显示这个工程下所有的文件名称，单击能够打开文件；

           if(Prj_checkedListBox.SelectedItems.Count>1||Prj_checkedListBox.SelectedItems.Count ==0)
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请选择一项需要检查的工程！");


            }
           else
            {

               

                UtilityVar.isCheckPrjSuccess = true;

                UtilityVar.CheckFileName = Prj_checkedListBox.GetItemText(Prj_checkedListBox.SelectedItem);

            }
            



            
        }

        private void Prj_checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Prj_checkedListBox.SelectedIndex;

            for(int j=0;j<Prj_checkedListBox.Items.Count;j++)
            {


                if(j!=index)
                {


                    Prj_checkedListBox.SetItemCheckState(j, CheckState.Unchecked);
                }
            }
        }
    }
}
