using CoffeeShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.API.Data
{
	public class DataContext : DbContext
	{

		public DataContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Items> Items { get; set; }
	}

}