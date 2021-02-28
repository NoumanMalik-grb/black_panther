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
    public class Sub_CategoryController : Controller
    {
        private Model2 db = new Model2();

        // GET: Sub_Category
        public ActionResult Index()
        {
            var sub_Category = db.Sub_Category.Include(s => s.Category);
            return View(sub_Category.ToList());
        }

        // GET: Sub_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            if (sub_Category == null)
            {
                return HttpNotFound();
            }
            return View(sub_Category);
        }

        // GET: Sub_Category/Create
        public ActionResult Create()
        {
            ViewBag.category_fid = new SelectList(db.Categories, "category_id", "Category_Name");
            return View();
        }

        // POST: Sub_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sub_category_id,Sub_category_name,category_fid,Discount")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                db.Sub_Category.Add(sub_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_fid = new SelectList(db.Categories, "category_id", "Category_Name", sub_Category.category_fid);
            return View(sub_Category);
        }

        // GET: Sub_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            if (sub_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_fid = new SelectList(db.Categories, "category_id", "Category_Name", sub_Category.category_fid);
            return View(sub_Category);
        }

        // POST: Sub_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sub_category_id,Sub_category_name,category_fid,Discount")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_fid = new SelectList(db.Categories, "category_id", "Category_Name", sub_Category.category_fid);
            return View(sub_Category);
        }

        // GET: Sub_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            if (sub_Category == null)
            {
                return HttpNotFound();
            }
            return View(sub_Category);
        }

        // POST: Sub_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            db.Sub_Category.Remove(sub_Category);
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
