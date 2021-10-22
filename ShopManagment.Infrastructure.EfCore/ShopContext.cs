using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EfCore.Mapers;

namespace ShopManagment.Infrastructure.EfCore
{
    class ShopContext : DbContext
    {
        public DbSet<ShopContext> _shopcontext { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var assambly = typeof(ProductCategoryMap).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);


            base.OnModelCreating(modelBuilder);
        }
    }
}
