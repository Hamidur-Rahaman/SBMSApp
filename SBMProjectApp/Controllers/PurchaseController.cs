﻿using System;
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
    public class PurchaseController : Controller
    {
        //
        // GET: /Purchase/
        SBMDbContext _db = new SBMDbContext();
        PurchaseManager purchaseManager = new PurchaseManager();
        public ActionResult PurchaseList()
        {
            ViewBag.CallingForm = "Purchase";
            ViewBag.CallingForm1 = "Purchase List";
            ViewBag.CallingViewPage = "#";
            return View(purchaseManager.GetPurchaseInfo());
        }
        public ActionResult PurchaseCreate()
        {
            DefaultLoad();
            
            ViewBag.ProductDropdownList = new SelectList(_db.Products, "Id", "Name");
            ViewBag.SupplierDropdownList = new SelectList(_db.Suppliers, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseCreate(Purchase purchase)
        {
            DefaultLoad();
            try
            {
                bool isSave;
                
                foreach (var purchasedetails in purchase.PurchaseDetailses)
                {
                    var product = _db.Products.FirstOrDefault(p => p.Id == purchasedetails.ProductId);
                    product.AvailableQuantity = product.AvailableQuantity + (double) purchasedetails.Quantity;
                    product.Price = (double) purchasedetails.NewMRP;
                    //productManager.UpdateProduct(product);
                    _db.Entry(product).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                isSave = purchaseManager.SavePurchase(purchase);
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
            ViewBag.SupplierDropdownList = new SelectList(_db.Suppliers, "Id", "Name", purchase.SupplierId);
            return View();
        }
        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Purchase";
            ViewBag.CallingForm1 = "Purchase List";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Purchase/PurchaseList";
        }

        public JsonResult PurchaseInfoDelete(int id)
        {
            bool isCompleted = false;
            try
            {
                isCompleted = purchaseManager.DeletePurchaseInfo(id);
            }
            catch (Exception ex)
            {
                throw ex;
                isCompleted = false;
            }

            return Json(new { isCompleted = isCompleted, JsonRequestBehavior.AllowGet });
        }
        public JsonResult FxProductCodeData(int id)
        {
            var data = _db.Products.Where(x => x.Id == id).Select(x => new { x.Code, x.AvailableQuantity }).FirstOrDefault();
            return Json(new { data , JsonRequestBehavior.AllowGet });
        }

    }
}