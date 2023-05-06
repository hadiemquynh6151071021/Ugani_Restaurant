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
            var list = db.CHITIETDATMONANs.Include(m=>m.AspNetUser).Include(m=>m.MONAN);
            list = list.Where(m => m.MAKH == id).Where(m=>m.NGAYDAT==date);
            //if (hOADON == null)
            //{
            //    return HttpNotFound();
            //}
            return View(list.ToList());
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
