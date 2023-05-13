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

        // GET: Admin/HOADONs
        public ActionResult Index()
        {
            var hOADONs = db.HOADONs.Include(m => m.AspNetUser).OrderByDescending(m=>m.NGAYDATCOC);
            return View(hOADONs.ToList());
        }
        // GET: Admin/HOADONs/Details
        public ActionResult Detailsfood(string id,DateTime date)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dataset = db.CHITIETDATBANs.Where(m => m.MAKH == id).Where(m=>m.NGAYDAT==date);
            IList<CHITIETDATBAN> listTable = new List<CHITIETDATBAN>();
            listTable = dataset.ToList();
            ViewBag.lsTable = listTable;
            var list = db.CHITIETDATMONANs.Include(m=>m.AspNetUser).Include(m=>m.MONAN).Where(m => m.MAKH == id).Where(m => m.NGAYDAT == date).ToList();
            //list = list.Where(m => m.MAKH == id).Where(m=>m.NGAYDAT==date);
            ViewBag.listFood = list;
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Admin/HOADONs/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detailsfood(string id, DateTime date,HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                hOADON = db.HOADONs.Where(m => m.MAKH == id).Where(m => m.NGAYDATCOC == date).First();
                hOADON.TINHTRANG = "Đã duyệt";
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(db.CHITIETDATMONANs);
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
