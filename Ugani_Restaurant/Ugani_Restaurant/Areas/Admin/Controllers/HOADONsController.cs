using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ugani_Restaurant.Models;

namespace Ugani_Restaurant.Areas.Admin.Controllers
{
    public class HOADONsController : Controller
    {
        private UGANI_1Entities db = new UGANI_1Entities();

        public ActionResult Index1()
        {

            return View(db.HOADONs.ToList());
        }

        // GET: Admin/HOADONs
        public ActionResult Index()
        {
            var hOADONs = db.HOADONs.Include(m => m.AspNetUser).OrderByDescending(m=>m.NGAYDATCOC);
            return View(hOADONs.ToList());
        }

        // GET: Admin/HOADONs/Details/5
        public ActionResult Detailsfood(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dataset = db.CHITIETDATBANs.Where(m => m.MAKH == id);
            IList<CHITIETDATBAN> listTable = new List<CHITIETDATBAN>();
            listTable = dataset.ToList();
            ViewBag.lsTable = listTable;
            HOADON hOADON = db.HOADONs.Find(id);
            var list = db.CHITIETDATMONANs.Include(m=>m.AspNetUser).Include(m=>m.MONAN);
            list = list.Where(m => m.MAKH == hOADON.MAKH);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(list.ToList());
        }

        // GET: Admin/HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: Admin/HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKH,NGAYDATCOC,TONGTIEN,TIENCOC")] HOADON hOADON)
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

        // GET: Admin/HOADONs/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName", hOADON.MAKH);
            return View(hOADON);
        }

        // POST: Admin/HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKH,NGAYDATCOC,TONGTIEN,TIENCOC")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName", hOADON.MAKH);
            return View(hOADON);
        }

        // GET: Admin/HOADONs/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetResultReport(int year)
        {
            var lsData = GetReportByYear(year);
            return Json(lsData, JsonRequestBehavior.AllowGet);
        }
        public List<Sp_Statistical_Bill_Result> GetReportByYear(int year)
        {
            using (db)
            {
                var lsData = db.Sp_Statistical_Bill(year).ToList();
                return lsData;
            }
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
