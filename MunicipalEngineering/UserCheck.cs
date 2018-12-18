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
using System.Net;
using System.Xml;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using Autodesk.AutoCAD.Colors;


namespace MunicipalEngineering
{
    public partial class UserCheck : Form
    {
        public UserCheck()
        {
            InitializeComponent();
        }

        private void ShowPSW_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPSW_checkBox.Checked == true)
            {

                PassWord_textBox.UseSystemPasswordChar = false;
            }
            else
            {
                PassWord_textBox.UseSystemPasswordChar = true;


            }
        }

        private void Quit_button_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void logIn_button_Click(object sender, EventArgs e)
        {

            
            try
            {

                //string url = "http://10.12.200.110:806/ConnectOut.asmx" ;//内网地址 
                string url = "http://60.28.130.70:806/ConnectOut.asmx";//外网部署地址
                string methodName = "CheckUser";

              //  string checkStr = "userName = " + UserName_textBox.Text + " & psw = " + PassWord_textBox.Text;
                // string Paras = "userName = 0628 & psw = 08370837";

                string Paras = "userName=" + UserName_textBox.Text+ "&psw=" + PassWord_textBox.Text;
                // string Paras = "userName=0628&psw=08370837";
               // string Paras = "userName=0930&psw=123456";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/" + methodName + "?" + Paras);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencode";
                WebResponse ws = request.GetResponse();

     
                StreamReader sr = new StreamReader(ws.GetResponseStream());
                string msg = sr.ReadToEnd();
                sr.Close();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(msg);

                string logMsg = xmlDoc.InnerText;
                // MessageBox.Show(xmlDoc.InnerText);
                //处理字符串 

                logMsg = logMsg.Replace("[", "");
                logMsg = logMsg.Replace("]", "");
                logMsg = logMsg.Replace("{", "");
                logMsg = logMsg.Replace("}", "");


                string [] logMsgArr = logMsg.Split(',');



                if(logMsgArr.Length == 3)
                {

                    UtilityVar.isLogSuccess = true;

                    foreach (string str in logMsgArr)
                    {


                        if (str.Contains("DepartmentName"))
                        {

                            string[] tempStr = str.Split(':');
                            UtilityVar.departmentName = tempStr[tempStr.Length - 1].Replace("\"", "");

                        }


                        if (str.Contains("TrueName"))
                        {


                            string[] tempStr = str.Split(':');
                            UtilityVar.trueName = tempStr[tempStr.Length - 1].Replace("\"", "");
                        }


                    }

                }
                else
                {

                    UtilityVar.isLogSuccess = false;

                    foreach (string str in logMsgArr)
                    {

                        if (str.Contains("msg"))
                        {

                            string[] tempStr = str.Split(':');
                            UtilityVar.logMsg = tempStr[tempStr.Length - 1].Replace("\"", "");

                        }




                    }
                }

                /*

                if (UtilityVar.isLogSuccess == true)
                {
                    this.Dispose();

                    //Form UserForm = new UserCheck();

                    MetadataForm MetaForm = new MetadataForm();

                    Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MetaForm, false);

                }
                else
                {

                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(UtilityVar.logMsg);

                }*/

                if (UtilityVar.isLogSuccess == true)
                {
                    this.Close(); //试验部分

                }
                else
                {

                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(UtilityVar.logMsg);

                }
                





            }
            catch( System.Exception )  
            {

                throw;
            }
        }
    }
}
