using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;

using MSWord = Microsoft.Office.Interop.Word;
using System.Reflection;

using System.Windows.Forms;
using System.Data.SQLite;

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

namespace MunicipalEngineering
{
   public static class UtilityFun
    {

        public static string filename = null;
        public static MSWord._Application wordApp;
        /// <summary>
        /// 读取数据文件，数据文件格式：
        /// 点名，X坐标,Y坐标;
        /// N14,301234.134,908423.604
        /// </summary>
        /// <returns></returns>
        /// 


        public static int ReadData()
        {
            //List<string> files = new List<string>();

            System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.Filter = "数据文件|*.txt";
            openDialog.Title = "选择理论坐标文件";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openDialog.FileName;

                UtilityVar.FileNameFullPath = Path.GetDirectoryName(filename);
            }
            

            else
            {
                MessageBox.Show("您未选择任何文件，请重新选择文件！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
                return -1;
            }


            string[] strArrary;
            List<string> data = new List<string>();
            List<string[]> dataNew = new List<string[]>();

            FileStream fStream = new FileStream(filename, FileMode.Open);
            StreamReader sReader = new StreamReader(fStream);
            string dataRow = sReader.ReadLine();

            while (!string.IsNullOrEmpty(dataRow))
            {
                data.Add(dataRow);
                dataRow = sReader.ReadLine();

            }
            sReader.Close();

            foreach (string pt in data)
            {
                string name = "";
                double X = 0.0;
                double Y = 0.0;


                strArrary = pt.Split(new char[] { ',' });
                if (strArrary.Length == 3)
                {
                    dataNew.Add(strArrary);
                    UtilityVar.ArraryList.Add(strArrary);
                    name = strArrary[0];
                    X = Convert.ToDouble(strArrary[1]);
                    Y = Convert.ToDouble(strArrary[2]);
                    UtilityVar.NameList.Add(name);
                    UtilityVar.XList.Add(X);
                    UtilityVar.YList.Add(Y);
                }
                else
                {
                    MessageBox.Show("输入文件格式错误，请检查文件!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();

                    return -1;

                }
            }

            return 0;

        }



        public static int ReadDataFCZB()
        {

            System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.Filter = "数据文件|*.txt";
            openDialog.Title = "选择复测坐标文件";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openDialog.FileName;

            }

            else
            {
                MessageBox.Show("您未选择任何文件，请重新选择文件！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
                return -1;
            }


            string[] strArrary1;
            List<string> data = new List<string>();
            List<string[]> dataNew = new List<string[]>();

            FileStream fStream = new FileStream(filename, FileMode.Open);
            StreamReader sReader = new StreamReader(fStream);
            string dataRow = sReader.ReadLine();

            while (! string.IsNullOrWhiteSpace(dataRow))
            {
                data.Add(dataRow);
                dataRow = sReader.ReadLine();

            }
            sReader.Close();

            foreach (string pt in data)
            {
                string name = "";
                double X = 0.0;
                double Y = 0.0;


                strArrary1 = pt.Split(new char[] { ',' });
                if (strArrary1.Length == 3)
                {
                    dataNew.Add(strArrary1);
                    UtilityVar.ArraryList_FC.Add(strArrary1);
                    name = strArrary1[0];
                    X = Convert.ToDouble(strArrary1[1]);
                    Y = Convert.ToDouble(strArrary1[2]);
                    UtilityVar.NameList_FC.Add(name);

                    UtilityVar.XRandList.Add(X);
                    //UtilityVar.XList.Add(X);
                    // UtilityVar.YList.Add(Y);
                    UtilityVar.YRandList.Add(Y);
                }
                else
                {
                    MessageBox.Show("输入文件格式错误，请检查文件!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();

                    return -1;

                }
            }

            return 0;



        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        public static int ReadData_KZD()
        {
            string filename = null;
            System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.Filter = "数据文件|*.txt";
            openDialog.Title = "选择控制点文件";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openDialog.FileName;
            }

            else
            {
                MessageBox.Show("您未选择任何文件，请重新选择文件！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
                return -1;
            }
            string[] strArrary;
            List<string> data = new List<string>();
            List<string[]> dataNew = new List<string[]>();

            FileStream fStream = new FileStream(filename, FileMode.Open);
            StreamReader sReader = new StreamReader(fStream);
            string dataRow = sReader.ReadLine();

            while (!String.IsNullOrEmpty(dataRow))
            {
                data.Add(dataRow);
                dataRow = sReader.ReadLine();

            }
            sReader.Close();

            foreach (string pt in data)
            {
                string name = "";
                double X = 0.0;
                double Y = 0.0;


                strArrary = pt.Split(new char[] { ',' });
                if (strArrary.Length == 3)
                {
                    dataNew.Add(strArrary);
                    UtilityVar.ArraryList_KZD.Add(strArrary);
                    name = strArrary[0];
                    X = Convert.ToDouble(strArrary[1]);
                    Y = Convert.ToDouble(strArrary[2]);
                    UtilityVar.NameList_KZD.Add(name);
                    UtilityVar.XList_KZD.Add(X);
                    UtilityVar.YList_KZD.Add(Y);
                }
                else
                {
                    MessageBox.Show("输入文件格式错误，请检查文件!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();

                    return -1;

                }
            }

            return 0;
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        public static void Gen_Rand()
        {
            double x_rand = 0;
            double y_rand = 0;
            double d_rand;
            int Arr_Len = UtilityVar.NameList.Count; //用来存储数组长度；
            Random ra = new Random();
            string str = string.Empty;

            string FCFileName = UtilityVar.FileNameFullPath + "\\FCZB.txt";
            StreamWriter sw = new StreamWriter(FCFileName, false);

            for (int i = 0; i < Arr_Len; i++)
            {

                x_rand = ra.NextDouble() * 30 * 0.001 - 0.01;
                y_rand = ra.NextDouble() * 30 * 0.001 - 0.01;
                d_rand = Math.Sqrt(x_rand * x_rand + y_rand * y_rand);

               // UtilityVar.XRandList.Add(UtilityVar.XList[i] + x_rand);
               // UtilityVar.YRandList.Add(UtilityVar.YList[i] + y_rand);
              // UtilityVar.DiffRandList.Add(d_rand); 

            

                     //str = UtilityVar.NameList[i] + "," + (UtilityVar.XList[i] + x_rand).ToString("0.000") + "," + (UtilityVar.YList[i] + y_rand).ToString("0.000");

               
                     str = UtilityVar.NameList[i] + "," + (UtilityVar.XList[i] + x_rand).ToString("0.000") + "," + (UtilityVar.YList[i] + y_rand).ToString("0.000") ;

                sw.WriteLine(str);
            }
            sw.Close();
        }

        /// <summary>
        /// 对字符串进行比较
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static int Str_Compare(string X, string Y)
        {

            if (X == null || Y == null)
            {
                throw new ArgumentException("Parameters Can't be null");

            }

            char[] arr1 = X.ToCharArray();
            char[] arr2 = Y.ToCharArray();

            int i = 0;
            int j = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (char.IsDigit(arr1[i]) && char.IsDigit(arr2[i]))
                {
                    string s1 = "", s2 = "";
                    while (i < arr1.Length && char.IsDigit(arr1[i]))
                    {
                        s1 += arr1[i];
                        i++;
                    }
                    while (j < arr2.Length && char.IsDigit(arr2[j]))
                    {
                        s2 += arr2[j];
                        j++;
                    }

                    if (int.Parse(s1) > int.Parse(s2))
                    {
                        return 1;
                    }

                    if (int.Parse(s1) < int.Parse(s2))
                    {
                        return -1;
                    }

                }
                else
                {
                    if (arr1[i] > arr2[j])
                    {
                        return 1;
                    }
                    if (arr1[i] < arr2[j])
                    {
                        return -1;
                    }
                    i++;
                    j++;
                }
            }

            return 0;


        }

        public static void sort_data()
        {
            int ArrNum = UtilityVar.NameList.Count;
            string TempNameList;
            double TempXList;
            double TempYList;
            double TempXRandList;
            double TempYRandList;
            double TempDiffRandList;
            int numbool;

            List<string> NameListTemp = new List<string>();


            //遍历NameList，若其中数字只有一位用0补齐----前提：就放线而言，一般默认数字为2位
            for (int k = 0; k < ArrNum; k++)
            {
                int numStr = UtilityVar.NameList[k].Length;
                string TempStr = UtilityVar.NameList[k];

                if (!char.IsDigit(TempStr[numStr - 2]))
                {
                    TempStr = TempStr.Insert(numStr - 1, "0");
                }

                NameListTemp.Add(TempStr);
            }

            for (int i = 0; i < ArrNum; i++)
            {
                for (int j = 0; j < ArrNum - 1 - i; j++)
                {
                    //numbool = Str_Compare(UtilityVar.NameList[j], UtilityVar.NameList[j + 1]);
                    //  numbool = string.Compare(UtilityVar.NameList[j], UtilityVar.NameList[j + 1]);

                    numbool = string.Compare(NameListTemp[j], NameListTemp[j + 1]);
                    if (numbool > 0)
                    {
                        TempNameList = UtilityVar.NameList[j];
                        UtilityVar.NameList[j] = UtilityVar.NameList[j + 1];
                        UtilityVar.NameList[j + 1] = TempNameList;

                        TempXList = UtilityVar.XList[j];
                        UtilityVar.XList[j] = UtilityVar.XList[j + 1];
                        UtilityVar.XList[j + 1] = TempXList;

                        TempYList = UtilityVar.YList[j];
                        UtilityVar.YList[j] = UtilityVar.YList[j + 1];
                        UtilityVar.YList[j + 1] = TempYList;

                        TempXRandList = UtilityVar.XRandList[j];
                        UtilityVar.XRandList[j] = UtilityVar.XRandList[j + 1];
                        UtilityVar.XRandList[j + 1] = TempXRandList;

                        TempYRandList = UtilityVar.YRandList[j];
                        UtilityVar.YRandList[j] = UtilityVar.YRandList[j + 1];
                        UtilityVar.YRandList[j + 1] = TempYRandList;

                        TempDiffRandList = UtilityVar.DiffRandList[j];
                        UtilityVar.DiffRandList[j] = UtilityVar.DiffRandList[j + 1];
                        UtilityVar.DiffRandList[j + 1] = TempDiffRandList;
                    }
                }
            }
        }

        public static MSWord.Document NewDocument()
        {
            //object path;      //文件路径变量

            MSWord.Document wordDoc;




            try
            {
                wordApp = new MSWord.ApplicationClass();  //初始化
               // wordApp = new MSWord.ApplicationClass();
                wordApp.Visible = true;

                object nothing = System.Reflection.Missing.Value;
                wordDoc = wordApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);

                // wordDoc.SaveAs(path, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                //  ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);

                // wordDoc.Close(ref nothing, ref nothing, ref nothing);

                // MessageBox.Show("Word 文件保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return wordDoc;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }





        }

        public static MSWord.Document writeContent(MSWord.Document wordDoc, string StrCont, string fontName, int Bold, float fontSize, float LineSpace, string Alignment)
        {

            try
            {

                switch (Alignment)
                {
                    case "Right":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;

                        break;
                    case "Left":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;

                        break;

                    case "Middle":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                        break;

                    case "Justify":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify;
                        break;

                    default:
                        //wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphDistribute;

                        break;
                }
                wordDoc.Paragraphs.Last.Format.LineSpacing = LineSpace;
                wordDoc.Paragraphs.Last.Range.Font.Name = fontName;
                wordDoc.Paragraphs.Last.Range.Bold = Bold;
                wordDoc.Paragraphs.Last.Range.Font.Size = fontSize;
                wordDoc.Paragraphs.Last.Range.Text = StrCont;


                return wordDoc;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }

        /// <summary>
        /// 重载writecontent
        /// </summary>
        /// <param name="wordDoc"></param>
        /// 
        public static MSWord.Document writeContent(MSWord.Document wordDoc, string StrCont, string fontName, int Bold, float fontSize, float LineSpace, string Alignment, bool FirstLineIndent)
        {

            try
            {

                if (FirstLineIndent)
                {
                    wordDoc.Paragraphs.Last.FirstLineIndent = 0.0f;
                    wordDoc.Paragraphs.Last.IndentFirstLineCharWidth(2);
                }
                else
                {
                    //wordDoc.Paragraphs.Last.IndentFirstLineCharWidth(0);
                    wordDoc.Paragraphs.Last.FirstLineIndent = 0.0f;
                }

                switch (Alignment)
                {
                    case "Right":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;

                        break;
                    case "Left":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;

                        break;

                    case "Middle":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                        break;

                    case "Justify":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify;
                        break;

                    default:
                        //wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphDistribute;

                        break;
                }


                wordDoc.Paragraphs.Last.Format.LineSpacing = LineSpace;
                wordDoc.Paragraphs.Last.Range.Font.Name = fontName;
                wordDoc.Paragraphs.Last.Range.Bold = Bold;
                wordDoc.Paragraphs.Last.Range.Font.Size = fontSize;
                wordDoc.Paragraphs.Last.Range.Text = StrCont;


                return wordDoc;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordDoc"></param>
        /// 

        public static MSWord.Document writeContent(MSWord.Document wordDoc, string StrCont, string fontName, int Bold, float fontSize, float LineSpace, string Alignment, bool FirstLineIndent, short FLIndentNum)
        {

            try
            {

                if (FirstLineIndent)
                {
                    wordDoc.Paragraphs.Last.FirstLineIndent = 0.0f;
                    wordDoc.Paragraphs.Last.IndentFirstLineCharWidth(FLIndentNum);
                }
                else
                {
                    //wordDoc.Paragraphs.Last.IndentFirstLineCharWidth(0);
                    wordDoc.Paragraphs.Last.FirstLineIndent = 0.0f;
                }

                switch (Alignment)
                {
                    case "Right":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;

                        break;
                    case "Left":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;

                        break;

                    case "Middle":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                        break;

                    case "Justify":
                        wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify;
                        break;

                    default:
                        //wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphDistribute;

                        break;
                }


                wordDoc.Paragraphs.Last.Format.LineSpacing = LineSpace;
                wordDoc.Paragraphs.Last.Range.Font.Name = fontName;
                wordDoc.Paragraphs.Last.Range.Bold = Bold;
                wordDoc.Paragraphs.Last.Range.Font.Size = fontSize;
                wordDoc.Paragraphs.Last.Range.Text = StrCont;


                return wordDoc;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordDoc"></param>
        /// 

        public static MSWord.Document writeContent(MSWord.Document wordDoc, string StrCont, string fontName, int Bold, float fontSize, float LineSpace, string Alignment,
            bool FirstLineIndent, short FLIndentNum, int ParNum)
        {


            try
            {

                if (FirstLineIndent)
                {
                    wordDoc.Paragraphs[ParNum - 1].Range.ParagraphFormat.FirstLineIndent = 0.0f;
                    wordDoc.Paragraphs[ParNum - 1].Range.ParagraphFormat.IndentFirstLineCharWidth(FLIndentNum);
                }
                else
                {
                    //wordDoc.Paragraphs.Last.IndentFirstLineCharWidth(0);
                    wordDoc.Paragraphs[ParNum - 1].Range.ParagraphFormat.FirstLineIndent = 0.0f;
                }

                switch (Alignment)
                {
                    case "Right":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;

                        break;
                    case "Left":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;

                        break;

                    case "Middle":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                        break;

                    case "Justify":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify;
                        break;

                    default:
                        //wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphDistribute;

                        break;
                }


                wordDoc.Paragraphs[ParNum - 1].Format.LineSpacing = LineSpace;
                wordDoc.Paragraphs[ParNum - 1].Range.Font.Name = fontName;
                wordDoc.Paragraphs[ParNum - 1].Range.Bold = Bold;
                wordDoc.Paragraphs[ParNum - 1].Range.Font.Size = fontSize;
                wordDoc.Paragraphs[ParNum - 1].Range.Text = StrCont;

                //
                if (FirstLineIndent)
                {
                    wordDoc.Paragraphs[ParNum - 1].Range.ParagraphFormat.FirstLineIndent = 0.0f;
                    wordDoc.Paragraphs[ParNum - 1].Range.ParagraphFormat.IndentFirstLineCharWidth(FLIndentNum);
                }
                else
                {
                    //wordDoc.Paragraphs.Last.IndentFirstLineCharWidth(0);
                    wordDoc.Paragraphs[ParNum - 1].Range.ParagraphFormat.FirstLineIndent = 0.0f;
                }

                switch (Alignment)
                {
                    case "Right":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;

                        break;
                    case "Left":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;

                        break;

                    case "Middle":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                        break;

                    case "Justify":
                        wordDoc.Paragraphs[ParNum - 1].Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify;
                        break;

                    default:
                        //wordDoc.Paragraphs.Last.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphDistribute;

                        break;
                }
                //

                return wordDoc;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordDoc"></param>
        ///  

        public static MSWord.Document CreatTable(MSWord.Document wordDoc, int NumColumns, int NumRows, int Cell_Sta, int Tab_Num)
        {
            Object Nothing = Missing.Value;


            String ZD_Style = UtilityVar.ZD_Style1;

            string StrCont = UtilityVar.Str40 + UtilityVar.Str0;
            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 18, "Middle", false);

            MSWord.Range Range = wordDoc.Paragraphs.Last.Range;

            MSWord.Table Table1 = wordDoc.Tables.Add(Range, NumRows, NumColumns, ref Nothing, ref Nothing);

            Table1.Borders.Enable = 1;
            Table1.Borders.OutsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;
            Table1.Borders.InsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;

            Table1.Columns[1].SetWidth((float)CenToPts(2.77), MSWord.WdRulerStyle.wdAdjustSameWidth);
            Table1.Columns[2].SetWidth((float)CenToPts(3.77), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[3].SetWidth((float)CenToPts(3.77), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[4].SetWidth((float)CenToPts(2.36), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[5].SetWidth((float)CenToPts(2.36), MSWord.WdRulerStyle.wdAdjustNone);

            Table1.Select();

            wordDoc.Application.Selection.Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            wordDoc.Application.Selection.Cells.SetHeight(wordDoc.Application.CentimetersToPoints(1f), MSWord.WdRowHeightRule.wdRowHeightAuto);
            wordDoc.Application.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 1).Merge(Table1.Cell(2, 1));
            Table1.Cell(1, 2).Merge(Table1.Cell(1, 3));
            Table1.Cell(1, 3).Merge(Table1.Cell(2, 4));
            Table1.Cell(1, 4).Merge(Table1.Cell(2, 5));

            Table1.Cell(1, 1).Range.Text = "桩号";
            Table1.Cell(1, 1).Range.Font.Size = 14;
            Table1.Cell(1, 1).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 1).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 2).Range.Text = "坐标(米)";
            Table1.Cell(1, 2).Range.Font.Size = 14;
            Table1.Cell(1, 2).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 3).Range.Text = "桩点类型";
            Table1.Cell(1, 3).Range.Font.Size = 14;
            Table1.Cell(1, 3).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 4).Range.Text = "备注";
            Table1.Cell(1, 4).Range.Font.Size = 14;
            Table1.Cell(1, 4).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 4).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 2).Range.Text = "X坐标(米)";
            Table1.Cell(2, 2).Range.Font.Size = 14;
            Table1.Cell(2, 2).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 3).Range.Text = "Y坐标(米)";
            Table1.Cell(2, 3).Range.Font.Size = 14;
            Table1.Cell(2, 3).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int iCount = 1; iCount < Cell_Sta + 1; iCount++)
            {
                Table1.Cell(iCount + 2, 1).Range.Text = UtilityVar.NameList[iCount - 1 + 19 * (Tab_Num - 1)].ToString();
                Table1.Cell(iCount + 2, 1).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 1).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 1).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 2).Range.Text = UtilityVar.XList[iCount - 1 + 19 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 2).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 2).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 3).Range.Text = UtilityVar.YList[iCount - 1 + 19 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 3).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 3).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                Table1.Cell(iCount + 2, 4).Range.Text = ZD_Style;
                Table1.Cell(iCount + 2, 4).Range.Font.Size = 12;
                Table1.Cell(iCount + 2, 4).Range.Font.Name = "仿宋_GB2312";
                Table1.Cell(iCount + 2, 4).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            }







