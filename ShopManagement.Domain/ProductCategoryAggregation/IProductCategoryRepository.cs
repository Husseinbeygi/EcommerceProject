using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _0_Framework.Domin;
using ShopManagement.Application.Contracts.ProductCategory;
using _0_Framework.Infastructure;

namespace ShopManagement.Domain
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);
    }
}
