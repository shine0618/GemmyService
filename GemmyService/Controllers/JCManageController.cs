using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelProductOffice;
using _1GemmyModel.Model.ModelUserAccount;
using _2GemmyBusness.BLL.BLLOfficePartManage;
using _2GemmyBusness.BLL.BLLUserAccount;
using Newtonsoft.Json;
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
        private BLL_Office_Part_Handset bll_office_part_handset = new BLL_Office_Part_Handset();
        private BLL_Office_Part_Sidebracket bll_office_part_sidebracket = new BLL_Office_Part_Sidebracket();
        private BLL_Office_Part_Controlbox bll_office_part_controlbox = new BLL_Office_Part_Controlbox();
        private BLL_Office_Part_Powercable bll_office_part_powercable = new BLL_Office_Part_Powercable();
        private BLL_Office_color bll_office_color = new BLL_Office_color();
        private BLL_Office_Desk bll_office_desk = new BLL_Office_Desk();
        private BLL_Office_DeskByUser bll_office_deskbyuser = new BLL_Office_DeskByUser();
        private BLL_Office_DeskDetail bll_office_deskdetail = new BLL_Office_DeskDetail();
        private BLL_Office_DescDetail bll_office_descdetail = new BLL_Office_DescDetail();
        private BLL_Office_Files bll_office_files = new BLL_Office_Files();
        private BLL_USER bll_user = new BLL_USER();
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
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            var t= usermanager.getAllUserInfo();
            ViewBag.userInfo = t;
            return View();
        }
        public ActionResult partColumn()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult partFrame()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }
        public ActionResult partFoot()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }
        public ActionResult partHandset()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }
        public ActionResult partControlbox()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }
        public ActionResult partSidebracket()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult userRegisterInfo()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }
        public ActionResult userCompanyInfo()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult partPowerCable()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }
        public ActionResult productcolor()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult productByJiecang()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }


        public ActionResult productByUser()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult productDeskDetail()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult productDescDetail(int textkey)
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            };
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            ViewBag.textkey = textkey == 0 ? 0 : textkey;
            return View();
        }

        public ActionResult filesDetail(string mode)
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            if (!string.IsNullOrEmpty(mode))
            {
                ViewBag.mode = mode;
            }

            return View();
        }

        public ActionResult userLevel()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
            }
            return View();
        }

        public ActionResult usercompanyapply()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            if (Session["level"] == null)
            {
                Session["level"] = 0;
            }
            if (Session["companyName"] == null)
            {
                Session["companyName"] = "";
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

        [HttpGet]
        public JsonResult GetAllPartHandsetInfo()
        {
            var t = bll_office_part_handset.getHandsetInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetAllPartSidebracketInfo()
        {
            var t = bll_office_part_sidebracket.getSidebracketInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetAllPartControlboxInfo()
        {
            var t = bll_office_part_controlbox.getControlboxInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetAllPartPowercableInfo()
        {
            var t = bll_office_part_powercable.getPowercableInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        
        [HttpGet]
        public JsonResult GetAllPartColorInfo()
        {
            var t = bll_office_color.getColorInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult GetAllDeskInfo()
        {
            var t = bll_office_desk.getDeskInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult GetAllDeskByUserInfo()
        {
            var t = bll_office_deskbyuser.getDeskByUserInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetAllDeskDetailInfo()
        {
            var t = bll_office_deskdetail.getDeskDetailInfo();
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetDeskDescInfo(int textkey)
        {
            var t = bll_office_descdetail.getDeskDescInfo(textkey);
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetFilesInfo(string mode)
        {
            var t = bll_office_files.getFileInfo(mode);
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpPost]
        public JsonResult UpdateUserLevel(string forminfo)
        {
            bool isadd = false;
            T_USER_UserInfo t_USER_UserInfo = JsonConvert.DeserializeObject<T_USER_UserInfo>(forminfo);
            isadd = bll_user.UpdateUserLevel(t_USER_UserInfo);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        #region 立柱操作
        [HttpPost]
        public JsonResult UpdateColumnInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Column t_Part_office_Column = JsonConvert.DeserializeObject<T_Part_office_Column>(forminfo);
            isadd = bll_office_part_column.UpdateColumnInfo(t_Part_office_Column);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpPost]
        public JsonResult addColumnInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Column t_Part_office_Column = JsonConvert.DeserializeObject<T_Part_office_Column>(forminfo);
            isadd = bll_office_part_column.AddColumnInfo(t_Part_office_Column);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteColumnInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Column t_Part_office_Column = JsonConvert.DeserializeObject<T_Part_office_Column>(forminfo);
            isadd = bll_office_part_column.DeleteColumnInfo(t_Part_office_Column);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 控制器操作

        [HttpPost]
        public JsonResult UpdateControlboxInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_ControlBox t_Part_office_ControlBox = JsonConvert.DeserializeObject<T_Part_office_ControlBox>(forminfo);
            isadd = bll_office_part_controlbox.UpdateControlboxInfo(t_Part_office_ControlBox);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addControlboxInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_ControlBox t_Part_office_ControlBox = JsonConvert.DeserializeObject<T_Part_office_ControlBox>(forminfo);
            isadd = bll_office_part_controlbox.AddControlboxInfo(t_Part_office_ControlBox);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteControlboxInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_ControlBox t_Part_office_ControlBox = JsonConvert.DeserializeObject<T_Part_office_ControlBox>(forminfo);
            isadd = bll_office_part_controlbox.DeleteControlboxInfo(t_Part_office_ControlBox);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 手控器操作

        [HttpPost]
        public JsonResult UpdateHandsetInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_HandSet t_Part_office_HandSet = JsonConvert.DeserializeObject<T_Part_office_HandSet>(forminfo);
            isadd = bll_office_part_handset.UpdateHandsetInfo(t_Part_office_HandSet);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addHandsetInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_HandSet t_Part_office_HandSet = JsonConvert.DeserializeObject<T_Part_office_HandSet>(forminfo);
            isadd = bll_office_part_handset.AddHandsetInfo(t_Part_office_HandSet);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteHandsetInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_HandSet t_Part_office_HandSet = JsonConvert.DeserializeObject<T_Part_office_HandSet>(forminfo);
            isadd = bll_office_part_handset.DeleteHandsetInfo(t_Part_office_HandSet);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 框架操作

        [HttpPost]
        public JsonResult UpdateFrameInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Frame t_Part_office_Frame = JsonConvert.DeserializeObject<T_Part_office_Frame>(forminfo);
            isadd = bll_office_part_frame.UpdateFrameInfo(t_Part_office_Frame);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addFrameInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Frame t_Part_office_Frame = JsonConvert.DeserializeObject<T_Part_office_Frame>(forminfo);
            isadd = bll_office_part_frame.AddFrameInfo(t_Part_office_Frame);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteFrameInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Frame t_Part_office_Frame = JsonConvert.DeserializeObject<T_Part_office_Frame>(forminfo);
            isadd = bll_office_part_frame.DeleteFrameInfo(t_Part_office_Frame);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 侧板操作

        [HttpPost]
        public JsonResult UpdateSidebracketInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_SideBracket t_Part_office_SideBracket = JsonConvert.DeserializeObject<T_Part_office_SideBracket>(forminfo);
            isadd = bll_office_part_sidebracket.UpdateSidebracketInfo(t_Part_office_SideBracket);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addSidebracketInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_SideBracket t_Part_office_SideBracket = JsonConvert.DeserializeObject<T_Part_office_SideBracket>(forminfo);
            isadd = bll_office_part_sidebracket.AddSidebracketInfo(t_Part_office_SideBracket);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteSidebracketInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_SideBracket t_Part_office_SideBracket = JsonConvert.DeserializeObject<T_Part_office_SideBracket>(forminfo);
            isadd = bll_office_part_sidebracket.DeleteSidebracketInfo(t_Part_office_SideBracket);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 地脚操作

        [HttpPost]
        public JsonResult UpdateFootInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Foot t_Part_office_Foot = JsonConvert.DeserializeObject<T_Part_office_Foot>(forminfo);
            isadd = bll_office_part_foot.UpdateFootInfo(t_Part_office_Foot);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addFootInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Foot t_Part_office_Foot = JsonConvert.DeserializeObject<T_Part_office_Foot>(forminfo);
            isadd = bll_office_part_foot.AddFootInfo(t_Part_office_Foot);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteFootInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Foot t_Part_office_Foot = JsonConvert.DeserializeObject<T_Part_office_Foot>(forminfo);
            isadd = bll_office_part_foot.DeleteFootInfo(t_Part_office_Foot);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 电源线操作

        [HttpPost]
        public JsonResult UpdatePowercableInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Powercable t_Part_office_Powercable = JsonConvert.DeserializeObject<T_Part_office_Powercable>(forminfo);
            isadd = bll_office_part_powercable.UpdatePowercableInfo(t_Part_office_Powercable);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addPowercableInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Powercable t_Part_office_Powercable = JsonConvert.DeserializeObject<T_Part_office_Powercable>(forminfo);
            isadd = bll_office_part_powercable.AddPowercableInfo(t_Part_office_Powercable);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeletePowercableInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_Powercable t_Part_office_Powercable = JsonConvert.DeserializeObject<T_Part_office_Powercable>(forminfo);
            isadd = bll_office_part_powercable.DeletePowercableInfo(t_Part_office_Powercable);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 颜色操作

        [HttpPost]
        public JsonResult UpdateColorInfo(string forminfo)
        {
            bool isadd = false;
            T_Office_Color t_Office_Color = JsonConvert.DeserializeObject<T_Office_Color>(forminfo);
            isadd = bll_office_color.UpdateColorInfo(t_Office_Color);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addColorInfo(string forminfo)
        {
            bool isadd = false;
            T_Office_Color t_Office_Color = JsonConvert.DeserializeObject<T_Office_Color>(forminfo);
            isadd = bll_office_color.AddColorInfo(t_Office_Color);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteColorInfo(string forminfo)
        {
            bool isadd = false;
            T_Office_Color t_Office_Color = JsonConvert.DeserializeObject<T_Office_Color>(forminfo);
            isadd = bll_office_color.DeleteColorInfo(t_Office_Color);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpPost]
        public JsonResult ChangeColor(double lvalue,double avalue,double bvalue)
        {
            int[] rgb = BLL_Office_color.LabToRGB(lvalue,avalue,bvalue);
            string hex = BLL_Office_color.getHex(rgb);
            var param = new
            {
                rgb = rgb,
                hex=hex
            };
            JsonResult jr = Json(param, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        #endregion
        #region 捷昌推荐整桌操作

        [HttpPost]
        public JsonResult UpdateDeskInfo(string forminfo)
        {
            bool isadd = false;
            T_Product_office_desk t_Product_office_desk = JsonConvert.DeserializeObject<T_Product_office_desk>(forminfo);
            isadd = bll_office_desk.UpdateDeskInfo(t_Product_office_desk);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addDeskInfo(string forminfo)
        {
            bool isadd = false;
            T_Product_office_desk t_Product_office_desk = JsonConvert.DeserializeObject<T_Product_office_desk>(forminfo);
            isadd = bll_office_desk.AddDeskInfo(t_Product_office_desk);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteDeskInfo(string forminfo)
        {
            bool isadd = false;
            T_Product_office_desk t_Product_office_desk = JsonConvert.DeserializeObject<T_Product_office_desk>(forminfo);
            isadd = bll_office_desk.DeleteDeskInfo(t_Product_office_desk);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 部件描述操作

        [HttpPost]
        public JsonResult UpdateDeskDescInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_describe t_Part_office_describe = JsonConvert.DeserializeObject<T_Part_office_describe>(forminfo);
            isadd = bll_office_descdetail.UpdateDeskDescInfo(t_Part_office_describe);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addDeskDescInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_describe t_Part_office_describe = JsonConvert.DeserializeObject<T_Part_office_describe>(forminfo);
            isadd = bll_office_descdetail.AddDeskDescInfo(t_Part_office_describe);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteDeskDescInfo(string forminfo)
        {
            bool isadd = false;
            T_Part_office_describe t_Part_office_describe = JsonConvert.DeserializeObject<T_Part_office_describe>(forminfo);
            isadd = bll_office_descdetail.DeleteDeskDescInfo(t_Part_office_describe);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 文件操作

        [HttpPost]
        public JsonResult UpdateFilesInfo(string forminfo)
        {
            bool isadd = false;
            T_Office_Files t_Office_Files = JsonConvert.DeserializeObject<T_Office_Files>(forminfo);
            isadd = bll_office_files.UpdateFileInfo(t_Office_Files);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpPost]
        public JsonResult addFilesInfo(string forminfo)
        {
            bool isadd = false;
            T_Office_Files t_Part_office_describe = JsonConvert.DeserializeObject<T_Office_Files>(forminfo);
            isadd = bll_office_files.AddFileInfo(t_Part_office_describe);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpPost]
        public JsonResult DeleteFilesInfo(string forminfo)
        {
            bool isadd = false;
            T_Office_Files t_Part_office_describe = JsonConvert.DeserializeObject<T_Office_Files>(forminfo);
            isadd = bll_office_files.DeleteFileInfo(t_Part_office_describe);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
        #region 订单权限修改

        [HttpPost]
        public JsonResult UpdateOrderApply(string forminfo,string user)
        {
            bool isadd = false;
            T_USER_UserInfo t_USER_UserInfo = JsonConvert.DeserializeObject<T_USER_UserInfo>(forminfo);
            isadd = bll_user.UpdateCompanyLevel(t_USER_UserInfo, user);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        #endregion
    }
}