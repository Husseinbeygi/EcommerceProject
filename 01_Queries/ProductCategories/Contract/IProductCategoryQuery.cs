using System.Collections.Generic;

namespace _01_Queries.ProductCategories.Contract
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryModel> GetAll();
    }
}
