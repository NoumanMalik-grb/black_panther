using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Black_Panther_Knives.Models;

namespace Black_Panther_Knives.Controllers
{
    public class ProductsController : Controller
    {
        private Model2 db = new Model2();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Sub_Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Sub_cat_Fid = new SelectList(db.Sub_Category, "sub_category_id", "Sub_category_name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,Product_Pics pics)
        {
            String fullpath = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic.FileName);
           pics.pic.SaveAs(fullpath);
            product.Product_PIc = "~/Content/Admin/img/Webpics/" + pics.pic.FileName;
            String fullpath2 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic2.FileName);
            pics.pic2.SaveAs(fullpath2);
            product.Product_pic2 = "~/Content/Admin/img/Webpics/" + pics.pic2.FileName;
            String fullpath3 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic3.FileName);
            pics.pic3.SaveAs(fullpath3);
            product.Product_pic3 = "~/Content/Admin/img/Webpics/" + pics.pic3.FileName;
            String fullpath4 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic4.FileName);
            pics.pic4.SaveAs(fullpath4);
            product.Product_pic4 = "~/Content/Admin/img/Webpics/" + pics.pic4.FileName;
            String fullpath5 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic5.FileName);
            pics.pic5.SaveAs(fullpath5);
            product.Product_pic5 = "~/Content/Admin/img/Webpics/" + pics.pic5.FileName;

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sub_cat_Fid = new SelectList(db.Sub_Category, "sub_category_id", "Sub_category_name", product.Sub_cat_Fid);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sub_cat_Fid = new SelectList(db.Sub_Category, "sub_category_id", "Sub_category_name", product.Sub_cat_Fid);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, Product_Pics pics)
        {

            if (pics.pic != null)
            {
                String fullpath = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic.FileName);
                pics.pic.SaveAs(fullpath);
                product.Product_PIc = "~/Content/Admin/img/Webpics/" + pics.pic.FileName;
            }
            if (pics.pic2 != null)
            {
                String fullpath2 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic2.FileName);
                pics.pic2.SaveAs(fullpath2);
                product.Product_pic2 = "~/Content/Admin/img/Webpics/" + pics.pic2.FileName;

            }
            if (pics.pic3 != null)
            {
                String fullpath3 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic3.FileName);
                pics.pic3.SaveAs(fullpath3);
                product.Product_pic3 = "~/Content/Admin/img/Webpics/" + pics.pic3.FileName;
            }
            if (pics.pic4 != null)
            {
                String fullpath4 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic4.FileName);
                pics.pic4.SaveAs(fullpath4);
                product.Product_pic4 = "~/Content/Admin/img/Webpics/" + pics.pic4.FileName;
            }
            if (pics.pic5 != null)
            {
                String fullpath5 = Server.MapPath("~/Content/Admin/img/Webpics/" + pics.pic5.FileName);
                pics.pic5.SaveAs(fullpath5);
                product.Product_pic5 = "~/Content/Admin/img/Webpics/" + pics.pic5.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sub_cat_Fid = new SelectList(db.Sub_Category, "sub_category_id", "Sub_category_name", product.Sub_cat_Fid);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
