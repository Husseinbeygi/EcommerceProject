using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framework.Domin;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain;
using ShopManagement.Domain.ProductCategoryAggregation;

namespace ShopManagement.Application
{

    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploads _upload;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploads upload)
        {
            _productCategoryRepository = productCategoryRepository;
            _upload = upload;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exist(x => x.Name == command.Name))
            {
                return operation.Failed(Messages.FailedOpration_Duplicate);
            }
            var _slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name, command.Description,
             "", command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, _slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();

            var productCatgory = _productCategoryRepository.Get(command.Id);
            if (productCatgory == null)
            {
                return operation.Failed(Messages.FailedOpration_Null);
            }
            if (_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(Messages.FailedOpration_Duplicate);
            }
            var _slug = command.Slug.Slugify();
            var filepath = _upload.Upload(command.Picture,command.Slug);
            productCatgory.Edit(command.Name, command.Description,
            filepath, command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, _slug);

            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }


        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategoriesList()
        {
            return _productCategoryRepository.GetProductCategoriesList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var productCatgory = _productCategoryRepository.Get(id);
            if (productCatgory == null)
            {
                return operation.Failed(Messages.FailedOpration_Null);
            }
            productCatgory.Remove();
            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var productCatgory = _productCategoryRepository.Get(id);
            if (productCatgory == null)
            {
                return operation.Failed(Messages.FailedOpration_Null);
            }
            productCatgory.Restore();
            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            return _productCategoryRepository.Search(command);
        }
    }
}
