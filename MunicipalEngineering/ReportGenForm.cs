using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using System.Reflection;
using MSWord = Microsoft.Office.Interop.Word;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;
using System.Text.RegularExpressions;

namespace MunicipalEngineering
{

   
    public partial class ReportGenForm : Form
    {
        const string  BZRINIPath = @"C:\app2016\SZFX\BZRConf.ini";  //用于存储用户编写的历史编制人；

        IniFile inifile = new IniFile(BZRINIPath);

        public ReportGenForm()
        {
            InitializeComponent();

            List<string> BZRList = new List<string>();

           

            //初始化编制人信息 
            //ArrayList Ali = new ArrayList();

            if(File.Exists(BZRINIPath))
            {


                string[] str = inifile.GetKeyNames("BZRINFO");

                foreach (string str1 in str)
                {

                    BZRList.Add(inifile.GetString("BZRINFO", str1));

                }



                if (BZRList.Count > 4)
                {
                    for (int i = 0; i < 4; i++)
                    {

                        BZR_comboBox.Items.Add(BZRList[BZRList.Count - 1 - i]);

                    }


                }
                else
                {
                    for (int i = 0; i < BZRList.Count; i++)
                    {

                        BZR_comboBox.Items.Add(BZRList[BZRList.Count - 1 - i]);

                    }

                }
                /*  StreamReader sr = new StreamReader(BZRINIPath, true);
                  while (sr.Peek()>0)
                  {


                      Ali.Add(sr.ReadLine());
                  }

                  //至多保留四个编制人在ComBox中 

                 if(Ali.Count >4)
                  {
                      for(int i =0; i<4;i++)
                      {

                          BZR_comboBox.Items.Add(Ali[Ali.Count-1-i]);

                      }


                  }
                 else
                  {
                      for (int i = 0; i < Ali.Count; i++)
                      {

                          BZR_comboBox.Items.Add(Ali[Ali.Count - 1 - i]);

                      }

                  }

                  sr.Close();*/

                // BZR_comboBox.Text = (string)BZR_comboBox.Items[0];
            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("指定路径下不存在*.INI文件！");
                return;
            }

            

            SQBH_textBox.Text = "";
            XMMC_textBox.Text = "";
            SJDW_textBox.Text = "";
            JSDW_textBox.Text = "";
           

            SHR_textBox.Enabled = false;
            PZR_textBox.Enabled = false;
            ZLDD_textBox.Text = "";
            ZYYJ_textBox.Text = "";
           // YQ_textBox.Enabled =false;
           
            KZD_textBox.Text = "";
            CTFF_textBox.Text = "";
            FXSM_textBox.Text = "由于施工方现场跟桩，未绘制点之记。";

            SZTD_radioButton.Checked = true;

            YQBH_comboBox.Enabled = false;
            YQ_comboBox.Enabled = false;
            

        }

