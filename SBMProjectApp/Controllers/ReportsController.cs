using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMProjectApp.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/
        public ActionResult StockSearch()
        {
            ViewBag.CallingForm = "Stock";
            ViewBag.CallingForm1 = "Stock Report";
            ViewBag.CallingViewPage = "#";
            return View();
        }
	}
}