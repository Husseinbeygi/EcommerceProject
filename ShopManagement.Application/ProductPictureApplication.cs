using System;
using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPicureAggregation;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {

        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var _operationResult = new OperationResult();

            if (_productPictureRepository.Exist(x => x.Picture == command.Picture))
            {
                return _operationResult.Failed(Messages.FailedOpration_Duplicate);
            }
            var productPicture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);

            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return _operationResult.Succeeded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var _operationResult = new OperationResult();

            var _productPictureForEdit = _productPictureRepository.Get(command.Id);
            if (_productPictureForEdit == null)
            {
                return _operationResult.Failed(Messages.FailedOpration_Null);
            }
            if (_productPictureForEdit.Picture == null)
            {
                return _operationResult.Failed(Messages.FailedOpration_PictureNull);
            }
            if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            {
                return _operationResult.Failed(Messages.FailedOpration_Duplicate);
            }

            _productPictureForEdit.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return _operationResult.Succeeded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {

            var _oprationResult = new OperationResult();
            var _productforedit = _productPictureRepository.Get(id);
            if (_productforedit == null)
            {
                return _oprationResult.Failed(Messages.FailedOpration_Null);
            }
            _productforedit.Remove();
            _productPictureRepository.SaveChanges();
            return _oprationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {


            var _oprationResult = new OperationResult();
            var _productforedit = _productPictureRepository.Get(id);
            if (_productforedit == null)
            {
                return _oprationResult.Failed(Messages.FailedOpration_Null);
            }
            _productforedit.Restore();
            _productPictureRepository.SaveChanges();
            return _oprationResult.Succeeded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSerachModel command)
        {
            return _productPictureRepository.Search(command);
        }
    }
}

