using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ItemDAL.cs;
using DapperProject.Models;

namespace DapperProject.Controllers
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
                Items mob = new Items();
                mob.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                mob.ItemName = dt.Rows[i]["ItemName"].ToString();
                mob.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                mob.Url = mob.Id + ".png"; // dt.Rows[i]["Url"].ToString();
                list.Add(mob);
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
            string mycmd = "select m.Id,m.ItemName,m.price,m.url,md.Features,md.model,md.color,md.SimType from Items m inner join ItemDetails md on m.Id=md.Id where m.Id="+m.Id+"";
            dt = new DataTable();
            dt = _mdal.SelactAll(mycmd);
            List<ProductDetails> list = new List<ProductDetails>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductDetails mob = new ProductDetails();
                mob.slno = Convert.ToInt32(dt.Rows[i]["Id"]);
                mob.ItemName = dt.Rows[i]["ItemName"].ToString();
                mob.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                mob.Url = dt.Rows[i]["Url"].ToString();
                mob.Features= dt.Rows[i]["Features"].ToString();
                mob.color = dt.Rows[i]["color"].ToString();
                mob.SimType = dt.Rows[i]["SimType"].ToString();
                list.Add(mob);
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