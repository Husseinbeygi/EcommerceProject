using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAggregation;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var _oprationresult = new OperationResult();
            if (_productRepository.Exist(x => x.Name == command.Name))
            {
                return _oprationresult.Failed(Messages.FailedOpration_Duplicate);
            }

            var _slug = command.Slug.Slugify();
            var _product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, 
                command.Picture, command.PictureAlt, command.PicutreTitle, _slug, 
                command.Keywords, command.MetaDescription, command.CaegoryId);

            _productRepository.Create(_product);
            _productRepository.SaveChanges();
            return _oprationresult.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var _oprationresult = new OperationResult();
            var _productforedit = _productRepository.Get(command.Id);
            if (_productforedit == null)
            {
                return _oprationresult.Failed(Messages.FailedOpration_Null);
            }

            if (_productRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
            {
                return _oprationresult.Failed(Messages.FailedOpration_Duplicate);
            }

            var _slug = command.Slug.Slugify();
            _productforedit.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, 
                command.Picture, command.PictureAlt, command.PicutreTitle, _slug, command.Keywords,
                command.MetaDescription, command.CaegoryId);

            _productRepository.SaveChanges();
            return _oprationresult.Succeeded();

        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public OperationResult InStock(long Productid)
        {
            var _oprationresult = new OperationResult();
            var _productforedit = _productRepository.Get(Productid);
            if (_productforedit == null)
            {
                return _oprationresult.Failed(Messages.FailedOpration_Null);
            }

            _productforedit.InStock();

            _productRepository.SaveChanges();
            return _oprationresult.Succeeded();
        }

        public OperationResult NotInStock(long Productid)
        {

            var _oprationresult = new OperationResult();
            var _productforedit = _productRepository.Get(Productid);
            if (_productforedit == null)
            {
                return _oprationresult.Failed(Messages.FailedOpration_Null);
            }

            _productforedit.OutOfStock();

            _productRepository.SaveChanges();
            return _oprationresult.Succeeded();
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            return _productRepository.Search(command);
        }
    }
}
