using CoffeeShop.API.Data;
using CoffeeShop.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Items>>> GetProducts()
        {
            var users = await _context.Items.ToListAsync();
            return users;
        }

        [HttpGet("{id}")] //e.g. /api/users/1
        public async Task<ActionResult<Items>> EachProductDetails(int id)
        {
            var user = await _context.Items.FindAsync(id);
            return user;
        }

    }
}



//public ActionResult Index()
//{
//    string mycmd = "select * from Items";
//    dt = new DataTable();
//    dt = _mdal.SelactAll(mycmd);

//    List<Items> list = new List<Items>();
//    for (int i = 0; i < dt.Rows.Count; i++)
//    {
//        Items model = new Items();
//        model.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
//        model.ItemName = dt.Rows[i]["ItemName"].ToString();
//        model.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
//        model.Url = model.Id + ".png";
//        list.Add(model);
//    }
//    return View(list);
//}


//public ActionResult EachProductDetails(Items m)
//{
//    string mycmd = "select Id,ItemName,Price,Description from Items where Id=" + m.Id;
//    dt = new DataTable();
//    dt = _mdal.SelactAll(mycmd);
//    List<Items> list = new List<Items>();
//    for (int i = 0; i < dt.Rows.Count; i++)
//    {
//        Items model = new Items();
//        model.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
//        model.ItemName = dt.Rows[i]["ItemName"].ToString();
//        model.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
//        model.Description = dt.Rows[i]["Description"].ToString();
//        model.Url = "./ZoomImages/" + model.Id + ".png";
//        list.Add(model);
//    }
//    return View(list);
//}

