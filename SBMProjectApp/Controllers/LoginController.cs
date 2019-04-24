using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using (SBMDbContext db = new SBMDbContext())
                {
                    var getUser = db.Logins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                    if (getUser != null)
                    {
                        Session["UserId"] = login.UserId.ToString();
                        Session["UserName"] = login.UserName.ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(login);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SBMDbContext db = new SBMDbContext())
                    {
                        db.Logins.Add(login);
                        int isSave = db.SaveChanges();
                        if (isSave>0)
                        {
                            ViewBag.SMsg = "Save Successfully!!";
                        }
                        else
                        {
                            ViewBag.FMsg = "Save Filed!!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.FMsg = e.Message;
            }
            return View(login);
        }

        public ActionResult Dashboard()
        {
            ViewBag.CallingForm = "Dashboard";
            ViewBag.CallingForm1 = "Dashboard";
            ViewBag.CallingViewPage = "#";
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }  
        }
        public ActionResult LogOut()
        {
            bool isCompleted = false;
            try
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                isCompleted = true;
            }
            catch (Exception e)
            {
                isCompleted = false;
                throw;
            }

            return Json(new {isCompleted = isCompleted, JsonRequestBehavior.AllowGet});
        }  
	}
}