using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagment.Infrastructure.EFCore.Mapper
{
    class CustomerDiscountMapper : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscounts");
            builder.HasKey(x => x.Id);

            
        }
    }
}
