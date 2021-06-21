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
    public class T_Part_office_FrameController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Part_office_Frame
        public ActionResult Index()
        {
            return View(db.T_Part_office_Frame.ToList());
        }

        // GET: T_Part_office_Frame/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_Frame t_Part_office_Frame = db.T_Part_office_Frame.Find(id);
            if (t_Part_office_Frame == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_Frame);
        }

        // GET: T_Part_office_Frame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Part_office_Frame/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mode,MaxLength,MinLength,StabilityLeave,CanEZ,CanFold,CanTurn,Inline,InsideSlider,DoubleMotor,HandCranking,GasSpring,SingleMotor,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,FrameWithColumn,FrameWithSideBracket,FrameWithAccessory,FrameWithControlBox,TaxCost,TransferPrice,ReferencePrice,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_Frame t_Part_office_Frame)
        {
            if (ModelState.IsValid)
            {
                db.T_Part_office_Frame.Add(t_Part_office_Frame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Part_office_Frame);
        }

        // GET: T_Part_office_Frame/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_Frame t_Part_office_Frame = db.T_Part_office_Frame.Find(id);
            if (t_Part_office_Frame == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_Frame);
        }

        // POST: T_Part_office_Frame/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mode,MaxLength,MinLength,StabilityLeave,CanEZ,CanFold,CanTurn,Inline,InsideSlider,DoubleMotor,HandCranking,GasSpring,SingleMotor,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,FrameWithColumn,FrameWithSideBracket,FrameWithAccessory,FrameWithControlBox,TaxCost,TransferPrice,ReferencePrice,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_Frame t_Part_office_Frame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Part_office_Frame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Part_office_Frame);
        }

        // GET: T_Part_office_Frame/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_Frame t_Part_office_Frame = db.T_Part_office_Frame.Find(id);
            if (t_Part_office_Frame == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_Frame);
        }

        // POST: T_Part_office_Frame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Part_office_Frame t_Part_office_Frame = db.T_Part_office_Frame.Find(id);
            db.T_Part_office_Frame.Remove(t_Part_office_Frame);
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
