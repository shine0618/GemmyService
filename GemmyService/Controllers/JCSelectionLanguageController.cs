using _1GemmyModel.Model.ModelSystem;
using _2GemmyBusness.BLL.BLLSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace GemmyService.Controllers
{
    /// <summary>
    /// JCSelectionLanguage
    /// </summary>
    public class JCSelectionLanguageController : Controller
    {
        // GET: JCSelectionLanguage
        public ActionResult Index()
        {
            return View();
        }
        BLL_SYS_language bll = new BLL_SYS_language();

        public ActionResult ChangeLangu(string langu)
        {
            if(langu!=null)
            {
                Session["PageLanguage"] = langu;
            }

              return RedirectToAction("main", "JCSelection");
        }

        [HttpGet]
        public string  GetLanguages(string keys)
        {
            //if (keys != _4GemmyTools.MD5T.MD5Encrypt("jiecanglangu"))
            //{
            //    return "";
            //}
            List<T_SYS_Language> list = bll.GetT_SYS_Language();
            return JsonConvert.SerializeObject(list);
        }

        [HttpGet]
        public string GetLanguagesDetail(string keys,string code)
        {
            T_SYS_Language lang = BLL_SYS_Helper.GetT_SYS_Language(code);
            return JsonConvert.SerializeObject(lang);
        }
    }
}