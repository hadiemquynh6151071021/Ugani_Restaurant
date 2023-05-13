using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ugani_Restaurant.Models;

namespace Ugani_Restaurant.Controllers
{
    public class HOADONsController : Controller
    {
        private UGANI_1Entities db = new UGANI_1Entities();
        [HttpPost]
        public ActionResult AddFoodForBill(string idUser,DateTime date)
        {
            
            HOADON hOADON = new HOADON();
            hOADON.MAKH = idUser;
            hOADON.NGAYDATCOC = date;
            hOADON.TINHTRANG = "Đang chờ duyệt";

            decimal SumBan;
            
            CHITIETDATMONAN cHITIETDATMONAN = new CHITIETDATMONAN();
            cHITIETDATMONAN.MAKH = makh;
            cHITIETDATMONAN.MAMONAN = mamonan;
            cHITIETDATMONAN.SOLUONG = soluong;
            db.CHITIETDATMONANs.Add(cHITIETDATMONAN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: HOADONs
        public ActionResult Index(string id)
        {
            var list = db.CHITIETDATMONANs.Include(m => m.MONAN).Include(m => m.AspNetUser).Where(m => m.MAKH == id).Where(m => m.NGAYDAT == null).ToList();
            return View(list);
        }

        // GET: HOADONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHD,MAKH,NGAYDATCOC,TONGTIEN,TINHTRANG")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName", hOADON.MAKH);
            return View(hOADON);
        }

        // GET: CHITIETDATMONANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDATMONAN cHITIETDATMONAN = db.CHITIETDATMONANs.Find(id);
            if (cHITIETDATMONAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName", cHITIETDATMONAN.MAKH);
            ViewBag.MAMONAN = new SelectList(db.MONANs, "MAMONAN", "TENMONAN", cHITIETDATMONAN.MAMONAN);
            return View(cHITIETDATMONAN);
        }

        // POST: CHITIETDATMONANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MAKH,MAMONAN,SOLUONG,NGAYDAT")] CHITIETDATMONAN cHITIETDATMONAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDATMONAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName", cHITIETDATMONAN.MAKH);
            ViewBag.MAMONAN = new SelectList(db.MONANs, "MAMONAN", "TENMONAN", cHITIETDATMONAN.MAMONAN);
            return View(cHITIETDATMONAN);
        }

        // GET: HOADONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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
