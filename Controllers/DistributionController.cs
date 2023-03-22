using ZERO_hunger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    //[Logged]
    public class OrderController : Controller
    {
        // GET: Order

        public ActionResult Index(int id = 1)
        {

            var db = new HungerContext();
            int itemperpage = 20;
            var products = db.Donations.OrderBy(e => e.Id).Skip((id - 1) * itemperpage).Take(itemperpage).ToList();

            var pagescount = Math.Ceiling(db.Donations.Count() / (decimal)itemperpage);
            ViewBag.Pages = pagescount;
            return View(products);


        }
        public ActionResult AddCart(int id)
        {
            HungerContext db = new HungerContext();
            List<Donation> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<Donation>();
            }
            else
            {
                cart = (List<Donation>)Session["cart"];
            }

            var product = db.Donations.Find(id);

            cart.Add(new Donation()
            {
                Id = product.Id,
                FoodName = product.FoodName,
                RId= product.RId,
                Status = product.Status,
                Validity = product.Validity,
            });
            Session["cart"] = cart;

            TempData["Msg"] = "Successfully Added";
            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {

            var cart = (List<Donation>)Session["cart"];
            if (cart != null)
            {
                return View(cart);
            }
            TempData["Msg"] = "Cart Empty";
            return RedirectToAction("Index");


        }
        public ActionResult EmployeePlace()
        {
            int orderSum = 0;
            var cart = (List<Donation>)Session["cart"];
            /*Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Status = "Ordered";
            order.Amount = 0;
            PMSContext db = new PMSContext();
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var p in cart)
            {
                var od = new OrderDetail();
                od.OId = order.Id;
                od.PId = p.Id;
                od.Price = (int)p.Price;
                od.Qty = p.Qty;
                orderSum += (p.Qty * (int)p.Price);
                db.OrderDetails.Add(od);
            }
            order.Amount = orderSum;
            db.SaveChanges();
            Session["cart"] = null;
            TempData["Msg"] = "Order Placed Successfully";*/
            return RedirectToAction("Index"); 

        }

    }
} 