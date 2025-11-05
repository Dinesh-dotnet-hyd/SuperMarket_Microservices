using Microsoft.EntityFrameworkCore;

namespace Products_MS.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
