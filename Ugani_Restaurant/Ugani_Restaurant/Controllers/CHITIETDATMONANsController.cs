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
    public class CHITIETDATMONANsController : Controller
    {
        private UGANI_1Entities db = new UGANI_1Entities();

        // GET: CHITIETDATMONANs
        public ActionResult Index(string id)
        {
            var list = db.CHITIETDATMONANs.Include(m => m.MONAN).Include(m => m.AspNetUser).Where(m => m.MAKH == id).Where(m => m.NGAYDAT == null).ToList();
            return View(list);
        }

        // GET: CHITIETDATMONANs/Details/5
        public ActionResult Details(int? id)
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
            return View(cHITIETDATMONAN);
        }

        // GET: CHITIETDATMONANs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.MAMONAN = new SelectList(db.MONANs, "MAMONAN", "TENMONAN");
            return View();
        }

        // POST: CHITIETDATMONANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MAKH,MAMONAN,SOLUONG,NGAYDAT")] CHITIETDATMONAN cHITIETDATMONAN)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDATMONANs.Add(cHITIETDATMONAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.AspNetUsers, "Id", "UserName", cHITIETDATMONAN.MAKH);
            ViewBag.MAMONAN = new SelectList(db.MONANs, "MAMONAN", "TENMONAN", cHITIETDATMONAN.MAMONAN);
            return View(cHITIETDATMONAN);
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

        // GET: CHITIETDATMONANs/Delete/5
        public ActionResult Delete(int? id)
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
            return View(cHITIETDATMONAN);
        }

        // POST: CHITIETDATMONANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDATMONAN cHITIETDATMONAN = db.CHITIETDATMONANs.Find(id);
            db.CHITIETDATMONANs.Remove(cHITIETDATMONAN);
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
