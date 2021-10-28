using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopManagment.Infrastructure.EfCore
{
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public static string DatabaseConnectionString { get; set; }
        public ShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(DatabaseConnectionString);

            return new ShopContext(optionsBuilder.Options);
        }
    }
}
