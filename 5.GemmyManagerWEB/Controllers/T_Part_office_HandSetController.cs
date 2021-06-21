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
    public class T_Part_office_HandSetController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Part_office_HandSet
        public ActionResult Index()
        {
            return View(db.T_Part_office_HandSet.ToList());
        }

        // GET: T_Part_office_HandSet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_HandSet t_Part_office_HandSet = db.T_Part_office_HandSet.Find(id);
            if (t_Part_office_HandSet == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_HandSet);
        }

        // GET: T_Part_office_HandSet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Part_office_HandSet/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mode,HaveScreen,ScreenType,Touch,Button,HaveUsb,Imbedding,Remote,BlueTooth,MemoryKeys,OutputVoltage,InputVoltage,TransformerPower,Voltage,Current,HandSetOutLet,DoubleMotor,HandCranking,GasSpring,SingleMotor,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,HandsetWithControlBox,HandsetWithAccessory,TaxCost,TransferPrice,ReferencePrice,HaveRabbet,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_HandSet t_Part_office_HandSet)
        {
            if (ModelState.IsValid)
            {
                db.T_Part_office_HandSet.Add(t_Part_office_HandSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Part_office_HandSet);
        }

        // GET: T_Part_office_HandSet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_HandSet t_Part_office_HandSet = db.T_Part_office_HandSet.Find(id);
            if (t_Part_office_HandSet == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_HandSet);
        }

        // POST: T_Part_office_HandSet/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mode,HaveScreen,ScreenType,Touch,Button,HaveUsb,Imbedding,Remote,BlueTooth,MemoryKeys,OutputVoltage,InputVoltage,TransformerPower,Voltage,Current,HandSetOutLet,DoubleMotor,HandCranking,GasSpring,SingleMotor,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,HandsetWithControlBox,HandsetWithAccessory,TaxCost,TransferPrice,ReferencePrice,HaveRabbet,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_HandSet t_Part_office_HandSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Part_office_HandSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Part_office_HandSet);
        }

        // GET: T_Part_office_HandSet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_HandSet t_Part_office_HandSet = db.T_Part_office_HandSet.Find(id);
            if (t_Part_office_HandSet == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_HandSet);
        }

        // POST: T_Part_office_HandSet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Part_office_HandSet t_Part_office_HandSet = db.T_Part_office_HandSet.Find(id);
            db.T_Part_office_HandSet.Remove(t_Part_office_HandSet);
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