            return wordDoc;

        }

        public static MSWord.Document CreatTable2(MSWord.Document wordDoc, int NumColumns, int NumRows, int Cell_Sta, int Tab_Num)
        {
            Object Nothing = Missing.Value;
            string StrCont = UtilityVar.Str41 + UtilityVar.Str0;
            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 18, "Middle", false);

            MSWord.Range Range = wordDoc.Paragraphs.Last.Range;

            MSWord.Table Table1 = wordDoc.Tables.Add(Range, NumRows, NumColumns, ref Nothing, ref Nothing);

            Table1.Borders.Enable = 1;
            Table1.Borders.OutsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;
            Table1.Borders.InsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;

            Table1.Columns[1].SetWidth((float)CenToPts(2.17), MSWord.WdRulerStyle.wdAdjustSameWidth);
            Table1.Columns[2].SetWidth((float)CenToPts(2.83), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[3].SetWidth((float)CenToPts(2.85), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[4].SetWidth((float)CenToPts(2.50), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[5].SetWidth((float)CenToPts(2.58), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[6].SetWidth((float)CenToPts(2.21), MSWord.WdRulerStyle.wdAdjustNone);

            Table1.Select();

            wordDoc.Application.Selection.Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            wordDoc.Application.Selection.Cells.SetHeight(wordDoc.Application.CentimetersToPoints(0.98f), MSWord.WdRowHeightRule.wdRowHeightExactly);
            wordDoc.Application.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 1).Merge(Table1.Cell(2, 1));
            Table1.Cell(1, 2).Merge(Table1.Cell(1, 3));
            Table1.Cell(1, 3).Merge(Table1.Cell(1, 4));
            Table1.Cell(1, 4).Merge(Table1.Cell(2, 6));

            Table1.Cell(1, 1).Range.Text = "桩号";
            Table1.Cell(1, 1).Range.Font.Size = 14;
            Table1.Cell(1, 1).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 1).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 2).Range.Text = "理论坐标(米)";
            Table1.Cell(1, 2).Range.Font.Size = 14;
            Table1.Cell(1, 2).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 3).Range.Text = "放线复测坐标(米)";
            Table1.Cell(1, 3).Range.Font.Size = 14;
            Table1.Cell(1, 3).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 4).Range.Text = "差值(米)";
            Table1.Cell(1, 4).Range.Font.Size = 14;
            Table1.Cell(1, 4).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 4).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 2).Range.Text = "X坐标";
            Table1.Cell(2, 2).Range.Font.Size = 14;
            Table1.Cell(2, 2).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 3).Range.Text = "Y坐标";
            Table1.Cell(2, 3).Range.Font.Size = 14;
            Table1.Cell(2, 3).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 4).Range.Text = "X坐标";
            Table1.Cell(2, 4).Range.Font.Size = 14;
            Table1.Cell(2, 4).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 4).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 5).Range.Text = "Y坐标";
            Table1.Cell(2, 5).Range.Font.Size = 14;
            Table1.Cell(2, 5).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 5).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int iCount = 1; iCount < Cell_Sta + 1; iCount++)
            {

                Table1.Cell(iCount + 2, 1).Range.Text = UtilityVar.NameList[iCount - 1 + 21 * (Tab_Num - 1)].ToString();
                Table1.Cell(iCount + 2, 1).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 1).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 1).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 2).Range.Text = UtilityVar.XList[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 2).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 2).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 3).Range.Text = UtilityVar.YList[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 3).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 3).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 4).Range.Text = UtilityVar.XRandList[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 4).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 4).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 4).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 5).Range.Text = UtilityVar.YRandList[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 5).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 5).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 5).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 6).Range.Text = UtilityVar.DiffRandList[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 6).Range.Font.Size = 11f;
                Table1.Cell(iCount + 2, 6).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 6).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;



            }







            return wordDoc;
        }
        /// <summary>
        /// 创建控制点坐标
        /// </summary>
        /// <returns></returns>

        public static MSWord.Document CreatTable_KZD(MSWord.Document wordDoc, int NumColumns, int NumRows, int Cell_Sta, int Tab_Num)
        {
            Object Nothing = Missing.Value;

            string StrCont = UtilityVar.Str42 + UtilityVar.Str0;
            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 18, "Middle", false);

            MSWord.Range Range = wordDoc.Paragraphs.Last.Range;

            MSWord.Table Table1 = wordDoc.Tables.Add(Range, NumRows, NumColumns, ref Nothing, ref Nothing);

            Table1.Borders.Enable = 1;
            Table1.Borders.OutsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;
            Table1.Borders.InsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;

            Table1.Columns[1].SetWidth((float)CenToPts(2.96), MSWord.WdRulerStyle.wdAdjustSameWidth);
            Table1.Columns[2].SetWidth((float)CenToPts(2.85), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[3].SetWidth((float)CenToPts(2.86), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[4].SetWidth((float)CenToPts(2.48), MSWord.WdRulerStyle.wdAdjustNone);
            Table1.Columns[5].SetWidth((float)CenToPts(3.88), MSWord.WdRulerStyle.wdAdjustNone);

            Table1.Select();

            wordDoc.Application.Selection.Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            wordDoc.Application.Selection.Cells.SetHeight(wordDoc.Application.CentimetersToPoints(1f), MSWord.WdRowHeightRule.wdRowHeightAuto);
            wordDoc.Application.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 1).Merge(Table1.Cell(2, 1));
            Table1.Cell(1, 2).Merge(Table1.Cell(1, 4));
            Table1.Cell(1, 3).Merge(Table1.Cell(2, 5));
            Table1.Cell(3, 5).Merge(Table1.Cell(NumRows, 5));

            Table1.Cell(1, 1).Range.Text = "点 名";
            Table1.Cell(1, 1).Range.Font.Size = 14;
            Table1.Cell(1, 1).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 1).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 2).Range.Text = "坐  标";
            Table1.Cell(1, 2).Range.Font.Size = 14;
            Table1.Cell(1, 2).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(1, 3).Range.Text = "备 注";
            Table1.Cell(1, 3).Range.Font.Size = 14;
            Table1.Cell(1, 3).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(1, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 2).Range.Text = "X(m)";
            Table1.Cell(2, 2).Range.Font.Size = 14;
            Table1.Cell(2, 2).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 3).Range.Text = "Y(m)";
            Table1.Cell(2, 3).Range.Font.Size = 14;
            Table1.Cell(2, 3).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(2, 4).Range.Text = "H(m)";
            Table1.Cell(2, 4).Range.Font.Size = 14;
            Table1.Cell(2, 4).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(2, 4).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            Table1.Cell(3, 5).Range.Text = "1990年天津市任意直角坐标系";
            Table1.Cell(3, 5).Range.Font.Size = 12;
            Table1.Cell(3, 5).Range.Font.Name = "仿宋_GB2312";
            Table1.Cell(3, 5).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int iCount = 1; iCount < Cell_Sta + 1; iCount++)
            {

                Table1.Cell(iCount + 2, 1).Range.Text = UtilityVar.NameList_KZD[iCount - 1 + 21 * (Tab_Num - 1)].ToString();
                Table1.Cell(iCount + 2, 1).Range.Font.Size = 10.5f;
                Table1.Cell(iCount + 2, 1).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 1).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 2).Range.Text = UtilityVar.XList_KZD[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 2).Range.Font.Size = 10.5f;
                Table1.Cell(iCount + 2, 2).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;

                Table1.Cell(iCount + 2, 3).Range.Text = UtilityVar.YList_KZD[iCount - 1 + 21 * (Tab_Num - 1)].ToString("0.000");
                Table1.Cell(iCount + 2, 3).Range.Font.Size = 10.5f;
                Table1.Cell(iCount + 2, 3).Range.Font.Name = "Times New Roman";
                Table1.Cell(iCount + 2, 3).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;




            }





            return wordDoc;
        }

        /// <summary>
        /// 对文档插入页码
        /// </summary>
        /// <param name="wordDoc"></param>
        /// 

        public static void Insert_Page(MSWord.Document wordDoc)
        {
            /*object oAlignment = MSWord.WdPageNumberAlignment.wdAlignPageNumberCenter;
            object oFirstPage = bHeader;
            MSWord.WdHeaderFooterIndex WdFooterIndex = MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary;
            switch (strType)
            {
                case "Center":
                    oAlignment = MSWord.WdPageNumberAlignment.wdAlignPageNumberCenter;

                    break;
                case "Right":

                    oAlignment = MSWord.WdPageNumberAlignment.wdAlignPageNumberRight;

                    break;
                case "Left":
                    oAlignment = MSWord.WdPageNumberAlignment.wdAlignPageNumberLeft;

                    break;

            }

            wordDoc.Application.Selection.Sections[1].Footers[WdFooterIndex].PageNumbers.Add(ref oAlignment, ref oFirstPage);*/

            // int PageNum = wordDoc.ComputeStatistics(MSWord.WdStatistic.wdStatisticPages, Missing.Value);

            MSWord.Range footerRange = wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            footerRange.Font.Name = "Times New Roman";
            footerRange.Font.Size = 9;
            footerRange.Text = "第";
            footerRange.Collapse(MSWord.WdCollapseDirection.wdCollapseEnd);

            wordDoc.Fields.Add(footerRange, Missing.Value, "Page", Missing.Value);
            footerRange.Collapse(MSWord.WdCollapseDirection.wdCollapseEnd);

            footerRange.SetRange(wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.End, wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.End);

            //string str1 = PageNum.ToString();
            string str2 = " 页 共 ";
            footerRange.Text = str2;

            footerRange.SetRange(wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.End, wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.End);
            footerRange.Collapse(MSWord.WdCollapseDirection.wdCollapseEnd);
            wordDoc.Fields.Add(footerRange, Missing.Value, "NumPages", Missing.Value);

            footerRange.SetRange(wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.End, wordDoc.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.End);
            footerRange.Collapse(MSWord.WdCollapseDirection.wdCollapseEnd);
            footerRange.Text = " 页";
            //wordDoc.Fields.Update();
            footerRange.Fields.Update();

            footerRange.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;





        }

        public static void docSaveAs(MSWord.Document wordDoc)
        {
            MSWord._Document wordDoc1 = wordDoc as MSWord._Document;
            object path;
            //path = @"C:\Users\DELL\Desktop\建设工程设计方案建设工程规划放线测量技术报告(市政工程).doc";   //默认路径 
            //path = @"D:\定线报告\建设工程设计方案建设工程规划放线测量技术报告(市政工程).doc";

            // string path_DXBG = @"D:\定线报告";

            // if (!Directory.Exists(path_DXBG))
            // {
            //    System.IO.Directory.CreateDirectory(path_DXBG);
            // }

            path = Path.GetDirectoryName(filename);

            path = path + "\\建设工程设计方案建设工程规划放线测量技术报告(市政工程).doc";


            try
            {
                if (File.Exists((string)path))
                {
                    File.Delete((string)path);
                }
                object nothing = System.Reflection.Missing.Value;
                wordDoc1.SaveAs(path, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                    ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);

                wordDoc1.Close(ref nothing, ref nothing, ref nothing);

                wordApp.Quit(Missing.Value, Missing.Value, Missing.Value);
                MessageBox.Show("Word 文件保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }

        public static double CenToPts(double Cen)
        {
            double Pts;

            Pts = Cen * 28.346;

            return Pts;
        }

        public static double PtsToCen(double Pts)
        {
            double Cen;

            Cen = Pts * 0.0352778;

            return Cen;

        }

        public static string GetLibPath()
        {
            string Libpath = string.Empty;

            string sPath = "C:\\app2016\\SZFX\\"; 

             Libpath = "Data Source=" + sPath + "BaseInfo.db"; 

            return Libpath;


        }

        public static System.Data.DataTable GetBaseInfo(string LibPath)
        {
            SQLiteConnection connection = new SQLiteConnection(LibPath);
            SQLiteCommand command = new SQLiteCommand(connection);
            try
            {

               

                string sSQL = "SELECT FYName,SHR,PZR From SHRPZRInfo";

                command.CommandText = sSQL;

                SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                sqlDataAdapter.SelectCommand = command;

                DataSet DS = new DataSet();
                sqlDataAdapter.Fill(DS, "SHRPZRInfo");
               // DataTable DT = new DataTable();
                System.Data.DataTable DT = new System.Data.DataTable();
                DT = DS.Tables["SHRPZRInfo"];
                connection.Close();

                return DT;

            }

            catch(System.Exception)
            {

                connection.Close();
                return null;

            }
           


        }

        public static System.Data.DataTable GetYQInfo(string LibPath,string FYName)
        {
            SQLiteConnection connection = new SQLiteConnection(LibPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            //DataTable DT = new DataTable();
            System.Data.DataTable DT = new System.Data.DataTable();
            switch (FYName)
            {
                case "测绘一院":

                case "天津市中新生态城天测测绘有限公司":
                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From CHYYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "CHYYYQInfo");
                        
                        DT = DS.Tables["CHYYYQInfo"];
                        connection.Close();
                        
                        break;
                        
                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;
                       
                    }
                   
                case "滨海分院":


                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From BHFYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "BHFYYQInfo");

                        DT = DS.Tables["BHFYYQInfo"];
                        connection.Close();

                        break;

                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;

                    }

                    

                case "测绘三院":

                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From CHSYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "CHSYYQInfo");

                        DT = DS.Tables["CHSYYQInfo"];
                        connection.Close();

                        break;

                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;

                    }

                case "测绘四院":

                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From CHSIYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "CHSIYYQInfo");

                        DT = DS.Tables["CHSIYYQInfo"];
                        connection.Close();

                        break;

                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;

                    }
                case "测绘八院":


                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From CHBYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "CHBYYQInfo");

                        DT = DS.Tables["CHBYYQInfo"];
                        connection.Close();

                        break;

                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;

                    }
                case "基础测绘院":

                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From JCCHYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "JCCHYYQInfo");

                        DT = DS.Tables["JCCHYYQInfo"];
                        connection.Close();

                        break;

                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;

                    }
                   
                case "海洋分院":


                    try
                    {



                        string sSQL = "SELECT ID,YQXH,YQBH From HYFYYQInfo";

                        command.CommandText = sSQL;

                        SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
                        sqlDataAdapter.SelectCommand = command;

                        DataSet DS = new DataSet();
                        sqlDataAdapter.Fill(DS, "HYFYYQInfo");

                        DT = DS.Tables["HYFYYQInfo"];
                        connection.Close();

                        break;

                    }

                    catch (System.Exception)
                    {

                        connection.Close();
                        return null;

                    }

                     

                default:

                    MessageBox.Show("分院名称不对，请重新核对！");

                    break;

            }


            return DT;
           
        }


        public static DBObjectCollection getEntityCollectionBylayer(Entity ent, Database db, Editor ed)
        {
            DBObjectCollection dbObjCol = new DBObjectCollection();

            string layer = ent.Layer;

            TypedValue[] tvs = new TypedValue[]
            {


                new TypedValue((int)DxfCode.LayerName,layer)
            };

            SelectionFilter sf = new SelectionFilter(tvs);

            PromptSelectionResult selRes = ed.SelectAll(sf);

            if (selRes.Status == PromptStatus.OK)
            {


                SelectionSet ss = selRes.Value;
                ObjectId[] ids = ss.GetObjectIds();

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {

                    for (int i = 0; i < ids.Length; i++)
                    {

                        Entity dbt = (Entity)trans.GetObject(ids[i], OpenMode.ForRead);

                        dbObjCol.Add(dbt);
                    }

                    trans.Commit();
                }
            }

            return dbObjCol;


        }

        public static ObjectIdCollection  AddToModelSpace(Database db,DBObjectCollection  DbObjCol)
        {

            ObjectIdCollection objIdCol = new ObjectIdCollection(); 

 
            foreach(Entity ent in DbObjCol)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {

                    try
                    {

                        BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                        BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                        Entity ent1 = (Entity)ent.Clone();

                        ObjectId entId = btr.AppendEntity(ent1);

                        trans.AddNewlyCreatedDBObject(ent1, true);

                        objIdCol.Add(entId);

                        trans.Commit();

                       // db.SaveAs("D:\\LY.dwg", DwgVersion.Current);
                    }
                    catch (System.Exception e)
                    {

                        Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(e.Message);
                        trans.Abort();

                        return null;
                    }

                }


            }


            return objIdCol;

        }


        public static ObjectId CreateLayer(Database myDatabase,string layername, short colornum)//Color layercolor
        {

            ObjectId layerId = ObjectId.Null;
            short colorIndex1 = (short)(colornum % 256);
            DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();
            using (Transaction trans = myDatabase.TransactionManager.StartTransaction())
            {

                LayerTable lt = (LayerTable)trans.GetObject(myDatabase.LayerTableId, OpenMode.ForWrite);
                

                if(lt.Has(layername) == false)
                {


                    LayerTableRecord ltr = new LayerTableRecord();
                    ltr.Name = layername;

                    ltr.Color = Color.FromColorIndex(ColorMethod.ByColor, colorIndex1);
                    layerId = lt.Add(ltr);

                    trans.AddNewlyCreatedDBObject(ltr, true);
                }

                trans.Commit();

                
            }

            m_DocumentLock.Dispose();
            return layerId;
        }


        public static double Scalefactor(Database myDatabase,Editor myEditor) //比例因子
        {
           
           
              //  Document myDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
               // Database myDatabase = myDoc.Database;// Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Database;
              //  Editor myEditor = myDoc.Editor;

                double Scalefactor = 0;

                if (myDatabase.Useri1 !=0)
                {
                    Scalefactor = myDatabase.Userr1 / 1000.0; //比例系数

                }
                else
                {
                    PromptDoubleOptions optDou = new PromptDoubleOptions("\n 请输入图形比例尺1：");
                    optDou.AllowNegative = false;
                    PromptDoubleResult resDou = myEditor.GetDouble(optDou);

                    if(resDou.Status == PromptStatus.OK)
                    {

                       // myDatabase.Userr1 = resDou.Value;
                    Autodesk.AutoCAD.ApplicationServices.Application.SetSystemVariable("USERR1",resDou.Value);
                         Scalefactor = myDatabase.Userr1 / 1000.0; //比例系数

                         
                    }

               

                }

            return Scalefactor;


        }



        /// <summary>
        /// 求两条曲线的交点,本函数为应对Polyline.IntersectWith函数的Bug
        /// Vrsion : 2010.12.25 增加判断输入实体是否为平面实体
        /// </summary>
        /// <param name="ent1"></param>
        /// <param name="ent2"></param>
        /// <returns></returns>
        public static Point3dCollection IntersectWith(Entity ent1, Entity ent2, Intersect intersectType)
        {
            try
            {
                if (ent1 is Polyline || ent2 is Polyline)
                {
                    if (ent1 is Polyline && ent2 is Polyline)
                    {
                        Polyline pline1 = (Polyline)ent1;
                        Polyline pline2 = (Polyline)ent2;
                        return IntersectWith(pline1.ConvertTo(false), pline2.ConvertTo(false), intersectType);
                    }
                    else if (ent1 is Polyline)
                    {
                        Polyline pline1 = (Polyline)ent1;
                        return IntersectWith(pline1.ConvertTo(false), ent2, intersectType);
                    }
                    else
                    {
                        Polyline pline2 = (Polyline)ent2;
                        return IntersectWith(ent1, pline2.ConvertTo(false), intersectType);
                    }
                }
                else
                {
                    Point3dCollection interPs = new Point3dCollection();
                    if (ent1.IsPlanar && ent2.IsPlanar)
                        ent1.IntersectWith(ent2, intersectType, new Plane(Point3d.Origin, Vector3d.ZAxis), interPs, IntPtr.Zero, IntPtr.Zero);
                    else
                        ent1.IntersectWith(ent2, intersectType, interPs, IntPtr.Zero, IntPtr.Zero);
                    return interPs;
                }
            }
            catch 
            {
                return null;
            }
        }


        public static ObjectId AddDimStyle(this Database db,string stylename)
        {
            DimStyleTable dst = (DimStyleTable)db.DimStyleTableId.GetObject(OpenMode.ForRead);
            if(!dst.Has(stylename))
            {

                DimStyleTableRecord dstr = new DimStyleTableRecord();
                dstr.Name = stylename;
                dst.UpgradeOpen();
                dst.Add(dstr);

                db.TransactionManager.AddNewlyCreatedDBObject(dstr, true);
                dst.DowngradeOpen();
            }

            return dst[stylename];
        }

        public static ResultBuffer InvokeLisp(ResultBuffer args,ref int stat)
        {

            IntPtr rb = IntPtr.Zero;

            stat = acedInvoke(args.UnmanagedObject, out rb);

            if(stat == (int)PromptStatus.OK&& rb!= IntPtr.Zero)
            {

                return (ResultBuffer)DisposableWrapper.Create(typeof(ResultBuffer), rb, true);

            }

            else
            {

                return null;
            }

        }


        [DllImport("accore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "acedInvoke")]
        private static extern int acedInvoke(IntPtr args, out IntPtr result);


        public static void Rotate(Entity ent, Point3d basePt,double angle,Vector3d Axis)
        {

            Matrix3d mt = Matrix3d.Rotation(angle, Axis, basePt);

            ent.TransformBy(mt);

        }


        public static bool merageDWGFiles(List<string> pDWGFiles, string pOutputFile, DwgVersion pDWGVersion = DwgVersion.AC1800)
        {
            try
            {
                Database db = HostApplicationServices.WorkingDatabase;              
                Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

                Database destDB = new Database(false, true);
                //打开一个Dwg
                destDB.ReadDwgFile(pDWGFiles[0], FileOpenMode.OpenForReadAndAllShare, false, string.Empty);
                destDB.CloseInput(true);
                string str1 = "请稍后，正在处理第";
                string str2 = "张图";
                for (int i = 1; i < pDWGFiles.Count; i++)
                {
                    
                    string str3 = str1 + i.ToString() + str2;
                    Autodesk.AutoCAD.ApplicationServices.Application.SetSystemVariable("MODEMACRO", str3);
                    string pdwgFile = pDWGFiles[i];
                    ObjectIdCollection pObjIdsColl = new ObjectIdCollection();
                    Database srcDB = new Database(false, true);
                    srcDB.ReadDwgFile(pdwgFile, FileOpenMode.OpenForReadAndAllShare, false, string.Empty);
                    srcDB.CloseInput(true);

                    Autodesk.AutoCAD.DatabaseServices.TransactionManager srcTMgr = srcDB.TransactionManager;

                    using (Transaction pTransac = srcTMgr.StartTransaction())
                    {
                        BlockTable srcBt = (BlockTable)srcTMgr.GetObject(srcDB.BlockTableId, OpenMode.ForRead);
                        ObjectId ModelSpaceID = srcBt[BlockTableRecord.ModelSpace];
                        BlockTableRecord srcBtr = (BlockTableRecord)srcTMgr.GetObject(ModelSpaceID, OpenMode.ForRead);

                        System.Collections.IEnumerator pIterator = srcBtr.GetEnumerator();

                        while (pIterator.MoveNext())
                        {
                            ObjectId objId = (ObjectId)pIterator.Current;
                            pObjIdsColl.Add(objId);
                        }

                                                  

                        Autodesk.AutoCAD.DatabaseServices.TransactionManager destTMgr = destDB.TransactionManager;
                        using (Transaction destrans = destTMgr.StartTransaction())
                        {
                            BlockTable destBT = (BlockTable)destTMgr.GetObject(destDB.BlockTableId, OpenMode.ForRead);
                            ObjectId destModelSpaceID = destBT[BlockTableRecord.ModelSpace];

                            IdMapping pIdMap = new IdMapping();
                            srcDB.WblockCloneObjects(pObjIdsColl, destModelSpaceID, pIdMap, DuplicateRecordCloning.Replace, false);
                            pObjIdsColl.Dispose();
                        }


                    }
                    //-------- System.Windows.Forms.Application.DoEvents();

                }
                //------ pm.Stop();

                destDB.SaveAs(pOutputFile, pDWGVersion);

               
                //对合并后的文档进行整理  

                //1.前台打开图纸

                DocumentCollection acDocMgr = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
                if (!System.IO.File.Exists(pOutputFile)) return false;

                Document acDoc = acDocMgr.Open(pOutputFile,false);

                acDocMgr.MdiActiveDocument = acDoc;  // 设置为当前文档 


                using (DocumentLock doclock = acDoc.LockDocument())
                {

                    Database newDb = acDoc.Database;
                    Editor newed = acDoc.Editor;


                    TypedValue[] tvs = new TypedValue[]
                     {

                        new TypedValue((int)DxfCode.LayerName,"GXTK")
                     };

                    SelectionFilter sf = new SelectionFilter(tvs);

                    PromptSelectionResult selRes = newed.SelectAll(sf);

                    if (selRes.Status != PromptStatus.OK)
                    {
                        return false;

                    }

                    SelectionSet ss = selRes.Value;

                    ObjectId[] ObjIds = ss.GetObjectIds();

                    using (Transaction acTran = newDb.TransactionManager.StartTransaction())
                    {

                        foreach (ObjectId id in ObjIds)
                        {
                            try
                            {
                                DBObject obj = acTran.GetObject(id, OpenMode.ForWrite);

                                if (obj.GetType() == typeof(DBText) || obj.GetType() == typeof(Polyline) || obj.GetType() == typeof(MText)
                                    || obj.GetType() == typeof(Line) || obj.GetType() == typeof(Circle))
                                {

                                    obj.Erase();

                                }

                                if(obj.GetType() == typeof(BlockReference))
                                {
                                    BlockReference bref = (BlockReference)obj;

                                    if(bref.Name == "指北针")
                                    {


                                        obj.Erase();


                                    }

                                }

                            }
                            catch
                            {
                                acTran.Abort();
                                return false;
                            }


                        }


                        acTran.Commit();
                    }

                }

               // acDoc.CloseAndSave(pOutputFile);
                

              //  string message = "本次任务共合并了" + pDWGFiles.Count.ToString() + "个dwg文件，请到" + pOutputFile + "中查看结果！";
                //System.Windows.Forms.MessageBox.Show(message);
              //  Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(message);

                return true;
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(ex.Message);
                return false;
            }

           

            

        }

        /// <summary>
        /// 遍历给定文件路径下的所有文件；
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static List<string>Director(string dir)
        {
            List<string> fileList = new List<string>();

            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹
                {
                    Director(fsinfo.FullName);//递归调用
                }
                else
                {

                    if(fsinfo.FullName.Contains(".dwg")|| fsinfo.FullName.Contains(".DWG"))
                    {

                        fileList.Add(fsinfo.FullName);//输出文件的全部路径
                    }
                    
                }
            }


            return fileList;
        }






    }


    public static class TextTools
    {

        public static ObjectId AddTextStyle(this Database acdb,string name,string smallfont,string bigfont,double height,double xscale,double OblAngle)
        {

            using (Transaction trans = acdb.TransactionManager.StartTransaction())
            {

                TextStyleTable TST = (TextStyleTable)trans.GetObject(acdb.TextStyleTableId, OpenMode.ForWrite);
                ObjectId id = acdb.GetIdFromSymbolTable(TST, name);

                if(id == ObjectId.Null)
                {

                    TextStyleTableRecord TSTR = new TextStyleTableRecord();
                    TSTR.Name = name;
                    TSTR.FileName = smallfont;
                    TSTR.BigFontFileName = bigfont;
                    TSTR.TextSize = height;
                    TSTR.XScale = xscale;
                    TSTR.ObliquingAngle = OblAngle;
                    TST.UpgradeOpen();

                    id = TST.Add(TSTR);

                    trans.AddNewlyCreatedDBObject(TSTR, true);

                }

                trans.Commit();
                return id;

            }

        }


        public static ObjectId GetIdFromSymbolTable(this Database acdb,SymbolTable st,string key)
        {


            using (Transaction trans = acdb.TransactionManager.StartTransaction())
            {
                if(st.Has(key))
                {

                    ObjectId idres = st[key];

                    if(!idres.IsErased)
                    {

                        return idres;
                    }


                    foreach(ObjectId id in st)
                    {

                        if(!id.IsErased)
                        {
                            SymbolTableRecord STR = (SymbolTableRecord)trans.GetObject(id, OpenMode.ForRead);

                            if(STR.Name == key)
                            {


                                return id;
                            }


                        }


                    }

                }


            }

            return ObjectId.Null;
        }

    }

    public static class PolyLineTools
    {


        /// <summary>
        /// 通过三维点集合创建多线段
        /// </summary>
        /// <param name="pline">多线段对象</param>
        /// <param name="pts">多线段的顶点</param>
        public static void CreatPolyline(this Polyline pline,Point3dCollection pts)
        {
            for(int i = 0; i< pts.Count; i++)
            {


                pline.AddVertexAt(i, new Point2d(pts[i].X, pts[i].Y), 0, 0, 0);
            }


        }
        /// <summary>
        /// 通过二维多线段集合创建多线段 
        /// </summary>
        /// <param name="pline"></param>
        /// <param name="pts"></param>
        public static void CreatPolyline(this Polyline pline,Point2dCollection pts)
        {


            for(int i= 0; i< pts.Count; i++)
            {

                pline.AddVertexAt(i,pts[i],0,0,0);

            }
        }

        public static void CreatPolyline(this Polyline pline,params Point2d[] pts)
        {


            pline.CreatPolyline(new Point2dCollection(pts));
        }

    }

    public static class LayerTools
    {


        public static void RemoveAllEntOfLayer(LayerTableRecord layer,Database db)
        {

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {

                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForWrite);

                foreach(ObjectId btrid in bt)
                {


                    BlockTableRecord btr = (BlockTableRecord)trans.GetObject(btrid, OpenMode.ForWrite);

                    foreach(ObjectId eid in btr)
                    {


                        Entity ent = trans.GetObject(eid, OpenMode.ForWrite) as Entity;

                        if(ent != null)
                        {

                            if(ent.LayerId == layer.ObjectId)
                            {

                                ent.Erase();
                            }
                        }
                    }
                }


                trans.Commit();

            }

        }
    }

    public class CutTK
    {
        public CutTK()
        {
        }

        //
        public Polyline cutPl = new Polyline();
        public Point3dCollection pts_cutPl = new Point3dCollection();
        public bool EntIsPolyline = false;
        private Editor ed =  Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
        private Database db = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Database;
        ObjectIdCollection ids = new ObjectIdCollection();

        /// <summary>
        /// 重载构造函数
        /// </summary>
        /// <param name="pl"></param>
        public CutTK(Polyline pl)
        {
            cutPl = pl;
            if (cutPl != null)
                pts_cutPl = PlToPts(cutPl);
        }


        private Point3dCollection PlToPts(Polyline pl)
        {
            Point3dCollection pts = new Point3dCollection();
            for (int i = 0; i < pl.NumberOfVertices; i++)
            {
                Point3d pt = pl.GetPoint3dAt(i); 
                //改变后看看效果
            
                //Point3d pt = pl.GetPoint3dAt(i).TransformBy(ed.CurrentUserCoordinateSystem);
                pts.Add(pt);
            }
            return pts;
        }

        public void Cut(string filePath, bool saveNewFile)
        {
            if(cutPl!= null)
            {

                Editor ed =  Autodesk.AutoCAD.ApplicationServices. Application.DocumentManager.MdiActiveDocument.Editor;

                DBObjectCollection obj_tk = new DBObjectCollection();
                DBObjectCollection obj_Crossing = new DBObjectCollection();

                TypedValue[] filterlist = new TypedValue[] {
                    new TypedValue ((int)DxfCode .Operator ,"<not"),
                new TypedValue ((int)DxfCode .LayerName ,"*TK"),
                new TypedValue ((int)DxfCode.Operator ,"not>") };
                SelectionFilter sfilter = new SelectionFilter(filterlist);
                //获取与框线相交或在内部的所有图形
                PromptSelectionResult psr_PolyGon1 = ed.SelectCrossingPolygon(pts_cutPl, sfilter);

                using (Transaction trans = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.TransactionManager.StartTransaction())
                {

                    if (psr_PolyGon1.Status == PromptStatus.OK)
                    {
                        for (int i = 0; i < psr_PolyGon1.Value.Count; i++)
                        {
                            DBObject obj = trans.GetObject(psr_PolyGon1.Value.GetObjectIds()[i], OpenMode.ForRead);

                            obj_Crossing.Add(obj);
                        }
                    }

                    trans.Commit();

                }


                //将所有与选择框线相交的图形打断
                DBObjectCollection obj_Break = new DBObjectCollection();
                if (obj_Crossing.Count != 0)
                    obj_Break = BreakAllCurve(obj_Crossing, cutPl);

                //获取被选框线的范围
                 Point3dCollection ptsBrk = PlToScale(cutPl, false);

                //获取裁剪范围

               // Point3dCollection ptsCut = CutRange(cutPl);

                if (saveNewFile == true)
                {
                    //获取需要保存的图形
                    SaveFigures(ptsBrk);

                    //另存为图形
                    WClone(ids, filePath);
                }
                else
                    //删除框线外围图形
                    //CutFigures(ptsCut);
                    CutFigures(ptsBrk);


            }



        }


        /// <summary>
        /// 用b(polyline) 和 a 的所有交点打断a
        /// 返回a被交点分割后的子线段
        /// </summary>
        /// <param name="well_be_break"></param>
        /// <param name="binputpl"></param>
        /// <returns></returns>
        //private static DBObjectCollection BreakAllCurve(DBObjectCollection well_be_break, DBObjectCollection binputpl)
        public DBObjectCollection BreakAllCurve(DBObjectCollection well_be_break, Polyline pl)
        {
            Document myDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor myEditor = myDoc.Editor;
            Database myDatabase = myDoc.Database;
            DBObjectCollection outputpl = new DBObjectCollection();
            DBObjectCollection oldids = new DBObjectCollection();

            using (Transaction trans = myDatabase.TransactionManager.StartTransaction())
            {
                foreach (DBObject apl in well_be_break)
                {
                    List<double> pars = new List<double>();
                    DBObject aObj = trans.GetObject(apl.ObjectId, OpenMode.ForRead);
                    Curve aCurve = aObj as Curve;
                    if (aCurve != null)
                    {

                        //获取曲线与其他曲线的交点处的param值集合，按该集合打断曲线              
                        //foreach (DBObject bpl in binputpl)
                        //{
                        if (apl != pl)
                        {
                            Polyline2d pl3 = new Polyline2d();

                            Curve bCurve = (Curve)trans.GetObject(pl.ObjectId, OpenMode.ForRead);
                            Point3dCollection iwpnts = new Point3dCollection();
                            aCurve.IntersectWith(bCurve, Intersect.OnBothOperands, iwpnts, IntPtr.Zero, IntPtr.Zero);
                            foreach (Point3d p in iwpnts)
                            {
                                Point3d pp = aCurve.GetClosestPointTo(p, false);
                                if (pp.DistanceTo(p) < 0.001)
                                {
                                    pars.Add(aCurve.GetParameterAtPoint(pp));
                                }
                            }
                        }
                        // }
                        //如果有交点，按param值排序并打断         
                        if (pars.Count > 0)
                        {
                            pars.Sort();
                            try
                            {
                                //将子曲线加入数据库，原曲线加入oldids集合                      
                                foreach (Curve newline in aCurve.GetSplitCurves(new DoubleCollection(pars.ToArray())))
                                {
                                    //CUsercontrol.AppendEntity(newline);
                                    MyAppendEntity(newline);
                                    //newline.Color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(Autodesk.AutoCAD.Colors.ColorMethod.ByColor, 1);
                                    outputpl.Add(newline);
                                }
                                oldids.Add(apl);
                                //inputpl.Remove(apl);
                            }
                            catch { }
                        }
                    }

                }
                if (oldids.Count != 0)
                {
                    foreach (DBObject id in oldids)
                    {
                        id.UpgradeOpen();
                        id.Erase(true);
                    }
                }
                trans.Commit();
            }
            return outputpl;
        }


        public void MyAppendEntity(Entity ent)
        {
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                btr.AppendEntity(ent);
                trans.AddNewlyCreatedDBObject(ent, true);
                trans.Commit();
            }
        }


        /// <summary>
        /// 对图框进行缩放
        /// 并判断是否保留图框附近的TK层上的对象
        /// </summary>
        /// <param name="pl"></param>
        /// <param name="IsBreak"></param>
        /// <returns></returns>
        public Point3dCollection PlToScale(Polyline pl, bool IsSaveTK)
        {
            Point3dCollection pts_pl = PlToPts(pl);
            Point3dCollection pts = new Point3dCollection();
            Polyline pl_scale = new Polyline();
            double scale = 1.01;

            for (int i = 0; i < pts_pl.Count; i++)
            {
                pl_scale.AddVertexAt(i, new Point2d(pts_pl[i].X, pts_pl[i].Y), 0, 0, 0);
            }
            pl_scale.Closed = true;

            //CUsercontrol.AppendEntity(pl_scale);
            MyAppendEntity(pl_scale);

            using (Transaction trans =Autodesk.AutoCAD.ApplicationServices. Application.DocumentManager.MdiActiveDocument.TransactionManager.StartTransaction())
            {
                pl_scale = (Polyline)trans.GetObject(pl_scale.ObjectId, OpenMode.ForWrite);

                Point3d center3d = GetCenter(pl_scale);
                if (IsSaveTK == true)
                    scale = GetscaleFactor(pl_scale);

                Scale(pl_scale, center3d, scale);

                pts = PlToPts(pl_scale);

                pl_scale.Erase();
                trans.Commit();
            }

            return pts;
        }


        private Point3d GetCenter(Polyline pl)
        {
            Point3dCollection pts = PlToPts(pl);
            double minX = 0, minY = 0, maxX = 0, maxY = 0;

            for (int i = 0; i < pts.Count; i++)
            {
                if (i == 0)
                {
                    maxX = minX = pts[i].X;
                    maxY = minY = pts[i].Y;
                }
                else
                {
                    if (pts[i].X >= maxX)
                        maxX = pts[i].X;
                    if (pts[i].X <= minX)
                        minX = pts[i].X;
                    if (pts[i].Y >= maxY)
                        maxY = pts[i].Y;
                    if (pts[i].Y <= minY)
                        minY = pts[i].Y;
                }
            }
            Point3d center = new Point3d((maxX + minX) / 2, (maxY + minY) / 2, 0.0);

            return center;
        }

        /// <summary>
        /// 图廓层的缩放因子算法
        /// </summary>
        /// <param name="pl"></param>
        /// <returns></returns>
        private double GetscaleFactor(Polyline pl)
        {
            double[] distance = new double[3];
            double x = 0.0;

            double shortline = 0, longline = 0;

            if (pl.NumberOfVertices == 4)
            {
                distance[0] = pl.GetPoint2dAt(0).GetDistanceTo(pl.GetPoint2dAt(1));
                distance[1] = pl.GetPoint2dAt(0).GetDistanceTo(pl.GetPoint2dAt(2));
                distance[2] = pl.GetPoint2dAt(0).GetDistanceTo(pl.GetPoint2dAt(3));
            }
            else if (pl.NumberOfVertices == 5 && pl.StartPoint == pl.EndPoint)
            {
                distance[0] = pl.GetPoint2dAt(0).GetDistanceTo(pl.GetPoint2dAt(1));
                distance[1] = pl.GetPoint2dAt(0).GetDistanceTo(pl.GetPoint2dAt(2));
                distance[2] = pl.GetPoint2dAt(0).GetDistanceTo(pl.GetPoint2dAt(3));
            }
            else
                return 1.01;
            double a = distance.Min();
            double cornerline = distance.Max();
            double b = Math.Sqrt(cornerline * cornerline - a * a);

            if (a > b)
            {
                longline = a;
                shortline = b;
            }
            else
            {
                longline = b;
                shortline = a;
            }
            x = 20 * cornerline / shortline;

            Point3d center3d = GetCenter(pl);
            Point2d center = new Point2d(center3d.X, center3d.Y);
            double scale = 1.0 + x / center.GetDistanceTo(new Point2d(pl.GetPoint2dAt(0).X, pl.GetPoint2dAt(0).Y));

            return scale;
        }

        private void Scale(ObjectId id, Point3d basePt, double scaleFactor)
        {
            Matrix3d mt = Matrix3d.Scaling(scaleFactor, basePt);

            Object obj = id.GetObject(OpenMode.ForWrite);
            Entity ent = obj as Entity;
            Entity entCopy = ent.GetTransformedCopy(mt);

            ent.TransformBy(mt);
            ent.DowngradeOpen();
        }

        private void Scale(Entity ent, Point3d basePt, double scaleFactor)
        {
            if (ent.IsNewObject)
            {
                Matrix3d mt = Matrix3d.Scaling(scaleFactor, basePt);

                ent.TransformBy(mt);
                ent.DowngradeOpen();
            }
            else
                Scale(ent.Id, basePt, scaleFactor);
        }


        /// <summary>
        /// 打断外围图形并另存为函数
        /// </summary>
        /// <param name="ptsBrk"></param>
        /// <param name="ptsTK"></param>
        //public void SaveFigures(Point3dCollection ptsBrk, Point3dCollection ptsTK)
        public void SaveFigures(Point3dCollection ptsBrk)
        {
            try
            {
               // TypedValue[] filterlist = new TypedValue[] { new TypedValue((int)DxfCode.LayerName, "*TK") };
              //  SelectionFilter sfilter = new SelectionFilter(filterlist);

                PromptSelectionResult psr_All = ed.SelectAll();
               // PromptSelectionResult psr_Brk = ed.SelectCrossingPolygon(ptsBrk);
                PromptSelectionResult psr_Brk = ed.SelectWindowPolygon(ptsBrk);
                // PromptSelectionResult psr_TK = ed.SelectWindowPolygon(ptsTK, sfilter);

                //IEnumerable<ObjectId> psr_Erase = null;
                //if (psr_All.Status == PromptStatus.OK && psr_Brk.Status == PromptStatus.OK)
                //    psr_Erase = psr_All.Value.GetObjectIds().Except(psr_Brk.Value.GetObjectIds());

                //if (psr_TK.Status == PromptStatus.OK)
                //    psr_Erase = psr_Erase.Except(psr_TK.Value.GetObjectIds());

                //Ids_Save = psr_All.Value.GetObjectIds().Except(psr_Erase);
                if (psr_Brk.Status == PromptStatus.OK )
                {
                    using (Transaction trans = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.TransactionManager.StartTransaction())
                    {
                        foreach (var id in psr_Brk.Value.GetObjectIds())
                        {
                            Entity ent = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                            if (ent != null)
                                ids.Add(id);
                        }
                       /* foreach (var id in psr_TK.Value.GetObjectIds())
                        {
                            Entity ent = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                            if (ent != null)
                                ids.Add(id);
                        }*/
                        trans.Commit();
                    }
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                ed.WriteMessage(ex.ErrorStatus.ToString());
                return;
            }
        }


        /// <summary>
        /// 写块克隆
        /// </summary>
        /// <param name="Idc">克隆的对象ID集合</param>
        /// <param name="FileName">克隆到的文件名</param>
        public void WClone(ObjectIdCollection idc, string FileName)
        {
            try
            {
                Database ndb = new Database(true, true);
                ObjectId idBtr = new ObjectId();
                Database db = idc[0].Database;
                IdMapping map = new IdMapping();

                using (Transaction trans = ndb.TransactionManager.StartTransaction())
                {
                    BlockTable bt = (BlockTable)trans.GetObject(ndb.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord modelSpace = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                    idBtr = modelSpace.ObjectId;
                    trans.Commit();
                }
                db.WblockCloneObjects(idc, idBtr, map, DuplicateRecordCloning.Ignore, false);
                ndb.SaveAs(FileName, DwgVersion.AC1800);
                ed.WriteMessage("\n已将剪切文件另存为：\n" + FileName + "\n");
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                ed.WriteMessage(ex.ErrorStatus.ToString());
                return;
            }
        }

        /// <summary>
        /// 剪切并删除外围图形
        /// </summary>
        /// <param name="ptsBrk"></param>
        /// <param name="ptsTK"></param>
        //public void CutFigures(Point3dCollection ptsBrk, Point3dCollection ptsTK)

        public void CutFigures(Point3dCollection ptsBrk)
        {

            // TypedValue[] filterlist = new TypedValue[] { new TypedValue((int)DxfCode.LayerName, "*TK") };
            // SelectionFilter sfilter = new SelectionFilter(filterlist);

           /* Point3dCollection cutPts = new Point3dCollection();
         
            Polyline cutpl = new Polyline(); 

           for(int i = 0;i<ptsBrk.Count;i++)
            {

                cutpl.AddVertexAt(i, new Point2d(ptsBrk[i].X, ptsBrk[i].Y), 0, 0, 0);

            }

              cutpl.Closed = true;


            Polyline offsetBox = cutpl.GetOffsetCurves(0.2)[0] as Polyline;


            if (offsetBox.Area < cutpl.Area)
            {
                offsetBox = cutpl.GetOffsetCurves(-0.2)[0] as Polyline;
            }

            offsetBox.Closed = true;
            MyAppendEntity(offsetBox);


            using (Transaction trans1 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.TransactionManager.StartTransaction())
            {
                offsetBox = (Polyline)trans1.GetObject(offsetBox.ObjectId, OpenMode.ForWrite);

                Point3d center3d = GetCenter(offsetBox);
                //if (IsSaveTK == true)
                // scale = GetscaleFactor(pl_scale);

                // Scale(pl_scale, center3d, scale);

                cutPts = PlToPts(offsetBox);

                offsetBox.Erase();
                trans1.Commit();
            }

            cutPts = PlToPts(offsetBox);*/

            
            PromptSelectionResult psr_All = ed.SelectAll();
            PromptSelectionResult psr_Brk = ed.SelectWindowPolygon(ptsBrk);

           // PromptSelectionResult psr_Brk = ed.SelectWindowPolygon(cutPts);
          
            IEnumerable<ObjectId> psr_Erase = null;
            if (psr_All.Status == PromptStatus.OK && psr_Brk.Status == PromptStatus.OK)
                psr_Erase = psr_All.Value.GetObjectIds().Except(psr_Brk.Value.GetObjectIds());

            if (psr_Erase != null)
            {
                using (Transaction trans = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.TransactionManager.StartTransaction())
                {
                    foreach (var psr in psr_Erase)
                    {

                        trans.GetObject(psr, OpenMode.ForWrite).Erase();

                    }
                       

                   // cutline1.Erase();

                    trans.Commit();
                }
            }

            
            // PromptSelectionResult psr_Brk = ed.SelectWindowPolygon(ptsBrk);
            //PromptSelectionResult psr_Brk = ed.SelectCrossingPolygon(ptsBrk);


            //PromptSelectionResult psr_TK = ed.SelectWindowPolygon(ptsTK, sfilter);



            /* if (psr_TK.Status == PromptStatus.OK)
                 psr_Erase = psr_Erase.Except(psr_TK.Value.GetObjectIds());*/


        }

        public  Point3dCollection CutRange(Polyline cutLine)
        {
            Point3dCollection cutPts = new Point3dCollection();

           

           

            Polyline offsetBox = cutLine.GetOffsetCurves(0.2)[0] as Polyline;


            if (offsetBox.Area < cutLine.Area)
            {
                offsetBox = cutLine.GetOffsetCurves(-0.2)[0] as Polyline;
            }

            cutPts = PlToPts(offsetBox);


            return cutPts;

        }
        


    }


    public class CutMap
    {

        Editor m_ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
        Database m_db = HostApplicationServices.WorkingDatabase;


        public CutMap()
        {
            //构造函数 
        }

        public void Cut(string filePath,bool saveNewFile)
        {

            #region 1.选择裁剪范围线 

            PromptEntityResult m_Per = null;
            if (!m_SelectEntity("请选择裁剪范围线", "", new Type[] { typeof(Polyline) }, ref m_Per)) return;

            Entity m_TrimEdgeEnt = (Entity)m_OpenEntity(m_Per.ObjectId);//剪切边界实体
            Curve m_TrimEdge = m_TrimEdgeEnt as Curve;
            if (m_TrimEdge == null)
                m_TrimEdge = m_CreateRectangle(m_TrimEdgeEnt.GeometricExtents.MinPoint, m_TrimEdgeEnt.GeometricExtents.MaxPoint, false);


            #endregion

            #region 2.选择裁剪方向 

            Point3d m_Pt = new Point3d();

            if(m_TrimEdge.GetType() == typeof(Polyline) )
            {
                Polyline pl_trim1 = m_TrimEdge as Polyline;

                m_Pt = GetCenter(pl_trim1);
            }
            else
            {
                if (!m_GetPoint("\n剪切方向", ref m_Pt, new Point3d(), false, false)) return;

            }
            

            Point3d m_Pt1 = m_TrimEdge.GetClosestPointTo(m_Pt, false);//曲线外一点距曲线最近的点
            Vector3d m_Vect = m_TrimEdge.GetFirstDerivative(m_Pt1);//曲线上此点的切向量
            int m_Direct = m_PtSide(m_Pt1.Convert2d(new Plane()), m_Pt1.Add(m_Vect).Convert2d(new Plane()), m_Pt.Convert2d(new Plane()));//裁剪方向 

            //裁剪方向转化为保留实体的方向 

            m_Direct = -m_Direct;
             


            //选择与剪切边包围的所有实体
            PromptSelectionResult m_psr = m_ed.SelectCrossingWindow(m_TrimEdge.GeometricExtents.MinPoint, m_TrimEdge.GeometricExtents.MaxPoint);

           

             


            #endregion


            if(saveNewFile)
            {

                //如果另存为文件  

                #region 3-1.保留剪切对象

                DBObjectCollection m_ObjCollSave = new DBObjectCollection();
                DBObjectCollection m_ObjColCur = new DBObjectCollection();
                foreach (ObjectId objid in m_psr.Value.GetObjectIds())
                {
                    if (!objid.Equals(m_Per.ObjectId))
                    {
                        Curve m_Cur = m_OpenEntity(objid) as Curve;
                        if (m_Cur != null)//判断是否曲线实体
                        {
                            if (m_Cur is Polyline2d)
                                m_Cur = m_Polyline2dToLWPolyline(objid);//二维多段线转换为轻量多段线

                            DBObjectCollection m_ObjColl = new DBObjectCollection();
                            if (SaveCutMap(m_Cur, m_TrimEdge, m_Direct, ref m_ObjColl))
                            {
                                foreach (Entity ent in m_ObjColl)
                                {


                                     m_CreateEntity(ent);

                                    m_ObjCollSave.Add(ent);
                                    

                                  //  m_EraseEntity(ent.ObjectId);

                                }


                               // m_EraseEntity(objid);
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                           
                         

                        }
                    }
                    // m_ed.WriteMessage("\r正在裁剪...已完成{0}％", ((double)(++i * 100.0 / m_psr.Value.GetObjectIds().GetLength(0))).ToString("0"));
                }





                Point3dCollection trimPts = PlToPts(m_TrimEdge as Polyline);

                PromptSelectionResult m_psr_notCur = m_ed.SelectWindowPolygon(trimPts);

                if (m_psr_notCur.Status == PromptStatus.OK)
                {
                    foreach (ObjectId id in m_psr_notCur.Value.GetObjectIds())
                    {

                        Entity ent = m_OpenEntity(id) as Entity;

                        if (ent is Curve)
                        {

                            continue;

                        }
                        else
                        {


                            m_ObjCollSave.Add(ent);
                        }

                    }

                }

                m_ObjCollSave.Add(m_TrimEdge);



                #endregion

                #region 克隆文件 


                ObjectIdCollection ObjIdc = new ObjectIdCollection();

                for(int i =0; i<m_ObjCollSave.Count;i++)
                {

                    ObjIdc.Add(m_ObjCollSave[i].ObjectId);

                }


                if(ObjIdc != null)
                {
                    WClone(ObjIdc, filePath);

                }
                else
                {
                    return;
                }



                #endregion

                //删除残线 

               foreach(Entity ent in m_ObjCollSave)
                {
                    if (!ent.ObjectId.Equals(m_Per.ObjectId))
                    {
                        m_EraseEntity(ent.ObjectId);

                    }

                        
                }

            }
            else
            {
                //如果不另存为新的文件 
                #region 3-2.剪切

                //int i = 0;
                foreach (ObjectId objid in m_psr.Value.GetObjectIds())
                {
                    if (!objid.Equals(m_Per.ObjectId))
                    {
                        Curve m_Cur = m_OpenEntity(objid) as Curve;
                        if (m_Cur != null)//判断是否曲线实体
                        {
                            if (m_Cur is Polyline2d)
                                m_Cur = m_Polyline2dToLWPolyline(objid);//二维多段线转换为轻量多段线

                            DBObjectCollection m_ObjColl = new DBObjectCollection();
                            if (m_TrimCurve(m_Cur, m_TrimEdge, m_Direct, ref m_ObjColl))
                            {
                                foreach (Entity ent in m_ObjColl) m_CreateEntity(ent);
                                m_EraseEntity(objid);
                            }
                            else
                            {

                            }
                        }
                    }
                    // m_ed.WriteMessage("\r正在裁剪...已完成{0}％", ((double)(++i * 100.0 / m_psr.Value.GetObjectIds().GetLength(0))).ToString("0"));
                }

                #endregion

                #region 4.删除多边形外的实体 

                PromptSelectionResult m_psr_all = m_ed.SelectAll();

                Polyline pl_trim = m_TrimEdge as Polyline;

                Point3dCollection trimPts = PlToPts(pl_trim);

                PromptSelectionResult m_psr_inner = m_ed.SelectCrossingPolygon(trimPts);

                IEnumerable<ObjectId> ids_Erase = null;

                if (m_psr_all.Status == PromptStatus.OK && m_psr_inner.Status == PromptStatus.OK)
                {

                    ids_Erase = m_psr_all.Value.GetObjectIds().Except(m_psr_inner.Value.GetObjectIds());






                }

                foreach (var id in ids_Erase)
                {

                    m_EraseEntity(id);

                }


                #endregion

            }







        }


        

        //提示选择单个实体
        public bool m_SelectEntity(string m_MSG, string m_RejectMSG, Type[] m_EntityType, ref PromptEntityResult m_PER)
        {
            PromptEntityOptions m_peo = new PromptEntityOptions((m_MSG.Substring(0, 2).Equals("\n") ? m_MSG : "\n" + m_MSG));
            m_peo.SetRejectMessage(m_RejectMSG);
            foreach (Type et in m_EntityType) m_peo.AddAllowedClass(et, false);
            m_peo.AllowNone = true;

            m_PER = m_ed.GetEntity(m_peo);
            if (m_PER.Status != PromptStatus.OK) return false;
            else return true;
        }

        //打开实体
        public Object m_OpenEntity(ObjectId m_ObjId)
        {
            Object m_Obj = new Object();
            if (!m_ObjId.IsNull)
            {
                using (Transaction m_tr = m_db.TransactionManager.StartTransaction())
                {
                    m_Obj = (Object)m_tr.GetObject(m_ObjId, OpenMode.ForRead);
                    m_tr.Commit();
                }
            }

            return m_Obj;
        }


        //生成矩形
        public Polyline m_CreateRectangle(Point3d m_Pt1, Point3d m_Pt2, bool m_bLUorLW)
        {
            if (!m_bLUorLW)//不是左上和右下点，而是左下点和右上点
            {
                Point3d m_Pt3 = m_Pt1, m_Pt4 = m_Pt2;
                m_Pt1 = new Point3d(m_Pt3.X, m_Pt4.Y, 0);
                m_Pt2 = new Point3d(m_Pt4.X, m_Pt3.Y, 0);
            }

            Polyline m_lwpline = new Polyline();
            m_lwpline.AddVertexAt(0, m_Pt1.Convert2d(new Plane()), 0, 0, 0);
            m_lwpline.AddVertexAt(1, new Point2d(m_Pt2.X, m_Pt1.Y), 0, 0, 0);
            m_lwpline.AddVertexAt(2, m_Pt2.Convert2d(new Plane()), 0, 0, 0);
            m_lwpline.AddVertexAt(3, new Point2d(m_Pt1.X, m_Pt2.Y), 0, 0, 0);
            m_lwpline.Closed = true;
            return m_lwpline;
        }

        //提示用户输入一点
        public bool m_GetPoint(string m_Msg, ref Point3d m_Pt, Point3d m_BasePoint, bool m_AllowNone, bool m_UseBasePoint)
        {
            if (!m_Pt.Equals(new Point3d())) m_Msg += "<" + m_Pt.X.ToString() + "," + m_Pt.Y.ToString() + "," + m_Pt.Z.ToString() + ">";

            PromptPointOptions m_ppo = new PromptPointOptions("\n" + m_Msg);
            m_ppo.AllowNone = m_AllowNone;
            m_ppo.BasePoint = m_BasePoint;
            m_ppo.UseBasePoint = m_UseBasePoint;

            PromptPointResult m_ppr = m_ed.GetPoint(m_ppo);

            if (m_ppr.Status != PromptStatus.OK)
            {
                if (m_ppr.Status == PromptStatus.None) { m_Pt = m_BasePoint; return true; }
                else return false;
            }
            m_Pt = m_ppr.Value;

            return true;
        }

        //判断点pt在直线pt1->Pt2的哪一侧？返回值：1右侧；0三点共线；-1左侧
        public int m_PtSide(Point2d pt1, Point2d pt2, Point2d pt)
        {
            Vector2d m_vect1 = pt1.GetVectorTo(pt2);
            Vector2d m_vect2 = pt1.GetVectorTo(pt);
            double m_value = m_vect2.X * m_vect1.Y - m_vect1.X * m_vect2.Y;
            if (Math.Abs(m_value) < 0.0000001) return 0;
            else if (m_value > 0) return 1;
            else return -1;
        }

        //求空间两曲线c1与c2在c1上的交点(带标高值)
        public Point3dCollection m_GetIntersectPoints(Curve c1, Curve c2)
        {
            Point3dCollection m_interpts = new Point3dCollection(), m_interpts1 = new Point3dCollection();
            Point3dCollection m_VertexPoints = new Point3dCollection();
            c1.IntersectWith(c2, Intersect.OnBothOperands, new Plane(), m_interpts, IntPtr.Zero, IntPtr.Zero);//求交点

            if (c1 is Polyline3d && !(c2 is Polyline3d))
            {
                foreach (Point3d pt in m_interpts)
                {
                    Polyline3d m_pl3d = new Polyline3d(Poly3dType.SimplePoly,
                      new Point3dCollection(new Point3d[] { pt, pt.Add(new Vector3d(0, 0, 10)) }), false);

                    Point3dCollection m_Pts = new Point3dCollection();
                    c1.IntersectWith(m_pl3d, Intersect.ExtendArgument, new Plane(), m_Pts, IntPtr.Zero, IntPtr.Zero);
                    foreach (Point3d pt1 in m_Pts) m_interpts1.Add(pt1);
                }
                m_interpts = m_interpts1;
            }

            //去掉不正确的交点（IntersectWith求出的交点有可能不正确！！！）
            ArrayList m_DistPtList = new ArrayList();
            foreach (Point3d pt in m_interpts)
            {
                try
                {
                    double m_Dist = c1.GetDistAtPoint(pt);//点是否在曲线上？
                    m_DistPoint3d m_DP = new m_DistPoint3d();
                    m_DP.m_dist = m_Dist;
                    m_DP.m_pt = pt;
                    m_DistPtList.Add(m_DP);
                }
                catch { }
            }

            m_DistPtList.Sort(new m_DistPtsSort());//排序
            m_interpts1 = new Point3dCollection();
            foreach (m_DistPoint3d dp in m_DistPtList) m_interpts1.Add(dp.m_pt);

            return m_interpts1;
        }

        private struct m_DistPoint3d
        {
            public double m_dist;
            public Point3d m_pt;
        }


        private class m_DistPtsSort : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                m_DistPoint3d dp1 = (m_DistPoint3d)a;
                m_DistPoint3d dp2 = (m_DistPoint3d)b;
                if (dp1.m_dist > dp2.m_dist)
                    return 1;
                if (dp1.m_dist < dp2.m_dist)
                    return -1;
                else
                    return 0;
            }
        }

        //二维多段线转换为轻量多段线
        public Polyline m_Polyline2dToLWPolyline(ObjectId m_ObjId)
        {
            Polyline m_pl = new Polyline();

            Polyline2d m_pl2d = m_OpenEntity(m_ObjId) as Polyline2d;
            if (m_pl2d != null)
            {
                switch (m_pl2d.PolyType)
                {
                    case Poly2dType.FitCurvePoly:
                        m_pl.ConvertFrom(m_pl2d, false);
                        break;
                    case Poly2dType.SimplePoly:
                    case Poly2dType.CubicSplinePoly:
                    case Poly2dType.QuadSplinePoly:
                        int index = 0;
                        foreach (ObjectId vid in m_pl2d)
                        {
                            Vertex2d v2d = m_OpenEntity(vid) as Vertex2d;
                            if (v2d.VertexType != Vertex2dType.SplineControlVertex)
                                m_pl.AddVertexAt(index++, new Point2d(v2d.Position.X, v2d.Position.Y), 0, v2d.StartWidth, v2d.EndWidth);
                        }
                        m_pl.LayerId = m_pl2d.LayerId;//继承层属性
                        m_pl.Elevation = m_pl2d.Elevation;//继承高程属性
                        m_pl.LinetypeId = m_pl2d.LinetypeId;//继承线型属性
                        m_pl.ColorIndex = m_pl2d.ColorIndex;//继承颜色属性
                        break;
                    default:
                        break;
                }
            }
            return m_pl;
        }


        private bool m_TrimCurve(Curve m_Cur, Entity m_TrimEdgeEnt, int m_Direction, ref DBObjectCollection m_ObjColl)
        {
            //m_Cur —被剪曲线；m_TrimEdge  —剪切边界曲线
            //m_Direction —剪切方向，只能是1或-1，1—剪掉边界曲线右边的线，-1—剪左边
            //返回true  —剪切成功，保留的实体保存在m_ObjColl中

            //判断被剪曲线是否位于锁定图层上
            LayerTableRecord m_ltr = (LayerTableRecord)m_OpenEntity(m_Cur.LayerId);
            if (m_ltr.IsLocked) return false;

            if (!(m_TrimEdgeEnt is Curve))//剪切实体不是曲线类，则用其边界框做为剪切边界
                m_TrimEdgeEnt = m_CreateRectangle(m_TrimEdgeEnt.GeometricExtents.MinPoint, m_TrimEdgeEnt.GeometricExtents.MaxPoint, false);
            Curve m_TrimEdge = m_TrimEdgeEnt as Curve;

            bool m_ReturnFlag = true;
            m_ObjColl = new DBObjectCollection();//初始化为空

            Point3dCollection m_InterPts = m_GetIntersectPoints(m_Cur, (Curve)m_TrimEdge);//求被剪曲线与剪切边的交点
            if (m_InterPts.Count > 0)//判断曲线是否与剪切边相交，若>0相交 ，若=0不相交
            {
                try
                {
                    #region 生成交点处拆分的实体集合
                    DBObjectCollection m_Objs = new DBObjectCollection();
                    if (m_Cur is Circle)//判断曲线是否为圆
                    {
                        #region 由交点把圆拆分为几条圆弧
                        Circle m_cir = m_Cur as Circle;
                        ArrayList m_AngArr = new ArrayList();
                        int n;
                        for (n = 0; n < m_InterPts.Count; n++)
                            m_AngArr.Add(m_InterPts[n].GetVectorTo(m_cir.Center).AngleOnPlane(new Plane()));
                        m_AngArr.Sort();
                        m_AngArr.Add(m_AngArr[0]);

                        for (n = 0; n < m_AngArr.Count - 1; n++)
                            m_Objs.Add(new Arc(m_cir.Center, m_cir.Radius, (double)m_AngArr[n], (double)m_AngArr[n + 1]));
                        #endregion
                    }
                    else
                        m_Objs = m_Cur.GetSplitCurves(m_InterPts);//拆分曲线实体 
                    #endregion

                    #region 对拆分实体集合中各实体进行判断，那些需要保留
                    foreach (Curve cur in m_Objs)
                    {
                        ObjectId m_CurId = m_CreateEntity(cur);//先生成实体，主要是三维多段线有问题，EndPoint属性老是错误！！！
                        Curve m_CurNew = m_OpenEntity(m_CurId) as Curve;

                        double m_Param = m_CurNew.StartParam + 0.0001;
                        if (!m_InterPts.Contains(m_CurNew.StartPoint))//点不是交点
                            m_Param = m_CurNew.EndParam - 0.0001;

                        Point3d m_Pt1 = m_CurNew.GetPointAtParameter(m_Param);
                        Point3d m_Pt2 = m_TrimEdge.GetClosestPointTo(m_Pt1, false);
                        Vector3d m_Vect = m_TrimEdge.GetFirstDerivative(m_Pt2);

                        int m_Direct = m_PtSide(m_Pt2.Convert2d(new Plane()), m_Pt2.Add(m_Vect).Convert2d(new Plane()), m_Pt1.Convert2d(new Plane()));
                        if (m_Direct != m_Direction) m_ObjColl.Add((DBObject)m_CurNew.Clone());//保存被剪之后的新实体

                        m_EraseEntity(m_CurId);
                    }
                    #endregion
                }
                catch
                {
                    m_ReturnFlag = false;
                }
            }
            else//若无交点，先判断裁剪实体与裁剪边界的位置关系，根据位置关系确定是否删除实体 
            {


                ObjectId m_curId = m_Cur.ObjectId;


                //判断曲线的方向 

                // double m_Param = m_Cur.StartParam + 0.0001;
                double m_Param = m_Cur.StartParam;
                //  if (!m_InterPts.Contains(m_Cur.StartPoint))//点不是交点
                //  m_Param = m_Cur.EndParam - 0.0001;

                Point3d m_Pt1 = m_Cur.GetPointAtParameter(m_Param);
                Point3d m_Pt2 = m_TrimEdge.GetClosestPointTo(m_Pt1, false);
                Vector3d m_Vect = m_TrimEdge.GetFirstDerivative(m_Pt2);

                int m_Direct = m_PtSide(m_Pt2.Convert2d(new Plane()), m_Pt2.Add(m_Vect).Convert2d(new Plane()), m_Pt1.Convert2d(new Plane()));
                if (m_Direct == m_Direction)
                {
                    m_EraseEntity(m_curId);

                }



                m_ReturnFlag = false;
            }






            return m_ReturnFlag;
        }


        /// <summary>
        /// 保存已剪切图像 
        /// </summary>
        /// <param name="m_Cur"></param>
        /// <param name="m_TrimEdgeEnt"></param>
        /// <param name="m_Direction"></param>
        /// <param name="m_ObjColl"></param>
        /// <returns></returns>
        private bool SaveCutMap(Curve m_Cur, Entity m_TrimEdgeEnt, int m_Direction, ref DBObjectCollection m_ObjColl)
        {
            //m_Cur —被剪曲线；m_TrimEdge  —剪切边界曲线
            //m_Direction —剪切方向，只能是1或-1，1—剪掉边界曲线右边的线，-1—剪左边
            //返回true  —剪切成功，保留的实体保存在m_ObjColl中

            //判断被剪曲线是否位于锁定图层上
            LayerTableRecord m_ltr = (LayerTableRecord)m_OpenEntity(m_Cur.LayerId);
            if (m_ltr.IsLocked) return false;

            if (!(m_TrimEdgeEnt is Curve))//剪切实体不是曲线类，则用其边界框做为剪切边界
                m_TrimEdgeEnt = m_CreateRectangle(m_TrimEdgeEnt.GeometricExtents.MinPoint, m_TrimEdgeEnt.GeometricExtents.MaxPoint, false);
            Curve m_TrimEdge = m_TrimEdgeEnt as Curve;

            bool m_ReturnFlag = true;
            m_ObjColl = new DBObjectCollection();//初始化为空

            Point3dCollection m_InterPts = m_GetIntersectPoints(m_Cur, (Curve)m_TrimEdge);//求被剪曲线与剪切边的交点
            if (m_InterPts.Count > 0)//判断曲线是否与剪切边相交，若>0相交 ，若=0不相交
            {
                try
                {
                    #region 生成交点处拆分的实体集合
                    DBObjectCollection m_Objs = new DBObjectCollection();
                    if (m_Cur is Circle)//判断曲线是否为圆
                    {
                        #region 由交点把圆拆分为几条圆弧
                        Circle m_cir = m_Cur as Circle;
                        ArrayList m_AngArr = new ArrayList();
                        int n;
                        for (n = 0; n < m_InterPts.Count; n++)
                            m_AngArr.Add(m_InterPts[n].GetVectorTo(m_cir.Center).AngleOnPlane(new Plane()));
                        m_AngArr.Sort();
                        m_AngArr.Add(m_AngArr[0]);

                        for (n = 0; n < m_AngArr.Count - 1; n++)
                            m_Objs.Add(new Arc(m_cir.Center, m_cir.Radius, (double)m_AngArr[n], (double)m_AngArr[n + 1]));
                        #endregion
                    }
                    else
                        m_Objs = m_Cur.GetSplitCurves(m_InterPts);//拆分曲线实体 
                    #endregion

                    #region 对拆分实体集合中各实体进行判断，那些需要保留
                    foreach (Curve cur in m_Objs)
                    {
                        ObjectId m_CurId = m_CreateEntity(cur);//先生成实体，主要是三维多段线有问题，EndPoint属性老是错误！！！
                        Curve m_CurNew = m_OpenEntity(m_CurId) as Curve;

                        double m_Param = m_CurNew.StartParam + 0.0001;
                        if (!m_InterPts.Contains(m_CurNew.StartPoint))//点不是交点
                            m_Param = m_CurNew.EndParam - 0.0001;

                        Point3d m_Pt1 = m_CurNew.GetPointAtParameter(m_Param);
                        Point3d m_Pt2 = m_TrimEdge.GetClosestPointTo(m_Pt1, false);
                        Vector3d m_Vect = m_TrimEdge.GetFirstDerivative(m_Pt2);

                        int m_Direct = m_PtSide(m_Pt2.Convert2d(new Plane()), m_Pt2.Add(m_Vect).Convert2d(new Plane()), m_Pt1.Convert2d(new Plane()));
                        if (m_Direct != m_Direction) m_ObjColl.Add((DBObject)m_CurNew.Clone());//保存被剪之后的新实体

                        m_EraseEntity(m_CurId);
                    }
                    #endregion
                }
                catch
                {
                    m_ReturnFlag = false;
                }
            }
            else//若无交点，先判断裁剪实体与裁剪边界的位置关系，根据位置关系确定是否删除实体 
            {


                ObjectId m_curId = m_Cur.ObjectId;


                //判断曲线的方向 

                // double m_Param = m_Cur.StartParam + 0.0001;
                double m_Param = m_Cur.StartParam;
                //  if (!m_InterPts.Contains(m_Cur.StartPoint))//点不是交点
                //  m_Param = m_Cur.EndParam - 0.0001;

                Point3d m_Pt1 = m_Cur.GetPointAtParameter(m_Param);
                Point3d m_Pt2 = m_TrimEdge.GetClosestPointTo(m_Pt1, false);
                Vector3d m_Vect = m_TrimEdge.GetFirstDerivative(m_Pt2);

                int m_Direct = m_PtSide(m_Pt2.Convert2d(new Plane()), m_Pt2.Add(m_Vect).Convert2d(new Plane()), m_Pt1.Convert2d(new Plane()));

                m_Direct = -m_Direct;
                if (m_Direct == m_Direction)
                {
                    // m_EraseEntity(m_curId);
                    m_ObjColl.Add((DBObject)m_Cur.Clone());

                }



                m_ReturnFlag = true;
            }






            return m_ReturnFlag;

        }

        //删除实体
        public void m_EraseEntity(ObjectId m_EntityId)
        {
            using (DocumentLock m_doclock =Autodesk.AutoCAD.ApplicationServices. Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                if (!m_EntityId.IsNull && !m_EntityId.IsErased)
                {
                    Entity m_Ent = m_OpenEntity(m_EntityId) as Entity;
                    LayerTableRecord m_ltr = (LayerTableRecord)m_OpenEntity(m_Ent.LayerId);
                    if (!m_ltr.IsLocked)//实体不在锁定图层上
                    {
                        using (Transaction m_tr = m_db.TransactionManager.StartTransaction())
                        {
                            try
                            {
                                Entity m_Entity = (Entity)m_tr.GetObject(m_EntityId, OpenMode.ForWrite, false);
                                if (m_Entity != null) m_Entity.Erase();
                            }
                            catch { }
                            m_tr.Commit();
                        }
                    }
                }
            }
        }

        //创建实体,把实体加入CAD数据库
        public ObjectId m_CreateEntity(Entity m_entity)
        {
            ObjectId m_objid = new ObjectId();
            if (m_entity != null)
            {
                using ( Autodesk.AutoCAD.ApplicationServices. Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    using (Transaction m_tr = m_db.TransactionManager.StartTransaction())
                    {
                        BlockTableRecord m_btr = (BlockTableRecord)m_tr.GetObject(m_db.CurrentSpaceId, OpenMode.ForWrite, false);
                        m_objid = m_btr.AppendEntity(m_entity);
                        m_tr.AddNewlyCreatedDBObject(m_entity, true);
                        m_tr.Commit();
                    }
                }
            }
            return m_objid;
        }


        /// <summary>
        /// 得到多边形的中心
        /// </summary>
        /// <param name="pl"></param> 所选多边形
        /// <returns></returns>
        private Point3d GetCenter(Polyline pl)
        {
            Point3dCollection pts = PlToPts(pl);
            double minX = 0, minY = 0, maxX = 0, maxY = 0;

            for (int i = 0; i < pts.Count; i++)
            {
                if (i == 0)
                {
                    maxX = minX = pts[i].X;
                    maxY = minY = pts[i].Y;
                }
                else
                {
                    if (pts[i].X >= maxX)
                        maxX = pts[i].X;
                    if (pts[i].X <= minX)
                        minX = pts[i].X;
                    if (pts[i].Y >= maxY)
                        maxY = pts[i].Y;
                    if (pts[i].Y <= minY)
                        minY = pts[i].Y;
                }
            }
            Point3d center = new Point3d((maxX + minX) / 2, (maxY + minY) / 2, 0.0);

            return center;
        }

        private Point3dCollection PlToPts(Polyline pl)
        {
            Point3dCollection pts = new Point3dCollection();
            for (int i = 0; i < pl.NumberOfVertices; i++)
            {
                Point3d pt = pl.GetPoint3dAt(i);
                //改变后看看效果

                //Point3d pt = pl.GetPoint3dAt(i).TransformBy(ed.CurrentUserCoordinateSystem);
                pts.Add(pt);
            }
            return pts;
        }


        /// <summary>
        /// 写块克隆
        /// </summary>
        /// <param name="Idc">克隆的对象ID集合</param>
        /// <param name="FileName">克隆到的文件名</param>
        public void WClone(ObjectIdCollection idc, string FileName)
        {
            try
            {
                Database ndb = new Database(true, true);
                ObjectId idBtr = new ObjectId();
                Database db = idc[0].Database;
                IdMapping map = new IdMapping();

                using (Transaction trans = ndb.TransactionManager.StartTransaction())
                {
                    BlockTable bt = (BlockTable)trans.GetObject(ndb.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord modelSpace = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                    idBtr = modelSpace.ObjectId;
                    trans.Commit();
                }
                db.WblockCloneObjects(idc, idBtr, map, DuplicateRecordCloning.Ignore, false);
                ndb.SaveAs(FileName, DwgVersion.AC1800);
                m_ed.WriteMessage("\n已将剪切文件另存为：\n" + FileName + "\n");
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                m_ed.WriteMessage(ex.ErrorStatus.ToString());
                return;
            }
        }
    }

    public class JsonHelper
    {

        /// <summary>
        /// 构造函数与析构函数
        /// </summary>
        public JsonHelper()
        {

        }
        ~JsonHelper()
        {
        }


        //定义变量 
        //  private string CLosingString =string.Empty;
        private string geoType = string.Empty;
        private string Json = string.Empty;

        List<Point3d> CoorList = new List<Point3d>();

        /// <summary>
        /// 返回Json格式字符串 
        /// </summary>
        /// <param name="rangeFilePath">范围线绝对路径</param>
        /// <returns></returns>
        public string DwgPlToJSon(string rangeFilePath,string wkid,string XMBH,string XMMC,string JDXH,string KSSJ,string YZDW,string CJDW,string XMLB,string XMLX)
        {

            //定义变量 
            List<Polyline> PlList = new List<Polyline>();
            try
            {
                //1.在当前CAD文档下后台打开范围线文档，读取范围线需要的属性 

                using (Database destDB = new Database(false, true))
                using (Transaction trans = destDB.TransactionManager.StartTransaction())
                {

                    if(System.IO.File.Exists(rangeFilePath))
                    {
                        //destDB.ReadDwgFile(rangeFilePath, FileOpenMode.OpenForReadAndAllShare, false, string.Empty);
                        destDB.ReadDwgFile(rangeFilePath, FileOpenMode.OpenForReadAndAllShare, false, null);
                        BlockTable bt = (BlockTable)trans.GetObject(destDB.BlockTableId, OpenMode.ForRead);
                        BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                        foreach (ObjectId id in btr)
                        {


                            Entity ent = trans.GetObject(id, OpenMode.ForRead) as Entity;

                            if (ent.GetType() == typeof(Polyline))
                            {
                                PlList.Add(ent as Polyline);


                            }
                        }



                        if (PlList.Count == 1)
                        {

                            Polyline pl = PlList[0];

                            for (int i = 0; i < pl.NumberOfVertices; i++)
                            {
                                CoorList.Add(pl.GetPoint3dAt(i));


                            }

                            if (pl.Closed)
                            {

                                geoType = "Polygon";
                            }
                            else
                            {
                                pl.Closed = true;
                                geoType = "Polygon";
                            }
                        }
                        else
                        {


                            Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("没有范围线或有多条范围线！");

                            return Json;
                        }
                        //2.把范围线信息写入JSon字符串 //为GeoJson格式 

                       /* Json = "[{\"DataTaskId\":" + "\""+UtilityVar.SZGuid +"\"," +"\"ZLYT\":" + "\"\"," + "\"REQUESTUSER\":" + "\"" 
                                +UtilityVar.trueName + "\"," + "\"REQUESTTIME\":"+ "\"\","+ "\"REQUESTDEPARMENT\":" + "\"" + UtilityVar.departmentName
                                + "\",";

                        Json += "\"DATAEXTENT\":" + "\"{\\\"type\\\":\\\"Feature\\\",\\\"properties\\\":{},\\\"geometry\\\":{\\\"type\\\":\\\""
                                + geoType + "\\\",\\\"coordinates\\\":" + "[[";

                        string strCoord = string.Empty;

                        for (int j = 0; j < CoorList.Count; j++)
                        {

                            strCoord += "[\\\"" + CoorList[j].X.ToString("0.000") + "\\\",\\\"" + CoorList[j].Y.ToString("0.000") + "\\\"],";

                        }

                        strCoord += "[\\\"" + CoorList[0].X.ToString("0.000") + "\\\",\\\"" + CoorList[0].Y.ToString("0.000") + "\\\"]]]}}\"";

                        string JsonEndStr = "}]";

                        Json = Json + strCoord + JsonEndStr;*/

                        //上传范围线使用EseiJson格式，具体格式参考葛亮发来的《对接说明》文档 
                        //-----------------------具体格式内容如下------------------------
                        //-----[{"geometry":{"rings":[[[117522.77204,285078.883975319],[117522.71104,285078.883975319]]]]},
                        //"spatialReference":{"wkid":"32650"},"attributes":{"XMBH":"aa","XMMC":"aa","JDXH":"aa","KSSJ":"2018-10-31","JSSJ":"2018-11-07",
                        //"YZDW":"规划自然资源局","CJDW":"测绘一院","XMLB":"规划工程","XMLX":"规划控制"}}]
                        Json = "[{\"geometry\":{\"rings\":[[";

                        string strCoord1 = string.Empty;

                        for (int j = 0; j < CoorList.Count; j++)
                        {

                            strCoord1 += "[" + CoorList[j].X.ToString("F5") + "," + CoorList[j].Y.ToString("F9") + "],";

                        }

                        strCoord1 += "[" + CoorList[0].X.ToString("F5") + "," + CoorList[0].Y.ToString("F9") + "]]]},";

                        string ConStr = "\"spatialReference\":{\"wkid\":"+"\""+wkid + "\"},"+ "\"attributes\":{\"XMBH\":"+
                                            "\"" + XMBH+"\",\"XMMC\":\""+XMMC+"\",\"JDXH\":\""+JDXH+  "\",\"KSSJ\":\"" +KSSJ+
                                            "\",\"JSSJ\":\""+"\",\"YZDW\":\""+YZDW+"\",\"CJDW\":\""+CJDW + "\",\"XMLB\":\""+
                                            XMLB+"\",\"XMLX\":\""+XMLX + "\"}}]";


                        Json = Json + strCoord1 + ConStr;

                    }
                    else
                    {
                        Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("文件不存在！");
                    }
                   


                    




                    trans.Commit();
                }


              

                return Json;
            }
            catch(Autodesk.AutoCAD.Runtime.Exception ex)
            {
                
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(ex.ErrorStatus.ToString());
                return Json;
               // throw;

            }



        }







    }




}
