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
            string mycmd = "select * from Items";
            dt = new DataTable();
            dt = _mdal.SelactAll(mycmd);
            //List<productDetails> list = new List<productDetails>();
            List<Items> list = new List<Items>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //productDetails pdet = new productDetails();
                //pdet.id = Convert.ToInt32(dt.Rows[i]["Id"]);
                //pdet.productName = dt.Rows[i]["ItemName"].ToString();
                //pdet.productDetail = dt.Rows[i]["productDetail"].ToString();
                //pdet.price = Convert.ToInt32(dt.Rows[i]["price"]);
                //list.Add(pdet);
                Items model = new Items();
                model.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                model.ItemName = dt.Rows[i]["ItemName"].ToString();
                model.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                model.Description = dt.Rows[i]["Description"].ToString();
                model.Url = dt.Rows[i]["Url"].ToString();
                list.Add(model);
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
                Items model = new Items();
                model.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                model.ItemName = dt.Rows[i]["ItemName"].ToString();
                model.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                model.Description = dt.Rows[i]["Description"].ToString();
                model.Url = dt.Rows[i]["Url"].ToString();
                list.Add(model);
            }
            return View(list);
        }
    }
}
