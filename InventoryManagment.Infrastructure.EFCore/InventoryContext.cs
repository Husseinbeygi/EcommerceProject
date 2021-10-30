using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagment.Domain.InventoryAggregation;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EfCore.Mapers;

namespace InventoryManagment.Infrastructure.EFCore
{
    public class InventoryContext : DbContext
    {
    public DbSet<Inventory> Inventories { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var assambly = typeof(InventoryMap).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);

            //var assamblyProduct = typeof(ProductMap).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assamblyProduct);

            base.OnModelCreating(modelBuilder);
        }
    }
}
