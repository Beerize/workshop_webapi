using Microsoft.EntityFrameworkCore;
using pos_api.Models;

namespace pos_api.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; } = null!;

        public DbSet<PurchaseDetail> PurchaseDetail { get; set; } = null!;
    }
}
