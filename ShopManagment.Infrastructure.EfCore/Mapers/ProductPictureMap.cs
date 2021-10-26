using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPicureAggregation;

namespace ShopManagment.Infrastructure.EfCore.Mapers
{
    public class ProductPictureMap : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Picture).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(150).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductPictures).HasForeignKey(x => x.ProductId);

        }
    }
}
