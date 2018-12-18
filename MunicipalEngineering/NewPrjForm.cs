using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MunicipalEngineering
{
    public partial class NewPrjForm : Form
    {
        public NewPrjForm()
        {
            InitializeComponent();

            PrjPath_textBox.Text = @"D:";
        }

        private void Brw_button_Click(object sender, EventArgs e)
        {
            string folderName = string.Empty;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "工程位置";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    // MessageBox.Show("文件夹路径不能为空", "提示");
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("文件夹路径不能为空");
                    return;
                }
                folderName = dialog.SelectedPath;
                
                PrjPath_textBox.Text = folderName;

            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("未选择任何文件");
                return;
            }
        }

        private void CreatPrj_button_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(PrjName_textBox.Text))
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入新建工程名称！");
                return;

            }

            //1.创建工程文件夹，并把路径传送给全局变量  FileNameFullPath ;

            string prjPath = PrjPath_textBox.Text +"\\" + PrjName_textBox.Text;

            if(!Directory.Exists(prjPath))
            {

                Directory.CreateDirectory(prjPath);
                UtilityVar.isPrjCreate = true;

                UtilityVar.FileNameFullPath = prjPath;
                this.Close();

            }
            else
            {
                UtilityVar.FileNameFullPath = prjPath;
                UtilityVar.isPrjCreate = true;
                this.Close();

            }

            //写一个prj文件，此文件记录项目编辑信息，如果编辑工程打开此文件，恢复上次编辑界面；

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtilityVar.isPrjCreate = false;
            this.Close();
            return;
        }
    }
}
