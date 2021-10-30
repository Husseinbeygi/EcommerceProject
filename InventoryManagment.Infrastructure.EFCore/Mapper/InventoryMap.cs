using InventoryManagment.Domain.InventoryAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopManagment.Infrastructure.EfCore.Mapers
{
    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);


            builder.OwnsMany(x => x.InventoryOperations, modelbuilder => {
                modelbuilder.ToTable("InventoryOperations");
                modelbuilder.HasKey(x => x.Id);
                modelbuilder.Property(x => x.Description).HasMaxLength(1000);
                modelbuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);

            });
        }
    }
}
