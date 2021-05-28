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
    public class T_Office_FilesController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Office_Files
        public ActionResult Index()
        {
            return View(db.T_Office_Files.ToList());
        }

        // GET: T_Office_Files/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Office_Files t_Office_Files = db.T_Office_Files.Find(id);
            if (t_Office_Files == null)
            {
                return HttpNotFound();
            }
            return View(t_Office_Files);
        }

        // GET: T_Office_Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Office_Files/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,partType,Mode,FileName,thumbnailImg,Nature,Information,Path,Size,Outdate,Type,Permission,Products,Lock,Language,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Office_Files t_Office_Files)
        {
            if (ModelState.IsValid)
            {
                db.T_Office_Files.Add(t_Office_Files);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Office_Files);
        }

        // GET: T_Office_Files/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Office_Files t_Office_Files = db.T_Office_Files.Find(id);
            if (t_Office_Files == null)
            {
                return HttpNotFound();
            }
            return View(t_Office_Files);
        }

        // POST: T_Office_Files/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,partType,Mode,FileName,thumbnailImg,Nature,Information,Path,Size,Outdate,Type,Permission,Products,Lock,Language,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Office_Files t_Office_Files)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Office_Files).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Office_Files);
        }

        // GET: T_Office_Files/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Office_Files t_Office_Files = db.T_Office_Files.Find(id);
            if (t_Office_Files == null)
            {
                return HttpNotFound();
            }
            return View(t_Office_Files);
        }

        // POST: T_Office_Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Office_Files t_Office_Files = db.T_Office_Files.Find(id);
            db.T_Office_Files.Remove(t_Office_Files);
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
