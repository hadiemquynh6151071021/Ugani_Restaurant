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
    public class BANANsController : Controller
    {
        private UGANI_1Entities db = new UGANI_1Entities();

        //GET: Admin/BANANs/VIP
        public ActionResult ListVIP()
        {
            var bANANs = db.BANANs.Include(b => b.LOAIBAN);
            bANANs = bANANs.Where(b => b.MALOAIBAN == 1).OrderBy(m=>m.SOGHE);
            ViewBag.MALOAIBAN = new SelectList(db.LOAIBANs, "MALOAIBAN", "TENLOAIBAN");
            return View(bANANs.ToList());
        }
        //GET: Admin/BANANs/Simple
        public ActionResult ListSimple()
        {
            var bANANs = db.BANANs.Include(b => b.LOAIBAN);
            bANANs = bANANs.Where(b => b.MALOAIBAN == 2).OrderBy(m => m.SOGHE);
            ViewBag.MALOAIBAN = new SelectList(db.LOAIBANs, "MALOAIBAN", "TENLOAIBAN");
            return View(bANANs.ToList());
        }


        // GET: Admin/BANANs/Create
        public ActionResult Create()
        {
            ViewBag.MALOAIBAN = new SelectList(db.LOAIBANs, "MALOAIBAN", "TENLOAIBAN");
            return View();
        }

        // POST: Admin/BANANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABAN,MALOAIBAN,SOGHE")] BANAN bANAN)
        {
            if (ModelState.IsValid)
            {
                db.BANANs.Add(bANAN);
                db.SaveChanges();
                if (bANAN.MALOAIBAN == 1)
                {
                    return RedirectToAction("ListVIP");
                }
                else
                {
                    return RedirectToAction("ListSimple");
                }
            }

            ViewBag.MALOAIBAN = new SelectList(db.LOAIBANs, "MALOAIBAN", "TENLOAIBAN", bANAN.MALOAIBAN);
            return View(bANAN);
        }

        // GET: Admin/BANANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAIBAN = new SelectList(db.LOAIBANs, "MALOAIBAN", "TENLOAIBAN", bANAN.MALOAIBAN);
            return View(bANAN);
        }

        // POST: Admin/BANANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABAN,MALOAIBAN,SOGHE")] BANAN bANAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANAN).State = EntityState.Modified;
                db.SaveChanges();
                if (bANAN.MALOAIBAN == 1)
                {
                    return RedirectToAction("ListVIP");
                }
                else
                {
                    return RedirectToAction("ListSimple");
                }
                
            }
            ViewBag.MALOAIBAN = new SelectList(db.LOAIBANs, "MALOAIBAN", "TENLOAIBAN", bANAN.MALOAIBAN);
            return View(bANAN);
        }

        // GET: Admin/BANANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return HttpNotFound();
            }
            return View(bANAN);
        }

        // POST: Admin/BANANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BANAN bANAN = db.BANANs.Find(id);
            db.BANANs.Remove(bANAN);
            db.SaveChanges();
            if (bANAN.MALOAIBAN == 1)
            {
                return RedirectToAction("ListVIP");
            }
            else
            {
                return RedirectToAction("ListSimple");
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
