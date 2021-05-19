using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelProductOffice;
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

        #region  捷昌标准推荐配置选择
        public ActionResult OfficeStandards(string domain,string Type,string recommend)
        {

          
           
            //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
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
            Session.Timeout = 9600;

            ViewBag.domain = domain;
            ViewBag.recommend = recommend;
            ViewBag.Type = Type;
            ViewBag.productGuid = productGuid;
            ViewBag.productName = productName;
            return View();
        }
        [HttpGet]
        public ActionResult GetOfficeDeskDetail(string productGuid,string lang)
        {

            T_Product_office_desk _T_Product_office_desk = bll_desk.GetT_Product_office_desk(productGuid);
            T_Product_office_desk_detail _T_Product_office_desk_detail = bll_desk.GetT_Product_office_desk_detail(_T_Product_office_desk.Id);
            List<T_Product_office_description> descriptions = bll_desk.GetT_Product_office_description(_T_Product_office_desk_detail.DescriptionIndex, lang);
            var list = new
            {
                T_Product_office_desk = _T_Product_office_desk,
                T_Product_office_desk_detail = _T_Product_office_desk_detail,
                descriptions = descriptions
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

        public ActionResult office_Eservice_test()
        { //如果语言是默认的话
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            Session.Timeout = 9600;

            return View();
        }
        #region 3D选配界面
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