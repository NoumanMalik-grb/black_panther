using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Black_Panther_Knives.Models;
namespace Black_Panther_Knives.Controllers
{
    public class CartController : Controller
    {
        Model2 db = new Model2();
        // GET: Cart
        public ActionResult cart()
        {
            return View();
        }
        public ActionResult Catfilter(int id)
        {
            TempData["Catid"] = id;
            return PartialView("_Shop");
        }
        public ActionResult SUbCatfilter(int id)
        {
            TempData["SubCatid"] = id;
            return PartialView("_Shop");
        }
        public ActionResult AddToCart(int id)
        {

            List<Product> list = new List<Product>();
            if (Session["myCart"] != null)
            {
                list = (List<Product>)Session["myCart"];
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
            Session["myCart"] = list;

            return RedirectToAction("cart");
        }
        public ActionResult MinusFromCart(int id)
        {

            List<Product> list = new List<Product>();
            if (Session["myCart"] != null)
            {
                list = (List<Product>)Session["myCart"];
            }
            list[id].Quantity--;
            if (list[id].Quantity == 0)
            {
                list.RemoveAt(id);
            }
            Session["myCart"] = list;

            return PartialView("_cart");
        }
        public ActionResult plusToCart(int id)
        {

            List<Product> list = new List<Product>();
            if (Session["myCart"] != null)
            {
                list = (List<Product>)Session["myCart"];
            }
            int p_id = list[id].Product_id;
            //int? available = db.Order_Detail.Where(x => x.product_fid == p_id).Sum(x => x.ORDER_QUANTITY);
            //if (available > list[id].Quantity)
                list[id].Quantity++;
            Session["myCart"] = list;

            return PartialView("_cart");
        }
        public ActionResult RemoveFromCart(int id)
        {
            List<Product> list = new List<Product>();
            if (Session["myCart"] != null)
            {
                list = (List<Product>)Session["myCart"];
            }
            list.RemoveAt(id);
            Session["myCart"] = list;
            return RedirectToAction("cart");
        }
        public ActionResult checkout() {

            return View();


         }
        [HttpPost]
        public ActionResult Checkout(Order o)
        {
            Session["Detail"] = o;
            
            //paypal code
            decimal totalamount = (decimal)Session["total"];
            //decimal totalamount = (decimal)Session["total"];

            //Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=wintershopping.info@gmail.com&amount=" + (totalamount / 170) + "&currency=USD&return=https://localhost:44328/cart/orderd_booked");
           //Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=waqasqureshi5456@gmail.com&amount=" + (totalamount) + "&currency=USD&return=https://localhost:44342/Cart/complete_order");

            return RedirectToAction("complete_order");

        }

        public ActionResult complete_order()
        {
            if (Session["Detail"] != null)
            {
                Order o = (Order)Session["Detail"];
                if (Session["userlogin"] != null)
                {
                    Account ac = (Account)Session["userlogin"];

                    o.Acount_fid = ac.Account_id;
                }
                o.Order_Date = System.DateTime.Now;
                o.order_payment_status = "Paypal";
                o.Order_Status = "Pending";
                o.order_type = "Sale";
                db.Orders.Add(o);
                db.SaveChanges();
                foreach (var pro in (List<Product>)Session["MyCart"])
                {
                    Order_Detail op = new Order_Detail();
                    op.Order_fid = db.Orders.Max(x => x.order_id);
                    op.product_fid = pro.Product_id;
                    op.od_purchase_price = pro.Product_Purchase_price;
                    op.Od_Sale_Price = pro.Product_Sale_Price;
                    op.ORDER_QUANTITY = pro.Quantity * -1;
                    db.Order_Detail.Add(op);
                    db.SaveChanges();


                }
                //Email
                if (o.Order_Email != null)
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("latin.food234@gmail.com");
                    mail.To.Add(o.Order_Email);
                    mail.Subject = "Verification Email";
                    mail.Body = "<b>Black Panther</b> <br> Thanks For Order ! Your Order has been placed your order will be deliverd in 2 working days <br>Your Order Number " + o.order_id + " " +
                        "Regrdas <br> Manager";
                    mail.IsBodyHtml = true;
                    SmtpClient Server = new SmtpClient("smtp.gmail.com");



                    Server.Port = 587;
                    Server.Credentials = new System.Net.NetworkCredential("latin.food234@gmail.com", "Latinfood123");
                    Server.EnableSsl = true;

                    Server.Send(mail);

                }
                //Email

                MailMessage mail1 = new MailMessage();
                mail1.From = new MailAddress("latin.food234@gmail.com");
                mail1.To.Add("ahsanchaudary10@gmail.com");
                mail1.Subject = "Email From Customer & Customer Email " + o.Order_Email + "& Customer Name" + o.Order_First_Name + " " + o.Order_Last_name + "";
                mail1.Body = "<b>Sheraz impex Site Customer </b> You have received new order from <b> " + o.Order_First_Name + " " + o.Order_Last_name + "</b> <br> and the Order id is <b> " + o.order_id + " </b>and customer" +
                "Email is <b> " + o.Order_Email + " </b> Please Login To Your Admin Account Check full Detail <br>" +
                    "From <br> Customer";
                mail1.IsBodyHtml = true;
                SmtpClient Server1 = new SmtpClient("smtp.gmail.com");



                Server1.Port = 587;
                Server1.Credentials = new System.Net.NetworkCredential("latin.food234@gmail.com", "Latinfood123");
                Server1.EnableSsl = true;

                Server1.Send(mail1);
                Session["Detail"] = null;
                Session["id"] = o.order_id;
                Session["MYCart"] = null;

            }
            return View();
        }
        //public ActionResult complete_order()
        //{
        //    return View();
        //}

    }
}