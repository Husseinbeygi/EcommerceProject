using System;
using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain;

namespace ShopManagement.Application
{

    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
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
             command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, _slug);

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
            productCatgory.Edit(command.Name, command.Description,
             command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, _slug);

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

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            return _productCategoryRepository.Search(command);
        }
    }
}
