using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Queries.Slider.Contract
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetAll();
    }
}
