using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CoffeeShop.Client.Models;
using System.Data;
using ItemDAL.cs;

namespace CoffeeShop.Client.Controllers
{
    public class AddToCartController : Controller
    {
        DataTable dt;
        ItemDetailDAL _mdal = new ItemDetailDAL();
        // GET: AddToCart
        public ActionResult Add( Items mo)
        {            
            if (Session["cart"]==null)
            {
                List<Items> li = new List<Items>();
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                    Session["count"] = 1;
            }
            else
            {
                List<Items> li = (List<Items>)Session["cart"];
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Index", "Home");           
        }

        public ActionResult Myorder()
        {
            return View((List<Items>)Session["cart"]);
        }

        public ActionResult Remove(Items mob)
        {
            List<Items> li = (List<Items>)Session["cart"];
            li.RemoveAll(x=>x.Id==mob.Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}