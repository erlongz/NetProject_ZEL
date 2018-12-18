using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Reflection;
using MSWord = Microsoft.Office.Interop.Word;



namespace MunicipalEngineering
{
    public partial class ReportGenOneForm : Form
    {
        public ReportGenOneForm()
        {
            InitializeComponent();

            DWZZ1_comboBox.Enabled = false;
            YQ_comboBox.Enabled = false;
            YQH_comboBox.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int JudgeNum = UtilityFun.ReadData();
            MSWord.Document wordDoc;
            string StrCont = "";
            int RitioNum = 0;

            if(CoSZ_radioButton.Checked == true)
            {

                RitioNum = 1;
            }
            else if(QL_radioButton.Checked == true)
            {


                RitioNum = 2;
            }
            else if(LH_radioButton.Checked == true)
            {

                RitioNum = 3;

            }
            else if(GHXZ_radioButton.Checked == true)
            {

                RitioNum = 4;
            }


            string zd_style = "";

            if(SZTD1_radioButton.Checked == true)
            {
                zd_style = "十字铁钉";

            }
            else if(YQBJ_radioButton.Checked == true)
            {
                zd_style = "油漆标记";

            }
            else if(MZGD1_radioButton.Checked == true)
            {

                zd_style = "木桩钢钉";

            }

            UtilityVar.ZD_Style1 = zd_style;

            if(JudgeNum == 0 )
            {

                UtilityFun.sort_data();  //所给数据自动排序 

                wordDoc = UtilityFun.NewDocument();
                //开始写入内容 

                switch(RitioNum)
                {
                    case 1:

                        StrCont = UtilityVar.Str_One1 + SQBH1_textBox.Text.ToString() + UtilityVar.Str_One0;

                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 12, 18, "Left");

                        for(int i=0;i<4;i++)
                        {

                            StrCont = UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 18, "Middle");
                        }

                        StrCont = UtilityVar.Str_One2 + UtilityVar.Str_One0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 22, 18, "Justify");  //放线测量报告 


                        StrCont = UtilityVar.Str_One3 + UtilityVar.Str_One0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 18, "Middle");  //市政工程


