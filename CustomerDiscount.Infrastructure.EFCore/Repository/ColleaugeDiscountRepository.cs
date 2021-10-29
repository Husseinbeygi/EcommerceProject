using System.Collections.Generic;
using _0_Framework.Infastructure;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;

namespace DiscountManagment.Infrastructure.EFCore.Repository
{
    class ColleaugeDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;

        public ColleaugeDiscountRepository(DiscountContext context) : base (context)
        {
            _context = context;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
