using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1GemmyModel;
using _1GemmyModel.Model.ModelSystem;

namespace _5.GemmyManagerWEB.Controllers
{
    public class T_SYS_LanguageController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_SYS_Language
        public ActionResult Index()
        {
            return View(db.T_SYS_Language.ToList());
        }

        // GET: T_SYS_Language/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SYS_Language t_SYS_Language = db.T_SYS_Language.Find(id);
            if (t_SYS_Language == null)
            {
                return HttpNotFound();
            }
            return View(t_SYS_Language);
        }

        // GET: T_SYS_Language/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_SYS_Language/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageCode,LanguageDesript,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_SYS_Language t_SYS_Language)
        {
            if (ModelState.IsValid)
            {
                db.T_SYS_Language.Add(t_SYS_Language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_SYS_Language);
        }

        // GET: T_SYS_Language/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SYS_Language t_SYS_Language = db.T_SYS_Language.Find(id);
            if (t_SYS_Language == null)
            {
                return HttpNotFound();
            }
            return View(t_SYS_Language);
        }

        // POST: T_SYS_Language/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageCode,LanguageDesript,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_SYS_Language t_SYS_Language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SYS_Language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_SYS_Language);
        }

        // GET: T_SYS_Language/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SYS_Language t_SYS_Language = db.T_SYS_Language.Find(id);
            if (t_SYS_Language == null)
            {
                return HttpNotFound();
            }
            return View(t_SYS_Language);
        }

        // POST: T_SYS_Language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_SYS_Language t_SYS_Language = db.T_SYS_Language.Find(id);
            db.T_SYS_Language.Remove(t_SYS_Language);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
