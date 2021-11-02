using _01_Queries.ProductCategories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Pages.ViewComponents
{
    public class ProductCategoryWithProductsViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProductsViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(_productCategoryQuery.GettproductCategoriesWithProduct());
        }

    }
}
