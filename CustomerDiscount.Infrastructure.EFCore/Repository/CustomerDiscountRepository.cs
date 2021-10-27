using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infastructure;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;

namespace DiscountManagment.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscount
    {
        private readonly DiscountContext _context;

        public CustomerDiscountRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public EditCustomerDiscount GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<CustomerDiscountViewModel> GetList()
        {
            throw new NotImplementedException();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
