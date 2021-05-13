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
using _1GemmyModel.Model.ModelSystem;

namespace _6.GemmyLanguageTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BLL_SYS_language bll_langu = new BLL_SYS_language();

        #region 获取语言
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
        private ArrayList language = new ArrayList();
        private ArrayList keylist = new ArrayList();
        private ArrayList valuelist = new ArrayList();
        private Hashtable multihst = new Hashtable();
        private Hashtable mainhst = new Hashtable();
        private void importbtn_Click(object sender, EventArgs e)
        {
            mainhst.Clear();
            multihst.Clear();
            string jsonfile = "../../json/text-"+ cbx_language.SelectedItem.ToString()+".json";//JSON文件路径
            string jsonmainfile = "../../json/text.json";//JSON文件路径
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o["language"];
                    foreach (JProperty item in value)
                    {
                        multihst.Add(item.Name,item.Value);
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
            CreatNewJson("text-"+ cbx_language.SelectedItem.ToString()+".json", jsonstr);
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
            EditJson(jsonstr, "../../json/text-"+ cbx_language.SelectedItem.ToString()+".json");
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
        }
    }
}
