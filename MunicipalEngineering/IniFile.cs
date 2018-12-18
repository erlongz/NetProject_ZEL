using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO;

namespace MunicipalEngineering
{
    class IniFile
    {


        #region 成员变量
        public string filePath = "";    //文件路径
        static private uint MaxBufferSize = 32767;//缓存大小
        #endregion

        #region 导入API
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string section, string key, string def, IntPtr retVal, int size, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileInt(string section, string key, int def, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSection(string section, IntPtr lpReturnedString, uint nSize, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string filepath);
        #endregion

        #region 构造函数

        public IniFile(string filename)
        {
            filePath = System.IO.Path.GetFullPath(filename);
        }
        #endregion

        #region 读取数据

        public string GetString(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.filePath);
            return temp.ToString();
        }

        public int GetInt(string Section, string Key)
        {
            return GetPrivateProfileInt(Section, Key, 0, this.filePath);
        }

        public List<KeyValuePair<string, string>> GetValueSetList(string Section)  //读取一段内的所有数据
        {
            List<KeyValuePair<string, string>> retval;
            string[] keyValuePairs;
            string key, value;
            int equalSignPos;
            //申请空间
            IntPtr ptr = Marshal.AllocCoTaskMem((int)IniFile.MaxBufferSize);

            try
            {
                int len = GetPrivateProfileSection(Section, ptr, MaxBufferSize, filePath);
                keyValuePairs = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
            //输出结果
            retval = new List<KeyValuePair<string, string>>(keyValuePairs.Length);
            for (int i = 0; i < keyValuePairs.Length; ++i)
            {
                equalSignPos = keyValuePairs[i].IndexOf('=');
                key = keyValuePairs[i].Substring(0, equalSignPos);
                value = keyValuePairs[i].Substring(equalSignPos + 1, keyValuePairs[i].Length - equalSignPos - 1);
                retval.Add(new KeyValuePair<string, string>(key, value));
            }
            return retval;
        }
        public string[] GetSectionNames()   //获得所有段名
        {
            string[] retval;
            int len;
            IntPtr ptr = Marshal.AllocCoTaskMem((int)IniFile.MaxBufferSize);
            try
            {
                len = GetPrivateProfileSectionNames(ptr, IniFile.MaxBufferSize, filePath);
                retval = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
            return retval;
        }
        public string[] GetKeyNames(string Section) //获得一段内所有关键码
        {
            int len;
            string[] retval;
            IntPtr ptr = Marshal.AllocCoTaskMem((int)IniFile.MaxBufferSize);
            try
            {
                len = GetPrivateProfileString(Section, null, null, ptr, (int)IniFile.MaxBufferSize, filePath);
                retval = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
            return retval;
        }

        private static string[] ConvertNullSeperatedStringToStringArray(IntPtr ptr, int valLength) //转换字符串指针空间为字符串数组
        {
            string[] retval;
            if (valLength == 0)
            {
                retval = new string[0];
            }
            else
            {
                string buff = Marshal.PtrToStringAuto(ptr, valLength - 1);
                retval = buff.Split('\0');
            }
            return retval;
        }
        #endregion

        #region 写数据

        public void SetValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.filePath);
        }
        public void SetValue(string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this.filePath);
        }
        public void SetValue(string Section, string Key, float Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this.filePath);
        }
        public void SetValue(string Section, string Key, double Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), this.filePath);
        }

        #endregion

        #region 删除
        public void DeleteKey(string Section, string Key)
        {
            SetValue(Section, Key, null);
        }
        public void DeleteKey(string Section)
        {
            SetValue(Section, null, null);
        }
        #endregion

        #region 补充
        static public void FormatIni(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            StreamWriter sw = new StreamWriter(filePath + ".gc1");
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                if (s != "" && s.IndexOf("[") == -1 && s.IndexOf("=") == -1)
                    s += "=";
                sw.WriteLine(s);
            }
            sr.Close();
            sw.Close();
            try
            {
                File.Move(filePath, filePath + ".gc");
            }
            catch { }
            try
            {
                File.Move(filePath + ".gc1", filePath);
            }
            catch { }
            try
            {
                File.Delete(filePath + ".gc1");
            }
            catch { }
        }
        #endregion
    }
}
