using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SliderAggregation;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide slidePicture)
        {

            var operation = new OperationResult();
            if (_slideRepository.Exist(x => x.Picture == slidePicture.Picture))
            {
                return operation.Failed(Messages.FailedOpration_Duplicate);
            }
            
            var slide = new Slide(slidePicture.Picture,slidePicture.PictureAlt,slidePicture.PictureTitle,
                slidePicture.Heading,slidePicture.Title,slidePicture.Text,slidePicture.BtnText);

            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Succeeded();

        }

        public OperationResult Edit(EditSlide slidePicture)
        {
            var operation = new OperationResult();
            var _slideforedit = _slideRepository.Get(slidePicture.Id);
            if (_slideRepository == null)
            {
                return operation.Failed(Messages.FailedOpration_Null);
            }
            if (_slideRepository.Exist(x => x.Picture == slidePicture.Picture))
            {
                return operation.Failed(Messages.FailedOpration_Duplicate);
            }

            _slideforedit.Edit(slidePicture.Picture, slidePicture.PictureAlt, slidePicture.PictureTitle,
                slidePicture.Heading,slidePicture.Title,slidePicture.Text,slidePicture.BtnText);

            _slideRepository.SaveChanges();
            return operation.Succeeded();

        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var _slideforedit = _slideRepository.Get(id);
            if (_slideRepository == null)
            {
                return operation.Failed(Messages.FailedOpration_Null);
            }


            _slideforedit.Remove();

            _slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {

            var operation = new OperationResult();
            var _slideforedit = _slideRepository.Get(id);
            if (_slideRepository == null)
            {
                return operation.Failed(Messages.FailedOpration_Null);
            }


            _slideforedit.Restore();

            _slideRepository.SaveChanges();
            return operation.Succeeded();
        }
    }
}
