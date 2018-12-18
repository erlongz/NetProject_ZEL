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
    public partial class EngineerStatusForm : Form
    {
        public EngineerStatusForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(NewProject_radioButton.Checked == true)
            {

                UtilityVar.PrjStatus = 1;
                this.Close();

              /* SaveFileDialog sfd = new SaveFileDialog();
                //设置文件类型 
                //  sfd.Filter = "数据库备份文件（*.bak）|*.bak|数据文件（*.mdf）|*.mdf|日志文件（*.ldf）|*.ldf";
                sfd.Filter = "市政放线工程文件（*.prj）|*.prj";

                 //设置默认文件类型显示顺序 
               // sfd.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    string localFilePath = sfd.FileName.ToString(); //获得文件路径
                }*/



            }
            else if(EditProject_radioButton.Checked == true)
            {

                UtilityVar.PrjStatus = 2;
                this.Close();

                //编辑工程：打开对话框，选择工程；
                FolderBrowserDialog folder = new FolderBrowserDialog();
                folder.Description = "选择工程";
                if (folder.ShowDialog() == DialogResult.OK)
                {

                    string sPath = folder.SelectedPath;
                    UtilityVar.FileNameFullPath = sPath;
                }

                //读取工程文件夹下的元数据模板*.XML
                //读取上次CAD打开的文档例如6-1,6-2；




            }
            else if(CheckProject_radioButton.Checked == true)
            {


                UtilityVar.PrjStatus = 3;
                this.Close();



            }
            else if(SubmitProject_radioButton.Checked == true)
            {


                UtilityVar.PrjStatus = 4;
                this.Close();


            }
            else
            {


                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请选择工程状态!");
            }
        }
    }
}
