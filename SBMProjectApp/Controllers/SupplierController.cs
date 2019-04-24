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
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        SupplierManager _cuManager = new SupplierManager();
        SBMDbContext _db = new SBMDbContext();
        public ActionResult SupplierList()
        {
            ViewBag.CallingForm = "Supplier";
            ViewBag.CallingForm1 = "Supplier List";
            ViewBag.CallingViewPage = "#";
            return View(LoadSuppliers());
        }
        public ActionResult SupplierCreate()
        {
            DefaultLoad();
            return View();
        }

        [HttpPost]
        public ActionResult SupplierCreate(Supplier supplier)
        {
            DefaultLoad();
            try
            {
                if (supplier.UploadFiles != null && supplier.UploadFiles[0] != null)
                {
                    var supplierFileses = new List<SupplierFiles>();
                    foreach (var uploadFile in supplier.UploadFiles)
                    {
                        SupplierFiles supplierFiles = new SupplierFiles();
                        var fileByte = new byte[uploadFile.ContentLength];
                        uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                        supplierFiles.File = fileByte;
                        supplierFiles.FileName = uploadFile.FileName;

                        supplierFileses.Add(supplierFiles);
                    }

                    supplier.supplierFileses = supplierFileses;
                }
                bool isSave = false;
                isSave = _cuManager.SaveSupplier(supplier);
                if (isSave)
                {
                    ViewBag.SMsg = "Supplier Add Successfully!!";
                }
                else
                {
                    ViewBag.FMsg = "Supplier Add Failed!!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }
            //ViewBag.SubDistrictId = new SelectList(_db.SubDistricts, "Id", "Name", student.SubDistrictId);
            return View(supplier);
        }

        public ActionResult SupplierUpdate(int id)
        {
            DefaultLoad();
            Supplier supplier = new Supplier();
            supplier = _db.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            return View(supplier);
        }
        [HttpPost]
        public ActionResult SupplierUpdate(Supplier supplier)
        {
            DefaultLoad();
            try
            {
                bool isSave = false;
                isSave = _cuManager.UpdateSupplier(supplier);
                if (isSave)
                {
                    ViewBag.SMsg = "Supplier Update Successfully!!";
                }
                else
                {
                    ViewBag.FMsg = "Supplier Update Failed!!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }
            return View(supplier);
        }
        public JsonResult FxSupplierInfoDelete(int id)
        {
            bool isCompleted = false;
            try
            {
                isCompleted = _cuManager.DeleteSupplier(id);
            }
            catch (Exception ex)
            {
                throw ex;
                isCompleted = false;
            }

            return Json(new {isCompleted = isCompleted, JsonRequestBehavior.AllowGet});
        }
        public List<Supplier> LoadSuppliers()
        {
            List<Supplier> stList = new List<Supplier>();
            stList = _cuManager.GetSupplier();
            return stList;
        }

        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Supplier";
            ViewBag.CallingForm1 = "Supplier";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Supplier/SupplierList";
        }
	}
}