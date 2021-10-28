using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using ShopManagment.Infrastructure.EfCore;

namespace DiscountManagment.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopcontext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopcontext) : base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.customerDiscounts.Select(x => new EditCustomerDiscount {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                StartDate = x.StartDate.ToFarsi(),
                ProductId = x.ProductId,
                Reason = x.Reason,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> GetList()
        {
            throw new NotImplementedException();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {

            var product = _shopcontext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.customerDiscounts.Select(x => new CustomerDiscountViewModel {
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                ProductId = x.ProductId,
                Reason = x.Reason,
                EndDateGr = x.EndDate,
                StartDateGr = x.StartDate,
                StartDate = x.StartDate.ToFarsi(),
                Id = x.Id,
                

            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query = query.Where(x => x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());

            }
            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                query = query.Where(x => x.EndDateGr > searchModel.EndDate.ToGeorgianDateTime());

            }

           var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(c => c.ProductName = product.FirstOrDefault(x => x.Id == c.ProductId)?.Name);
            return discount;

        }
    }
}
