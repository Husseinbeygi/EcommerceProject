using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel command);
        List<CustomerDiscountViewModel> GetCustomerDiscountList();



    }
}
