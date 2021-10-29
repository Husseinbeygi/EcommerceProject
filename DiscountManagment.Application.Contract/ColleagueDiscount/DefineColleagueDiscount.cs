using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;

namespace DiscountManagment.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        [Range(1,100000,ErrorMessage = Messages.IsRequired)]

        public long ProductId { get; set; }
        [Range(1, 100, ErrorMessage = Messages.IsRequired)]

        public int DiscountRate { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }


}
