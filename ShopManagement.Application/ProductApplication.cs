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
        public OperationResult Create(CreateProduct command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditProduct command)
        {
            throw new NotImplementedException();
        }

        public EditProduct GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            throw new NotImplementedException();
        }
    }
}
