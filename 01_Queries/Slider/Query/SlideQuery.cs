using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Queries.Slider.Contract;
using ShopManagment.Infrastructure.EfCore;

namespace _01_Queries.Slider.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetAll()
        {
            return _context.Slide.Where(x => x.IsRemoved == false)
                                 .Select(x => new SlideQueryModel { 
                                     BtnText = x.BtnText,
                                     Heading = x.Heading,
                                     Link = x.Link,
                                     Picture = x.Picture,
                                     PictureAlt = x.PictureAlt,
                                     PictureTitle = x.PictureTitle,
                                     Text =x.Text,
                                     Title =x.Title
                                    }).ToList();
        }
    }
}
