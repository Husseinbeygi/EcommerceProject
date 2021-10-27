using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagment.Infrastructure.EFCore
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> customerDiscounts;
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //var assambly = typeof(ProductCategoryMap).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assambly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
