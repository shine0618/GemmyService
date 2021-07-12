using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Controllers
{
    public class JCManageController : Controller
    {
        // GET: JCManger
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagePage()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }

            return View();
        }
        public ActionResult test1()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }

            return View();
        }
    }
}