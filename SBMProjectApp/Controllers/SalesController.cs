using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBMProjectBLL.settings;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectApp.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Sales/
        SBMDbContext _db = new SBMDbContext();
        SalesManager salesManager = new SalesManager();
        public ActionResult SalesList()
        {
            ViewBag.CallingForm = "Sales";
            ViewBag.CallingForm1 = "Sales List";
            ViewBag.CallingViewPage = "#";
            return View(salesManager.GetSalesInfo());
        }
        public ActionResult SalesCreate()
        {
            DefaultLoad();

            ViewBag.ProductDropdownList = new SelectList(_db.Products, "Id", "Name");
            ViewBag.CustomerDropdownList = new SelectList(_db.Customers, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalesCreate(Sales sales)
        {
            DefaultLoad();
            try
            {
                bool isSave;

                foreach (var salesDetails in sales.SalesDetailses)
                {
                    var product = _db.Products.FirstOrDefault(p => p.Id == salesDetails.ProductId);
                    product.AvailableQuantity = product.AvailableQuantity - (double)salesDetails.Quantity;
                    //productManager.UpdateProduct(product);
                    _db.Entry(product).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                isSave = salesManager.SaveSales(sales);
                if (isSave)
                {
                    ViewBag.SMsg = "Save Successfully !!";
                }
                else
                {
                    ViewBag.FMsg = "Save Failed !!";
                }
            }
            catch (Exception e)
            {
                ViewBag.FMsg = e.Message;
            }
            ViewBag.ProductDropdownList = new SelectList(_db.Products, "Id", "Name");
            ViewBag.CustomerDropdownList = new SelectList(_db.Customers, "Id", "Name", sales.CustomerId);
            return View();
        }
        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Sales";
            ViewBag.CallingForm1 = "Sales List";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Sales/SalesList";
        }
	}
}