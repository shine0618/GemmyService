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

namespace GemmyLanguageManageTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ArrayList keylist = new ArrayList();
        private ArrayList valuelist = new ArrayList();
        private void importbtn_Click(object sender, EventArgs e)
        {
            string jsonfile = "../../../json/text-zh.json";//JSON文件路径

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
            for (int i = 0; i < keylist.Count; i++)
            {
                ((DataTable)jsondgv.DataSource).Rows.Add();
                jsondgv.Rows[i].Cells[0].Value = keylist[i].ToString();
                jsondgv.Rows[i].Cells[1].Value = valuelist[i].ToString();
            }

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            GetDgvToTable(jsondgv);
            string jsonstr = DataTableToJsonWithJsonNet(hst);
            CreatNewJson("text-en.json", jsonstr);
        }

        private Hashtable hst = new Hashtable();

        public void GetDgvToTable(DataGridView dgv)
        {




            // 循环行
            for (int i = 0; i < dgv.Rows.Count; i++)
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
                string path = "../../../json" + @"\" + Name;//System.IO.Directory.GetCurrentDirectory() + @"\" + Name;
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
    }
}
