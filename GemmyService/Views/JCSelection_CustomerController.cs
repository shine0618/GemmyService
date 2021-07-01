using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Views
{
    public class JCSelection_CustomerController : Controller
    {
        // GET: JCSelection_Customer
   
        public ActionResult personal()
        {

            //如果语言是默认的话
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