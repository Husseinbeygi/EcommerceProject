using System;
using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);
        List<ProductCategoryViewModel> GetProductCategoriesList();
        OperationResult Remove(long id);
        OperationResult Restore(long id);

    }
}
