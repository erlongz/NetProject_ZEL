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

namespace MunicipalEngineering
{
    public partial class FileOrgForm : Form
    {
        public FileOrgForm()
        {
            InitializeComponent();
        }

        private string Path1 = @"C:\Users\CH4Y-ZEL\Desktop\chsy1708-0033---盛庭丽景10kV电力电缆配套工程放线";
         private   string PathResult = @"C:\Users\CH4Y-ZEL\Desktop\chsy1708-0033---盛庭丽景10kV电力电缆配套工程放线(成果)";
        private List<string> subFile = new List<string>();
        private void Sort_button_Click(object sender, EventArgs e)
        {
            if(Sort_button.Text == "完 成")
            {


                this.Close();
            }
            //1.新建一个文件夹，命名为PATH（成果）

           
            
            try
            {
                if (!Directory.Exists(PathResult))
                {

                    Directory.CreateDirectory(PathResult);

                }
                //2.建立三个子文件夹 

                string SHP = PathResult + "\\SHP";
                string DOC = PathResult + "\\DOC";
                string FFT = PathResult + "\\分幅图";
                if (!Directory.Exists(SHP))
                {

                    Directory.CreateDirectory(SHP);

                }
                if (!Directory.Exists(DOC))
                {

                    Directory.CreateDirectory(DOC);

                }
                if (!Directory.Exists(FFT))
                {

                    Directory.CreateDirectory(FFT);

                }

                //3.把对应的文件放到对应的文件夹下

                for (int i = 0; i < subFile.Count; i++)
                {


                    string extent = Path.GetExtension(subFile[i]);

                    if (extent.Contains("doc") || extent.Contains("docx"))
                    {

                          File.Copy(subFile[i], DOC+"\\"+Path.GetFileName(subFile[i]),true);

                       // CopyDir(subFile[i], DOC );
                    }

                    if (extent.Contains("dbf") || extent.Contains("sbn")|| extent.Contains("sbx") || extent.Contains("shp") || extent.Contains("shx"))
                    {

                        // File.Copy(subFile[i], DOC+"\\");

                       // CopyDir(subFile[i], SHP );
                        File.Copy(subFile[i], SHP + "\\" + Path.GetFileName(subFile[i]), true);
                    }

                    if(extent.Contains("dwg"))
                    {


                        if(Path.GetFileName(subFile[i]).Contains("-"))
                        {
                           // CopyDir(subFile[i], FFT );
                            File.Copy(subFile[i],FFT + "\\" + Path.GetFileName(subFile[i]), true);

                        }
                        else
                        {


                           // CopyDir(subFile[i],PathResult);
                            File.Copy(subFile[i], PathResult + "\\" + Path.GetFileName(subFile[i]), true);
                        }
                    }



                }

                //4.加载树结构 

                if (Directory.Exists(Path1))
                {

                    string fileNameOri = Path.GetFileName(PathResult);

                    // this.directoryTree.Nodes.Add(fileNameOri);
                    this.CG_treeView.Nodes.Add(fileNameOri);


                    PaintTreeView(this.CG_treeView.Nodes[0], PathResult);
                }

                CG_treeView.ExpandAll();
               

            }
            catch(Exception ex)
            {

                throw;
            }


            subFile.Clear();
            Sort_button.Text = "完 成";
        }

        private void FileOrgForm_Load(object sender, EventArgs e)
        {
            if(Directory.Exists(Path1))
            {

                string fileNameOri = Path.GetFileName(Path1);

               // this.directoryTree.Nodes.Add(fileNameOri);
                this.YS_treeView.Nodes.Add(fileNameOri);


                PaintTreeView1(this.YS_treeView.Nodes[0], Path1);
                YS_treeView.ExpandAll();
            }
           
        }


