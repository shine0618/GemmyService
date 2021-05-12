using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Controllers
{
    public class JCSelectionController : Controller
    {
        // GET: JCSelection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult main()
        {
            return View();
        }
        public ActionResult selectType()
        {
            return View();
        }

       
        public ActionResult ProductDetail()
        {
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
        public ActionResult office()
        {
          
            //如果语言是默认的话
            if (Session["PageLanguage"]==null)
            {
                Session["PageLanguage"] = "default";
            }

            
            Session.Timeout = 9600;


            return View();
        }


        /// <summary>
        /// 动态加载语言
        /// </summary>
        /// <returns></returns>
        public ActionResult qwertyui()
        {
            return View();
        }

        public ActionResult qwertyui2()
        {
            return View();
        }

    }
}