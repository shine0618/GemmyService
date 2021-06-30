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

namespace GemmyService.Controllers
{
    public class T_Product_office_desk_customerController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Product_office_desk_customer
        public ActionResult Index()
        {
            if (Session["PageLanguage"] == null)
            {
                Session["PageLanguage"] = "default";
            }
            if (Session["emailName"] == null)
            {
                Session["emailName"] = "";
            }
            return View(db.T_Product_office_desk_customer.ToList());
        }

        // GET: T_Product_office_desk_customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_desk_customer t_Product_office_desk_customer = db.T_Product_office_desk_customer.Find(id);
            if (t_Product_office_desk_customer == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_desk_customer);
        }

        // GET: T_Product_office_desk_customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Product_office_desk_customer/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,deskGuid,langCode,configurationName,customerUserName,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Product_office_desk_customer t_Product_office_desk_customer)
        {
            if (ModelState.IsValid)
            {
                db.T_Product_office_desk_customer.Add(t_Product_office_desk_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Product_office_desk_customer);
        }

        // GET: T_Product_office_desk_customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_desk_customer t_Product_office_desk_customer = db.T_Product_office_desk_customer.Find(id);
            if (t_Product_office_desk_customer == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_desk_customer);
        }

        // POST: T_Product_office_desk_customer/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,deskGuid,langCode,configurationName,customerUserName,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Product_office_desk_customer t_Product_office_desk_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Product_office_desk_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Product_office_desk_customer);
        }

        // GET: T_Product_office_desk_customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_desk_customer t_Product_office_desk_customer = db.T_Product_office_desk_customer.Find(id);
            if (t_Product_office_desk_customer == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_desk_customer);
        }

        // POST: T_Product_office_desk_customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Product_office_desk_customer t_Product_office_desk_customer = db.T_Product_office_desk_customer.Find(id);
            db.T_Product_office_desk_customer.Remove(t_Product_office_desk_customer);
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
