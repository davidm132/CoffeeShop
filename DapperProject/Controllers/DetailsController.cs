using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using ItemDAL.cs;
using System.Reflection;

namespace DapperProject.Controllers
{
    public class DetailsController : Controller
    {
        ItemDetailDAL _mdal = new ItemDetailDAL();
        DataTable dt;
       
        public DetailsController()
        {
         
        }

      public ActionResult Index()
        {
            string mycmd = "select * from productDetails";
            dt = new DataTable();
            dt = _mdal.SelactAll(mycmd);
            List<productDetails> list = new List<productDetails>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                productDetails pdet = new productDetails();
                pdet.id = Convert.ToInt32(dt.Rows[i]["Id"]);
                pdet.productName = dt.Rows[i]["productName"].ToString();
                pdet.productDetail = dt.Rows[i]["productDetail"].ToString();
                pdet.price =Convert.ToInt32(dt.Rows[i]["price"]);
                list.Add(pdet);
            }
            return View(list);
        }

        public ActionResult DisplayProducts()
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
                mob.Url = dt.Rows[i]["Url"].ToString();
                list.Add(mob);
            }
            return View(list);

        }
            
        }
    }
