using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1GemmyModel;
using _1GemmyModel.Model;

namespace _5.GemmyManagerWEB.Controllers
{
    public class T_Product_office_descriptionController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Product_office_description
        public ActionResult Index()
        {
            return View(db.T_Product_office_description.ToList());
        }

        // GET: T_Product_office_description/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_description t_Product_office_description = db.T_Product_office_description.Find(id);
            if (t_Product_office_description == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_description);
        }

        // GET: T_Product_office_description/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Product_office_description/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,textKay,langCode,textValue")] T_Product_office_description t_Product_office_description)
        {
            if (ModelState.IsValid)
            {
                db.T_Product_office_description.Add(t_Product_office_description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Product_office_description);
        }

        // GET: T_Product_office_description/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_description t_Product_office_description = db.T_Product_office_description.Find(id);
            if (t_Product_office_description == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_description);
        }

        // POST: T_Product_office_description/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,textKay,langCode,textValue")] T_Product_office_description t_Product_office_description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Product_office_description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Product_office_description);
        }

        // GET: T_Product_office_description/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_description t_Product_office_description = db.T_Product_office_description.Find(id);
            if (t_Product_office_description == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_description);
        }

        // POST: T_Product_office_description/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Product_office_description t_Product_office_description = db.T_Product_office_description.Find(id);
            db.T_Product_office_description.Remove(t_Product_office_description);
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