        private void GENRep_button_Click(object sender, EventArgs e)
        {
           
            int JudgeNum = UtilityFun.ReadData();
            MSWord.Document wordDoc;
            string StrCont = "";
            int RitioNum = 0;




            if (GDGC_radioButton.Checked == true)
            {
                RitioNum = 1;  //供电工程
            }
            else if (TXGC_radioButton.Checked == true)
            {
                RitioNum = 2;  //通信工程
            }
            else if (PSGC_radioButton.Checked == true)
            {
                RitioNum = 3; //排水工程
            }
            else if (GSGC_radioButton.Checked == true)
            {
                RitioNum = 4;//给水工程
            }
            else if (RQGC_radioButton.Checked == true)
            {
                RitioNum = 5;//天然气工程
            }
            else if(GRGC_radioButton.Checked == true)
            {
                RitioNum = 6;//供热工程;
            }
            else if (DLGC_radioButton.Checked == true)
            {
                RitioNum = 7;//道路工程
            }
            else
            {
                RitioNum = 8;//桥梁工程
            }

            string zd_style = "";


            if (SZTD_radioButton.Checked == true)
            {
                zd_style = "十字铁钉";

            }

            if (MZ_radioButton.Checked == true)
            {
                zd_style = "木桩";
            }

            if (GangD_radioButton.Checked == true)
            {
                zd_style = "钢钉";
            }

            if(YQBJ_radioButton.Checked == true)
            {


                zd_style = "油漆标记";
            }

            UtilityVar.ZD_Style1 = zd_style;

            if (JudgeNum == 0)
            {

                UtilityFun.Gen_Rand();   //产生随机数并生成随机坐标

                UtilityFun.ReadDataFCZB();  //读取复测坐标文件 

                //检核两个文件中文件名是否一致 

                if(UtilityVar.NameList.SequenceEqual(UtilityVar.NameList_FC))

                {
                   

                    //生成理论坐标与复测坐标差值 

                   for (int i = 0; i< UtilityVar.NameList.Count;i++)
                    {


                        double diff_Rand = Math.Sqrt((UtilityVar.XRandList[i] - UtilityVar.XList[i]) * (UtilityVar.XRandList[i] - UtilityVar.XList[i]) +
                          (UtilityVar.YRandList[i] - UtilityVar.YList[i]) * (UtilityVar.YRandList[i] - UtilityVar.YList[i]));
                        UtilityVar.DiffRandList.Add(diff_Rand);

                    }

                }
                else
                {

                   // MessageBox.Show("请检查理论坐标文件与复测坐标文件是否一致");
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请检查理论坐标文件与复测坐标文件是否一致");
                    return;
                }







                UtilityFun.sort_data();

                wordDoc = UtilityFun.NewDocument();
                //开始写入内容 

                switch (RitioNum)
                {
                    case 1:

                    case 2:

                    case 3:

                    case 4:

                    case 5:

                    case 6:

                         StrCont = UtilityVar.Str1 + SQBH_textBox.Text.ToString()+UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont,"宋体",0,12,18,"Left");
                         StrCont = UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 1, 22, 18, "Middle");
                         StrCont = UtilityVar.Str2 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 1, 22, 18, "Middle");
                         StrCont = UtilityVar.Str3+UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle");

                         //int ParNum =  wordDoc.Paragraphs.Count;
                         float Begin_X,Begin_Y,End_X,End_Y;
                         Begin_X = (float)UtilityFun.CenToPts(0.0);
                         Begin_Y = (float)UtilityFun.CenToPts(0.0);
                         End_X =(float)UtilityFun.CenToPts(14.61);
                         End_Y = (float)UtilityFun.CenToPts(0.0);

                         //object Anchor1 = wordDoc.Paragraphs[ParNum].Range ;
                         object Anchor = wordDoc.Paragraphs.Last.Range;

                         for (int i = 0; i < 10; i++)
                         {

                             StrCont = UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle");
                         }

                         StrCont = UtilityVar.Str4 + XMMC_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str5 + JSDW_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str6 + SJDW_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                        int ParNum1 = wordDoc.Paragraphs.Count;

                        object Anchor2 = wordDoc.Paragraphs[ParNum1].Range ;

                         //StrCont = UtilityVar.Str7  + UtilityVar.Str0;
                         StrCont = UtilityVar.Str7_1 + CLDW_comboBox.Text + UtilityVar.Str7_2 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str8  + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str9_1 + BZR_comboBox.Text + UtilityVar.Str9_2 + SHR_textBox.Text + UtilityVar.Str9_3 + PZR_textBox.Text  + UtilityVar.Str0; //有所改动
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         string Date = DateTime.Now.ToLongDateString();

                         StrCont = Date + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle"); 
                         
                         StrCont = UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle"); 
                        //------------------------------------------------报告正文---------------------------------------
                         StrCont = UtilityVar.Str10 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 1, 18, 18, "Middle");

                         StrCont = UtilityVar.Str11 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify");

                         StrCont = XMMC_textBox.Text + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str12.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify",false);

