using _1GemmyModel.Model.ModelProductOffice;
using _2GemmyBusness.BLL.BLLOfficeDesk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Controllers
{
    public class JCOfficeManagerController : Controller
    {
        // GET: JCOfficeManager
        public ActionResult Index(string msg)
        {
            if(!string.IsNullOrEmpty(msg))
            {
                msg = "";
            }
            ViewBag.msg = msg;
            return View();
        }

        BLL_Office_File bll_file = new BLL_Office_File();
        public ActionResult addT_file(T_Office_Files model)
        {


           int n =  bll_file.AddT_Office_Files(model);

            if(n>0)
            {
                return RedirectToAction("Index", "JCOfficeManager", new { msg = "添加成功！！" });

            }
            else
            {
                return RedirectToAction("Index", "JCOfficeManager", new { msg = "添加失败！！" });
            }

        }



        #region 上传资料

        public JsonResult Add_File1()
        {
            //得到了文件的流对象
            var oFile = Request.Files["file1"];
            //T_SRM_File file = bll_file.AddFile(oFile.FileName, "S_File1");

            string guid = System.Guid.NewGuid().ToString("N");
            string extension = System.IO.Path.GetExtension(oFile.FileName);//扩展名

          

            //根据原文件名存储数据库
            var oStream = oFile.InputStream;
            //  写文件核心代码：
            byte[] bytes = new byte[oStream.Length];
            oStream.Read(bytes, 0, bytes.Length);
            //   设置当前流的位置为流的开始
            oStream.Seek(0, SeekOrigin.Begin);

            // 获取路径
            HttpContext context1 = System.Web.HttpContext.Current;

            string datef = DateTime.Now.ToString("yyyyMMdd");


            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"Upload\office\"+ datef;
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }


            System.IO.Directory.CreateDirectory("/Upload/office/" + datef);



            string T_TR_nameOriginal3 = oFile.FileName;
            string T_TR_nameGuid3 = guid + extension;
            string T_TR_nameExtend3 = extension;
            string fileurl = "/Upload/office/" + datef + "/" + T_TR_nameGuid3;
         

            string uploadpath = context1.Server.MapPath(fileurl);

            //   把 byte[] 写入文件
            FileStream fs = new FileStream(uploadpath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
            Console.WriteLine(oStream);

            FileInfo fiinfo = new System.IO.FileInfo(filepath  +"/" + T_TR_nameGuid3);
            long fsize = fiinfo.Length;

            string rtstr = string.Format("{0}|{1}|{2}|{3}|{4}", T_TR_nameOriginal3, T_TR_nameGuid3, T_TR_nameExtend3, fileurl, fsize/1024);
            return Json(rtstr, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上传缩略图
        /// </summary>
        /// <returns></returns>
        public JsonResult Add_File2()
        {
            //得到了文件的流对象
            var oFile = Request.Files["file2"];
            //T_SRM_File file = bll_file.AddFile(oFile.FileName, "S_File1");

            string guid = System.Guid.NewGuid().ToString("N");
            string extension = System.IO.Path.GetExtension(oFile.FileName);//扩展名



            //根据原文件名存储数据库
            var oStream = oFile.InputStream;
            //  写文件核心代码：
            byte[] bytes = new byte[oStream.Length];
            oStream.Read(bytes, 0, bytes.Length);
            //   设置当前流的位置为流的开始
            oStream.Seek(0, SeekOrigin.Begin);

            // 获取路径
            HttpContext context1 = System.Web.HttpContext.Current;

            string datef = DateTime.Now.ToString("yyyyMMdd");


            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"Upload\office\" + datef;
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }


            System.IO.Directory.CreateDirectory("/Upload/office/" + datef);



            string T_TR_nameOriginal3 = oFile.FileName;
            string T_TR_nameGuid3 = guid + extension;
            string T_TR_nameExtend3 = extension;
            string fileurl = "/Upload/office/" + datef + "/" + T_TR_nameGuid3;


            string uploadpath = context1.Server.MapPath(fileurl);

            //   把 byte[] 写入文件
            FileStream fs = new FileStream(uploadpath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
            Console.WriteLine(oStream);

            FileInfo fiinfo = new System.IO.FileInfo(filepath + "/" + T_TR_nameGuid3);
            long fsize = fiinfo.Length;

            string rtstr = string.Format("{0}|{1}|{2}|{3}|{4}", T_TR_nameOriginal3, T_TR_nameGuid3, T_TR_nameExtend3, fileurl, fsize / 1024);
            return Json(rtstr, JsonRequestBehavior.AllowGet);
        }

        


        #endregion
    }
}