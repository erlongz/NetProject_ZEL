using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Security.Cryptography;

namespace MunicipalEngineering
{
    public partial class EnCodeForm : Form
    {
        public EnCodeForm()
        {
            InitializeComponent();
        }

        private void GenCode_button_Click(object sender, EventArgs e)
        {
            string HWID = Value();

            MCode_textBox.Text = HWID;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(MCode_textBox.Text))
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请先生成机器码！");
                return;
            }
            if (!String.IsNullOrEmpty(Reg_textBox.Text))
            {

                string ResCode = GetCode(MCode_textBox.Text);


                if (ResCode.Equals(Reg_textBox.Text))
                {

                  //  MessageBox.Show("验证成功");

                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("验证成功！");

                    Form GenReport = new ReportGenForm();
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, GenReport, false);


                }
                else
                {
                   // MessageBox.Show("验证失败，请重新输入验证码");
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("验证失败，请重新输入验证码！");
                }

            }
            else
            {

                MessageBox.Show("请输入验证码!", "验证提示");

            }
        }



        private static string _fingerPrint = string.Empty;
        /// <summary>
        /// 利用HASH算法MD5，生成整齐的机器码 
        /// </summary>
        /// <returns></returns>
        private static string Value()
        {
            //You don't need to generate the HWID again if it has already been generated. This is better for performance
            //Also, your HWID generally doesn't change when your computer is turned on but it can happen.
            //It's up to you if you want to keep generating a HWID or not if the function is called.
            if (string.IsNullOrEmpty(_fingerPrint))
            {
                _fingerPrint = GetHash("CPU >> " + CpuId() + "\nBIOS >> " + BiosId() + "\nBASE >> " + BaseId() + "\nDISK >> " + DiskId() + "\nVIDEO >> " + VideoId() + "\nMAC >> " + MacId());
            }
            return _fingerPrint;
        }



        //步骤三: 使用机器码生成软件注册码, 代码如下:
        //使用机器码生成注册码
        public static int[] intCode = new int[127];//用于存密钥

        private static void setIntCode()//给数组赋值个小于10的随机数
        {
            //Random ra = new Random();
            //for (int i = 1; i < intCode.Length;i++ )
            //{
            //    intCode[i] = ra.Next(0, 9);
            //}
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i + 3 > 9 ? 0 : i + 3;
            }
        }
        public static int[] intNumber = new int[33];//用于存机器码的Ascii值
        public static char[] Charcode = new char[33];//存储机器码字

        //生成注册码

        /// <summary>
        /// 利用机器码通过一定的法则，生成注册码 
        /// </summary>
        /// <param name="MeCode"></param>
        /// <returns></returns>
        /// 
       // private static string _RegCode = string.Empty;
        private static string GetCode(string MeCode)
        {

            //把字符串中的“-”去掉 

            if (!string.IsNullOrEmpty(MeCode))
            {

                MeCode = MeCode.Replace("-", "");


                //把机器码存入数组中
                setIntCode();//初始化127位数组
                for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
                {
                    Charcode[i] = Convert.ToChar(MeCode.Substring(i - 1, 1));
                }//
                for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
                {
                    intNumber[j] =
                    intCode[Convert.ToInt32(Charcode[j])] +
                    Convert.ToInt32(Charcode[j]);

                }
                string strAsciiName = null;//用于存储机器码
                for (int j = 1; j < intNumber.Length; j++)
                {
                    //MessageBox.Show((Convert.ToChar(intNumber[j])).ToString());
                    //判断字符ASCII值是否0－9之间

                    if (intNumber[j] >= 48 && intNumber[j] <= 57)
                    {
                        // strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                        if (intNumber[j] + 3 > 57)

                        {

                            strAsciiName += Convert.ToChar(intNumber[j] + 3 - 10).ToString();

                        }
                        else
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] + 3).ToString();

                        }

                    }
                    //判断字符ASCII值是否A－Z之间

                    else if (intNumber[j] >= 65 && intNumber[j] <= 90)
                    {
                        // strAsciiName += Convert.ToChar(intNumber[j]).ToString();



                        if (intNumber[j] + 5 > 90)
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] + 5 - 26).ToString();

                        }
                        else
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] + 5).ToString();

                        }


                    }
                    //判断字符ASCII值是否a－z之间


                    else if (intNumber[j] >= 97 && intNumber[j] <= 122)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    else//判断字符ASCII值不在以上范围内
                    {
                        if (intNumber[j] > 122)//判断字符ASCII值是否大于z
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                        }
                        else
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                        }

                    }
                    //label3.Text = strAsciiName;//得到注册码


                    if (j % 4 == 0 && j != 32)
                    {
                        strAsciiName += "-";

                    }
                }






                return strAsciiName;

            }

            else
            {

                return "";
            }


        }

        private static string GetHash(string s)
        {
            //   string a = Base64Encode(s);

            //  string b = Base64Decode(a);
            //Initialize a new MD5 Crypto Service Provider in order to generate a hash
            MD5 sec = new MD5CryptoServiceProvider();
            //Grab the bytes of the variable 's'
            byte[] bt = Encoding.ASCII.GetBytes(s);
            //Grab the Hexadecimal value of the MD5 hash
            return GetHexString(sec.ComputeHash(bt));
        }

        private static string GetHexString(IList<byte> bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Count; i++)
            {
                byte b = bt[i];
                int n = b;
                int n1 = n & 15;
                int n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + 'A')).ToString(CultureInfo.InvariantCulture);
                else
                    s += n2.ToString(CultureInfo.InvariantCulture);
                if (n1 > 9)
                    s += ((char)(n1 - 10 + 'A')).ToString(CultureInfo.InvariantCulture);
                else
                    s += n1.ToString(CultureInfo.InvariantCulture);
                if ((i + 1) != bt.Count && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        //Return a hardware identifier
        private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementBaseObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() != "True") continue;
                //Only get the first one
                if (result != "") continue;
                try
                {
                    result = mo[wmiProperty].ToString();
                    break;
                }
                catch
                {
                }
            }
            return result;
        }


        //Return a hardware identifier
        private static string Identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementBaseObject mo in moc)
            {
                //Only get the first one
                if (result != "") continue;
                try
                {
                    result = mo[wmiProperty].ToString();
                    break;
                }
                catch
                {
                }
            }
            return result;
        }
        private static string CpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = Identifier("Win32_Processor", "UniqueId");
            if (retVal != "") return retVal;
            retVal = Identifier("Win32_Processor", "ProcessorId");
            if (retVal != "") return retVal;
            retVal = Identifier("Win32_Processor", "Name");
            if (retVal == "") //If no Name, use Manufacturer
            {
                retVal = Identifier("Win32_Processor", "Manufacturer");
            }
            //Add clock speed for extra security
            retVal += Identifier("Win32_Processor", "MaxClockSpeed");
            return retVal;
        }
        //BIOS Identifier
        private static string BiosId()
        {
            return Identifier("Win32_BIOS", "Manufacturer") + Identifier("Win32_BIOS", "SMBIOSBIOSVersion") + Identifier("Win32_BIOS", "IdentificationCode") + Identifier("Win32_BIOS", "SerialNumber") + Identifier("Win32_BIOS", "ReleaseDate") + Identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private static string DiskId()
        {
            return Identifier("Win32_DiskDrive", "Model") + Identifier("Win32_DiskDrive", "Manufacturer") + Identifier("Win32_DiskDrive", "Signature") + Identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private static string BaseId()
        {
            return Identifier("Win32_BaseBoard", "Model") + Identifier("Win32_BaseBoard", "Manufacturer") + Identifier("Win32_BaseBoard", "Name") + Identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private static string VideoId()
        {
            return Identifier("Win32_VideoController", "DriverVersion") + Identifier("Win32_VideoController", "Name");
        }
        //First enabled network card ID
        private static string MacId()
        {
            return Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
    }
}