                         StrCont = ZLDD_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str13.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str14.ToString() + ZYYJ_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str15 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                        
                         StrCont = UtilityVar.Str16 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str17 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str18 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str19_1 + YQ_comboBox.Text.ToString() + UtilityVar.Str19_2 +YQBH_comboBox.Text.ToString() + UtilityVar.Str19_3 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str20 + KZD_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str21 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);


                         if (DZJ_checkBox.Checked == true )
                         {
                             StrCont = UtilityVar.Str22 + CTFF_textBox.Text.ToString() + UtilityVar.Str23 + UtilityVar.Str23_00 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                         }
                         else
                         {
                             StrCont = UtilityVar.Str22 + CTFF_textBox.Text.ToString() + UtilityVar.Str23 + UtilityVar.Str23_0 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                         }

                        

                         StrCont = UtilityVar.Str24 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str25 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str26 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = FXSM_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str27 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str28 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str29 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str30 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str31 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str32 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str33 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         if (DZJ_checkBox.Checked == true)
                         {
                             StrCont = UtilityVar.Str34 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                             StrCont = UtilityVar.Str36 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                         }
                         else
                         {
                             StrCont = UtilityVar.Str35 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                         }

                         
                         //计算Word文档的页数

                         MSWord.WdStatistic stat = MSWord.WdStatistic.wdStatisticPages;
                         //MSWord.WdStatistic statPar = MSWord.WdStatistic.wdStatisticParagraphs;

                         Object Nothing = Missing.Value;

                         int PageNum = wordDoc.ComputeStatistics(stat, ref Nothing);  //页数统计  
                         int ParNum = wordDoc.Paragraphs.Count;//段落统计 
                         int TempPageNum = PageNum;
                         int ParNumTemp = 0;

                         while (TempPageNum < PageNum + 1)
                         {
                             //StrCont =  UtilityVar.Str0;
                            // wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify", true);
                             wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();
                             TempPageNum = wordDoc.ComputeStatistics(stat, ref Nothing);  //页数统计  

                             ParNumTemp = wordDoc.Paragraphs.Count;
                         }

                        /* if (ParNumTemp - 3 <= ParNum)
                         {
                             StrCont = UtilityVar.Str39 +Date+ UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 0,ParNum);

                         }
                         else
                         {
                             StrCont = Date + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 1);

                             StrCont = UtilityVar.Str38 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 2);

                             StrCont = UtilityVar.Str37 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16,ParNumTemp-3);
                            
                         }*/


                             StrCont = Date + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 0);

                             StrCont = UtilityVar.Str38 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 1);

                             StrCont = UtilityVar.Str37 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16,ParNumTemp-2);

                         //插入表格《放线点坐标成果表》
                         //object Rng = wordDoc.Paragraphs.Last.Range;

                         int Sta_Num = UtilityVar.NameList.Count;
                         int Tab_Num = Convert.ToInt16(Math.Floor(Convert.ToDouble(Sta_Num / 19))) + 1;

                         int Tab_Num2 = Convert.ToInt16(Math.Floor(Convert.ToDouble(Sta_Num / 21))) + 1;

                         if (Tab_Num == 1)
                         {
                             
                             
                             wordDoc = UtilityFun.CreatTable(wordDoc, 5, 21, Sta_Num , Tab_Num);

                             wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23, Sta_Num, Tab_Num);
                         }
                         else
                         {
                             for (int i = 1; i < Tab_Num + 1; i++)
                             {

                                 if (i == Tab_Num)
                                 {
                                    
                                   
                                     wordDoc = UtilityFun.CreatTable(wordDoc, 5, 21, Sta_Num - 19 * (Tab_Num - 1), i);

                                     if (Tab_Num2 == 1)
                                     {
                                         wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23,Sta_Num,Tab_Num2);
                                     }
                                     else
                                     {
                                         for (int j = 1; j < Tab_Num2 + 1; j++)
                                         {
                                             if (j == Tab_Num2)
                                             {
                                                 wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23, Sta_Num - 21 * (Tab_Num2 - 1), j);

                                             }
                                             else
                                             {
                                                 wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23, 21, j);
                                             }
                                         }
                                     }
                                     
                                    
                                 }
                                 else
                                 {
                                     
                                     wordDoc = UtilityFun.CreatTable(wordDoc, 5, 21, 19, i);
                                     
                                 }
                             }
                         }



                             



                        //未封面添加黑色线段
                         MSWord.Shape NewLine = wordDoc.Shapes.AddLine(Begin_X, Begin_Y, End_X, End_Y,ref Anchor);

                         NewLine.Line.Weight = 1.5f;

                         MSWord.Shape NewLine1 = wordDoc.Shapes.AddLine(Begin_X, Begin_Y, End_X, End_Y, ref Anchor2);

                         NewLine1.Line.Weight = 1.5f;

                        //插入页码

                         UtilityFun.Insert_Page(wordDoc);

                        break;
                    case 7:
                         StrCont = UtilityVar.Str1 + SQBH_textBox.Text.ToString()+UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont,"宋体",0,14,18,"Left");
                         StrCont = UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 1, 22, 18, "Middle");
                         StrCont = UtilityVar.Str2 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 1, 22, 18, "Middle");
                         StrCont = UtilityVar.Str3+UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle");

                         //int ParNum =  wordDoc.Paragraphs.Count;
                         //float Begin_X,Begin_Y,End_X,End_Y;
                         Begin_X = (float)UtilityFun.CenToPts(0.0);
                         Begin_Y = (float)UtilityFun.CenToPts(0.0);
                         End_X =(float)UtilityFun.CenToPts(14.61);
                         End_Y = (float)UtilityFun.CenToPts(0.0);

                         //object Anchor1 = wordDoc.Paragraphs[ParNum].Range ;
                         Anchor = wordDoc.Paragraphs.Last.Range;

                         for (int i = 0; i < 10; i++)
                         {

                             StrCont = UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle");
                         }

                         StrCont = UtilityVar.Str4 + XMMC_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str5 + JSDW_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str6 + SJDW_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         ParNum1 = wordDoc.Paragraphs.Count;

                         Anchor2 = wordDoc.Paragraphs[ParNum1].Range ;

                         StrCont = UtilityVar.Str7  + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str8  + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         StrCont = UtilityVar.Str9  + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Justify");

                         Date = DateTime.Now.ToLongDateString();

                         StrCont = Date + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle"); 
                         
                         StrCont = UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 0, 16, 18, "Middle"); 
                        //------------------------------------------------报告正文---------------------------------------
                         StrCont = UtilityVar.Str10 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "宋体", 1, 18, 18, "Middle");

                         StrCont = UtilityVar.Str11 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify");

                         StrCont = XMMC_textBox.Text + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str12.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify",false);

                         StrCont = ZLDD_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str13.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str14.ToString() + ZYYJ_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str15 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                        
                         StrCont = UtilityVar.Str16 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str17 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str18 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str19_1 + YQ_comboBox.Text.ToString() + UtilityVar.Str19_2 + YQBH_comboBox.Text.ToString() + UtilityVar.Str19_3 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str20 + KZD_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str21 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str22 + CTFF_textBox.Text.ToString()+ UtilityVar.Str23_1 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str24 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str25 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str26 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = FXSM_textBox.Text.ToString() + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str27 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str28 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str29 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 12, "Justify", false);

                         StrCont = UtilityVar.Str30 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str31 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str32 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         StrCont = UtilityVar.Str33 + UtilityVar.Str0;
                         wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                         if (DZJ_checkBox.Checked == true)
                         {
                             StrCont = UtilityVar.Str34 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);

                             StrCont = UtilityVar.Str36 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                         }
                         else
                         {
                             StrCont = UtilityVar.Str35 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true);
                         }

                         
                         //计算Word文档的页数

                         stat = MSWord.WdStatistic.wdStatisticPages;
                         //MSWord.WdStatistic statPar = MSWord.WdStatistic.wdStatisticParagraphs;

                         Nothing = Missing.Value;

                         PageNum = wordDoc.ComputeStatistics(stat, ref Nothing);  //页数统计  
                         ParNum = wordDoc.Paragraphs.Count;//段落统计 
                         TempPageNum = PageNum;
                         ParNumTemp = 0;

                         while (TempPageNum < PageNum + 1)
                         {
                             //StrCont =  UtilityVar.Str0;
                            // wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify", true);
                             wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();
                             TempPageNum = wordDoc.ComputeStatistics(stat, ref Nothing);  //页数统计  

                             ParNumTemp = wordDoc.Paragraphs.Count;
                         }

                         if (ParNumTemp - 3 <= ParNum)
                         {
                             StrCont = UtilityVar.Str39 +Date+ UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 0,ParNum);

                         }
                         else
                         {
                             StrCont = Date + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 1);

                             StrCont = UtilityVar.Str38 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 2);

                             StrCont = UtilityVar.Str37 + UtilityVar.Str0;
                             wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16,ParNumTemp-3);
                            
                         }

                         //插入表格《放线点坐标成果表》
                         //object Rng = wordDoc.Paragraphs.Last.Range;

                          Sta_Num = UtilityVar.NameList.Count;
                          Tab_Num = Convert.ToInt16(Math.Floor(Convert.ToDouble(Sta_Num / 19))) + 1;

                         Tab_Num2 = Convert.ToInt16(Math.Floor(Convert.ToDouble(Sta_Num / 21))) + 1;

                         if (Tab_Num == 1)
                         {
                             
                             
                             wordDoc = UtilityFun.CreatTable(wordDoc, 5, 21, Sta_Num , Tab_Num);

                             wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23, Sta_Num, Tab_Num);
                         }
                         else
                         {
                             for (int i = 1; i < Tab_Num + 1; i++)
                             {

                                 if (i == Tab_Num)
                                 {
                                    
                                   
                                     wordDoc = UtilityFun.CreatTable(wordDoc, 5, 21, Sta_Num - 19 * (Tab_Num - 1), i);

                                     if (Tab_Num2 == 1)
                                     {
                                         wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23,Sta_Num,Tab_Num2);
                                     }
                                     else
                                     {
                                         for (int j = 1; j < Tab_Num2 + 1; j++)
                                         {
                                             if (j == Tab_Num2)
                                             {
                                                 wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23, Sta_Num - 21 * (Tab_Num2 - 1), j);

                                             }
                                             else
                                             {
                                                 wordDoc = UtilityFun.CreatTable2(wordDoc, 6, 23, 21, j);
                                             }
                                         }
                                     }
                                     
                                    
                                 }
                                 else
                                 {
                                     
                                     wordDoc = UtilityFun.CreatTable(wordDoc, 5, 21, 19, i);
                                     
                                 }
                             }
                         }



                             



                        //未封面添加黑色线段
                         NewLine = wordDoc.Shapes.AddLine(Begin_X, Begin_Y, End_X, End_Y,ref Anchor);

                         NewLine.Line.Weight = 1.5f;

                        NewLine1 = wordDoc.Shapes.AddLine(Begin_X, Begin_Y, End_X, End_Y, ref Anchor2);

                         NewLine1.Line.Weight = 1.5f;

                        //插入页码

                         UtilityFun.Insert_Page(wordDoc);
                        break;
                        
                    case 8:
                        break;
                }

                UtilityFun.docSaveAs(wordDoc);

                UtilityVar.ArraryList.Clear();
                UtilityVar.ArraryList_KZD.Clear();
                UtilityVar.NameList.Clear();
                UtilityVar.NameList_KZD.Clear();
                UtilityVar.DiffRandList.Clear();
                UtilityVar.XRandList.Clear();
                UtilityVar.YRandList.Clear();
                UtilityVar.XList.Clear();
                UtilityVar.YList.Clear();
                UtilityVar.XList_KZD.Clear();
                UtilityVar.YList_KZD.Clear();
                UtilityVar.ArraryList_FC.Clear();
                UtilityVar.NameList_FC.Clear();


            }
            else
            {
                return;
            }


            IniFile file1 = new IniFile(BZRINIPath);

            List<string> BZRList1 = new List<string>();

            string[] str = null;
            if (File.Exists(BZRINIPath))
            {


                 str = file1.GetKeyNames("BZRINFO");

                foreach (string str1 in str)
                {

                    BZRList1.Add(file1.GetString("BZRINFO", str1));

                }
            }

            if(BZRList1.Contains(BZR_comboBox.Text) && !string.IsNullOrEmpty(BZR_comboBox.Text))
            {

               for(int i = 0;i<BZRList1.Count;i++)
                {



                    if(BZRList1[i].ToString() == BZR_comboBox.Text)
                    {


                        BZRList1.RemoveAt(i);
                       

                    }

                    file1.DeleteKey("BZRINFO", str[i]);

                }

                for (int j = 0; j < BZRList1.Count; j++)
                {

                    file1.SetValue("BZRINFO", "BZR" + (j + 1).ToString(), BZRList1[j]);

                }
            }



            file1.SetValue("BZRINFO", "BZR" + (str.Length+1).ToString(), BZR_comboBox.Text);










            //  int flagIni = 0;
            // string BZRINIPath = @"C:\2016app\SZFX\BZRConf.ini";


            /*   ArrayList Lines = new ArrayList();
           StreamReader reader = new StreamReader(BZRINIPath);

           while(reader.Peek()>0)
           {

               Lines.Add(reader.ReadLine());
           }

          // string text = reader.ReadToEnd();

            reader.Close();

          // string[] textlines = Regex.Split(text, Environment.NewLine);
          // StringBuilder str = new StringBuilder();

           if(Lines.Contains(BZR_comboBox.Text)&& !string.IsNullOrEmpty(BZR_comboBox.Text))
           {
               for (int i = 0; i < Lines.Count; i++)
               {
                   if (Lines[i].ToString() == BZR_comboBox.Text)

                   {
                       Lines.RemoveAt(i);


                   }
                   else
                   {
                       continue;

                   }



               }




               StreamWriter writer = new StreamWriter(BZRINIPath,false);
               for(int j = 0; j<Lines.Count;j++)
               {

                   writer.WriteLine(Lines[j].ToString());
               }
               writer.Close();





           }


               StreamWriter sw = new StreamWriter(BZRINIPath, true);
               sw.WriteLine(BZR_comboBox.Text);              
               sw.Close();*/










        }

        private void CLDW_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            //根据测量单位信息，读取各个分院审核人，批准人信息 
            YQ_comboBox.Enabled = true;
            string LibPath = UtilityFun.GetLibPath();

            System.Data.DataTable InfoDT = UtilityFun.GetBaseInfo(LibPath);

            if(InfoDT == null)
            {


                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("BaseInfo信息读取失败");
                return;
            }

            switch (CLDW_comboBox.Text)
            {
                case "测绘一院":

                    for(int i = 0; i<InfoDT.Rows.Count; i++)
                    {

                        if(CLDW_comboBox.Text  == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }
                       

                    break;

                case "滨海分院":
                    for (int i = 0; i < InfoDT.Rows.Count; i++)
                    {

                        if (CLDW_comboBox.Text == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }

                    break;

                case "测绘三院":
                    for (int i = 0; i < InfoDT.Rows.Count; i++)
                    {

                        if (CLDW_comboBox.Text == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }

                    break;

                case "测绘四院":
                    for (int i = 0; i < InfoDT.Rows.Count; i++)
                    {

                        if (CLDW_comboBox.Text == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }

                    break;
                case "测绘八院":
                    for (int i = 0; i < InfoDT.Rows.Count; i++)
                    {

                        if (CLDW_comboBox.Text == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }

                    break;
                case "基础测绘院":
                    for (int i = 0; i < InfoDT.Rows.Count; i++)
                    {

                        if (CLDW_comboBox.Text == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }

                    break;
                case "海洋分院":
                    for (int i = 0; i < InfoDT.Rows.Count; i++)
                    {

                        if (CLDW_comboBox.Text == InfoDT.Rows[i][0].ToString())
                        {

                            SHR_textBox.Text = InfoDT.Rows[i][1].ToString();

                            PZR_textBox.Text = InfoDT.Rows[i][2].ToString();
                        }


                    }

                    break;

                default:


                    break;

            }


            //根据测量单位信息，确定各个分院的仪器型号，并加载到YQ_ComboBox.items中 

            System.Data.DataTable YQInfoDT = UtilityFun.GetYQInfo(LibPath, CLDW_comboBox.Text);

            if(YQInfoDT !=null)
            {
                  

                YQ_comboBox.Items.Clear(); //首先清空集合

                var list = YQInfoDT.AsEnumerable().Select(c => c.Field<string>("YQXH")).ToList();

                var source = list.GroupBy(t => t.Trim()).Select(t => new { count = t.Count(), key = t.Key }).ToArray();

              /*  for (int k = 0; k < YQInfoDT.Rows.Count; k++)
                {

                    YQBH_comboBox.Items.Add(YQInfoDT.Rows[k][2]);

                }*/

                foreach (var s in source)
                {

                    YQ_comboBox.Items.Add(s.key);

                }

            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("仪器信息读取失败，请检查数据库！");
                return;

            }

           
            



        }
        /// <summary>
        /// 通过选择仪器编号的值，确定仪器型号；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YQBH_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* string LibPath = UtilityFun.GetLibPath();
            System.Data.DataTable YQInfoDT = UtilityFun.GetYQInfo(LibPath, CLDW_comboBox.Text);

            if (YQInfoDT != null)
            {

                for(int i = 0; i<YQInfoDT.Rows.Count; i++)
                {
                    if(YQInfoDT.Rows[i][2].ToString()==YQBH_comboBox.Text.ToString())
                    {

                        //YQ_textBox.Text = YQInfoDT.Rows[i][1].ToString();

                    }

                    continue;

                }
                

            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("仪器信息读取失败，请检查数据库！");
                return;

            }*/

        }

        private void DZJ_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(DZJ_checkBox.Checked == true)
            {


                FXSM_textBox.Text = "";

            }
            else
            {
                FXSM_textBox.Text = "由于施工方现场跟桩，未绘制点之记。";

            }
        }

        private void YQ_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            YQBH_comboBox.Enabled = true;
            string LibPath = UtilityFun.GetLibPath();
            
            if (  !string.IsNullOrEmpty(YQ_comboBox.Text))
            {

                System.Data.DataTable YQInfoDT = UtilityFun.GetYQInfo(LibPath, CLDW_comboBox.Text);

                if (YQInfoDT != null)
                {

                    for (int i = 0; i < YQInfoDT.Rows.Count; i++)
                    {
                        if (YQInfoDT.Rows[i][1].ToString() == YQ_comboBox.Text.ToString())
                        {

                            //YQ_textBox.Text = YQInfoDT.Rows[i][1].ToString();

                            YQBH_comboBox.Items.Add(YQInfoDT.Rows[i][2].ToString());

                        }

                        

                    }


                }
                else
                {

                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("仪器信息读取失败，请检查数据库！");
                    return;

                }
                
            }
        }

        /// <summary>
        /// 作业依据的文字内容投射到成图方法中去,内容是否一致还需看最终模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZYYJ_textBox_TextChanged(object sender, EventArgs e)
        {

            CTFF_textBox.Text= ZYYJ_textBox.Text ;
        }
    }
}
