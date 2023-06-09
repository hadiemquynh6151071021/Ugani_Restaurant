﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ugani_Restaurant.Models;

namespace Ugani_Restaurant.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private UGANI_1Entities db = new UGANI_1Entities();

        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.a = getListYear();
            ViewBag.PageView = HttpContext.Application["PageView"].ToString();
            ViewBag.Online = HttpContext.Application["Online"].ToString();
            ViewBag.CountFoods = CountFoods();
            ViewBag.CountBills = CountBills();
            return View();
        }

        public Object getListYear()
        {
            var lsYear = db.Sp_ListYear().ToList();
            return lsYear;
        }
        public int CountFoods()
        {
            int Sum = db.MONANs.Count();
            return Sum;
        }

        public int CountBills()
        {
            int Sum = db.HOADONs.Count();
            return Sum;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(db != null)
                {
                    db.Dispose();
                }
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}