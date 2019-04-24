using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBMProjectBLL.settings;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectApp.Controllers
{
    public class ProductController : Controller
    {
        
        SBMDbContext _db = new SBMDbContext();
        ProductManager _productManager=new ProductManager();

        public ActionResult ProductList()
        {
            ViewBag.CallingForm = "Product";
            ViewBag.CallingForm1 = "Show Product";
            ViewBag.CallingViewPage = "#";
            return View(_productManager.GetProducts());
        }

        public ActionResult ProductCreate()
        {
            DefaultLoad();
            ViewBag.CategoryDropdownList = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product product)
        {
            DefaultLoad();
            try
            {
                if (product.UploadFiles != null && product.UploadFiles[0] != null)
                {
                    var productFiles = new List<ProductFiles>();
                    foreach (var uploadFile in product.UploadFiles)
                    {
                        var productFile = new ProductFiles();
                        var fileByte = new byte[uploadFile.ContentLength];
                        uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                        productFile.File = fileByte;
                        productFile.FileName = uploadFile.FileName;

                        productFiles.Add(productFile);
                    }

                    product.ProductFileses = productFiles;
                }

                bool isSave;
                isSave = _productManager.SaveCategory(product);
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
            ViewBag.CategoryDropdownList = new SelectList(_db.Categories, "Id", "Name", product.CategoryId);
            return View();
        }
        public ActionResult ProductUpdate(int id)
        {
            DefaultLoad();
            Product product = new Product();
            product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.CategoryDropdownList = new SelectList(_db.Categories, "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product product)
        {
            DefaultLoad();
            try
            {
                bool isSave;
                isSave = _productManager.UpdateProduct(product);
                if (isSave)
                {
                    ViewBag.SMsg = "Update Successfully !!";
                }
                else
                {
                    ViewBag.FMsg = "Update Failed !!";
                }
            }
            catch (Exception e)
            {
                ViewBag.FMsg = e.Message;
            }
            ViewBag.CategoryDropdownList = new SelectList(_db.Categories, "Id", "Name", product.CategoryId);
            return View();
        }
        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Product";
            ViewBag.CallingForm1 = "Product List";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Product/ProductList";
        }
        public JsonResult FxProductInfoDelete(int id)
        {
            bool isCompleted = false;
            try
            {
                isCompleted = _productManager.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw ex;
                isCompleted = false;
            }

            return Json(new { isCompleted = isCompleted, JsonRequestBehavior.AllowGet });
        }

        /*public void ProductDelete(int id)
        {
            Product product = GeProductById(id);
            _productManager.DeleteProduct(product);
        }
        public Product GeProductById(int id)
        {
            return _productManager.GeProductById(id);
        }*/
    }
}