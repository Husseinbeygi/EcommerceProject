using System;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {

        public long ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}
