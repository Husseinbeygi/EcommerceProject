using InventoryManagment.Domain.InventoryAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopManagment.Infrastructure.EfCore.Mapers
{
    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            //builder.ToTable("Products");
            builder.HasKey(x => x.Id);
        }
    }
}
