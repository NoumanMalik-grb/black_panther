using Black_Panther_Knives.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Black_Panther_Knives.Controllers
{
    public class ReportsController : Controller
    {
        Model2 db = new Model2();
        // GET: Repport
        public ActionResult PurchaseReport(Filters f)
        {

            if (f.Date_From == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                f.Date_From = System.DateTime.Today;
            }
            else
                ViewBag.DateFrom = Convert.ToDateTime(f.Date_From).ToString("s");
            if (f.Date_To == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                f.Date_To = System.DateTime.Now;
            }
            else
                ViewBag.DateTo = Convert.ToDateTime(f.Date_To).ToString("s");

            ViewBag.Category = db.Sub_Category.Select(x => new SelectListItem { Value = x.sub_category_id.ToString(), Text = x.Sub_category_name });
            if (f.Category == null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });
            }
            else
                ViewBag.Product = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });


            var od = db.Order_Detail.Select(x => x.Order_fid).ToList();
            if (f.Category != null)
            {
                var p = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => x.Product_id).ToList();
                if (f.Product != null)
                {

                    p = db.Products.Where(x => x.Product_id == f.Product).Select(x => x.Product_id).ToList();
                }

                od = db.Order_Detail.Where(x => p.Contains(x.product_fid)).Select(x => x.Order_fid).ToList();

            }
            var o = db.Orders.Where(x => x.order_type == "Purchase" & x.Order_Date >= f.Date_From & x.Order_Date <= f.Date_To & od.Contains(x.order_id)).ToList();

            return View(o);
        }


        public ActionResult SaleReport(Filters f)
        {

            if (f.Date_From == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                f.Date_From = System.DateTime.Today;
            }
            else
                ViewBag.DateFrom = Convert.ToDateTime(f.Date_From).ToString("s");
            if (f.Date_To == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                f.Date_To = System.DateTime.Now;
            }
            else
                ViewBag.DateTo = Convert.ToDateTime(f.Date_To).ToString("s");

            ViewBag.Category = db.Sub_Category.Select(x => new SelectListItem { Value = x.sub_category_id.ToString(), Text = x.Sub_category_name });
            if (f.Category == null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });
            }
            else
                ViewBag.Product = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });


            var od = db.Order_Detail.Select(x => x.Order_fid).ToList();
            if (f.Category != null)
            {
                var p = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => x.Product_id).ToList();
                if (f.Product != null)
                {

                    p = db.Products.Where(x => x.Product_id == f.Product).Select(x => x.Product_id).ToList();
                }

                od = db.Order_Detail.Where(x => p.Contains(x.product_fid)).Select(x => x.Order_fid).ToList();

            }
            var o = db.Orders.Where(x => x.order_type == "Sale" & x.Order_Status == "Deliverd" & x.Order_Date >= f.Date_From & x.Order_Date <= f.Date_To & od.Contains(x.order_id)).ToList();

            return View(o);
        }



        public ActionResult NewOrder(Filters f)
        {

            if (f.Date_From == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.AddMonths(-1).ToString("s");
                f.Date_From = System.DateTime.Today.AddMonths(-1);
            }
            else
                ViewBag.DateFrom = Convert.ToDateTime(f.Date_From).ToString("s");
            if (f.Date_To == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                f.Date_To = System.DateTime.Now;
            }
            else
                ViewBag.DateTo = Convert.ToDateTime(f.Date_To).ToString("s");

            ViewBag.Category = db.Sub_Category.Select(x => new SelectListItem { Value = x.sub_category_id.ToString(), Text = x.Sub_category_name });
            if (f.Category == null)
            {
                ViewBag.Product = new SelectList(db.Products, "Product_ID", "Product_Name");
            }
            else
                ViewBag.Product = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });


            var od = db.Order_Detail.Select(x => x.Order_fid).ToList();
            if (f.Category != null)
            {
                var p = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => x.Product_id).ToList();
                if (f.Product != null)
                {

                    p = db.Products.Where(x => x.Product_id == f.Product).Select(x => x.Product_id).ToList();
                }

                od = db.Order_Detail.Where(x => p.Contains(x.product_fid)).Select(x => x.Order_fid).ToList();

            }
            var o = db.Orders.Where(x => x.order_type == "Sale" & x.Order_Status == "Pending" & x.Order_Date >= f.Date_From & x.Order_Date <= f.Date_To & od.Contains(x.order_id)).OrderBy(x => x.Order_Date).ToList();

            return View(o);
        }
        public ActionResult Invoice(int id)
        {
            TempData["ID"] = id;
            return View();
        }
        public ActionResult StockReport(Filters f)
        {
            if (f.Date_To == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                f.Date_To = System.DateTime.Now;
            }
            else
                ViewBag.DateTo = Convert.ToDateTime(f.Date_To).ToString("s");

            ViewBag.Category = db.Sub_Category.Select(x => new SelectListItem { Value = x.sub_category_id.ToString(), Text = x.Sub_category_name });
            if (f.Category == null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });
            }
            else
                ViewBag.Product = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });


            var p = db.Products.ToList();
            if (f.Category != null)
            {
                p = db.Products.Where(x => x.Sub_cat_Fid == f.Category).ToList();
                if (f.Product != null)
                {

                    p = db.Products.Where(x => x.Product_id == f.Product).ToList();
                }



            }


            return View(p);
        }

        [HttpPost]
        public ActionResult contactreport(Filters f)
        {
            TempData["contactDate"] = f;
            return View();
        }

        public ActionResult Update(int id)
        {
            Order o = db.Orders.Where(x => x.order_id == id).FirstOrDefault();

            o.Order_Status = "Deliverd";

            db.Entry(o).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("NewOrder");


        }

        public ActionResult contactreport()
        {

            return View();
        }
        public ActionResult invoice_c()
        {
            return View();
        }
        public ActionResult ProfitLossReport()
        {
            return View();
        }

        public JsonResult Report(Filters f)
        {

            if (f.Date_From == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                f.Date_From = System.DateTime.Today;
            }
            else
                ViewBag.DateFrom = Convert.ToDateTime(f.Date_From).ToString("s");
            if (f.Date_To == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                f.Date_To = System.DateTime.Now;
            }
            else
                ViewBag.DateTo = Convert.ToDateTime(f.Date_To).ToString("s");

            ViewBag.Category = db.Sub_Category.Select(x => new SelectListItem { Value = x.sub_category_id.ToString(), Text = x.Sub_category_name });
            if (f.Category == null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });
            }
            else
                ViewBag.Product = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_Name });


            var od = db.Order_Detail.Select(x => x.Order_fid).ToList();
            if (f.Category != null)
            {
                var p = db.Products.Where(x => x.Sub_cat_Fid == f.Category).Select(x => x.Product_id).ToList();
                if (f.Product != null)
                {

                    p = db.Products.Where(x => x.Product_id == f.Product).Select(x => x.Product_id).ToList();
                }

                od = db.Order_Detail.Where(x => p.Contains(x.product_fid)).Select(x => x.Order_fid).ToList();

            }
            var o = db.Orders.Where(x => x.order_type == "Sale" & x.Order_Status == "Deliverd" & x.Order_Date >= f.Date_From & x.Order_Date <= f.Date_To & od.Contains(x.order_id)).ToList();

            return Json(o);
        }

    }
}