using _2GemmyBusness.BLL.BLLOfficePartManage;
using _2GemmyBusness.BLL.BLLUserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Controllers
{
    public class JCManageController : Controller
    {
        private UserManager usermanager = new UserManager();
        private BLL_Office_Part_Column bll_office_part_column = new BLL_Office_Part_Column();
        private BLL_Office_Part_Foot bll_office_part_foot = new BLL_Office_Part_Foot();
        private BLL_Office_Part_Frame bll_office_part_frame = new BLL_Office_Part_Frame();

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
            var t= usermanager.getAllUserInfo();
            ViewBag.userInfo = t;
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

        [HttpGet]
        public JsonResult GetAllUserInfo()
        {
            var t = usermanager.getAllUserInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpGet]
        public JsonResult GetAllUserCompanyInfo()
        {
            var t = usermanager.getAllUserCompanyInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpGet]
        public JsonResult GetAllPartColumnInfo()
        {
            var t = bll_office_part_column.getColumnInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpGet]
        public JsonResult GetAllPartFootInfo()
        {
            var t = bll_office_part_foot.getFootInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetAllPartFrameInfo()
        {
            var t = bll_office_part_frame.getFrameInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
    }
}