using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        public OperationResult Create(CreateSlide productPicture)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditSlide productPicture)
        {
            throw new NotImplementedException();
        }

        public EditSlide GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<SlideViewModel> GetList()
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Restore(long id)
        {
            throw new NotImplementedException();
        }
    }
}
