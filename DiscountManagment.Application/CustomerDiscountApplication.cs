using System;
using System.Collections.Generic;
using _0_Framework.Application;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using DiscountManagment.Infrastructure.EFCore.Repository;

namespace DiscountManagment.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var oprationResult = new OperationResult();
            if (_customerDiscountRepository.Exist(x => x.ProductId == command.ProductId))
            {
                return oprationResult.Failed(Messages.FailedOpration_Duplicate);
            }
            var _customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(),command.Reason);

            _customerDiscountRepository.Create(_customerDiscount);
            _customerDiscountRepository.SaveChanges();
            return oprationResult.Succeeded();

        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var oprationResult = new OperationResult();
            var _customerDiscount = _customerDiscountRepository.Get(command.Id);
            if (_customerDiscount == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }
            
            _customerDiscount.Edit(command.ProductId,command.DiscountRate,command.StartDate.ToGeorgianDateTime(),command.EndDate.ToGeorgianDateTime(),command.Reason);
            _customerDiscountRepository.SaveChanges();
            return oprationResult.Succeeded();
        }

        public List<CustomerDiscountViewModel> GetCustomerDiscountList()
        {
            throw new NotImplementedException();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel command)
        {
            return _customerDiscountRepository.Search(command);
        }
    }
}
