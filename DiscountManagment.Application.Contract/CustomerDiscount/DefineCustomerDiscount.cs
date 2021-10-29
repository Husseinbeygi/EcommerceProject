using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100000, ErrorMessage = Messages.IsRequired)]

        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]

        public string StartDate { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]

        public string EndDate { get; set; }
        public string Reason { get; set; }

        public List<ProductViewModel> Products { get; set; }

    }


}