                        for (int i = 0; i < 4; i++)
                        {

                            StrCont = UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 18, "Middle");  //四行空行 
                        }

                        StrCont = UtilityVar.Str_One4 ;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 18, "Justify");  //项目名称

                        StrCont = ZLDD1_textBox.Text + UtilityVar.Str_One0; 
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 18, "Justify");  //项目名称

                        StrCont = UtilityVar.Str_One5;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 18, "Justify");  //建设单位

                        StrCont = JSDW1_textBox.Text + UtilityVar.Str_One0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 18, "Justify");  //建设单位

                        StrCont = UtilityVar.Str_One6;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 18, "Justify");  //设计单位

                        StrCont = SJDW1_textBox.Text+ UtilityVar.Str_One0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 18, "Justify");  //设计单位


                       

                        if(CLDW1_comboBox.Text == "测绘一院")
                        {

                            string str1 = "天津市测绘院测绘一院";

                            StrCont = UtilityVar.Str_One7 + str1 + UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //测量单位
                        }
                        else
                        {
                            StrCont = UtilityVar.Str_One7 + CLDW1_comboBox.Text + UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //测量单位

                        }


                        if(DWZZ1_comboBox.Text == "测绘甲级")
                        {

                            string str1 = "国家测绘地理信息局甲级测绘资质";

                            StrCont = UtilityVar.Str_One8 + str1 + UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //单位资质

                        }
                        else if(DWZZ1_comboBox.Text == "测绘乙级")
                        {

                            string str1 = "国家测绘地理信息局乙级测绘资质";

                            StrCont = UtilityVar.Str_One8 + str1 + UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //单位资质

                        }
                        else if(DWZZ1_comboBox.Text == "测绘丙级")
                        {

                            string str1 = "国家测绘地理信息局丙级测绘资质";

                            StrCont = UtilityVar.Str_One8 + str1 + UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //单位资质

                        }
                        else if(DWZZ1_comboBox.Text == "测绘丁级")
                        {

                            string str1 = "国家测绘地理信息局丁级测绘资质";

                            StrCont = UtilityVar.Str_One8 + str1 + UtilityVar.Str_One0;
                            wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //单位资质

                        }


                        StrCont = UtilityVar.Str_One9  + UtilityVar.Str_One0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Justify");  //编制人   审核人  批准人


                        string Date = DateTime.Now.ToLongDateString();

                        StrCont = Date + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 14, 18, "Middle");  //日期 


                        //----------------------------------报告正文-------------------------------------

                        StrCont = UtilityVar.Str_One10 + UtilityVar.Str_One0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 18, 18, "Middle");  //天津市建设工程规划放线测量技术报告

                        StrCont = UtilityVar.Str_One11 + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify"); //一、项目名称 

                        StrCont = ZLDD1_textBox.Text + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //项目名称内容 


                        StrCont = UtilityVar.Str_One12.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //坐落地点 

                        StrCont = ZLDD1_textBox.Text.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //坐落地点内容


                        StrCont = UtilityVar.Str_On13.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //三、作业依据 

                        StrCont = UtilityVar.Str_On14.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //1、

                        StrCont = UtilityVar.Str_On15.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //2、

                        StrCont = UtilityVar.Str_On16.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //3、


                        StrCont = UtilityVar.Str_On17.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //4、


                        StrCont = UtilityVar.Str_On18.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //5、

                        StrCont = UtilityVar.Str_On19.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //6、

                        StrCont = UtilityVar.Str_On20.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //7、


                        StrCont = UtilityVar.Str_On21.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //四、平面控制 

                        StrCont = UtilityVar.Str_On22.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //1、

                        string str = UtilityVar.Str_On23;

                        int iCount = dataGridView1.Rows.Count;

                        
                        
                        for(int i =0; i< iCount; i++)
                        {


                            str = str + UtilityVar.Str_On23_1+ dataGridView1.Rows[i].Cells[0].Value.ToString() + UtilityVar.Str_On23_2+ UtilityVar.Str_On23_3+
                                dataGridView1.Rows[i].Cells[1].Value.ToString() + UtilityVar.Str_On23_2;

                            if(i == iCount -1)
                            {

                                str = str + UtilityVar.Str_On23_1 + dataGridView1.Rows[i].Cells[0].Value.ToString() + UtilityVar.Str_On23_2 + UtilityVar.Str_On23_3 +
                                dataGridView1.Rows[i].Cells[1].Value.ToString() +"。";

                            }
                        }


                        StrCont = str + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //2、

                        StrCont = UtilityVar.Str_On24.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //3、  有问题 


                        StrCont = UtilityVar.Str_One25.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //五、成图方法 

                        StrCont = UtilityVar.Str_One26.ToString() + BLC1_comboBox.Text.ToString() + UtilityVar.Str_One26_1.ToString();
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //成图方法内容 


                        StrCont = UtilityVar.Str_One27.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //六、放桩方法 


                        StrCont = UtilityVar.Str_One28.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //放桩方法内容

                        StrCont = UtilityVar.Str_One29.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //七、放线说明 


                        StrCont = UtilityVar.Str_One30.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //放线说明内容


                        StrCont = UtilityVar.Str_One40.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //八、质量结论

                        StrCont = UtilityVar.Str_One31.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //质量结论内容

                        StrCont = UtilityVar.Str_One32.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 1, 16, 26, "Justify", false); //九、使用须知 

                        StrCont = UtilityVar.Str_One33.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //使用须知内容

                        StrCont = UtilityVar.Str_One34.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", false); //使用须知内容:附件 

                        StrCont = UtilityVar.Str_One35.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //1 

                        StrCont = UtilityVar.Str_One35_1.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //2

                        StrCont = UtilityVar.Str_One36_1.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //3

                        StrCont = UtilityVar.Str_One37_1.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 16, 26, "Justify", true); //4

                      


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




                        StrCont = Date + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 0);

                        StrCont = UtilityVar.Str_One39.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 1);//检查人

                        StrCont = UtilityVar.Str_One38.ToString() + UtilityVar.Str0;
                        wordDoc = UtilityFun.writeContent(wordDoc, StrCont, "仿宋_GB2312", 0, 15, 18, "Justify", true, 16, ParNumTemp - 2); //放线人






                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;

                    default:

                        break;






                }

            }
            else
            {

                return;

            }
        }

        private void CLDW1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            YQ_comboBox.Enabled = true;
            DWZZ1_comboBox.Enabled = true;

            string LibPath = UtilityFun.GetLibPath();

            System.Data.DataTable InfoDT = UtilityFun.GetBaseInfo(LibPath);

            if (InfoDT == null)
            {


                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("BaseInfo信息读取失败");
                return;
            }

            switch(CLDW1_comboBox.Text)
            {

                case "测绘一院":

                    DWZZ1_comboBox.Text = "测绘甲级";

                    break;
                case "天津市中新生态城天测测绘有限公司":

                    DWZZ1_comboBox.Text = "测绘乙级";

                    break;


            }

            //根据测量单位信息，确定各个分院的仪器型号，并加载到YQ_ComboBox.items中 

            System.Data.DataTable YQInfoDT = UtilityFun.GetYQInfo(LibPath, CLDW1_comboBox.Text);

            if (YQInfoDT != null)
            {


                YQ_comboBox.Items.Clear(); //首先清空集合

                var list = YQInfoDT.AsEnumerable().Select(c => c.Field<string>("YQXH")).ToList();

                var source = list.GroupBy(t => t.Trim()).Select(t => new { count = t.Count(), key = t.Key }).ToArray();


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

        private void YQ_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            YQH_comboBox.Enabled = true;
            YQH_comboBox.Items.Clear();
            string LibPath = UtilityFun.GetLibPath();

            if (!string.IsNullOrEmpty(YQ_comboBox.Text))
            {

                System.Data.DataTable YQInfoDT = UtilityFun.GetYQInfo(LibPath, CLDW1_comboBox.Text);

                if (YQInfoDT != null)
                {

                    for (int i = 0; i < YQInfoDT.Rows.Count; i++)
                    {
                        if (YQInfoDT.Rows[i][1].ToString() == YQ_comboBox.Text.ToString())
                        {

                            //YQ_textBox.Text = YQInfoDT.Rows[i][1].ToString();

                            YQH_comboBox.Items.Add(YQInfoDT.Rows[i][2].ToString());

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

        private void ADDYQ_button_Click(object sender, EventArgs e)
        {
           
                     
            if(!string.IsNullOrEmpty(YQ_comboBox.Text)&& !string.IsNullOrEmpty(YQH_comboBox.Text))
            {

                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = YQ_comboBox.Text;
                this.dataGridView1.Rows[index].Cells[1].Value = YQH_comboBox.Text;
            }
            else
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("仪器或仪器号为空，请重新选择！");
                return;

            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void Del_button_Click(object sender, EventArgs e)
        {
          try
          {
                int iCount =this. dataGridView1.SelectedRows.Count;

                if (iCount < 1)
                {
                   
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("删除数据失败！");
                    return;
                }


                for(int i =0; i<dataGridView1.Rows.Count-1; i++)
                {


                    if(this.dataGridView1.Rows[i].Selected == true)
                    {

                        this.dataGridView1.Rows.RemoveAt(i);
                    }
                }

            }
            catch (Exception ex)
          {

                MessageBox.Show(ex.Message);


           }
        }
    }
}
