using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain;
using ShopManagment.Infrastructure.EfCore.Mapers;

namespace ShopManagment.Infrastructure.EfCore
{
   public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
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
