using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain;
using ShopManagement.Domain.ProductAggregation;
using ShopManagement.Domain.ProductPicureAggregation;
using ShopManagement.Domain.SliderAggregation;
using ShopManagment.Infrastructure.EfCore.Mapers;

namespace ShopManagment.Infrastructure.EfCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductPicture> ProductsPicture { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var assambly = typeof(ProductCategoryMap).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);

            //var assamblyProduct = typeof(ProductMap).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assamblyProduct);

            base.OnModelCreating(modelBuilder);
        }
    }
}
