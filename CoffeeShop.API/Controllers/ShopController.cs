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
        public async Task<ActionResult<IEnumerable<Items>>> GetUsers()
        {
            var users = await _context.Items.ToListAsync();
            return users;
        }

        [HttpGet("{id}")] //e.g. /api/users/1
        public async Task<ActionResult<Items>> GetUser(int id)
        {
            var user = await _context.Items.FindAsync(id);
            return user;
        }

    }
}

