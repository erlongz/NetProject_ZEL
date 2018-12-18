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

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;


namespace MunicipalEngineering
{
    public partial class SHPForm_SZGC : Form
    {
        public SHPForm_SZGC()
        {
            InitializeComponent();
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
           /* FolderBrowserDialog folderName = new FolderBrowserDialog();

            if (folderName.ShowDialog() == DialogResult.OK)
            {
                GCLJ_textBox.Text = folderName.SelectedPath;
               

            }*/


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

                GCLJ_textBox.Text = folderName;

            }
            else
            {
                
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("未选择任何文件");
                return;
            }

           // string SHPFolderName = folderName + "\\SHP";

        }

        private void GCLJ_textBox_TextChanged(object sender, EventArgs e)
        {
            GEN_button.Text = "转 换";
        }

        private void GEN_button_Click(object sender, EventArgs e)
        {

            string SHPFolderName = null;
            if (GEN_button.Text == "完 成")
            {
                this.Close();
                return;
            }

            if (!string.IsNullOrEmpty(GCLJ_textBox.Text))
            {
               SHPFolderName = GCLJ_textBox.Text + "\\SHP";
            }
            else
            {
                //MessageBox.Show("请选择工程路径！");
                // this.Close();
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请选择工程路径！");
                return;
            }
            

           if (!Directory.Exists(SHPFolderName))
           {
               Directory.CreateDirectory(SHPFolderName);
           }

           string expFileName = SHPFolderName + "\\SZGC";



           if (string.IsNullOrEmpty(XMMC_textBox.Text) || string.IsNullOrEmpty(CLNR_textBox.Text) || string.IsNullOrEmpty(XMBH_textBox.Text))
           {
               //MessageBox.Show("请完善SHP字段信息");
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("请完善SHP字段信息");
               return;
           }
              int shprecordno = 0;
              int dbfrecordno = 0;

              Document myDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
              Database myDatabase = myDoc.Database;
              Editor myEditor = myDoc.Editor;

              //打开shp文件，写入特定字段,主要操作dbf表
             // string DbfFileName = SHPFolderName + "\\SZGC.dbf";


              #region 1、选择定线层所有实体
              TypedValue[] filList = new TypedValue[] {
                      new TypedValue((int)DxfCode.LayerName,"定线"),
                      new TypedValue ((int)DxfCode .Operator ,"<or"),
                      new TypedValue((int)DxfCode.Start, "*polyline"),                
                      new TypedValue ((int)DxfCode .Operator ,"OR>")
                  };

              DBObjectCollection EntCol = new DBObjectCollection();
              SelectionFilter filter = new SelectionFilter(filList);
              PromptSelectionResult PSREnt = myEditor.SelectAll(filter);
              //把实体添加到DBObjectCollection中  
              Entity entity1 = null;
              if (PSREnt.Status == PromptStatus.OK)
              {
                  using (Transaction trans = myDatabase.TransactionManager.StartTransaction())
                  {

                      SelectionSet SS = PSREnt.Value;

                      foreach (ObjectId id in SS.GetObjectIds())
                      {
                          entity1 = trans.GetObject(id, OpenMode.ForWrite) as Entity;
                          if (entity1 != null)
                          {
                              EntCol.Add(entity1);
                        
                          }
                      }

                      trans.Commit();
                  }
              }
              else
              {
                  myEditor.WriteMessage("没有选中实体，已退出...");
                  return;
              }

              #endregion


              double[] Xcoord = new double[] { };
              double[] Ycoord = new double[] { };

              //用DataTable创建市政工程SHP字段表 
              System.Data.DataTable SZDataT = new System.Data.DataTable();
              //创建列 

              progressBar1.Minimum = 0;
             // progressBar1.Maximum = EntCol.Count;
              progressBar1.Step = 1;
            
              SZDataT.Columns.Add("FieldName", typeof(string));
              SZDataT.Columns.Add("FiledType", typeof(string));
              SZDataT.Columns.Add("nWidth", typeof(Int32));
              SZDataT.Columns.Add("nDecimal", typeof(Int32));

              //写内容  

              SZDataT.Rows.Add( "SJSQBH","String", 50, 0);
              SZDataT.Rows.Add("CLNR", "String", 100, 0);
              SZDataT.Rows.Add("GCMC", "String", 100, 0);
              SZDataT.Rows.Add("QT", "String", 100, 0);

              //创建属性List

              ArrayList AttrList = new ArrayList(4);

              AttrList.Add(XMBH_textBox.Text);
              AttrList.Add(CLNR_textBox.Text);
              AttrList.Add(XMMC_textBox.Text);
              AttrList.Add(QT_textBox.Text);

              shprecordno = SHPTools.CreatSHP(expFileName, EntCol, shprecordno, progressBar1 ,ref Xcoord, ref Ycoord);
              dbfrecordno = SHPTools.CreatDBF(expFileName,SZDataT,shprecordno,dbfrecordno,AttrList );




            //MessageBox.Show(ProcessInfo);

             GEN_button.Text = "完 成";

              


              string ProcessInfo = "本次共转换了" + shprecordno.ToString() + "个对象!";

              Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(ProcessInfo);

             


        }

     

    }
}
