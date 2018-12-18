using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;
//using Autodesk.AutoCAD.Interop;
//using Autodesk.AutoCAD.Interop.Common;
using Autodesk.AutoCAD.Colors;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System.Collections;

using System.IO;
using System.Xml;


namespace MunicipalEngineering
{
    public partial class MetadataForm : Form
    {
        public MetadataForm()
        {
            InitializeComponent();

            this.Text = " 市政工程放线元数据信息" + "  " + UtilityVar.departmentName + ":" + UtilityVar.trueName+ " 欢迎您！";
            this.FilePath_textBox.Text = UtilityVar.FileNameFullPath;
        }

        private void Brosw_button_Click(object sender, EventArgs e)
        {
            string folderName = string.Empty;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择工程所在文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    // MessageBox.Show("文件夹路径不能为空", "提示");
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("文件夹路径不能为空");
                    return;
                }
                folderName = dialog.SelectedPath;

                FilePath_textBox.Text = folderName;

            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("未选择任何文件");
                return;
            }


        }

        private void GEN_button_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FilePath_textBox.Text);
            string XmlFilePath = FilePath_textBox.Text + "\\"+fileName+".xml";

            XmlHelper xhelper = new XmlHelper();

            string wkid = "32650";
            string XMBH = "津西青线建案申字0005号";
            string XMMC = "XXXX供电工程";
            string JDXH = "XXXX";
            string KSSJ = "2018-10-31";
            string YZDW = "规划自然资源局";
            string CJDW = "测绘一院";
            string XMLB = "规划工程";
            string XMLX = "规划控制";

            //写入范围线信息，以JSon格式呈现 

            //string FWXPath = @"D:\FWXTest.dwg"; 

            string FWXPath = FWX_textBox.Text;
                JsonHelper JH = new JsonHelper();

            string JSon = JH.DwgPlToJSon(FWXPath,wkid,XMBH,XMMC,JDXH,KSSJ,YZDW,CJDW,XMLB,XMLX);


            try
            {
                xhelper.CreateXmlRoot("市政工程放线");
                if (!string.IsNullOrEmpty(XMMC_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "项目名称", XMMC_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "项目名称", "");

                }
                if (!string.IsNullOrEmpty(XMZBH_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "项目总编号", XMZBH_textBox.Text);

                }
                else
                {


                    //允许字段为空
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目总编号！");
                    //return;
                    xhelper.CreatXmlNode("市政工程放线", "项目总编号", "");
                }


                if (!string.IsNullOrEmpty(GCID_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "工程ID", GCID_textBox.Text);

                }
                else
                {


                    //允许字段为空
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目总编号！");
                    //return;
                    xhelper.CreatXmlNode("市政工程放线", "工程ID", "");
                }

                if (!string.IsNullOrEmpty(WKID_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "WKID", WKID_textBox.Text);

                }
                else
                {


                    //允许字段为空
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目总编号！");
                    //return;
                    xhelper.CreatXmlNode("市政工程放线", "WKID", "");
                }



                if (!string.IsNullOrEmpty(GCBH_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "工程编号", GCBH_textBox.Text);

                }
                else
                {
                    // Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    // return;

                    xhelper.CreatXmlNode("市政工程放线", "工程编号", "");

                }

                if (!string.IsNullOrEmpty(SQBH_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "申请编号", SQBH_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "申请编号", "");

                }



                if (!string.IsNullOrEmpty(XKZ_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "许可证编号", XKZ_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "许可证编号", "");

                }


                if (!string.IsNullOrEmpty(GCZL_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "工程种类", GCZL_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "工程种类", "");

                }


                if (!string.IsNullOrEmpty(GCLX_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "工程类型", GCLX_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "工程类型", "");

                }


                if (!string.IsNullOrEmpty(GCGG_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "工程规格", GCGG_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "工程规格", "");

                }


                if (!string.IsNullOrEmpty(XKCD_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "许可长度", XKCD_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "许可长度", "");

                }


                if (!string.IsNullOrEmpty(CLNR_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "测量内容", CLNR_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "测量内容", "");

                }


                



                if (!string.IsNullOrEmpty(ZLDD_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "坐落地点", ZLDD_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "坐落地点", "");

                }


                if (!string.IsNullOrEmpty(JSDW_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "建设单位", JSDW_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "建设单位", "");

                }


                if (!string.IsNullOrEmpty(WTDW_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "委托单位", WTDW_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "委托单位", "");

                }


                if (!string.IsNullOrEmpty(SJDW_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "设计单位", SJDW_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "设计单位", "");

                }

                if (!string.IsNullOrEmpty(SGDW_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "施工单位", SGDW_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "施工单位", "");

                }

                if (!string.IsNullOrEmpty(YZDW_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "YZ单位", YZDW_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "YZ单位", "");

                }


                if (!string.IsNullOrEmpty(CLDW_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "测量单位", CLDW_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "测量单位", "");

                }


                if (!string.IsNullOrEmpty(CLY_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "测量员", CLY_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "测量员", "");

                }


                if (!string.IsNullOrEmpty(HTY_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "绘图员", HTY_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "绘图员", "");

                }


                if (!string.IsNullOrEmpty(JCY_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "检查员", JCY_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "检查员", "");

                }


                if (!string.IsNullOrEmpty(FXR_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "放线人", FXR_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "放线人", "");

                }

                if (!string.IsNullOrEmpty(dateTimePicker1.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "作业时间", dateTimePicker1.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "作业时间", "");

                }


                if (!string.IsNullOrEmpty(GCND_textBox.Text))
                {

                    xhelper.CreatXmlNode("市政工程放线", "高程年代", GCND_textBox.Text);

                }
                else
                {
                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请输入项目编号！");
                    //return;

                    xhelper.CreatXmlNode("市政工程放线", "高程年代", "");

                }

                //把市政工程放线项目范围线写入xml文档，并且把时空数据库要求的信息传入时空数据库

                if (!string.IsNullOrEmpty(JSon))
                {
                    xhelper.CreatXmlNode("市政工程放线", "范围线",JSon);

                }
                else
                {

                    xhelper.CreatXmlNode("市政工程放线", "范围线", "");
                }



                //保存文件

                xhelper.XmlSave(XmlFilePath);

                //接受采编软件传入的工程基本信息和状态信息



                


                bool UpMdataInfo = true;

                if(UpMdataInfo)
                {
                    UtilityVar.isWriteMDataSuccess = true;
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("上传工程信息成功!!写入元数据信息成功，请到工程文件夹下查看！");
                    this.Close();
                }

                
                



            }
            catch
            {
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("写入元数据信息时发生错误！");
                return;


            }
           
          

        }

        private void MetadataForm_Load(object sender, EventArgs e)
        {

        }

        private void FWX_button_Click(object sender, EventArgs e)
        {

            //string FWX_FileName = string.Empty;
            System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.Filter = "数据文件|*.dwg";
            openDialog.Title = "选择范围线文件";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               // FWX_FileName = openDialog.FileName;

                FWX_textBox.Text = openDialog.FileName;
            }


            else
            {
                //MessageBox.Show("您未选择任何文件，请重新选择文件！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("您未选择任何文件，请重新选择文件！");
                // Application.Exit();
                return ;
            }
        }
    }
}
