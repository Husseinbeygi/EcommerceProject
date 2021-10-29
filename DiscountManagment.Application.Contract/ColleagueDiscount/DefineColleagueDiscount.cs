using System.Collections.Generic;
using ShopManagement.Domain.ProductAggregation;

namespace DiscountManagment.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {

        public long ProductId { get; set; }
        public int DiscountRate { get; set; }

        public List<Product> Products { get; set; }
    }


}
