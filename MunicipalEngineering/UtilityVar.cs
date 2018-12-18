using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSWord = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace MunicipalEngineering
{
   public static class UtilityVar
    {

        //登录信息变量 

        public static string logMsg = string.Empty;

        public static bool isLogSuccess = false;

        public static bool isWriteMDataSuccess = false;

        public static string trueName = string.Empty;
        public static string departmentName = string.Empty;

        public static string SZGuid = string.Empty;
        //检查工程全局变量
        public static bool isCheckPrjSuccess = false;
        public static string CheckFileName = string.Empty;

        //登录状态变量 
        public static int PrjStatus = 0;

        //新建工程变量 
        public static bool isPrjCreate = false;

        //市政工程报告常变量
        private static string T_Str0 = "\n";
        private static string T_Str1 = "建设工程设计方案（市政工程）申请编号:";
        private static string T_Str2 = "天津市建设工程规划放线测量技术报告";

        private static string T_Str3 = "市政工程";
        private static string T_Str4 = "项目名称:";
        private static string T_Str5 = "建设单位:";
        private static string T_Str6 = "设计单位:";
        private static string T_Str7 = "测量单位：天津市测绘院测绘四院（公章）";
        private static string T_Str7_1 = "测量单位：天津市测绘院";
        private static string T_Str7_2 = "（公章）";
        private static string T_Str8 = "单位资质：国家测绘局甲级测绘资质证书";
        private static string T_Str9 = "编制人:范亚男     审核人:刘恩利      批准人:黎慕韩";

        private static string T_Str9_1 = "编制人:";
        private static string T_Str9_2 = "     审核人:";
        private static string T_Str9_3 = "      批准人:";

        private static string T_Str10 = "市政工程规划放线测量技术报告";

        private static string T_Str11 = "一、项目名称";
        private static string T_Str12 = "二、坐落地点";
        private static string T_Str13 = "三、作业依据";
        private static string T_Str14 = "（一）城乡规划主管部门审批的建设工程方案审定通知书、附图和";
        private static string T_Str15 = "（二）《天津市市政工程规划放线测量技术规程》。";
        private static string T_Str16 = "（三）《城市测量规范》CJJ／T 8-2011。";
        private static string T_Str17 = "四、平面依据";
        private static string T_Str18 = "（一）坐标系统：采用1990年天津市任意直角坐标系。";
        private static string T_Str19 = "（二）仪器：Trimble-R8，仪器号：5152479936。";
        private static string T_Str19_1 = "（二）仪器：";
        private static string T_Str19_2 = "，仪器号：";
        private static string T_Str19_3 = "。";
        private static string T_Str20 = "（三）已知控制点：";
        private static string T_Str20_1 = "，见《控制点坐标成果表》。";
        private static string T_Str21 = "五、成图方法";
        private static string T_Str22 = "根据甲方提供的建设工程设计方案审定通知书、";
        private static string T_Str23 = "，利用测绘院基础地理信息采集编辑系统采集管线各特征点坐标，见《放线点坐标成果表》。同时利用该系统绘制放线总平面图";
        private static string T_Str23_0 = "。";
        private static string T_Str23_00 = "和放线点点之记。";
        private static string T_Str23_1 = "，利用测绘院基础地理信息采集编辑系统采集道路规划中心桩坐标，见《放线点坐标成果表》。同时利用该系统绘制放线点之记和放线总平面图。";
        private static string T_Str23_2 = "，利用测绘院基础地理信息采集编辑系统采集桥墩底座轴线中心点坐标，见《放线点坐标成果表》。同时利用该系统绘制放线点之记和放线总平面图。";
        private static string T_Str24 = "六、放桩方法";
        private static string T_Str25 = "以附近区域内的GPS网进行点校正，利用Trimble-R10直接在现场钉桩。钉桩后，利用RTK测量所定位的桩点坐标进行检测，见《放线成果数值对比表》。";
        private static string T_Str25_1 = "利用本区域内的已有E级静态控制点，用Leica TC1102全站仪设站使用极坐标法直接在现场钉桩。钉桩后，再通过不同设站点进行检测，见《放线成果数值对比表》。";
        private static string T_Str26 = "七、放线说明";
        private static string T_Str27 = "八、质量结论";
        private static string T_Str28 = "规划定位后，经检查人员使用Leica TC1102全站仪重新设站检查，点位精度符合《城市测量规范》第9.3.9款中的有关规定的要求，可交付甲方使用。";
        private static string T_Str29 = "九、使用须知";
        private static string T_Str30 = "本产品交付甲方后，只作为申报《建设工程规划许可证》（市政工程）立案要件之一，须经城乡规划主管部门核发《建设工程规划许可证》后方可开工。";
        private static string T_Str31 = "附件：";
        private static string T_Str32 = "1、放线点坐标成果表";
        private static string T_Str33 = "2、放线成果数值对比表";
        private static string T_Str34 = "3、放线点点之记";
        private static string T_Str35 = "3、放线总平面图";
        private static string T_Str36 = "4、放线总平面图";

        private static string T_Str37 = "放线人：郑二龙";
        private static string T_Str38 = "检查人：";

        private static string T_Str39 = "放线人:郑二龙      检查人:刘恩利      ";
        private static string T_Str40 = "放线点坐标成果表";
        private static string T_Str41 = "放线成果数值对比表";
        private static string T_Str42 = "控制点坐标成果表";


        public static string ZD_Style1 = "十字铁钉";







        public static string Str0
        {
            get { return T_Str0; }
        }

        public static string Str1
        {
            get { return T_Str1; }
        }

        public static string Str2
        {
            get { return T_Str2; }

        }

        public static string Str3
        {
            get { return T_Str3; }
        }

        public static string Str4
        {
            get { return T_Str4; }
        }

        public static string Str5
        {
            get { return T_Str5; }
        }

        public static string Str6
        {
            get { return T_Str6; }
        }

        public static string Str7
        {
            get { return T_Str7; }
        }


        public static string Str7_1
        {
            get { return T_Str7_1; }
        }

        public static string Str7_2
        {
            get { return T_Str7_2; }
        }

        public static string Str8
        {
            get { return T_Str8; }
        }

        public static string Str9
        {
            get { return T_Str9; }
        }

        public static string Str9_1
        {
            get { return T_Str9_1; }
        }

        public static string Str9_2
        {
            get { return T_Str9_2; }
        }

        public static string Str9_3
        {
            get { return T_Str9_3; }
        }

        public static string Str10
        {
            get { return T_Str10; }
        }

        public static string Str11
        {
            get { return T_Str11; }
        }

        public static string Str12
        {
            get { return T_Str12; }
        }

        public static string Str13
        {
            get { return T_Str13; }
        }

        public static string Str14
        {
            get { return T_Str14; }
        }

        public static string Str15
        {
            get { return T_Str15; }
        }

        public static string Str16
        {
            get { return T_Str16; }
        }
        public static string Str17
        {
            get { return T_Str17; }
        }
        public static string Str18
        {
            get { return T_Str18; }
        }
        public static string Str19
        {
            get { return T_Str19; }
        }
        public static string Str19_1
        {
            get { return T_Str19_1; }
        }
        public static string Str19_2
        {
            get { return T_Str19_2; }
        }
        public static string Str19_3
        {
            get { return T_Str19_3; }
        }
        public static string Str20
        {
            get { return T_Str20; }
        }

        public static string Str20_1
        {
            get { return T_Str20_1; }
        }
        public static string Str21
        {
            get { return T_Str21; }
        }
        public static string Str22
        {
            get { return T_Str22; }
        }
        public static string Str23
        {
            get { return T_Str23; }
        }

        public static string Str23_1
        {
            get { return T_Str23_1; }
        }

        public static string Str23_2
        {
            get { return T_Str23_2; }
        }

        public static string Str24
        {
            get { return T_Str24; }
        }
        public static string Str25
        {
            get { return T_Str25; }
        }

        public static string Str25_1
        {
            get { return T_Str25_1; }
        }
        public static string Str26
        {
            get { return T_Str26; }
        }
        public static string Str27
        {
            get { return T_Str27; }
        }
        public static string Str28
        {
            get { return T_Str28; }
        }
        public static string Str29
        {
            get { return T_Str29; }
        }
        public static string Str30
        {
            get { return T_Str30; }
        }

        public static string Str31
        {
            get { return T_Str31; }
        }

        public static string Str32
        {
            get { return T_Str32; }
        }

        public static string Str33
        {
            get { return T_Str33; }
        }
        public static string Str34
        {
            get { return T_Str34; }
        }
        public static string Str35
        {
            get { return T_Str35; }
        }
        public static string Str36
        {
            get { return T_Str36; }
        }
        public static string Str37
        {
            get { return T_Str37; }
        }
        public static string Str38
        {
            get { return T_Str38; }
        }

        public static string Str39
        {
            get { return T_Str39; }
        }

        public static string Str40
        {
            get { return T_Str40; }
        }

        public static string Str41
        {
            get { return T_Str41; }
        }

        public static string Str42
        {
            get { return T_Str42; }
        }

        public static string Str23_0
        {
            get { return T_Str23_0; }
        }


        public static string Str23_00
        {
            get { return T_Str23_00; }
        }




        ////////设定全局变量 
        public static List<string[]> ArraryList = new List<string[]>();
        public static List<string> NameList = new List<string>();
        public static List<double> XList = new List<double>();
        public static List<double> YList = new List<double>();


        public static List<string[]> ArraryList_FC = new List<string[]>();
        public static List<double> XRandList = new List<double>();
        public static List<double> YRandList = new List<double>();
        public static List<double> DiffRandList = new List<double>();
        public static List<string> NameList_FC = new List<string>();

        public static List<string[]> ArraryList_KZD = new List<string[]>();
        public static List<string> NameList_KZD = new List<string>();
        public static List<double> XList_KZD = new List<double>();
        public static List<double> YList_KZD = new List<double>();

        public static string FileNameFullPath = string.Empty;

        //-------------------测绘一院报告文档常量---------------------------------------
        private static string T_Str_One0 = "\n";
        private static string T_Str_One1 = "建设工程设计方案（市政工程）申请编号:";
        private static string T_Str_One2 = "天津市建设工程规划放线测量技术报告";

        private static string T_Str_One3 = "市政工程";
        private static string T_Str_One4 = "项目名称:";
        private static string T_Str_One5 = "建设单位:";
        private static string T_Str_One6 = "设计单位:";
        private static string T_Str_One7 = "测量单位：";
        private static string T_Str_One8 = "单位资质：";

        private static string T_Str_One9 = "编制人:              审核人:                  批准人:   ";
        private static string T_Str_One10 = "天津市建设工程规划放线测量技术报告";
        private static string T_Str_One11 = "一、项目名称";
        private static string T_Str_One12 = "二、坐落地点";
        private static string T_Str_One13 = "三、作业依据";

        private static string T_Str_One14 = "1、城乡规划主管部门审批的建设工程设计方案通知书、方案总平面图和依据方案设计的施工总平面图（含电子文件）等。";

        private static string T_Str_One15 = "2、《城市测量规范》CJJ/T 8-2011。";
        private static string T_Str_One16 = "3、《卫星定位城市测量技术规范》CJJ/T73-2010。";

        private static string T_Str_One17 = "4、《全球定位系统实时动态测量（RTK）技术规范》   CH/T 2009-2010。";
        private static string T_Str_One18 = "5、《国家基本比例尺地形图图式第1部分：1:500      1:1000  1:2000地形图图式》GB/T 20257.1－2007。";
        private static string T_Str_One19 = "6、《天津市测绘院规划测量技术规定》YB301-2017。";

        private static string T_Str_One20 = "7、《天津市测绘院市政工程管线测量管理规定》。";

        private static string T_Str_One21 = "四、平面控制";
        private static string T_Str_One22 = "1、坐标系统：采用1990年天津市任意直角坐标系。";

        private static string T_Str_One23 = "2、";
        private static string T_Str_One23_1 = "仪器： ";
        private static string T_Str_One23_2 = "，";
        private static string T_Str_One23_3 = "仪器号：";

        private static string T_Str_One24 = "3、布设方法：施测Ⅱ级GPS控制点XX点。";
        private static string T_Str_One24_1 = "个。";

        private static string T_Str_One25 = "五、成图方法";
        private static string T_Str_One26 = "根据甲方提供的规划盖章的建设工程设计方案通知书及审批施工图设计等资料，按照审批施工图上坐标放线，详见《放线点坐标成果表》，结合现场放线结果，利用SCS2004数字测图系统成图，成图比例尺";
        private static string T_Str_One26_1 = "〈见后附图〉。";

        private static string T_Str_One27 = "六、放桩方法";

        private static string T_Str_One28 = "以所布设GPS点为控制点，在控制点上设站，采用极坐标法现场施测。";

        private static string T_Str_One29 = "七、放线说明";
        private static string T_Str_One30 = "现场以甲方提供施工图设计上坐标进行放线,每个桩点均现场进行复测，待甲方与施工人员进场后交接。在桩点的接收、使用及维护等方面造成的一切后果由甲方自负。";
        private static string T_Str_One40 = "八、质量结论";
        private static string T_Str_One31 = "规划定位后，经检查人员使用Leica TCR1202 R300全站仪重新设站检查，点位精度符合《城市测量规范》要求，可交付甲方使用。";

        private static string T_Str_One32 = "九、使用须知";
        private static string T_Str_One33 = "本产品交付甲方后，只作为申报《建设工程规划许可证》（市政工程）立案要件之一，须经城乡规划主管部门核发《建设工程规划许可证》后方可开工。";

        private static string T_Str_One34 = "附件：";
        private static string T_Str_One35 = "1、放线点坐标成果表";
        private static string T_Str_One35_1 = "2、管线长度表 ";
        private static string T_Str_One36 = "2、平面位置示意图";
        private static string T_Str_One36_1 = "3、平面位置示意图";
        private static string T_Str_One37 = "3、放线总平面图";
        private static string T_Str_One37_1 = "4、放线总平面图";

        private static string T_Str_One38 = "                                 放线人：";
        private static string T_Str_One39 = "                                 检查人：";

        public static string Str_One0
        {
            get { return T_Str_One0; }
        }

        public static string Str_One1
        {
            get { return T_Str_One1; }
        }

        public static string Str_One2
        {
            get { return T_Str_One2; }
        }

        public static string Str_One3
        {
            get { return T_Str_One3; }
        }

        public static string Str_One4
        {
            get { return T_Str_One4; }
        }

        public static string Str_One5
        {
            get { return T_Str_One5; }
        }

        public static string Str_One6
        {
            get { return T_Str_One6; }
        }

        public static string Str_One7
        {
            get { return T_Str_One7; }
        }

        public static string Str_One8
        {
            get { return T_Str_One8; }
        }

        public static string Str_One9
        {
            get { return T_Str_One9; }
        }

        public static string Str_One10
        {
            get { return T_Str_One10; }
        }

        public static string Str_One11
        {
            get { return T_Str_One11; }
        }

        public static string Str_One12
        {
            get { return T_Str_One12; }
        }

        public static string Str_On13
        {
            get { return T_Str_One13; }
        }

        public static string Str_On14
        {
            get { return T_Str_One14; }


        }

        public static string Str_On15
        {
            get { return T_Str_One15; }
        }

        public static string Str_On16
        {
            get { return T_Str_One16; }
        }

        public static string Str_On17
        {
            get { return T_Str_One17; }
        }

        public static string Str_On18
        {
            get { return T_Str_One18; }
        }

        public static string Str_On19
        {
            get { return T_Str_One19; }
        }

        public static string Str_On20
        {
            get { return T_Str_One20; }
        }

        public static string Str_On21
        {
            get { return T_Str_One21; }
        }

        public static string Str_On22
        {
            get { return T_Str_One22; }
        }

        public static string Str_On23
        {
            get { return T_Str_One23; }
        }

        public static string Str_On23_1
        {
            get { return T_Str_One23_1; }
        }

        public static string Str_On23_2
        {
            get { return T_Str_One23_2; }
        }

        public static string Str_On23_3
        {
            get { return T_Str_One23_3; }
        }


        public static string Str_On24
        {
            get { return T_Str_One24; }
        }

        public static string Str_On24_1
        {
            get { return T_Str_One24_1; }
        }

        public static string Str_One25
        {
            get { return T_Str_One25; }
        }

        public static string Str_One26
        {
            get { return T_Str_One26; }
        }

        public static string Str_One26_1
        {
            get { return T_Str_One26_1; }
        }

        public static string Str_One27
        {
            get { return T_Str_One27; }
        }

        public static string Str_One28
        {
            get { return T_Str_One28; }
        }

        public static string Str_One29
        {
            get { return T_Str_One29; }
        }

        public static string Str_One30
        {
            get { return T_Str_One30; }
        }


        public static string Str_One31
        {
            get { return T_Str_One31; }
        }

        public static string Str_One32
        {
            get { return T_Str_One32; }
        }

        public static string Str_One33
        {
            get { return T_Str_One33; }
        }


        public static string Str_One34
        {
            get { return T_Str_One34; }
        }

        public static string Str_One35
        {
            get { return T_Str_One35; }
        }

        public static string Str_One35_1
        {
            get { return T_Str_One35_1; }
        }

        public static string Str_One36
        {
            get { return T_Str_One36; }
        }

        public static string Str_One36_1
        {
            get { return T_Str_One36_1; }
        }

        public static string Str_One37
        {
            get { return T_Str_One37; }
        }

        public static string Str_One37_1
        {
            get { return T_Str_One37_1; }
        }


        public static string Str_One38
        {
            get { return T_Str_One38; }
        }


        public static string Str_One39
        {
            get { return T_Str_One39; }
        }

        public static string Str_One40
        {
            get { return T_Str_One40; }
        }

    }
}
