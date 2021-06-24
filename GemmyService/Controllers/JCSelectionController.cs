using _1GemmyModel;
using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelProductOffice;
using _1GemmyModel.Model.ModelUserAccount;
using _2GemmyBusness.BLL.BLLOfficeDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GemmyService.Controllers
{
    public class JCSelectionController : Controller
    {

        #region 字段
        private DBGemmyService2 db = new DBGemmyService2();
        private BLL_Office_desk bll_desk = new BLL_Office_desk();
        private BLL_Office_File bll_file = new BLL_Office_File();
        private BLL_Office_Color bll_color = new BLL_Office_Color();
        private BLL_Office_desk_collect bll_collect = new BLL_Office_desk_collect();
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
            if(Session["emailName"] == null)
            {
                Session["emailName"] = "";
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
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;
            return View();
        }

        #region  捷昌标准推荐配置选择
        public ActionResult OfficeStandards(string domain,string Type,string recommend)
        {

            if(string.IsNullOrEmpty(recommend))
            {
                recommend = "all";
            }
          
           
            //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;

            if (Type == null || Type == "")
            {
                return View("office");
            }


            ViewBag.domain = domain;
            ViewBag.recommend = recommend;
            ViewBag.Type = Type;

            return View();
        }

      

        [HttpGet]
        public JsonResult GetOfficeStards(string domain,string Type, string recommend, string Order,string OrderValue, string langCode,string searchText)
        {


            List<T_Product_office_desk> list = bll_desk.GetT_Product_office_desk(Type, langCode,recommend,searchText);
          
            if(OrderValue!=null&&OrderValue!="")
            {
                if (Order == "2")//倒序
                {
                    list = list.OrderByDescending(DynamicLambda<T_Product_office_desk, double>(OrderValue)).ToList();
                    
                }
                else
                {
                    list = list.OrderBy(DynamicLambda<T_Product_office_desk, double>(OrderValue)).ToList();
                }
            }
          

            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;


        }

        #endregion

        public ActionResult selectType()
        {
            return View();
        }

        #region 显示产品详细界面
        public ActionResult ProductDetail(string domain, string Type, string recommend,string productName,string productGuid)
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
            Session.Timeout = 9600;

            ViewBag.domain = domain;
            ViewBag.recommend = recommend;
            ViewBag.Type = Type;
            ViewBag.productGuid = productGuid;
            ViewBag.productName = productName;
            return View();
        }



        [HttpPost]
        public JsonResult CollectDesk(int deskId)
        {
            int suc = 0;
            if (Session["emailName"] != null && Session["emailName"].ToString() != "")
            {
                string pname = Session["emailName"].ToString();

                suc = bll_collect.AddT_Office_desk_collect(deskId, pname);
            }

            JsonResult jr = Json(suc, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;


        }

        [HttpPost]
        public JsonResult CancelCollectDesk(int deskId)
        {
            int suc = 0;
            if (Session["emailName"] != null && Session["emailName"].ToString() != "")
            {
                string pname = Session["emailName"].ToString();
                suc = bll_collect.deleteT_Office_desk_collect(deskId, pname);
            }
            JsonResult jr = Json(suc, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;


        }
        
        [HttpGet]
        public ActionResult GetCollect(int deskId)
        {
            //收藏
            T_Office_desk_collect collect = new T_Office_desk_collect();
            if (Session["emailName"] != null && Session["emailName"].ToString() != "")
            {
                string pname = Session["emailName"].ToString();
                collect = bll_collect.GetT_Office_desk_collect(deskId, pname);
            }
            JsonResult jr = Json(collect, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }




        [HttpGet]
        public ActionResult GetOfficeDeskDetail(string productGuid,string lang)
        {

            T_Product_office_desk _T_Product_office_desk = bll_desk.GetT_Product_office_desk(productGuid);
            T_Product_office_desk_detail _T_Product_office_desk_detail = bll_desk.GetT_Product_office_desk_detail(_T_Product_office_desk.Id);

            T_Product_office_description m = bll_desk.GetT_Product_office_description_first(_T_Product_office_desk_detail.introductionIndex, lang);
            _T_Product_office_desk_detail.introduction = m == null ? "" : m.textValue;//产品介绍

            List<T_Product_office_description> descriptions = bll_desk.GetT_Product_office_description(_T_Product_office_desk_detail.DescriptionIndex, lang);//产品关键参数

            List<T_Office_Files> T_Office_Files = bll_file.GetT_Office_Files(_T_Product_office_desk.Id);
            //收藏
            T_Office_desk_collect collect = new T_Office_desk_collect();
            if (Session["emailName"]!=null && Session["emailName"].ToString()!="")
            {
                string pname = Session["emailName"].ToString();
             
                 collect =  bll_collect.GetT_Office_desk_collect(_T_Product_office_desk.Id, pname);
            }

            var list = new
            {
                T_Product_office_desk = _T_Product_office_desk,
                T_Product_office_desk_detail = _T_Product_office_desk_detail,
                descriptions = descriptions,
                T_Office_Files = T_Office_Files,
                collect = collect,
            };
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }



        #endregion


        public ActionResult Eservice()
        {
            return View();

        }

        public ActionResult office_Eservice()
        {

            return View();
        }

        public ActionResult office_Eservice_test(string productGuid)
        { //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;
            ViewBag.productGuid = productGuid;            
            return View();
        }
        #region 3D选配界面

        [HttpGet]
        public JsonResult GetPartDetail(string partType, string Mode,string langCode)
        {

            string imgurl = string.Empty;
            string mode = string.Empty;
            List<string> des = new List<string>();

            switch (partType)
            {
                case "ControlBox":
                    T_Part_office_ControlBox q = bll_desk.GetT_Part_office_ControlBox(Mode);
                    imgurl = q.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                        break;

                case "HandSet":
                    T_Part_office_HandSet q2 = bll_desk.GetT_Part_office_HandSet(Mode);
                    imgurl = q2.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                    break;

                case "Powercable":
                    T_Part_office_Powercable q3 = bll_desk.GetT_Part_office_Powercable(Mode);
                    imgurl = q3.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                    break;
                case "SideBracket":
                    T_Part_office_SideBracket q4 = bll_desk.GetT_Part_office_SideBracket(Mode);
                    imgurl = q4.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                    break;
                case "foot":
                    T_Part_office_Foot q5 = bll_desk.GetT_Part_office_Foot(Mode);
                    imgurl = q5.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                    break;
                case "frame":
                    T_Part_office_Frame q6 = bll_desk.GetT_Part_office_Frame(Mode);
                    imgurl = q6.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                    break;
                case "column":
                    T_Part_office_Column q7 = bll_desk.GetT_Part_office_Column(Mode);
                    imgurl = q7.PictureName;
                    mode = Mode;
                    des.Add("介绍");
                    break;

                default:
                    break;
            }

            var param = new
            {
                imgurl = imgurl,
                mode = mode,
                des = des


            };

            JsonResult jr = Json(param, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetOfficeColumn()
        {


            List<T_Part_office_Column> list = bll_desk.GetT_Part_office_Column();

            //if (OrderValue != null && OrderValue != "")
            //{
            //    if (Order == "2")//倒序
            //    {
            //        list = list.OrderByDescending(DynamicLambda<T_Product_office_desk, double>(OrderValue)).ToList();

            //    }
            //    else
            //    {
            //        list = list.OrderBy(DynamicLambda<T_Product_office_desk, double>(OrderValue)).ToList();
            //    }
            //}


            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;


        }
        [HttpGet]
        public JsonResult GetOfficeFrame()
        {
            List<T_Part_office_Frame> list = bll_desk.GetT_Part_office_Frame();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult GetOfficeFoot()
        {
            List<T_Part_office_Foot> list = bll_desk.GetT_Part_office_Foot();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult GetOfficeSideBracket()
        {
            List<T_Part_office_SideBracket> list = bll_desk.GetT_Part_office_SideBracket();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult GetOfficeControlBox()
        {
            List<T_Part_office_ControlBox> list = bll_desk.GetT_Part_office_ControlBox();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult GetOfficeHandSet()
        {
            List<T_Part_office_HandSet> list = bll_desk.GetT_Part_office_HandSet();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetOfficePowercable()
        {
            List<T_Part_office_Powercable> list = bll_desk.GetT_Part_office_Powercable();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        


        [HttpGet]
        public ActionResult GetOfficeDeskDetail2(string productGuid, string lang)
        {

            T_Product_office_desk _T_Product_office_desk = bll_desk.GetT_Product_office_desk(productGuid);
            T_Product_office_desk_detail _T_Product_office_desk_detail = bll_desk.GetT_Product_office_desk_detail(_T_Product_office_desk.Id);





            var list = new
            {
                T_Product_office_desk = _T_Product_office_desk,
                T_Product_office_desk_detail = _T_Product_office_desk_detail,
            };
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }





        [HttpGet]
        public JsonResult GetOfficeColor()
        {
            List<T_Office_Color> list = bll_color.GetColorList();
            JsonResult jr = Json(list, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        #endregion



        /// <summary>
        /// 动态加载语言测试界面
        /// </summary>
        /// <returns></returns>
        public ActionResult qwertyui()
        {   //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
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
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;
            return View();
        }


        public ActionResult uploadFileTest()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;
            return View();
        }

        public ActionResult testpage()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;

            return View();

        }
        public ActionResult PersonInfo(string email,string name)
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            Session.Timeout = 9600;
            ViewBag.email = email;
            ViewBag.name = name;
            return View();
        }

        #region 方法集

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Func<T, Tkey> DynamicLambda<T, Tkey>(string propertyName)
        {
            //var query = list.OrderByDescending(DynamicLambda<T_Salary_report, string>(ordername)); 引用
            ParameterExpression p = Expression.Parameter(typeof(T), "p");
            Expression body = Expression.Property(p, typeof(T).GetProperty(propertyName));

            var lambda = Expression.Lambda<Func<T, Tkey>>(body, p);

            return lambda.Compile();
        }



       
        #endregion

    }
}