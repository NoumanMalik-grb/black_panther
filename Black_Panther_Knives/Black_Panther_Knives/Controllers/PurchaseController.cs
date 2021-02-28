using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Black_Panther_Knives.Models;

namespace Black_Panther_Knives.Controllers
{
    public class PurchaseController : Controller
    {
        Model2 db = new Model2();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult cart()
        {
            return View();
        }
         public ActionResult shop()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {

            List<Product> list = new List<Product>();
            if (Session["Purchasecart"] != null)
            {
                list = (List<Product>)Session["Purchasecart"];
            }
            Boolean isnewproduct = true;
            foreach (var pro in list)
            {
                if (pro.Product_id == id)
                {
                    pro.Quantity++;
                    isnewproduct = false;
                }
            }
            if (isnewproduct == true)
            {
                list.Add(db.Products.Where(x => x.Product_id == id).FirstOrDefault());
                list[list.Count - 1].Quantity = 1;
            }
            Session["Purchasecart"] = list;

            return RedirectToAction("cart");
        }
        public ActionResult MinusFromCart(int id)
        {

            List<Product> list = new List<Product>();
            if (Session["Purchasecart"] != null)
            {
                list = (List<Product>)Session["Purchasecart"];
            }
            list[id].Quantity-=2;
            if (list[id].Quantity <= 0)
            {
                list.RemoveAt(id);
            }
            Session["Purchasecart"] = list;

            return PartialView("_cartpurchase");
        }
        public ActionResult plusToCart(int id)
        {

            List<Product> list = new List<Product>();
            if (Session["Purchasecart"] != null)
            {
                list = (List<Product>)Session["Purchasecart"];
            }
            int p_id = list[id].Product_id;
            //int? available = db.Order_Detail.Where(x => x.product_fid == p_id).Sum(x => x.ORDER_QUANTITY);
            //if (available > list[id].Quantity)
            list[id].Quantity+=3;
            Session["Purchasecart"] = list;

            return PartialView("_cartpurchase");
        }
        public ActionResult RemoveFromCart(int id)
        {
            List<Product> list = new List<Product>();
            if (Session["Purchasecart"] != null)
            {
                list = (List<Product>)Session["Purchasecart"];
            }
            list.RemoveAt(id);
            Session["Purchasecart"] = list;
            return PartialView("_cartpurchase");
        }
        public ActionResult checkout()
        {

            return View();


        }
        [HttpPost]
        public ActionResult Checkout(Order o)
        {
            Session["Detail"] = o;

            //paypal code
           
            //decimal totalamount = (decimal)Session["total"];

            //Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=wintershopping.info@gmail.com&amount=" + (totalamount / 170) + "&currency=USD&return=https://localhost:44328/cart/orderd_booked");
            //Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=waqasqureshi5456@gmail.com&amount=" + (totalamount) + "&currency=USD&return=https://localhost:44342/Cart/complete_order");

            return RedirectToAction("complete_order");

        }

        public ActionResult complete_order()
        {
            if (Session["Purchasecart"] != null)
            {
                Order o = new Order();
              
                    Account ac = (Account)Session["Adminlogin"];

                    o.Acount_fid = ac.Account_id;
                
                o.Order_Date = System.DateTime.Now;
                o.order_payment_status = "By Hand";
                o.Order_Status = "Deliverd";
                o.order_type = "Purchase";
                db.Orders.Add(o);
                db.SaveChanges();
                foreach (var pro in (List<Product>)Session["Purchasecart"])
                {
                    Order_Detail op = new Order_Detail();
                    op.Order_fid = db.Orders.Max(x => x.order_id);
                    op.product_fid = pro.Product_id;
                    op.od_purchase_price = pro.Product_Purchase_price;
                    op.Od_Sale_Price = pro.Product_Sale_Price;
                    op.ORDER_QUANTITY = pro.Quantity;
                    db.Order_Detail.Add(op);
                    db.SaveChanges();


                }
              
             
                Session["id"] = o.order_id;
                Session["Purchasecart"] = null;

            }
            return View();
        }
        //public ActionResult complete_order()
        //{
        //    return View();
        //}
    }
}