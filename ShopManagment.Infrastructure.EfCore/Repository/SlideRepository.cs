using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infastructure;
using ShopManagement.Domain.SliderAggregation;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public  class SlideRepository : RepositoryBase<long,Slide>,ISlideRepository
    {
    }
}
