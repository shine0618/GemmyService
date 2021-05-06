using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2GemmyBusness.BLL.BLLUserAccount;
using GemmyService.Models.HomeViewModels;

namespace GemmyService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult test()
        {
            return View();
        }

        public ActionResult test22()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ViewResult Register(Models.HomeViewModels.RegisterViewModel model)
        //{
            
        //    if (!ModelState.IsValid) return View(model);

        //    _2GemmyBusness.BLL.BLLUserAccount.UserManager usermanager = new UserManager();
        //    usermanager.Register(model.UserName,model.Password,model.Question,model.Answer,model.Email);
        //    return View(Index());
        //}

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //    [HttpPost]
        //    public ViewResult Login(LoginViewModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            UserManager usermaganer = new UserManager();
        //            bool isLogin = usermaganer.Login(model.UserName, model.Password);
        //            if (isLogin==true)
        //            {
        //                return View(Index());
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("","abc");
        //            }
        //        }

        //        return View(model);
        //    }
    }
}