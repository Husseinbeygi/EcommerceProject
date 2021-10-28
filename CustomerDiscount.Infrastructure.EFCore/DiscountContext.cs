using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagment.Domain.CustomerDiscountAgg;
using DiscountManagment.Infrastructure.EFCore.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagment.Infrastructure.EFCore
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> customerDiscounts { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var assambly = typeof(CustomerDiscountMap).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
