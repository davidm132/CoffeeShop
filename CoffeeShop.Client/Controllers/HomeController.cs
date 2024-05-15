using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using ItemDAL.cs;
using CoffeeShop.Client.Models;

namespace CoffeeShop.Client.Controllers
{
    public class HomeController : Controller
    {

        ItemDetailDAL _mdal = new ItemDetailDAL();
        DataTable dt;

        public ActionResult Index()
        {
            string mycmd = "select * from Items";
            dt = new DataTable();
            dt = _mdal.SelactAll(mycmd);

            List<Items> list = new List<Items>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Items model = new Items();
                model.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                model.ItemName = dt.Rows[i]["ItemName"].ToString();
                model.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                model.Url = model.Id + ".png";
                list.Add(model);
            }
            return View(list);
        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult EachProductDetails(Items m)
        {
            string mycmd = "select Id,ItemName,Price,Description from Items where Id=" + m.Id;
            dt = new DataTable();
            dt = _mdal.SelactAll(mycmd);
            List<Items> list = new List<Items>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Items model = new Items();
                model.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                model.ItemName = dt.Rows[i]["ItemName"].ToString();
                model.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                model.Description = dt.Rows[i]["Description"].ToString();
                model.Url = "./ZoomImages/" + model.Id + ".png";
                list.Add(model);
            }           
            return View(list);         
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}