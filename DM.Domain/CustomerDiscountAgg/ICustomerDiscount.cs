using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domin;
using DiscountManagment.Application.Contract.CustomerDiscount;

namespace DiscountManagment.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscount : IRepository<long,CustomerDiscount>
    {

        EditCustomerDiscount GetDetails();
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
        List<CustomerDiscountViewModel> GetList();


    }
}
