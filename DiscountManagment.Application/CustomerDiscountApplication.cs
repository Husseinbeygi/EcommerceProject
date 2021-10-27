using System;
using System.Collections.Generic;
using _0_Framework.Application;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Infrastructure.EFCore.Repository;

namespace DiscountManagment.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly CustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(CustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
                throw new NotImplementedException();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDiscountViewModel> GetCustomerDiscountList()
        {
            throw new NotImplementedException();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel command)
        {
            throw new NotImplementedException();
        }
    }
}
