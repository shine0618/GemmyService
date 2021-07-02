using _1GemmyModel.Model.ModelProductOffice;
using _2GemmyBusness.BLL.BLLOfficeDesk;
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
   
        public ActionResult personal(string personal,string token)
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

        BLL_Office_desk_customer bll = new BLL_Office_desk_customer();

        [HttpGet]
        public JsonResult GetCustomerList(string langCode,string userName,string token)
        {
            List<T_Product_office_desk_customer> list = bll.GetT_Product_office_desk_customer(langCode, userName);
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
    }
}