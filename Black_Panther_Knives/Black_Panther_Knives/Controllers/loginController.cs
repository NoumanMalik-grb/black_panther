using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Black_Panther_Knives.Models;
namespace Black_Panther_Knives.Controllers
{
    public class loginController : Controller
    {
        Model2 db = new Model2();
        // GET: login
        public ActionResult userlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult userlogin(Account ac)
        {
            Account userlogin = new Account();
            if (ac.Account_Name != null)
            {
            int emailcount=    db.Accounts.Where(x => x.Acount_Email == ac.Acount_Email).Count();
                if (emailcount >= 1)
                {
                    ViewBag.emailregister = "Email Already Register";
                    return View();
                }
                ac.Type = "Customer";
                ac.Acount_Pic = "no picture";
                db.Accounts.Add(ac);
                db.SaveChanges();
                ViewBag.registermsg = "Successfully Account Created";

            }
            else
            {
             userlogin=  db.Accounts.Where(x => x.Acount_Email == ac.Acount_Email && x.Acount_Password == ac.Acount_Password).FirstOrDefault();
                if (userlogin != null)
                {
                    if (userlogin.Type == "Customer")
                    {
                        Session["userlogin"] = userlogin;
                        return RedirectToAction("Shop", "Home");
                    }
                    else
                    {
                        Session["Adminlogin"] = userlogin;
                        return RedirectToAction("Adminindex", "Home");
                    }
                }
                else
                {
                    ViewBag.loginmessage = "Invalid Email And Password";
                }
            }
            return View();
        }
    }
}