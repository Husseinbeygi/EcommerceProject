using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Domin;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.SliderAggregation
{
    public interface ISlideRepository : IRepository<long , Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();


    }
}
