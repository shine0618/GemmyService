using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using _1GemmyModel;
using _2GemmyBusness.BLL;
using _2GemmyBusness.BLL.BLLSystem;
using _2GemmyBusness.BLL.BLLOfficeDesk;
using _1GemmyModel.Model.ModelSystem;
using _1GemmyModel.Model.ModelProductOffice;
using System.Net;
using System.Net.Mail;

namespace _6.GemmyLanguageTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        #region 获取语言
        BLL_SYS_language bll_langu = new BLL_SYS_language();
        public void BindingLangu()
        {
            List<T_SYS_Language> list = bll_langu.GetT_SYS_Language();
            foreach (T_SYS_Language m in list)
            {
                this.cbx_language.Items.Add(m.LanguageCode);
            }
            if (list.Count > 0)
            {
                this.cbx_language.SelectedIndex = 0;
            }

        }

        #endregion
        #region 语言管理
        private ArrayList language = new ArrayList();
        private ArrayList keylist = new ArrayList();
        private ArrayList valuelist = new ArrayList();
        private Hashtable multihst = new Hashtable();
        private Hashtable mainhst = new Hashtable();
        private void importbtn_Click(object sender, EventArgs e)
        {
            mainhst.Clear();
            multihst.Clear();
            string jsonfile = "../../json/text-" + cbx_language.SelectedItem.ToString() + ".json";//JSON文件路径
            string jsonmainfile = "../../json/text.json";//JSON文件路径
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o["language"];
                    foreach (JProperty item in value)
                    {
                        multihst.Add(item.Name, item.Value);
                    }
                    //return value;
                }
            }
            using (System.IO.StreamReader file1 = System.IO.File.OpenText(jsonmainfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file1))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o["language"];
                    foreach (JProperty item in value)
                    {
                        mainhst.Add(item.Name, item.Value);
                    }
                    //return value;
                }
            }
            insertdgv();
        }

        private void insertdgv()
        {
            jsondgv.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            jsondgv.DataSource = dt;
            jsondgv.Columns[0].Width = jsondgv.Width / 2 - 80;
            jsondgv.Columns[1].Width = jsondgv.Width / 2 + 60;
            jsondgv.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            jsondgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            jsondgv.Columns[0].ReadOnly = true;
            int num = 0;
            foreach (DictionaryEntry a in mainhst)
            {
                ((DataTable)jsondgv.DataSource).Rows.Add();
                jsondgv.Rows[num].Cells[0].Value = a.Key;
                if (multihst.ContainsKey(a.Key))
                {
                    jsondgv.Rows[num].Cells[1].Value = multihst[a.Key].ToString();
                }

                num++;
            }

        }
        private void insertmaindgv()
        {
            jsonmaindgv.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            jsonmaindgv.DataSource = dt;
            jsonmaindgv.Columns[0].Width = jsonmaindgv.Width / 2 - 80;
            jsonmaindgv.Columns[1].Width = jsonmaindgv.Width / 2 + 60;
            jsonmaindgv.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            jsonmaindgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //jsonmaindgv.Columns[1].ReadOnly = true;
            for (int i = 0; i < keylist.Count; i++)
            {
                ((DataTable)jsonmaindgv.DataSource).Rows.Add();
                jsonmaindgv.Rows[i].Cells[0].Value = keylist[i].ToString();
                jsonmaindgv.Rows[i].Cells[1].Value = valuelist[i].ToString();
            }

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            GetDgvToTable(jsondgv);
            string jsonstr = DataTableToJsonWithJsonNet(hst);
            CreatNewJson("text-" + cbx_language.SelectedItem.ToString() + ".json", jsonstr);
        }

        private Hashtable hst = new Hashtable();

        public void GetDgvToTable(DataGridView dgv)
        {
            hst.Clear();
            // 循环行
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                hst.Add(dgv.Rows[i].Cells[0].Value, dgv.Rows[i].Cells[1].Value);
            }

        }
        public void GetMainDgvToTable(DataGridView dgv)
        {
            hst.Clear();
            // 循环行
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                hst.Add(dgv.Rows[i].Cells[0].Value, dgv.Rows[i].Cells[1].Value);
            }

        }
        public string DataTableToJsonWithJsonNet(Hashtable table)
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(table);
            JsonString = "{\"language\":" + JsonString + "}";
            return JsonString;
        }
        private void CreatNewJson(string Name, string json)
        {
            try
            {
                string path = "../../json" + @"\" + Name;//System.IO.Directory.GetCurrentDirectory() + @"\" + Name;
                FileStream fsvbs = new FileStream(path, FileMode.Create, FileAccess.Write);
                fsvbs.Close();
                StreamWriter runBat = new StreamWriter(path);
                runBat.Write(json);
                runBat.Close();
            }
            catch (Exception ex)
            {

            }
        }


        public void EditJson(string jsonstr, string strPath)
        {
            //string strJson = File.ReadAllText(strPath, Encoding.UTF8);
            JObject oJson = JObject.Parse(jsonstr); //using Newtonsoft.Json.Linq
            var o = oJson["language"];
            foreach (JProperty a in o)
            {
                int num = 0;
                for (int i = 0; i < jsondgv.RowCount; i++)
                {
                    if (a.Name == jsondgv.Rows[i].Cells[0].Value.ToString())
                    {
                        num = i;
                    }
                }
                a.Value = jsondgv.Rows[num].Cells[1].Value.ToString();
            }
            string strConvert = Convert.ToString(oJson); //将json装换为string
            File.WriteAllText(strPath, strConvert); //将内容写进json文件中
        }
        public void EditMainJson(string jsonstr, string strPath)
        {
            //string strJson = File.ReadAllText(strPath, Encoding.UTF8);
            JObject oJson = JObject.Parse(jsonstr); //using Newtonsoft.Json.Linq
            var o = oJson["language"];
            foreach (JProperty a in o)
            {
                int num = 0;
                for (int i = 0; i < jsonmaindgv.RowCount - 1; i++)
                {
                    if (a.Name == jsonmaindgv.Rows[i].Cells[0].Value.ToString())
                    {
                        num = i;
                    }
                }
                a.Value = jsonmaindgv.Rows[num].Cells[1].Value.ToString();
            }
            string strConvert = Convert.ToString(oJson); //将json装换为string
            File.WriteAllText(strPath, strConvert); //将内容写进json文件中
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            GetDgvToTable(jsondgv);
            string jsonstr = DataTableToJsonWithJsonNet(hst);
            EditJson(jsonstr, "../../json/text-" + cbx_language.SelectedItem.ToString() + ".json");
        }

        private void improtmainbtn_Click(object sender, EventArgs e)
        {
            keylist.Clear();
            valuelist.Clear();
            string jsonfile = "../../json/text.json";//JSON文件路径

            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o["language"];
                    foreach (JProperty item in value)
                    {
                        keylist.Add(item.Name);
                        valuelist.Add(item.Value);
                    }
                    //return value;
                }
            }
            insertmaindgv();
        }

        private void updatemainbtn_Click(object sender, EventArgs e)
        {
            GetMainDgvToTable(jsonmaindgv);
            string jsonstr = DataTableToJsonWithJsonNet(hst);
            EditMainJson(jsonstr, "../../json/text.json");
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {

        }

        private void languagecbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingLangu();
            dgv_FileInsert();
        }
        #endregion
        #region 文件上传
        BLL_Office_File bll_file = new BLL_Office_File();
        T_Office_Files t_files = new T_Office_Files();
        nsHashtable headers = new nsHashtable();
        List<string> partList = new List<string>();
        List<string> languageList = new List<string>();
        List<bool> lockList = new List<bool>();

        public void dgv_FileInsert()//dgv_File格式生成
        {
            headers.Add("partType", 100);
            headers.Add("Mode", 250);
            headers.Add("FileName", 200);
            headers.Add("Nature", 300);
            headers.Add("Information", 500);
            headers.Add("Path", 100);
            headers.Add("Size", 80);
            headers.Add("Type", 80);
            headers.Add("Lock", 70);
            headers.Add("Language", 80);
            headers.Add("thumbnailImg", 100);
            partList = new List<string> {
            "桌子",
            "认证"
            };
            languageList = new List<string> {
            "zh",
            "en"
            };
            lockList = new List<bool> {
            true,
            false
            };
            for (int i = 0; i < this.headers.Count; i++)
            {
                string keyi = headers.list[i].ToString();//找到第i个key
                DataGridViewTextBoxColumn tbColumn = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn cbColumn = new DataGridViewComboBoxColumn();
                if (keyi == "")
                {
                    cbColumn.DataSource = partList;
                    this.dgv_fileUpload.Columns.Add(cbColumn);
                }
                else
                {
                    this.dgv_fileUpload.Columns.Add(tbColumn);
                }
                //this.bQDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;//禁用排序
                this.dgv_fileUpload.Columns[i].Name = keyi;
                this.dgv_fileUpload.Columns[i].HeaderText = keyi;//设置标题行文字
                this.dgv_fileUpload.Columns[i].Width = Convert.ToInt16(headers[keyi]);//设置列宽度
            }
        }



        private void toolbtn_addFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openUserFileWin = new OpenFileDialog();
            openUserFileWin.Multiselect = true;//允许多选
            openUserFileWin.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //定义打开的默认文件夹位置
            openUserFileWin.Title = "请选择添加一个文件";
            if (openUserFileWin.ShowDialog() == DialogResult.OK)//显示打开文件的窗口
            {
                string[] filespathlist = openUserFileWin.FileNames;
                foreach (var item in filespathlist)
                {
                    pathhst.Add(Path.GetFileNameWithoutExtension(item), item);
                }
                docPathList(filespathlist);//文件地址清单加入表格
                //pathhst.Add(Path.GetFileNameWithoutExtension(openUserFileWin.FileNames[0].ToString()), openUserFileWin.FileNames[0].ToString());


            }
        }

        private void toolbtn_addFolderFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择一个文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹为空或者没有被选中", "提示");
                    return;
                }
                string folderpath = dialog.SelectedPath;
                List<string> names = new List<string>();
                AddDirFiles(folderpath, ref names);
                String[] nameslist = names.ToArray();
                docPathList(nameslist);//文件地址清单加入表格
            }
        }

        private void toolbtn_clearRow_Click(object sender, EventArgs e)
        {
            string columnindex = "";
            foreach (DataGridViewCell cell in this.dgv_fileUpload.SelectedCells)
            {
                if (columnindex == "")
                {
                    this.dgv_fileUpload.Rows.RemoveAt(cell.RowIndex);//删除行
                    columnindex = cell.ColumnIndex.ToString();
                }
                else if (columnindex == cell.ColumnIndex.ToString())
                {
                    this.dgv_fileUpload.Rows.RemoveAt(cell.RowIndex);//删除行
                }
            }
            this.dgv_fileUpload.ClearSelection();
        }

        private void toolbtn_clearAll_Click(object sender, EventArgs e)
        {
            this.dgv_fileUpload.Rows.Clear();//清除所有行
        }
        Hashtable pathhst = new Hashtable();
        private void docPathList(string[] filespaths)
        {
            foreach (var filepath in filespaths)
            {
                string extendedName = Path.GetExtension(filepath);       //获得文件扩展名
                if (extendedName != "")
                { extendedName = extendedName.Substring(1, extendedName.Length - 1); }//去掉扩展名前面的小点
                string fileName1 = Path.GetFileNameWithoutExtension(filepath);//获得文件名
                string foldName1 = Path.GetDirectoryName(filepath);
                foldName1 = foldName1.Substring(foldName1.LastIndexOf(@"\") + 1);//包含文件的文件夹名称，方便分辨文件类型
                string creatdate = File.GetCreationTime(filepath).ToString();
                string modifydate = File.GetLastWriteTime(filepath).ToString();
                FileInfo fiinfo = new System.IO.FileInfo(filepath);
                long fsize = fiinfo.Length;
                //string filesize = fsize.ToString() + "B";
                //if (fsize > 1024)
                //{
                //    fsize = (fsize / 1024);
                //    filesize = fsize.ToString() + "KB";
                //    if (fsize > 1024)
                //    {
                //        fsize = (fsize / 1024);
                //        filesize = fsize.ToString() + "MB";
                //    }
                //}
                //string date = DateTime.Now.ToString("yyyymmdd");
                string serverPath = "/Upload/office/" + DateTime.Now.ToString("yyyyMMdd") + "/" + Path.GetFileName(filepath);

                                //docListAddFile(fileName1, extendedName, filepath, foldName1, creatdate, modifydate, ini.ConfigClass.userName, filesize);//写入表格
                docListAddFile(fileName1, serverPath, fsize, extendedName);
            }
        }


        private void docListAddFile(string FileName, string Path, long Size, string Type)
        {
            int index = this.dgv_fileUpload.Rows.Add();//数据表新增一行
            //this.dgv_fileUpload.Rows[index].Cells["partType"].Value = partType;
            //this.dgv_fileUpload.Rows[index].Cells["Mode"].Value = Mode;
            this.dgv_fileUpload.Rows[index].Cells["FileName"].Value = FileName;
            //this.dgv_fileUpload.Rows[index].Cells["Nature"].Value = Nature;
            //this.dgv_fileUpload.Rows[index].Cells["Information"].Value = Information;
            this.dgv_fileUpload.Rows[index].Cells["Path"].Value = Path;
            this.dgv_fileUpload.Rows[index].Cells["Size"].Value = Size;
            this.dgv_fileUpload.Rows[index].Cells["Type"].Value = Type;
            //this.dgv_fileUpload.Rows[index].Cells["Lock"].Value = Lock;
            //this.dgv_fileUpload.Rows[index].Cells["Language"].Value = Language;
            //this.dgv_fileUpload.Rows[index].Cells["thumbnailImg"].Value = thumbnailImg;
        }

        private void AddDirFiles(string dir, ref List<string> namelist)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] fis = di.GetFiles();

            foreach (FileInfo fi in fis)
            {
                namelist.Add(fi.FullName);

            }
            DirectoryInfo[] dis = di.GetDirectories();//目录下的子目录
            foreach (DirectoryInfo item in dis)
            {
                AddDirFiles(item.FullName, ref namelist);//循环遍历子目录
            }
        }

        private void lbx_partType_Click(object sender, EventArgs e)
        {
            string selstr = this.lbx_partType.SelectedItem.ToString();
            dgv_fileUpload.CurrentCell.Value = selstr;
            this.lbx_partType.Visible = false;
        }

        private void dgv_fileUpload_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Point po = dgv_fileUpload.CurrentCellAddress;
            if (po.X == dgv_fileUpload.Columns["partType"].Index)
            {
                Rectangle pointinfo = dgv_fileUpload.GetCellDisplayRectangle(po.X, po.Y, true);
                Point po1 = new Point(pointinfo.X + 2, pointinfo.Y + 50);
                if (po.Y > 17)
                {
                    po1 = new Point(pointinfo.X + 2, pointinfo.Y - 128);//调整选择框出现位置
                }

                lbx_partType.Location = po1;
                lbx_partType.Width = pointinfo.Width;
                lbx_partType.Items.Clear();
                foreach (string str in partList)
                {
                    lbx_partType.Items.Add(str);
                }
                lbx_partType.Height = 15 * partList.Count;
                lbx_partType.Visible = true;

            }
            else if (po.X == dgv_fileUpload.Columns["Lock"].Index)
            {
                Rectangle pointinfo = dgv_fileUpload.GetCellDisplayRectangle(po.X, po.Y, true);
                Point po1 = new Point(pointinfo.X + 2, pointinfo.Y + 50);
                if (po.Y > 17)
                {
                    po1 = new Point(pointinfo.X + 2, pointinfo.Y - 128);//调整选择框出现位置
                }

                lbx_Lock.Location = po1;
                lbx_Lock.Width = pointinfo.Width;
                lbx_Lock.Items.Clear();
                foreach (bool str in lockList)
                {
                    lbx_Lock.Items.Add(str);
                }
                lbx_Lock.Height = 15 * lockList.Count;
                lbx_Lock.Visible = true;
            }
            else if (po.X == dgv_fileUpload.Columns["Language"].Index)
            {
                Rectangle pointinfo = dgv_fileUpload.GetCellDisplayRectangle(po.X, po.Y, true);
                Point po1 = new Point(pointinfo.X + 2, pointinfo.Y + 50);
                if (po.Y > 17)
                {
                    po1 = new Point(pointinfo.X + 2, pointinfo.Y - 128);//调整选择框出现位置
                }

                lbx_Language.Location = po1;
                lbx_Language.Width = pointinfo.Width;
                lbx_Language.Items.Clear();
                foreach (string str in languageList)
                {
                    lbx_Language.Items.Add(str);
                }
                lbx_Language.Height = 15 * languageList.Count;
                lbx_Language.Visible = true;
            }
        }


        private void lbx_Lock_Click(object sender, EventArgs e)
        {
            bool selstr = bool.Parse(this.lbx_Lock.SelectedItem.ToString());
            dgv_fileUpload.CurrentCell.Value = selstr;
            this.lbx_Lock.Visible = false;
        }

        private void lbx_Language_Click(object sender, EventArgs e)
        {
            string selstr = this.lbx_Language.SelectedItem.ToString();
            dgv_fileUpload.CurrentCell.Value = selstr;
            this.lbx_Language.Visible = false;
        }



        private void dgv_fileUpload_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            lbx_partType.Visible = false;
            lbx_Lock.Visible = false;
            lbx_Language.Visible = false;
        }

        public void checkFileExists(string uri)
        {            
            if (!Directory.Exists(uri))
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(uri);
                req.Credentials = new NetworkCredential("renc", "Jc..111");
                req.Method = WebRequestMethods.Ftp.MakeDirectory;
                try
                {
                    FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                    response.Close();
                }
                catch (Exception)
                {
                    req.Abort();
                }
                req.Abort();
            }
        }
        string folduri = "ftp://" + "61.175.247.114:11001/httpinput/gemmyConfig/Upload/office/"+DateTime.Now.ToString("yyyyMMdd");
        public bool upLoad(string filename, string file,string foldpath)//文件上传
        {
            if (foldpath.EndsWith("/") == false) foldpath = foldpath + "/";
            checkFileExists(foldpath);
            bool issuccsee = false;
            FtpWebRequest reqFTP;
            string strResult = string.Empty;
            Stream strm = null;
            FileInfo fileInf = new FileInfo(filename);
            //string uri = "ftp://" + "61.175.247.114:11001/httpinput/gemmyConfig/Upload/office/" + "/" + file + ".png";            
            string uri = foldpath +DateTime.Now.ToString("yyyyMMdd") + file ;
            if (File.Exists(uri))
            {

                MessageBox.Show("文件已经存在!");



                return issuccsee;
            }
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential("renc", "Jc..111");
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                issuccsee = true;
            }
            catch (Exception ex)
            {
                strResult = "Upload Error" + ex.Message;
            }
            finally
            {
                strm.Close();
                fs.Close();
            }
            return issuccsee;
        }


        private void toolbtn_importRow_Click(object sender, EventArgs e)
        {
            if (dgv_fileUpload.SelectedRows.Count == 0 || dgv_fileUpload.SelectedRows.Count > 1)
            {
                return;
            }
            string columnindex = "";
            foreach (DataGridViewCell cell in this.dgv_fileUpload.SelectedCells)
            {
                bool impResult = false;
                if (columnindex == "")
                {
                    impResult = upLoad(pathhst[dgv_fileUpload.CurrentRow.Cells["FileName"].Value.ToString()].ToString(), dgv_fileUpload.CurrentRow.Cells["Path"].Value.ToString().Split('/').Last(), folduri);//
                    columnindex = cell.ColumnIndex.ToString();
                    Hashtable hst = dgvTohst(dgv_fileUpload);
                    //bll_file.InsertT_Office_Files(hst);
                }
                else if (columnindex == cell.ColumnIndex.ToString())
                {
                    impResult = upLoad(pathhst[dgv_fileUpload.CurrentRow.Cells["FileName"].Value.ToString()].ToString(), dgv_fileUpload.CurrentRow.Cells["Path"].Value.ToString().Split('/').Last(), folduri);//
                    Hashtable hst = dgvTohst(dgv_fileUpload);
                    //bll_file.InsertT_Office_Files(hst);
                }
                if (impResult == true)
                {
                    this.dgv_fileUpload.Rows.RemoveAt(cell.RowIndex);
                }
                else
                {
                    this.dgv_fileUpload.Rows[cell.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                this.dgv_fileUpload.Update();
            }
            this.dgv_fileUpload.ClearSelection();
        }

        public Hashtable dgvTohst(DataGridView dgv)
        {
            Hashtable hst = new Hashtable();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                hst.Add(dgv.Columns[i].HeaderText, dgv.Rows[0].Cells[i].Value);
            }
            return hst;
        }



        #endregion

        private void btn_sendemail_Click(object sender, EventArgs e)
        {
            //设置要调用的发送邮件的服务器
            SmtpClient smtp = new SmtpClient("smtp.qq.com");
            //创建发件人对象
            MailAddress from = new MailAddress("1194778796@qq.com");
            //创建收件人对象
            MailAddress to = new MailAddress("tangwj@qq.com");
            //要发送的邮件对象，包含四个内容要填充
            MailMessage mail = new MailMessage(from, to);
            //设置邮件的标题
            mail.Subject = "Test";
            mail.IsBodyHtml = true;
            //设置邮件的主题正文格式
            mail.Body = emailBody();
            //创建发件人身份验证凭证
            NetworkCredential cred = new NetworkCredential("1194778796@qq.com", "vjmyuabouewyghgc");
            smtp.Credentials = cred;
            //此服务器对象执行发送邮件功能
            smtp.Send(mail);
        }

        private string emailBody()
        {
            string emailBody = "";
            emailBody+= "<style>.alignleft{display:inline;float:left;}</style>\r\n" + "<div><img class=\"alignleft\" src=\"https://img01.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\" ></div><div><span style=\"color:#0f4c81\"><span style=\"font-family:微软雅黑\"><span style=\"line-height:1.2\"><span style=\"font-size:20px\">股票代码：603583<br>股票名称：捷昌驱动</span></span></span></span></div>"+"\r\n" +
                "<hr />\r\n" + "<div><span style=\"font - size:20px\">尊敬的用户：<br>首先感谢您使用GemmyConfiguration，本条邮件是用于激活您所注册的账号，请点击以下链接来进行账号的激活<br><a href=\"https://www.baidu.com\" > ClickMe</a><br>如有打扰之处，请多谅解!</span></div>";
            return emailBody;
        }
    }
}
