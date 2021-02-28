using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Black_Panther_Knives.Models;

namespace Black_Panther_Knives.Controllers
{
    public class HomeController : Controller
    {
        Model2 db = new Model2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            contact.Contact_Date = System.DateTime.Now;
            contact.Status = "new";
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Product_Detail(int id)
        {
            
                TempData["pid"] = id;
           
            return View();
        }
        public ActionResult shop()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult cart()
        {
            

            return View();
        }

    }
}