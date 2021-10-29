using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using ShopManagment.Infrastructure.EfCore;

namespace DiscountManagment.Infrastructure.EFCore.Repository
{
    public class ColleaugeDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopcontext;
        public ColleaugeDiscountRepository(DiscountContext context, ShopContext shopcontext) : base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.colleagueDiscounts.Select(x => new EditColleagueDiscount {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var _product = _shopcontext.products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _context.colleagueDiscounts.Select(x => new ColleagueDiscountViewModel {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }
            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(c => c.ProductName = _product.FirstOrDefault(x => x.Id == c.ProductId)?.Name);
            return discount;


        }
    }
}
