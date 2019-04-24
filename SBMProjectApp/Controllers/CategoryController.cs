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
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        CategoryManager _cgManager=new CategoryManager();
        SBMDbContext _db = new SBMDbContext();

        public ActionResult CategoryList()
        {
            ViewBag.CallingForm = "Category";
            ViewBag.CallingForm1 = "Category List";
            ViewBag.CallingViewPage = "#";

            return View(_cgManager.GetCategory());
        }

        public ActionResult CategoryCreate()
        {
            DefaultLoad();
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(Category category)
        {
            DefaultLoad();
            try
            {
                bool isSave;
                isSave = _cgManager.SaveCategory(category);
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
            return View();
        }
        public ActionResult CategoryUpdate(int id)
        {
            DefaultLoad();
            Category category = new Category();
            category = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            DefaultLoad();
            try
            {
                bool isSave;
                isSave = _cgManager.UpdateCategory(category);
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
            return View();
        }
        public void DefaultLoad()
        {
            ViewBag.CallingForm = "Category";
            ViewBag.CallingForm1 = "Category List";
            ViewBag.CallingForm2 = "Add New";
            ViewBag.CallingViewPage = "/Category/CategoryList";
        }

        public JsonResult FxCategoryInfoDelete(int id)
        {
            bool isCompleted = false;
            try
            {
                isCompleted = _cgManager.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                throw ex;
                isCompleted = false;
            }

            return Json(new { isCompleted = isCompleted, JsonRequestBehavior.AllowGet });
        }
    }
}