        private void PaintTreeView1(TreeNode tNode, string fullPath)
        {

            try
            {
                // tView.Nodes.Clear();//清空 TreeView

                DirectoryInfo dirs = new DirectoryInfo(fullPath);//获取程序所在路径的目录对象 
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象 
                int dirCount = dir.Count(); //获得文件夹对象数量 
                int fileCount = file.Count(); //获取文件对象数量 



                //增加一个主目录--即项目主文件夹  


                //循环文件夹 

               for (int i = 0; i < dirCount; i++)
                {


                   // tNode.Nodes.Add(dir[i].Name);

                    if(dir[i].Name.Contains("SHP")|| dir[i].Name.Contains("shp")|| dir[i].Name.Contains("DOC") || dir[i].Name.Contains("doc") || dir[i].Name.Contains("分幅图") )
                    {
                        string pathNode = fullPath + "\\" + dir[i].Name;
                        GetSonFileNode(tNode, pathNode);

                    }
                    else
                    {
                        continue;
                    }

                }

                //获取文件对象 

                for (int j = 0; j < fileCount; j++)
                {
                    subFile.Add(fullPath + "\\" + file[j].Name);

                    tNode.Nodes.Add(file[j].Name);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n出错位置为：Form1.PaintTreeView()");
            }


        }
        private void PaintTreeView(TreeNode tNode, string fullPath)
        {

            try
            {
                // tView.Nodes.Clear();//清空 TreeView

                DirectoryInfo dirs = new DirectoryInfo(fullPath);//获取程序所在路径的目录对象 
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象 
                int dirCount = dir.Count(); //获得文件夹对象数量 
                int fileCount = file.Count(); //获取文件对象数量 



                //增加一个主目录--即项目主文件夹  


                //循环文件夹 

                for (int i = 0; i < dirCount; i++)
                {


                    tNode.Nodes.Add(dir[i].Name);

                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(tNode.Nodes[i], pathNode);
                }

                //获取文件对象 

                for (int j = 0; j < fileCount; j++)
                {


                    tNode.Nodes.Add(file[j].Name);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n出错位置为：Form1.PaintTreeView()");
            }


        }


        private bool GetMultiNode(TreeNode tNode, string path)
        {
            if (Directory.Exists(path) == false)
            {


                return false;
            }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;


            if (sumcount == 0)
            { return false; }


            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                tNode.Nodes.Add(dir[j].Name);
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(tNode.Nodes[j], pathNodeB);
            }


            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                tNode.Nodes.Add(file[j].Name);
            }
            return true;
        }

        private bool GetSonFileNode(TreeNode tNode, string path)
        {

            if (Directory.Exists(path) == false)
            {


                return false;
            }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;


            if (sumcount == 0)
            { return false; }


            //循环文件
            for (int j = 0; j < filecount; j++)
            {

                subFile.Add(path + "\\" + file[j].Name);
                tNode.Nodes.Add(file[j].Name);
            }
            return true;
        }


        private void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    aimPath += System.IO.Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建
                if (!System.IO.Directory.Exists(aimPath))
                {
                    System.IO.Directory.CreateDirectory(aimPath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (System.IO.Directory.Exists(file))
                    {
                        CopyDir(file, aimPath + System.IO.Path.GetFileName(file));
                    }
                    // 否则直接Copy文件
                    else
                    {
                        System.IO.File.Copy(file, aimPath + System.IO.Path.GetFileName(file), true);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            TreeNode TN2 = CG_treeView.SelectedNode;
            try
            {

                if (TN2 != null)
                {

                    TreeNode TNP = TN2.Parent;

                    if (TNP.Text == "SHP" || TNP.Text == "DOC" || TNP.Text == "分幅图")
                    {

                        string DelPath = Path1 + "(成果)" + "\\" + TNP.Text + "\\" + TN2.Text;

                        File.Delete(DelPath);
                    }
                    else
                    {

                      string DelPath = Path1 + "(成果)" + "\\" + TN2.Text;
                        File.Delete(DelPath);
                    }

                }

                TN2.Remove();  
            }
            catch(Exception ex)
            {

                throw;
            }
            
        }

        private void Add_button_Click(object sender, EventArgs e)
        {

            TreeNode TN = YS_treeView.SelectedNode;
            try
            {

                string fileName = TN.Text;
                DirectoryInfo dirs = new DirectoryInfo(Path1); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象

                if(File.Exists(Path1 + "\\" +fileName))
                {

                    CG_treeView.Nodes[0].Nodes.Add(fileName);
                    File.Copy(Path1 + "\\" + fileName,Path1+ "(成果)"+"\\"+fileName);

                    //根据实际情况完善
                   
                }
                else if(File.Exists(Path1 + "\\SHP\\" + fileName)|| File.Exists(Path1 + "\\shp\\" + fileName))
                {

                    foreach(TreeNode tn in CG_treeView.Nodes[0].Nodes)
                    {

                        if(tn.Text =="SHP")
                        {

                            tn.Nodes.Add(fileName);
                        }

                    }

                    File.Copy(Path1 + "\\" + fileName, Path1 + "(成果)" + "\\SHP\\" + fileName);
                }
                else if (File.Exists(Path1 + "\\DOC\\" + fileName) || File.Exists(Path1 + "\\doc\\" + fileName))
                {


                    foreach (TreeNode tn in CG_treeView.Nodes[0].Nodes)
                    {

                        if (tn.Text == "DOC")
                        {

                            tn.Nodes.Add(fileName);
                        }

                    }

                    File.Copy(Path1 + "\\" + fileName, Path1 + "(成果)" + "\\DOC\\" + fileName);

                }
                else if (File.Exists(Path1 + "\\分幅图\\" + fileName) || File.Exists(Path1 + "\\分幅\\" + fileName))
                {
                    foreach (TreeNode tn in CG_treeView.Nodes[0].Nodes)
                    {

                        if (tn.Text == "分幅图")
                        {

                            tn.Nodes.Add(fileName);
                            
                        }

                    }

                    File.Copy(Path1 + "\\" + fileName, Path1 + "(成果)" + "\\分幅图\\" + fileName);

                }


     

               

            }
            catch
            {



            }

        }
    }
}
