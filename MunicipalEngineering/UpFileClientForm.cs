using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalEngineering
{
    public partial class UpFileClientForm : Form
    {
        public UpFileClientForm()
        {
            InitializeComponent();
        }

        string filePath = "";

        private void sel_button_Click(object sender, EventArgs e)
        {
            //创建文件弹出选择窗口（包括文件名）对象
                     
            string folderName = string.Empty;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择工程所在文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    // MessageBox.Show("文件夹路径不能为空", "提示");
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("文件夹路径不能为空");
                }
                folderName = dialog.SelectedPath;
                sel_textBox.Text = folderName;

                string destPath = folderName + ".zip";

                bool isSuccess = ZipHelper.CreateZip(folderName, destPath);

               

                if (isSuccess)
                {

                    filePath = destPath;
                }
                else
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("工程文件夹压缩失败！");
                    return;

                }

            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("未选择任何文件");
                return;
            }
        }

        private void upLoad_button_Click(object sender, EventArgs e)
        {
            try
            {
                //上传服务器的地址（web服务）
               // string address = "http://10.12.200.110:806/aspx/SaveFile.aspx";//内网服务器地址

                string url = "http://60.28.130.70:806/aspx/SaveFile.aspx";//外网部署地址
                //上传后文件保存的名称
                //string saveName = DateTime.Now.ToString("yyyyMMddHHmmss");
                string saveName = Path.GetFileName(filePath);
                //HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address + "?prjType=" + prjType + "&TaskId= b98b7bf6-a913-45e5-9ec8-37ae9baadaf6"));/

                 int count = UpFile_Request(url, filePath, saveName, this.progressBar1);
                if (count > 0)
                {
                    MessageBox.Show("上传文件成功！");
                }
                else
                {
                    MessageBox.Show("上传文件失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.GetBaseException());
            }
        }



        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="address">文件上传到服务器的路径</param>
        /// <param name="fileNamePath">要上传的本地路径（全路径）</param>
        /// <param name="saveName">文件上传后的名称</param>
        /// <returns>成功返回1，失败返回0</returns>
        public int UpFile_Request(string address, string fileNamePath, string saveName, ProgressBar progressBar)
        {
            int returnValue = 0;
            //要上传的文件
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            //二进制对象
            BinaryReader r = new BinaryReader(fs);
            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
            //请求的头部信息
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);

            sb.Append("\";");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
            // 根据uri创建HttpWebRequest对象   
            // string prjType = "JCRJ";//检查软件类型字典：JCRJ；采编软件管线工程资料类型字典：GXGC；其他类型的联系葛亮进行扩充
            string prjType = "SZFX";//市政放线工程类型字典：SZFX
            //string guid = Guid.NewGuid().ToString();  //随机生成的工程ID,只有新项目是随机生成的，以后编辑项目都需要用这一个ID，这样才能与时空数据库对接
            string guid = "b98b7bf6-a913-45e5-9ec8-37ae9baadaf6";
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address + "?prjType=" + prjType + "&TaskId=" + guid));
            httpReq.Method = "POST";
            //对发送的数据不使用缓存   
            httpReq.AllowWriteStreamBuffering = false;
            //设置获得响应的超时时间（300秒）   
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                progressBar.Maximum = int.MaxValue;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                //每次上传4k       
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength]; //已上传的字节数   
                long offset = 0;         //开始上传时间   
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();         //发送请求头部消息   
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    progressBar.Value = (int)(offset * (int.MaxValue / length));
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;
                    labTime.Text = "已用时：" + second.ToString("F2") + "秒";
                    if (second > 0.001)
                    {
                        labSpeed.Text = "平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                    }
                    else
                    {
                        labSpeed.Text = " 正在连接…";
                    }
                    labState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                    labSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    Application.DoEvents();
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳   
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();
                //获取服务器端的响应   
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                //读取服务器端返回的消息  
                StreamReader sr = new StreamReader(s);
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString.Contains("Success"))
                {
                    /////////////////////在这里需要记录返回的文件名/////////////////////////
                   // string returnFileName = sReturnString.Split(',')[1]; //返回的结果是  GUID.ZIP，光昇用于后边的流程
                  //  MessageBox.Show(returnFileName);
                    returnValue = 1;
                }
                else if (sReturnString.Contains("Error"))
                {
                   // string returnErrMsg = sReturnString.Split(',')[1];
                  //  MessageBox.Show(returnErrMsg);
                    returnValue = 0;
                }
            }
            catch
            {
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }
            return returnValue;
        }
    }
}
