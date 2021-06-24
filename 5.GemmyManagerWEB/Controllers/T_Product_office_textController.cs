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
using _1GemmyModel.Model.ModelProductOffice;
using _2GemmyBusness.BLL.BLLOfficeDesk;

namespace _5.GemmyManagerWEB.Controllers
{
    public class T_Product_office_textController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();
        private BLL_Office_desk bll = new BLL_Office_desk();
        // GET: T_Product_office_text 桌子的相关信息描述
        public ActionResult Index(string Mode,string  Key, string langCode)
        {

            ViewBag.Mode = Mode;
            ViewBag.Key = Key;
            ViewBag.langCode = langCode;
            if (Mode==null||Mode == "")
            {
                return View();
            }
            else
            {
                try
                {
                    T_Product_office_desk desk = db.T_Product_office_desk.Where(x => x.deskSerialName == Mode).FirstOrDefault();
                    T_Product_office_desk_detail deskdetail = bll.GetT_Product_office_desk_detail(desk.Id,"");

                    ViewBag.desk = desk;
                    ViewBag.deskdetail = deskdetail;

                    //标签 短描述
                    List<T_Product_office_text> list = new List<T_Product_office_text>();
                    if (desk.deskShortDescriptionKey != 0)
                    {
                        var q = from x in db.T_Product_office_text
                                where x.textKay == desk.deskShortDescriptionKey
                                select x;
                        list.AddRange(q.ToList());
                    }
                    if (desk.deskTagKey != 0)
                    {
                        var q = from x in db.T_Product_office_text
                                where x.textKay == desk.deskTagKey
                                select x;
                        list.AddRange(q.ToList());
                    }
                    
                        
                    if (Key != "")
                    {
                        int ikey = Convert.ToInt32(Key);
                        list = list.Where(x => x.textKay == ikey).ToList();

                    }
                    if (langCode != "")
                    {
                        list = list.Where(x => x.langCode == langCode).ToList();
                    }
                    ViewBag.T_Product_office_texts = list;

                    // //长描述  关键参数
                    List<T_Product_office_description> list2 = new List<T_Product_office_description>();
                    if (deskdetail.DescriptionIndex != 0)
                    {
                        var q = from x in db.T_Product_office_description
                                where x.textKay == deskdetail.DescriptionIndex
                                select x;
                        list2.AddRange(q.ToList());
                    }
                    if (deskdetail.introductionIndex != 0)
                    {
                        var q = from x in db.T_Product_office_description
                                where x.textKay == deskdetail.introductionIndex
                                select x;
                        list2.AddRange(q.ToList());
                    }


                    if (Key != "")
                    {
                        int ikey = Convert.ToInt32(Key);
                        list2 = list2.Where(x => x.textKay == ikey).ToList();

                    }
                    if (langCode != "")
                    {
                        list2 = list2.Where(x => x.langCode == langCode).ToList();
                    }
                    ViewBag.T_Product_office_descriptions = list2;


                }
                catch (Exception ex)
                {

                }

               return View();

            }
        }

        // GET: T_Product_office_text/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_text t_Product_office_text = db.T_Product_office_text.Find(id);
            if (t_Product_office_text == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_text);
        }

        // GET: T_Product_office_text/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Product_office_text/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,textKay,langCode,textValue")] T_Product_office_text t_Product_office_text)
        {
            if (ModelState.IsValid)
            {
                db.T_Product_office_text.Add(t_Product_office_text);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Product_office_text);
        }

        // GET: T_Product_office_text/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_text t_Product_office_text = db.T_Product_office_text.Find(id);
            if (t_Product_office_text == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_text);
        }

        // POST: T_Product_office_text/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,textKay,langCode,textValue")] T_Product_office_text t_Product_office_text)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Product_office_text).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Product_office_text);
        }

        // GET: T_Product_office_text/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Product_office_text t_Product_office_text = db.T_Product_office_text.Find(id);
            if (t_Product_office_text == null)
            {
                return HttpNotFound();
            }
            return View(t_Product_office_text);
        }

        // POST: T_Product_office_text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Product_office_text t_Product_office_text = db.T_Product_office_text.Find(id);
            db.T_Product_office_text.Remove(t_Product_office_text);
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
