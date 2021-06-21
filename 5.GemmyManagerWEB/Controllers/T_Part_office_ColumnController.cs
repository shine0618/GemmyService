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
    public class T_Part_office_ColumnController : Controller
    {
        private DBGemmyService2 db = new DBGemmyService2();

        // GET: T_Part_office_Column
        public ActionResult Index()
        {
            return View(db.T_Part_office_Column.ToList());
        }

        // GET: T_Part_office_Column/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_Column t_Part_office_Column = db.T_Part_office_Column.Find(id);
            if (t_Part_office_Column == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_Column);
        }

        // GET: T_Part_office_Column/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Part_office_Column/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mode,Type,Level,Form,Size_Out,Size_Middle,Size_Inside,StrokeLength,MaxStroke,LowestPosition,HighestPosition,LoadCapacity,MaxLoad,Speed,MaxSpeed,Power,StabilityLeave,MotorCode,HaveMotor,Inline,InsideSlider,SingleMotor,HandCranking,GasSpring,CanEZ,CanFold,CanTurn,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,ColumnWithFoot,ColumnWithFrame,HandsetConnect,ControlboxConnect,AccessoryConnect,ColumnWithSideBracket,TaxCost,TransferPrice,ReferencePrice,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_Column t_Part_office_Column)
        {
            if (ModelState.IsValid)
            {
                db.T_Part_office_Column.Add(t_Part_office_Column);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Part_office_Column);
        }

        // GET: T_Part_office_Column/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_Column t_Part_office_Column = db.T_Part_office_Column.Find(id);
            if (t_Part_office_Column == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_Column);
        }

        // POST: T_Part_office_Column/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mode,Type,Level,Form,Size_Out,Size_Middle,Size_Inside,StrokeLength,MaxStroke,LowestPosition,HighestPosition,LoadCapacity,MaxLoad,Speed,MaxSpeed,Power,StabilityLeave,MotorCode,HaveMotor,Inline,InsideSlider,SingleMotor,HandCranking,GasSpring,CanEZ,CanFold,CanTurn,GS,EN527,CE,EMC,BIFMA,UL962,DrawingNum2D,DrawingNum3D,DrawingName3D,DrawingName2D,PictureName,PictureNum,PartCode,Weight,DescriptionZH,DescriptionEN,ColumnWithFoot,ColumnWithFrame,HandsetConnect,ControlboxConnect,AccessoryConnect,ColumnWithSideBracket,TaxCost,TransferPrice,ReferencePrice,Customization,SpecialDescriptionZH,SpecialDescriptionEN,verificationCode,deleteSign,UpdateTime,CreateTime,deletePerson,CreatePerson,UpdatePerson,Remark")] T_Part_office_Column t_Part_office_Column)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Part_office_Column).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Part_office_Column);
        }

        // GET: T_Part_office_Column/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Part_office_Column t_Part_office_Column = db.T_Part_office_Column.Find(id);
            if (t_Part_office_Column == null)
            {
                return HttpNotFound();
            }
            return View(t_Part_office_Column);
        }

        // POST: T_Part_office_Column/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Part_office_Column t_Part_office_Column = db.T_Part_office_Column.Find(id);
            db.T_Part_office_Column.Remove(t_Part_office_Column);
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
