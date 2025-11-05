using Microsoft.EntityFrameworkCore;

namespace Order_MS.Models
{
    public class OrderDbContext :DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Orders> orders { get; set; }
    }
}
