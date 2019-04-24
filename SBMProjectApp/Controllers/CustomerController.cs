using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBMProjectBLL.settings;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;
using SBMProjectModel.Models.ViewModels;


namespace SBMProjectApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /Customer/
        CustomerManager _cuManager = new CustomerManager();
        SBMDbContext _db = new SBMDbContext();
        public ActionResult CustomerList()
        {
            ViewBag.CallingForm = "Customer";
            ViewBag.CallingForm1 = "Customer List";
            ViewBag.CallingViewPage = "#";
            return View(LoadCustomers());
        }
        public ActionResult CustomerCreate()
        {
            DefaultLoad();
            return View();
            
        }

        [HttpPost]
        public ActionResult CustomerCreate(Customer customer)
        {
            DefaultLoad();
            try
            {
                if (customer.UploadFiles != null && customer.UploadFiles[0] != null)
                {
                    var customerFiles = new List<CustomerFiles>();
                    foreach (var uploadFile in customer.UploadFiles)
                    {
                        var customerFile = new CustomerFiles();
                        var fileByte = new byte[uploadFile.ContentLength];
                        uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                        customerFile.File = fileByte;
                        customerFile.FileName = uploadFile.FileName;

                        customerFiles.Add(customerFile);
                    }

                    customer.CustomerFileses = customerFiles;
                }

                bool isSave = false;
                isSave = _cuManager.SaveCustomer(customer);
                if (isSave)
                {
                    ViewBag.SMsg = "Student Add Successfully!!";
                }
                else
                {
                    ViewBag.FMsg = "Student Add Failed!!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }
            //ViewBag.SubDistrictId = new SelectList(_db.SubDistricts, "Id", "Name", student.SubDistrictId);
            return View(customer);
        }

        public ActionResult CustomerUpdate(int id)
        {
            DefaultLoad();
            Customer customer = new Customer();
            customer = _db.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(customer);
        }
        [HttpPost]
        public ActionResult CustomerUpdate(Customer customer)
        {
            DefaultLoad();
            try
            {
                
                bool isSave = false;
                isSave = _cuManager.UpdateCustomer(customer);
                if (isSave)
                {
                    ViewBag.SMsg = "Student Update Successfully!!";
                }
                else
                {
                    ViewBag.FMsg = "Student Update Failed!!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }
            return View(customer);
        }
        public JsonResult FxCustomerInfoDelete(int id)
        {
            bool isCompleted = false;
            try
            {
                isCompleted = _cuManager.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw ex;
                isCompleted = false;
            }

            return Json(new { isCompleted = isCompleted, JsonRequestBehavior.AllowGet });
        }
        //public ActionResult CustomerDelete(int id)
        //{
        //    DefaultLoad();
        //    try
        //    {
        //        bool isSave = false;
        //        isSave = _cuManager.UpdateCustomer(customer);
        //        if (isSave)
        //        {
        //            ViewBag.SMsg = "Student Update Successfully!!";
        //        }
        //        else
        //        {
        //            ViewBag.FMsg = "Student Update Failed!!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.FMsg = ex.Message;
        //    }
        //    return View(customer);
        //}
        public List<Customer> LoadCustomers()
        {
            List<Customer> stList = new List<Customer>();
            stList = _cuManager.GetCustomer();
            return stList;
        }

        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Customer";
            ViewBag.CallingForm1 = "Customer";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Customer/CustomerList";
        }
	}
}