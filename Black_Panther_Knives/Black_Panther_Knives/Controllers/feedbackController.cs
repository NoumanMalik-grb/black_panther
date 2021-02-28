using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Black_Panther_Knives.Models;
namespace Black_Panther_Knives.Controllers
{
    public class feedbackController : Controller
    {
        Model2 db = new Model2();
        // GET: review
        public ActionResult savefeedback(Review R)
        {
           
            db.Reviews.Add(R);
            db.SaveChanges();
            return RedirectToAction("Product_Detail","Home",new { id=R.Product_Fid});
        }
    }
}