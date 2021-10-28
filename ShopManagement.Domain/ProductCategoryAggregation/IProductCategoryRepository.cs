using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _0_Framework.Domin;
using ShopManagement.Application.Contracts.ProductCategory;
using _0_Framework.Infastructure;

namespace ShopManagement.Domain.ProductCategoryAggregation
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategoriesList();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);
    }
}
