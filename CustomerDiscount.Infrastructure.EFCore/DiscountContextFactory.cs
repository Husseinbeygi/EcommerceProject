using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DiscountManagment.Infrastructure.EFCore
{
    public class DiscountContextFactory : IDesignTimeDbContextFactory<DiscountContext>
    {
        public static string DatabaseConnectionString { get; set; }
        public DiscountContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DiscountContext>();
            optionsBuilder.UseSqlServer(DatabaseConnectionString);

            return new DiscountContext(optionsBuilder.Options);
        }
    }
}
