using System.Collections.Generic;

namespace _01_Queries.ProductCategories.Contract
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryModel> GetAll();
        List<ProductCategoryModel> GettproductCategoriesWithProduct();
        List<ProductCategoryModel> GetLastesArrivals();
        ProductCategoryModel GetProdctsInCategoryby(string slug);
    }
}
