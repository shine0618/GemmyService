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
    public class T_Part_office_ControlBoxController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Part_office_ControlBox
        public ActionResult Index()
        {
            return View(db.T_Part_office_ControlBox.ToList());
        }

        // GET: T_Part_office_ControlBox/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_ControlBox t_Part_office_ControlBox = db.T_Part_office_ControlBox.Find(id);
            if (t_Part_office_ControlBox == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_ControlBox);
        }

        // GET: T_Part_office_ControlBox/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Part_office_ControlBox/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mode,ControlColumnNo,OutputVoltage,InputVoltage,TransformerPower,Current,MaxSpeed,MaxLoad,PowerOutLet,ColumnOutLet,HandSetOutLet,ProgramOutLet,DoubleMotor,HandCranking,GasSpring,SingleMotor,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,ControlBoxWithHandSet,ControlBoxWithColumn,ControlBoxWithAccessory,TaxCost,TransferPrice,ReferencePrice,HaveRabbt,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_ControlBox t_Part_office_ControlBox)
        {
            if (ModelState.IsValid)
            {
                db.T_Part_office_ControlBox.Add(t_Part_office_ControlBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Part_office_ControlBox);
        }

        // GET: T_Part_office_ControlBox/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_ControlBox t_Part_office_ControlBox = db.T_Part_office_ControlBox.Find(id);
            if (t_Part_office_ControlBox == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_ControlBox);
        }

        // POST: T_Part_office_ControlBox/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mode,ControlColumnNo,OutputVoltage,InputVoltage,TransformerPower,Current,MaxSpeed,MaxLoad,PowerOutLet,ColumnOutLet,HandSetOutLet,ProgramOutLet,DoubleMotor,HandCranking,GasSpring,SingleMotor,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,ControlBoxWithHandSet,ControlBoxWithColumn,ControlBoxWithAccessory,TaxCost,TransferPrice,ReferencePrice,HaveRabbt,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_ControlBox t_Part_office_ControlBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Part_office_ControlBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Part_office_ControlBox);
        }

        // GET: T_Part_office_ControlBox/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_ControlBox t_Part_office_ControlBox = db.T_Part_office_ControlBox.Find(id);
            if (t_Part_office_ControlBox == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_ControlBox);
        }

        // POST: T_Part_office_ControlBox/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Part_office_ControlBox t_Part_office_ControlBox = db.T_Part_office_ControlBox.Find(id);
            db.T_Part_office_ControlBox.Remove(t_Part_office_ControlBox);
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
