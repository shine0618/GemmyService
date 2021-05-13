using _1GemmyModel.Model.ModelProductOffice;
using _2GemmyBusness.BLL.BLLOfficeDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Controllers
{
    public class JCSelectionController : Controller
    {

        #region 字段
        private BLL_Office_desk bll_desk = new BLL_Office_desk();

        #endregion
        // GET: JCSelection
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult main()
        {
            //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;
            return View();
        }

        /// <summary>
        /// 第二集办公
        /// </summary>
        /// <returns></returns>
        public ActionResult office()
        {

            //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;
            return View();
        }


        public  ActionResult OfficeStandards(string domain,string Type,string recommend)
        {
           
            //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;



            ViewBag.domain = domain;
            ViewBag.recommend = recommend;
            ViewBag.Type = Type;

            return View();
        }

        [HttpGet]
        public JsonResult GetOfficeStards(string domain,string Type, string recommend, string Order,string OrderValue, string langCode)
        {


            List<T_Product_office_desk> list = bll_desk.GetT_Product_office_desk(Type);


            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;


        }

        public ActionResult selectType()
        {
            return View();
        }

       
        public ActionResult ProductDetail(string domain, string Type, string recommend,string productGuid)
        {
            //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;

            ViewBag.domain = domain;
            ViewBag.recommend = recommend;
            ViewBag.Type = Type;

            return View();
        }


        public ActionResult Eservice()
        {
            return View();

        }

        public ActionResult office_Eservice()
        {

            return View();
        }

        public ActionResult office_Eservice_test()
        {

            return View();
        }

     


        /// <summary>
        /// 动态加载语言
        /// </summary>
        /// <returns></returns>
        public ActionResult qwertyui()
        {   //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;
            return View();
        }

        public ActionResult qwertyui2()
        {   //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;
            return View();
        }

    }
}