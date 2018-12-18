using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Threading;

/*using Autodesk.Gis.Map;
using Autodesk.Gis.Map.ImportExport;
using Autodesk.Gis.Map.Project;
using Autodesk.Gis.Map.ObjectData;
using Autodesk.Gis.Map.Filters;*/

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using Autodesk.AutoCAD.Colors;

using Utility;
using Autodesk.AutoCAD.Windows;

namespace MunicipalEngineering
{
    public static class SZGCFX
    {



    }

    public sealed class SampleCommands
    {

        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("shp")]
        public static void Dwg2SHP()
        {



            Form creatSHPForm = new SHPForm_SZGC();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, creatSHPForm, false);


         
        }
        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("MData")]
        public static void GenMataData()
        {

            Form MDForm = new MetadataForm();

            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MDForm, false);


        }


        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("SZReport")]
        public static void GenReport_SZGC()
        {
            Form GenReport = new ReportGenForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, GenReport, false);

           // Form EncodeForm = new EnCodeForm();
          //  Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, EncodeForm, false);


        }


        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("SZReportYY")]
        public static void GenReport1_SGGC()
        {

            Form GenReport1 = new ReportGenOneForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, GenReport1, false);
        }

        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("log")]
        public static void CheckUser()
        {
           // Form UserForm = new UserCheck();

           // Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null,UserForm,false);


            Form UserForm = new UserCheck();

            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, UserForm, false);

            if (UtilityVar.isLogSuccess == true)
            {
                // this.Dispose();

                //Form UserForm = new UserCheck();

                MetadataForm MetaForm = new MetadataForm();

                Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MetaForm, false);

            }


        }

        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("CutP",CommandFlags.Session)]
        public static void CutPolyGon()
        {
            //定义裁剪多线段 
            /* Polyline plCut = new Polyline();

             Document acdoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
             Database acdb = acdoc.Database;
             Editor aced = acdoc.Editor;

             PromptEntityOptions entOpt = new PromptEntityOptions("请选择裁剪线或者裁剪多边形");
             entOpt.SetRejectMessage("请选择多线段");
             entOpt.AddAllowedClass(typeof(Polyline),true);
             PromptEntityResult entRes = aced.GetEntity(entOpt);

             if (entRes.Status != PromptStatus.OK) return;

             ObjectId objId = entRes.ObjectId;

             using (Transaction trans = acdb.TransactionManager.StartTransaction())
             {

                 plCut = trans.GetObject(objId, OpenMode.ForRead) as Polyline;


                 CutTK cutT = new CutTK(plCut);

                 cutT.Cut(@"D:\testCut.dwg", false);


                 trans.Commit();

             }*/

            //定义裁剪实体 

            CutMap cutmap = new CutMap();
            cutmap.Cut(@"D:\testCut.dwg", true);


            
        }

        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("CutL", CommandFlags.Session)]

        public static void CutLine()
        {



        }

      //  [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("MP")]
       /* public static void MapProcessToolBox()
        {
            Form MPForm = new MapProcessForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MPForm, false);
        }*/

        [Autodesk.AutoCAD.Runtime.CommandMethodAttribute("MPP",CommandFlags.Session)]
        public static void MapPreProcess()
        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            //a.先选择所有对象  

            PromptSelectionResult ss1_All = ed.SelectAll();

            if (ss1_All.Status != PromptStatus.OK) return;

            ObjectId[] ObjId_All = ss1_All.Value.GetObjectIds();

            if (ObjId_All.Length == 0)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("此图是一张空白图！！！");

                return;
            }
            UtilityFun.CreateLayer(db,"定线", 5);  //1.先生成标准图层 

            DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();

            //2.根据图形比例尺，把多线段线宽和颜色变了 
            double sf = UtilityFun.Scalefactor(db,ed);

            //分步选择不同对象


            //建立多线段的过滤集   
            TypedValue[] valusPolyLine = new TypedValue[]
            {
                new TypedValue((int)DxfCode.Start,"*POLYLINE*")



            };

            SelectionFilter sfPloyLine = new SelectionFilter(valusPolyLine);

            PromptSelectionResult ss1_PLine = ed.SelectAll(sfPloyLine);

            if (ss1_PLine.Status != PromptStatus.OK) return;

            ObjectId[] ObjId_Pline = ss1_PLine.Value.GetObjectIds();

            if(ObjId_Pline.Length == 0)
            {

                ed.WriteMessage("图面中无路由，继续其他对象标准化处理！\n");

            }
            else
            {

                var ss_qy = ObjId_All.Union(ObjId_Pline);  //其余ID集合 
                
                foreach (ObjectId id in ObjId_Pline)
                {

                    using (Transaction trans = db.TransactionManager.StartTransaction())
                    {

                        Polyline pl = (Polyline)trans.GetObject(id, OpenMode.ForWrite);

                        pl.Layer = "定线";
                        pl.Linetype = "ByLayer";
                        // pl.SetStartWidthAt(0, sf);
                        // pl.SetEndWidthAt(pl.NumberOfVertices - 1, sf);
                        pl.ConstantWidth = sf;
                        pl.ColorIndex = 0;

                        trans.Commit();
                    }


                }

                ed.WriteMessage("路由处理完毕！\n");

            }

           

            //3. 遍历直线的集合，判断垂直的两条直线的交点，并且插入标准块 


            //建立多线段的过滤集   
            TypedValue[] valusLine = new TypedValue[]
            {
                new TypedValue((int)DxfCode.Start,"LINE")



            };

            SelectionFilter sfLine = new SelectionFilter(valusLine);

            PromptSelectionResult ss1_Line = ed.SelectAll(sfLine);

            if (ss1_PLine.Status != PromptStatus.OK) return;

            ObjectId[] ObjId_line = ss1_Line.Value.GetObjectIds();

            Point3dCollection BlockPtCOl = new Point3dCollection();

            if(ObjId_line.Length == 0)
            {

                ed.WriteMessage("图面中无十字直线集合，继续其他对象标准化处理\n");

            }
            else
            {

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {

                    for (int i = 0; i < ObjId_line.Length - 1; i++)
                    {

                        Line Li = (Line)trans.GetObject(ObjId_line[i], OpenMode.ForWrite);

                        for (int j = i + 1; j < ObjId_line.Length; j++)
                        {
                            Point3dCollection ptc = new Point3dCollection();
                            Line Lj = (Line)trans.GetObject(ObjId_line[j], OpenMode.ForWrite);

                            ptc = UtilityFun.IntersectWith(Li, Lj, Intersect.OnBothOperands);

                            if (ptc.Count == 0)
                            {


                                continue;
                            }
                            else
                            {

                                BlockPtCOl.Add(ptc[0]);
                                break;

                            }

                        }

                    }

                    trans.Commit();

                }


                //4.根据交点写入块 

                string symbol_name = "C:\\2016app\\SZFX\\BLOCKS\\" + "SZS.DWG";
                ObjectId BlockId = CUsercontrol.CreateBlockfromfile(symbol_name);
                for (int j = 0; j < BlockPtCOl.Count; j++)
                {
                    ObjectId BlockId1 = CUsercontrol.Fillbyblock(BlockPtCOl[j], 0.0, BlockId);

                    using (Transaction trans2 = db.TransactionManager.StartTransaction())
                    {

                        BlockReference bref = trans2.GetObject(BlockId1, OpenMode.ForWrite) as BlockReference;

                        bref.Layer = "定线";

                        trans2.Commit();

                    }

                }

                //5.删除直线 

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {

                    for (int i = 0; i < ObjId_line.Length; i++)
                    {


                        Line Ln = (Line)trans.GetObject(ObjId_line[i], OpenMode.ForWrite);

                        Ln.Erase();








                    }

                    trans.Commit();

                }
                ed.WriteMessage("十字丝添加完毕\n");

            }




           


            //6处理标注样式 

            string dimName = "路宽标注";

            using (Transaction trans3 = db.TransactionManager.StartTransaction())
            {
                try
                {
                    ObjectId dimId = db.AddDimStyle(dimName);

                    DimStyleTableRecord dstr = (DimStyleTableRecord)trans3.GetObject(dimId, OpenMode.ForWrite);

                    dstr.Dimasz = 3.0; //箭头大小 
                    
                    dstr.Dimtxt = 2.0; //文字高度 
                   // dstr.Dimapost =
                    dstr.Dimclrd = Color.FromColorIndex(ColorMethod.ByLayer,5);
                    dstr.Dimclrt = Color.FromColorIndex(ColorMethod.ByLayer, 5);
                    dstr.Dimclre = Color.FromColorIndex(ColorMethod.ByLayer, 5);
                    dstr.Dimexe = 0.0;
                    dstr.Dimexo = 0.0;
                    dstr.Dimdec = 1;
                    dstr.Dimpost = "M";
                     
                    dstr.Dimtxsty = db.AddTextStyle("黑体2.0", "黑体", "", 0, 1.0, 0);

                    dstr.Dimgap = 0; //文字偏移

                    db.Dimstyle = dimId;


                    //设置文字样式 ？？？？

                    //为防止出现替代样式的问题，添加下面的语句 
                    db.SetDimstyleData(dstr);


                }
                catch(Autodesk.AutoCAD.Runtime.Exception acExc)
                {

                    ed.WriteMessage("\nAddDimStyle错误：{0}", acExc.Message);

                }

                trans3.Commit();
            }


            //过滤对齐标注样式 
            TypedValue[] valusAliDim = new TypedValue[]
              {
                new TypedValue((int)DxfCode.Start,"*Dimension")



              };

            SelectionFilter sfAliDim = new SelectionFilter(valusAliDim);

            PromptSelectionResult ss1_AliDim = ed.SelectAll(sfAliDim);

            if (ss1_AliDim.Status != PromptStatus.OK)
            {


                ed.WriteMessage("对齐标准对象选择失败或是没有对齐标注对象，已全部处理完毕！！");
                return;

            }
            

            ObjectId[] ObjId_AliDim = ss1_AliDim.Value.GetObjectIds();




            foreach(ObjectId id in ObjId_AliDim)
            {

                using (Transaction trans4 = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                       // ObjectId dimId = db.AddDimStyle(dimName);


                        AlignedDimension adi = (AlignedDimension)trans4.GetObject(id, OpenMode.ForWrite);


                      /*  adi.Dimasz = 3.0; //箭头大小 

                        adi.Dimtxt = 2.0; //文字高度 
                                          // dstr.Dimapost =
                        adi.Dimclrd = Color.FromColorIndex(ColorMethod.ByLayer, 5);
                        adi.Dimclrt = Color.FromColorIndex(ColorMethod.ByLayer, 5);
                        adi.Dimclre = Color.FromColorIndex(ColorMethod.ByLayer, 5);
                        adi.Dimexe = 0.0;
                        adi.Dimexo = 0.0;
                        adi.Dimdec = 1;
                        adi.Dimpost = "M";
                        adi.Layer = "定线";
                        //adi.TextStyleId = db.AddTextStyle("黑体2.0", "黑体", "", 0, 1.0, 0);
                        
                        //db.Dimstyle = dimId;*/

                        adi.DimensionStyleName = "路宽标注";
                        adi.Layer = "定线";
                        //设置文字样式 ？？？？
                        

                        //为防止出现替代样式的问题，添加下面的语句 
                        // db.SetDimstyleData(dstr);

                        trans4.Commit();
                    }
                    catch (Autodesk.AutoCAD.Runtime.Exception acExc)
                    {

                        ed.WriteMessage("\nAddDimStyle错误：{0}", acExc.Message);
                        trans4.Abort();
                    }
                    

                    

                }

            }

            ed.WriteMessage("对齐标注标准化完毕\n");

            m_DocumentLock.Dispose();
        }

        [CommandMethod("szcj1",CommandFlags.Modal)]
        public void CallDXJDCLListFuntion()
        {

            // ResultBuffer args = new ResultBuffer();
            //int stat = 0;

            // args.Add(new TypedValue ((int)LispDataType.Text,"c:SZCJ" ));
            // ResultBuffer res = UtilityFun.InvokeLisp(args,ref stat);

           // ResultBuffer args = new ResultBuffer(
           //  new TypedValue((int)LispDataType.Text, "c:szcj"));

           // ResultBuffer result =   Autodesk.AutoCAD.ApplicationServices.Application.Invoke(args);

            CUsercontrol.SendCommand("szcj\n");
        }

        [CommandMethod("ZDZB")]

        public void ZDZB()
        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            int numBref = 1;

            double angle = 0;

            //建立GCD层过滤器，给所扯坐标定一个角度 

            TypedValue[] ValuesGCD = new TypedValue[]
          {
              
                new TypedValue((int)DxfCode.LayerName,"GCD"),
                

          };

            SelectionFilter sfGCD = new SelectionFilter(ValuesGCD);
            PromptSelectionResult SelResGCD = ed.SelectAll(sfGCD);

            if(SelResGCD.Status == PromptStatus.OK)

            {


                SelectionSet ssGCD = SelResGCD.Value;

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {

                        foreach (ObjectId id in ssGCD.GetObjectIds())
                        {

                            Entity ent = trans.GetObject(id, OpenMode.ForRead) as Entity;

                            if(ent is DBText)
                            {

                                DBText text = (DBText)ent;
                                angle = text.Rotation;
                                break;
                            }
                        }

                    }

                    catch
                    {


                        trans.Abort();
                    }



                }

            }
            else
            {


                return;
            }

            //建立过滤器  

            TypedValue[] ValuesIn = new TypedValue[]
            {    


                //new TypedValue((int)DxfCode.Operator,"<or"),

                new TypedValue((int)DxfCode.LayerName,"定线"),
                new TypedValue((int)DxfCode.Start,"Insert"),

               // new TypedValue((int)DxfCode.Operator,"or>"),

            };
            
            SelectionFilter sfInS = new SelectionFilter(ValuesIn);

            PromptSelectionResult SelRes = ed.SelectAll(sfInS);

            if (SelRes.Status != PromptStatus.OK) return;

            SelectionSet SS = SelRes.Value;



            foreach(ObjectId id in SS.GetObjectIds())
            {
                Point3d pt1 = new Point3d();
                Point3d pt2 = new Point3d();
                Point3d pt3 = new Point3d();
                Point3d BasePt1 = new Point3d(); //X=XXX文本的基点
                Point3d BasePt2 = new Point3d();//Y=XXX文本的基点 

                Point3dCollection ptCol = new Point3dCollection();

                Polyline pl = new Polyline();
                DBText txt1 = new DBText();
                DBText txt2 = new DBText();

               
                    using (Transaction trans = db.TransactionManager.StartTransaction())
                    {
                        
                        try
                        {
                           // BlockReference Bref = (BlockReference)trans.GetObject(id, OpenMode.ForRead);

                        DBObject Obj = (DBObject)trans.GetObject(id, OpenMode.ForRead);

                           if(Obj is BlockReference)
                            {


                                BlockReference Bref = Obj as BlockReference;

                                pt1 = Bref.Position;
                            }
                            else
                            {

                                continue;
                            }

                            
                            
                            


                        }
                        catch(Autodesk.AutoCAD.Runtime.Exception e)
                        {
                            ed.WriteMessage(e.Message + "发生在读块坐标\n");
                            trans.Abort();
                            return;
                        }
                        

                        if(numBref % 2 != 0)
                        {

                        double x1 = pt1.X - 15;
                        double y1 = pt1.Y - 4.8;

                        double x2 = pt1.X - 15;
                        double y2 = pt1.Y - 6.2;

                        BasePt1 = new Point3d(x1, y1, 0);
                        BasePt2 = new Point3d(x2, y2, 0);

                        pt2 = new Point3d(pt1.X - 6,pt1.Y -5 ,0);
                        pt3 = new Point3d(pt1.X - 15, pt1.Y - 5, 0);
                        
                        }
                        else
                        {
                        double x1 = pt1.X +6.2;
                        double y1 = pt1.Y+6.2;

                        double x2 = pt1.X +6.2;
                        double y2 = pt1.Y +4.8;

                        BasePt1 = new Point3d(x1, y1, 0);
                        BasePt2 = new Point3d(x2, y2, 0);

                        pt2 = new Point3d(pt1.X + 6, pt1.Y + 6, 0);
                        pt3 = new Point3d(pt1.X + 15, pt1.Y + 6, 0);


                       
                        }

                        ptCol.Add(pt1);
                        ptCol.Add(pt2);
                        ptCol.Add(pt3);

                        pl.CreatPolyline(ptCol);

                        txt1.TextString = "X=" + pt1.X.ToString("0.000");
                        txt2.TextString = "Y=" + pt1.Y.ToString("0.000");

                        txt1.Position = BasePt1;
                         txt2.Position = BasePt2;

                       txt1.WidthFactor = 0.8;
                       txt2.WidthFactor = 0.8;

                       txt1.Height = 1;
                       txt2.Height = 1;

                       txt1.TextStyleId = db.AddTextStyle("HZ","RS","HZTXT",0.75,0.8,0);
                       txt2.TextStyleId = db.AddTextStyle("HZ", "RS", "HZTXT", 0.75, 0.8,0);

                       txt1.Oblique = 0;
                       txt2.Oblique = 0;

                      // txt1.Rotation = angle;
                      // txt2.Rotation = angle;

                       txt1.Layer = "定线";
                        txt2.Layer = "定线";

                        pl.Layer = "定线";


                    UtilityFun.Rotate(txt1, pt1, angle, Vector3d.ZAxis);
                    UtilityFun.Rotate(txt2, pt1, angle, Vector3d.ZAxis);
                    UtilityFun.Rotate(pl, pt1, angle, Vector3d.ZAxis);

                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;


                    btr.AppendEntity(txt1);

                    btr.AppendEntity(txt2);

                    btr.AppendEntity(pl);
                    trans.AddNewlyCreatedDBObject(txt1, true);
                    trans.AddNewlyCreatedDBObject(txt2, true);
                    trans.AddNewlyCreatedDBObject(pl, true);


                    trans.Commit();





                }





                numBref = numBref + 1;
            }

        }
        /// <summary>
        /// 手动扯坐标，在旋正的情况下  
        /// </summary>
        [CommandMethod("CZB")]         

        public void CZB()
        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            double angle = 0;

            //建立GCD层过滤器，给所扯坐标定一个角度 

            TypedValue[] ValuesGCD = new TypedValue[]
          {

                new TypedValue((int)DxfCode.LayerName,"GCD"),


          };

            SelectionFilter sfGCD = new SelectionFilter(ValuesGCD);
            PromptSelectionResult SelResGCD = ed.SelectAll(sfGCD);

            if (SelResGCD.Status == PromptStatus.OK)

            {


                SelectionSet ssGCD = SelResGCD.Value;

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {

                        foreach (ObjectId id in ssGCD.GetObjectIds())
                        {

                            Entity ent = trans.GetObject(id, OpenMode.ForRead) as Entity;

                            if (ent is DBText)
                            {

                                DBText text = (DBText)ent;
                                angle = text.Rotation;
                                break;
                            }
                        }

                    }

                    catch
                    {


                        trans.Abort();
                    }



                }

            }
            else
            {


                return;
            }

            Point3d blockPt = new Point3d();
            //提示用户选择一个十字节点 ，

            /* TypedValue[] valueSZS = new TypedValue[]
             {

                 new TypedValue((int)DxfCode.Start,"Insert")


             };

             SelectionFilter sf = new SelectionFilter(valueSZS);*/


            PromptEntityOptions EntOpt = new PromptEntityOptions("请选择十字节点");

            PromptEntityResult entRes = ed.GetEntity(EntOpt);


            if (entRes.Status != PromptStatus.OK) return;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {

                BlockReference bref ;
                try
                {
                    DBObject obj = trans.GetObject(entRes.ObjectId, OpenMode.ForRead) as DBObject;

                    if(obj.GetType() == typeof(BlockReference))
                    {

                        try
                        {

                            bref = (BlockReference)obj;

                            blockPt = bref.Position;

                        }
                        catch
                        {


                            ed.WriteMessage("类型转换为块失败");
                        }

                    }


                }

                catch
                {

                    ed.WriteMessage("getobject()时出错！！！");

                }


            }


            //提示用户选择引线的第二点  

            Point3d ptSecond = new Point3d();
            Point3d ptEnd = new Point3d();

            //定义文本的两个基点  

            Point3d ptText1 = new Point3d();
            Point3d ptText2 = new Point3d();

            PromptPointOptions ptOpt = new PromptPointOptions("请输入引线拐点");



            PromptPointResult ptRes = ed.GetPoint(ptOpt);

            if (ptRes.Status != PromptStatus.OK) return;

            ptSecond = ptRes.Value;


            //需要判断引线拐点向左还是向右

            if(blockPt.X < ptSecond.X)
            {


                ptEnd = new Point3d(ptSecond.X + 9, ptSecond.Y, 0);
                ptText1 = new Point3d(ptSecond.X + 0.2, ptSecond.Y + 0.2, 0);
                ptText2 = new Point3d(ptSecond.X+0.2,ptSecond.Y-1.2,0);
            }

            else

            {


                ptEnd = new Point3d(ptSecond.X - 9, ptSecond.Y, 0);

                ptText1 = new Point3d(ptSecond.X -9, ptSecond.Y + 0.2, 0);
                ptText2 = new Point3d(ptSecond.X -9, ptSecond.Y - 1.2, 0);
            }

            //创建多线段 以及文字 

            Polyline pl = new Polyline();

            Point3dCollection pt3col = new Point3dCollection();

            pt3col.Add(blockPt); pt3col.Add(ptSecond); pt3col.Add(ptEnd);

            DBText text1 = new DBText();
            DBText text2 = new DBText();

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {

                BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                pl.CreatPolyline(pt3col);

                text1.TextString = "X=" + blockPt.X.ToString("0.000");
                text2.TextString = "Y=" + blockPt.Y.ToString("0.000");

                text1.Position = ptText1;
                text2.Position = ptText2;

                text1.WidthFactor = 0.8;
                text2.WidthFactor = 0.8;

                text1.Height = 1;
                text2.Height = 1;

                text1.TextStyleId = db.AddTextStyle("HZ", "RS", "HZTXT", 0.75, 0.8, 0);
                text2.TextStyleId = db.AddTextStyle("HZ", "RS", "HZTXT", 0.75, 0.8, 0);

                text1.Oblique = 0;
                text2.Oblique = 0;

                // txt1.Rotation = angle;
                // txt2.Rotation = angle;

                text1.Layer = "定线";
                text2.Layer = "定线";

                pl.Layer = "定线";


              //  UtilityFun.Rotate(text1, blockPt, angle, Vector3d.ZAxis);
              //  UtilityFun.Rotate(text2, blockPt, angle, Vector3d.ZAxis);
               // UtilityFun.Rotate(pl, blockPt, angle, Vector3d.ZAxis);

              

                btr.AppendEntity(text1);

                btr.AppendEntity(text2);

                btr.AppendEntity(pl);
                trans.AddNewlyCreatedDBObject(text1, true);
                trans.AddNewlyCreatedDBObject(text2, true);
                trans.AddNewlyCreatedDBObject(pl, true);


                trans.Commit();



            }









        }


        /// <summary>
        /// 利用定线分幅图变为总图 
        /// </summary>
        [CommandMethod("ZT",CommandFlags.Session)]
        public void ZongTu()
        {

            //1.暂定给定一个文件路径，遍历该文件路径下的所有DWG文件 

            string PathName = string.Empty;
            List<string> FileList = new List<string>();
            System.Windows.Forms.FolderBrowserDialog folder = new FolderBrowserDialog();

            if(folder.ShowDialog() == DialogResult.OK)
            {

                PathName = folder.SelectedPath;

            }
            else
            {

                return;
            }

            FileList = UtilityFun.Director(PathName);

            if (FileList == null) return;

            string folderPath = new FileInfo(PathName).DirectoryName;

            string OutPutString = folderPath + "\\总图.dwg";

            UtilityFun.merageDWGFiles(FileList, OutPutString, DwgVersion.AC1800);

        }

        /// <summary>
        /// 由详勘图转报验图 
        /// </summary>
        [CommandMethod("DXT")]
        public void sctToBJT()
        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;


            //首先选择内边框，并存储它，以便计算工程编号以及项目总编号的基点时要用 

            Polyline innerPl = new Polyline();

            TypedValue[] plValue = new TypedValue[]
            {

                 new TypedValue((int)DxfCode.LayerName,"GXTK"),
                 new TypedValue((int)DxfCode.Start,"*Polyline")


            };

            SelectionFilter GXfl = new SelectionFilter(plValue);

            PromptSelectionResult plPSR = ed.SelectAll(GXfl);

            if (plPSR.Status != PromptStatus.OK) return;

            using (Transaction pltrans = db.TransactionManager.StartTransaction())
            {

                try
                {
                    foreach (ObjectId id in plPSR.Value.GetObjectIds())
                    {

                        Polyline pl = pltrans.GetObject(id, OpenMode.ForWrite) as Polyline;


                        if (pl.ConstantWidth > 0.1)
                        {

                            innerPl = pl;
                            break;
                        }


                    }

                    pltrans.Commit();
                }
                catch (Autodesk.AutoCAD.Runtime.Exception acExc)
                {
                    ed.WriteMessage(acExc.Message);
                    pltrans.Abort();


                }

            }

                //定义 多线段容器 

                List<Polyline> plList = new List<Polyline>();
            //1.GXTK层的内容改变（文字内容+删除一些必要东西，例如用图说明以及探测范围）


            TypedValue[] filList = new TypedValue[]
            {
                new TypedValue((int)DxfCode.LayerName,"GXTK")


            };


           

            SelectionFilter GXTKfilter = new SelectionFilter(filList);

            PromptSelectionResult GXTKPSR = ed.SelectAll(GXTKfilter);

            if (GXTKPSR.Status != PromptStatus.OK) return;


            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {

                    foreach (ObjectId objId in GXTKPSR.Value.GetObjectIds())
                    {

                        Entity ent = trans.GetObject(objId, OpenMode.ForWrite) as Entity;

                        if(ent is DBText)
                        {
                            DBText GXtext = ent as DBText;

                            if (GXtext.TextString.Contains("地下管线实测图"))
                            {

                                string[] XMMC = GXtext.TextString.Split(new string[] { "地下管线实测图" }, StringSplitOptions.None);

                                string XMMC_XG = XMMC[0] + "放线总平面图";

                                GXtext.TextString = XMMC_XG;

                            }
                            else if (GXtext.TextString.Contains("探测范围"))
                            {

                                // GXtext.Erase();
                                ent.Erase();
                            }
                            //探测员:        测量员:
                            //检查员:        日期:2017.08.03
                            else if (GXtext.TextString.Contains("探测员"))
                            {
                                string Text_XG = "测量员:" + "郑二龙" + "  绘图员:" + "范亚男";  //要根据具体情况修改

                                GXtext.TextString = Text_XG;



                            }
                            else if (GXtext.TextString.Contains("检查员"))
                            {

                                string Text_XG = "检查员:" + "刘恩利" + "  日期:";
                                DateTime dt = DateTime.Now;

                                string yr = dt.Year.ToString();
                                string mon = dt.Month.ToString();
                                string day = dt.Day.ToString();
                                string Text_date = yr + "." + mon + "." + day;

                                Text_XG = Text_XG + Text_date;

                                GXtext.TextString = Text_XG;

                            }
                            else if(GXtext.TextString.Contains("工程编号"))
                            {
                                //实验坐标系的变换
                                //1.从WCS变换到UCS
                                //2.在UCS下设定项目总编号的基点  ,创建文字内容，以及其他的一些变化 
                                //3.从UCS变换到WCS

                                //定义UCS的原点以及坐标轴 

                                double angleRo = GXtext.Rotation;

                                Point3d bPt = GXtext.Position;

                                string XMZBH = "2013北辰0128(2017北辰线建案申字0029号)";


                                Point3d bpt1s = new Point3d(bPt.X -3*Math.Sin(angleRo),bPt.Y+3*Math.Cos(angleRo),0  );


                                  Vector3d zAxis  = Vector3d.ZAxis;

                                   zAxis.GetNormal();

                                   Vector3d yAxis = Vector3d.YAxis.RotateBy(angleRo,Vector3d.ZAxis);

                                   yAxis.GetNormal();

                                   Vector3d xAxis = Vector3d.XAxis.RotateBy(angleRo, Vector3d.ZAxis);


                                   Matrix3d mat = Matrix3d.AlignCoordinateSystem(Point3d.Origin, Vector3d.XAxis, Vector3d.YAxis, Vector3d.ZAxis
                                  , Point3d.Origin, xAxis, yAxis, zAxis);



                                //------------------以下部分为试验转换到UCS坐标系下，进行文字的平移以及修改  

                                Point3d bptUCS = bPt.TransformBy(mat.Inverse());  //把基点坐标变换到ucs坐标系中，默认提取的基点坐标为wcs坐标系中坐标

                                Point3d bpt1UCS = new Point3d(bptUCS.X, bptUCS.Y + 3, 0);

                                GXtext.TransformBy(mat.Inverse());  //把工程编号dbtext变换到ucs坐标系中

                                Matrix3d mat1 = Matrix3d.Displacement(bpt1UCS - bptUCS);

                                DBText XMZBHText = GXtext.GetTransformedCopy(mat1) as DBText;
                                XMZBHText.TextString = "项目总编号:" + XMZBH ;

                                    Polyline ppl = new Polyline();

                                    ppl.CopyFrom(innerPl);

                                    ppl.TransformBy(mat.Inverse());


                                    Extents3d plExt = ppl.GeometricExtents;
                                Extents3d ZBHExt = XMZBHText.GeometricExtents;
                                Extents3d GXExt = GXtext.GeometricExtents;

                                //计算边界的宽度   

                                double zbhWidth = ZBHExt.MaxPoint.X - ZBHExt.MinPoint.X;

                                double gxWidth = GXExt.MaxPoint.X - GXExt.MinPoint.X;

                                // XMZBHText.Position = new Point3d(plExt.MaxPoint.X - zbhWidth / 2, bptUCS.Y + 3, 0);
                                //  GXtext.Position = new Point3d(ZBHExt.MinPoint.X+gxWidth/2,   bptUCS.Y,0);

                               // Point3d pt3ucs = new Point3d(bpt1UCS.X - (ZBHExt.MaxPoint.X-plExt.MaxPoint.X),bpt1UCS.Y+3,0);
                                Point3d pt1ucs = new Point3d(plExt.MaxPoint.X - zbhWidth / 2, bptUCS.Y + 3+0.5, 0);

                                Point3d pt2ucs = new Point3d(plExt.MaxPoint.X -zbhWidth+ gxWidth / 2, bptUCS.Y+0.5, 0);

                               
                                Point3d pt1wcs = pt1ucs.TransformBy(mat);
                                Point3d pt2wcs = pt2ucs.TransformBy(mat);

                                ppl.TransformBy(mat);
                                XMZBHText.TransformBy(mat); //从ucs坐标系转换到wcs坐标系
                                GXtext.TransformBy(mat);
                                // XMZBHText.TransformBy(mat);

                                // XMZBHText.Position = pt1wcs;
                                // GXtext.Position = pt2wcs;

                                GXtext.AlignmentPoint = pt2wcs;
                                XMZBHText.AlignmentPoint = pt1wcs;
                                //----------------------试验结束部----------------------------

                                //  DBText XMZBHText = GXtext.GetTransformedCopy(mat) as DBText;

                                BlockTable bt = trans.GetObject(db.BlockTableId,OpenMode.ForRead) as BlockTable;

                                BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                                btr.AppendEntity(XMZBHText);

                                trans.AddNewlyCreatedDBObject(XMZBHText,true);


                            }






                        }
                        else if(ent is MText)
                        {

                            MText GXMtext = ent as MText;

                             GXMtext.Erase();

                          //  ent.Erase();

                        }
                        else if(ent is Polyline)
                        {
                            Polyline GXPL = ent as Polyline;

                            if(GXPL.ConstantWidth > 0.01 )   //0,01设定为一个阈值
                            {


                                plList.Add(GXPL);
                            }


                        }
                        else
                        {



                        }


                    }

                    if (plList.Count == 2)   //一般情况下，GXTK层有两个宽度为0.25的闭合多线段
                    {

                       

                        if(plList[0].Area <plList[1].Area)
                        {
                            plList[0].Erase();

                        }
                        else
                        {

                            plList[1].Erase();

                        }

                           


                

                    }




                    //2.图层颜色变白 （除了红线层以及定线层）

                    //打开层表  

                    LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);

                    foreach(ObjectId id in lt)
                    {

                        //打开层表记录 

                        LayerTableRecord ltr = (LayerTableRecord)trans.GetObject(id, OpenMode.ForWrite);

                        if(!ltr.Name.Contains("road_zxx")&&!ltr.Name.Contains("net")&&!ltr.Name.Contains("定线"))
                        {

                            ltr.Color = Color.FromColorIndex(ColorMethod.ByAci,7);

                        }

                    }


                    //变换管线点层中的颜色  


                    //建立过滤器  

                    TypedValue[] ValuesPoint = new TypedValue[]
                    {    


                //new TypedValue((int)DxfCode.Operator,"<or"),

                new TypedValue((int)DxfCode.LayerName,"*POINT"),
                new TypedValue((int)DxfCode.Start,"Insert"),

                        // new TypedValue((int)DxfCode.Operator,"or>"),

                    };

                    SelectionFilter sf = new SelectionFilter(ValuesPoint);

                    PromptSelectionResult PSR = ed.SelectAll(sf);

                    if (PSR.Status != PromptStatus.OK) return;


                    foreach(ObjectId id in PSR.Value.GetObjectIds())
                    {

                        BlockReference br = (BlockReference)trans.GetObject(id,OpenMode.ForWrite);

                        br.Color = Color.FromColorIndex(ColorMethod.ByBlock,0);
                    }




                    trans.Commit();


                    plList.Clear();

                }
                catch(Autodesk.AutoCAD.Runtime.Exception acExc)
                {
                    ed.WriteMessage(acExc.Message);
                    trans.Abort();


                }
                finally
                {

                    trans.Dispose();
                }


            }

               

            
        }


        [CommandMethod("UpLoad")]
        public void UpFile()
        {
            
            Form UpFile = new UpFileClientForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, UpFile, false);

        }

        [CommandMethod("Meta")]
        
        public void MForm()
        {
            
            Form MetaForm = new MetadataForm();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MetaForm, false);
   
        }

        [CommandMethod("ADD")]

        public void ADD()
        {

            MapProcessUserControl myControl = new MapProcessUserControl();
           
            Autodesk.AutoCAD.Windows.PaletteSet ps = new PaletteSet("图面处理工具箱");
            ps.Visible = true;
            ps.Style = PaletteSetStyles.ShowCloseButton;
            ps.Dock = DockSides.Left;
            //ps.MinimumSize = new System.Drawing.Size(200, 400);
            ps.Size = new System.Drawing.Size(154, 600);
            ps.Add("图面处理工具箱", myControl);
            ps.Visible = true;

        }


        [CommandMethod("SortFile")]
        public void SortFile()
        {

            Form OrgFile = new FileOrgForm();

            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null,OrgFile,false);

        }

        public static Autodesk.AutoCAD.Windows.PaletteSet ps;
        [CommandMethod("LP")]

        
        public void loadPanel()
        {

            
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                string strTagText = "市政工程测量系统";
                if (ps == null || ps.IsDisposed)
                {
                    ps = new Autodesk.AutoCAD.Windows.PaletteSet(strTagText);
                    System.Windows.Forms.UserControl myCtrl = new MainUserControl();
                    ps.Add(strTagText, myCtrl);


                    ps.Visible = true;
                    ps.Size = new System.Drawing.Size(160, 2000);
                   // ps.SetSize(new System.Drawing.Size(178, 2000));

                    ps.Dock = Autodesk.AutoCAD.Windows.DockSides.Left;
                    ps.KeepFocus = true;
                    ps.Opacity = 50;
                }
               
               

            }
            catch
            {
                ed.WriteMessage("Error Showing Palette");
            }
        }

        [CommandMethod("CheckPrj")]
        public void CheckProject()
        {

            Form ckf = new CheckProjectForm();

            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, ckf, false);


        }

    }

    public sealed class Utility
    {
        private Utility()
        {


        }

        public static void ShowMsg(string msg)
        {
            AcadEditor.WriteMessage(msg);
        }

        public static Autodesk.AutoCAD.EditorInput.Editor AcadEditor
        {
            get
            {
                return Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            }
        }
    }

    public sealed class ImportExportSampleApplication : IExtensionApplication
    {
        public void Initialize()
        {


            //添加文件搜索路径系统变量路径PATH 
            string sysPath = @" C:\app2016\SZFX\DLL";
            //RegSysPath.SetPath(sysPath);
            //RegSysPath.SetPathAfter(sysPath);

            AcadApplication acadApp = Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication as AcadApplication;

            string supportPath = acadApp.Preferences.Files.SupportPath.ToString();

            if (!supportPath.Contains(sysPath))
            {
                acadApp.Preferences.Files.SupportPath = acadApp.Preferences.Files.SupportPath + ";" + sysPath;

            }
            Utility.ShowMsg("\n 市政工程应用初始化完毕 \n");

            //用户登录  

            Form UserForm = new UserCheck();

            Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, UserForm, false);

            if (UtilityVar.isLogSuccess == true)
            {
                // this.Dispose();

                //Form UserForm = new UserCheck();

                EngineerStatusForm ESForm = new EngineerStatusForm();
                Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, ESForm, false);

                if (UtilityVar.PrjStatus == 1)
                {


                    NewPrjForm NPForm = new NewPrjForm();
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, NPForm, false);

                  if(UtilityVar.isPrjCreate)
                  {

                        MetadataForm MetaForm = new MetadataForm();

                        Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MetaForm, false);

                   }
                  else
                    {


                        return;
                    }


                    if (UtilityVar.isWriteMDataSuccess == true)
                    {
                        // this.Dispose();

                        //调出市政工程放线模板

                        // MetadataForm MetaForm = new MetadataForm();

                        // Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null, MetaForm, false);

                       // SZFXUserControl sz = new SZFXUserControl();
                       // sz.Upload_button.Enabled = false;
                        SampleCommands sc = new SampleCommands();
                        sc.loadPanel();

                    }
                    else
                    {

                        return;
                    }





                }
                else if(UtilityVar.PrjStatus == 2)
                {


                    SampleCommands sc = new SampleCommands();
                    sc.loadPanel();
                    //调出面板：

                }
                else if(UtilityVar.PrjStatus == 3)
                {

                    CheckProjectForm cpf = new CheckProjectForm();
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null,cpf,false);

                }
                else if(UtilityVar.PrjStatus == 4)
                {

                    ProjectSubmitForm psf = new ProjectSubmitForm();
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(null,psf,false);


                }

                

            }
            else
            {

                return;
            }



          


        }

        public void Terminate()
        {

        }
    }

    public sealed class SHPTools
    {
        public SHPTools()
        {

        }

  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="toshp"></param>
        /// <param name="shprecordno"></param>
        /// <param name="gcbh"></param>工程编号
        /// <param name="AttrTable"></param>
        /// <param name="ProBar"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static int CreatSHP(string filename, DBObjectCollection toshp, int shprecordno, ProgressBar proBar,ref double[] X,ref double [] Y)
        {
            Document myDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database myDatabase = myDoc.Database;
            Editor myEditor = myDoc.Editor;
            using(Transaction myTransa = myDatabase.TransactionManager.StartTransaction())
            {

            try
            {
                ShapeLib.ShapeType shpType = ShapeLib.ShapeType.PolyLine;
                IntPtr hSHP;
                if (shprecordno == 0)
                {
                    //创建线shapefile
                   hSHP =  ShapeLib.SHPCreate(filename, shpType);

                }
                else
                {
                   hSHP =  ShapeLib.SHPOpen(filename, "rb+");
                }

                if (hSHP.Equals(IntPtr.Zero))
                {
                    return 0;
                }

                DBObjectCollection ployCol = GetPolyLine(toshp);

                if (ployCol == null)
                {
                    myTransa.Abort();
                    return -1;
                }

               

                ArrayList apartStart = new ArrayList();
                //定义一个polyline  
                Polyline pl = new Polyline();
                

                Point3dCollection p3ds = new Point3dCollection();
               
                for (int i = 0; i < ployCol.Count; i++)
                {

                    ArrayList xcoord = new ArrayList();
                    ArrayList ycoord = new ArrayList();
                    pl = myTransa.GetObject(ployCol[i].ObjectId, OpenMode.ForWrite) as Polyline;

                    apartStart.Add(xcoord.Count);
                    p3ds = GetPLVertices3D(pl, false);

                    for (int t = 0; t < p3ds.Count; t++)
                    {
                        xcoord.Add(Math.Round(p3ds[t].X, 3));    //精度默认为3位
                        ycoord.Add(Math.Round(p3ds[t].Y, 3));
                    }

                    X = new double[xcoord.Count];
                    Y = new double[ycoord.Count];
                    double[] Z = new double[xcoord.Count];
                    double[] M = new double[xcoord.Count];

                    xcoord.CopyTo(X);
                    ycoord.CopyTo(Y);
                    IntPtr pshpObj;

                    pshpObj = ShapeLib.SHPCreateSimpleObject(shpType, xcoord.Count, X, Y, Z);  //创建简单图形a

                     int iRet = ShapeLib.SHPWriteObject(hSHP, -1, pshpObj);
                    //int iRet = ShapeLib.SHPWriteObject(hSHP, apartStart.Count, pshpObj);  //实验第二个参数ishape----the entity number of the shape to write
                    ShapeLib.SHPDestroyObject(pshpObj);


                    shprecordno++;
                    proBar.PerformStep();
                }

                  
                    
                   /* else
                    {
                        int[] part = new int[apartStart.Count];
                        apartStart.CopyTo(part);
                        ShapeLib.PartType[] apartType = new ShapeLib.PartType[apartStart.Count];
                        for (int c = 0; c < apartStart.Count; c++)
                            apartType[c] = ShapeLib.PartType.Ring;
                        pshpObj = ShapeLib.SHPCreateObject(shpType, -1, apartStart.Count, part, apartType, xcoord.Count, X, Y, Z, M);
                    }*/

                 
                    ShapeLib.SHPClose(hSHP);
                    myTransa.Commit();
                
            }

            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                myTransa.Abort();

            }
           

            }
            

            return shprecordno;
        }

        public static int CreatDBF(string filename, System.Data.DataTable Filed, int shprecordno, int dbfrecordno,ArrayList AttrList)
        {

            bool iscreate = false;
            IntPtr hDbf;
            if (dbfrecordno == 0)
            {
                // Create a file to write to.
                hDbf = ShapeLib.DBFCreate(filename);
                iscreate = true;
            }
            else
                hDbf = ShapeLib.DBFOpen(filename, "rb+");
            if (hDbf.Equals(IntPtr.Zero))
            {
                //Console.WriteLine("Error:  Unable to create {0}.dbf!", FILENAME);
                return 0;
            }

            int iRet = 0;

            if (iscreate)
            {

                for (int i = 0; i < Filed.Rows.Count; i++)
                {
                    switch (Filed.Rows[i][1].ToString())
                    {
                        case "String":
                            iRet = ShapeLib.DBFAddField(hDbf, Filed.Rows[i][0].ToString(), ShapeLib.DBFFieldType.FTString, Convert.ToInt32(Filed.Rows[i][2].ToString()), Convert.ToInt32(Filed.Rows[i][3].ToString()));
                            break;
                        case "Double":
                            iRet = ShapeLib.DBFAddField(hDbf, Filed.Rows[i][0].ToString(), ShapeLib.DBFFieldType.FTDouble, Convert.ToInt32(Filed.Rows[i][2].ToString()), Convert.ToInt32(Filed.Rows[i][3].ToString()));
                            break;
                        case "Date":
                            iRet = ShapeLib.DBFAddField(hDbf, Filed.Rows[i][0].ToString(), ShapeLib.DBFFieldType.FTDate, Convert.ToInt32(Filed.Rows[i][2].ToString()), Convert.ToInt32(Filed.Rows[i][3].ToString()));
                            break;
                        default: break;
                    }
                }

                
            }

            //int attr = 0;
            //填写属性记录
           for (int iShape = dbfrecordno; iShape < shprecordno; iShape++)
            {
                
                //市政工程SHP字段相对简单，目前先安排一个简版 

                for (int k = 0; k < Filed.Rows.Count; k++)
                {
                    iRet = ShapeLib.DBFWriteStringAttribute(hDbf, iShape, k,AttrList[k].ToString()); 
                }
                   

            }
            ShapeLib.DBFClose(hDbf);
            return (shprecordno);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjCol"></param>
        /// <returns></returns>
        private static DBObjectCollection GetPolyLine(DBObjectCollection ObjCol)
        {
           

            Document myDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database myDatabase = myDoc.Database;
            Editor myEditor = myDoc.Editor;

            DBObjectCollection polycol = new DBObjectCollection();  //polyline容器

           
            int count = ObjCol.Count;  //记录对象的个数


            for (int i = 0; i < count; i++)
            {
                if (ObjCol[i].GetType().Name.ToString() == "Polyline")
                {
                    polycol.Add(ObjCol[i]);
                }
                else
                {

                    continue;
                }

            }
                

            return polycol;
        }

        private static Point3dCollection GetPLVertices3D(Polyline pl, bool isclosed)
        {
            Point3dCollection p3ds = new Point3dCollection();
            Point3d p3t = new Point3d();

            int numofVer = pl.NumberOfVertices;

            if (isclosed)
            {
                for (int i = 0; i < numofVer-1; i++)
                {

                    p3t = pl.GetPoint3dAt(i);

                    p3ds.Add(p3t);

                }
            }
            else
            {
                for (int i = 0; i < numofVer; i++)
                {

                    p3t = pl.GetPoint3dAt(i);

                    p3ds.Add(p3t);

                }


            }

            return p3ds;
        }

    }

}
