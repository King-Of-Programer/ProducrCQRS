using Microsoft.EntityFrameworkCore;
using ProducrCQRS.Models;

namespace ProducrCQRS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
    }
}
