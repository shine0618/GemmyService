using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1GemmyModel;
using _1GemmyModel.Model.ModelProductOffice;

namespace _5.GemmyManagerWEB.Controllers
{
    public class T_Part_office_describeController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Part_office_describe
        public ActionResult Index()
        {
            return View(db.T_Part_office_describe.ToList());
        }

        // GET: T_Part_office_describe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_describe t_Part_office_describe = db.T_Part_office_describe.Find(id);
            if (t_Part_office_describe == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_describe);
        }

        // GET: T_Part_office_describe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Part_office_describe/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,textKay,langCode,textValue")] T_Part_office_describe t_Part_office_describe)
        {
            if (ModelState.IsValid)
            {
                db.T_Part_office_describe.Add(t_Part_office_describe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Part_office_describe);
        }

        // GET: T_Part_office_describe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_describe t_Part_office_describe = db.T_Part_office_describe.Find(id);
            if (t_Part_office_describe == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_describe);
        }

        // POST: T_Part_office_describe/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,textKay,langCode,textValue")] T_Part_office_describe t_Part_office_describe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Part_office_describe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Part_office_describe);
        }

        // GET: T_Part_office_describe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_describe t_Part_office_describe = db.T_Part_office_describe.Find(id);
            if (t_Part_office_describe == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_describe);
        }

        // POST: T_Part_office_describe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Part_office_describe t_Part_office_describe = db.T_Part_office_describe.Find(id);
            db.T_Part_office_describe.Remove(t_Part_office_describe);
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
