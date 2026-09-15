using Microsoft.EntityFrameworkCore;
using testAPI_2.Models;
namespace testAPI_2.DBContext
{
    public class LearnApiContext : DbContext
    {
        public LearnApiContext(DbContextOptions<LearnApiContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
