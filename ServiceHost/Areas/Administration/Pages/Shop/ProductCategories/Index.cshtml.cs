using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> productCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {

            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductCategorySearchModel searchModel)
        {
            productCategories = _productCategoryApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory productCategory)
        {
            var result = _productCategoryApplication.Create(productCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editProductCategory = _productCategoryApplication.GetDetails(id);
            return Partial("./Edit", _editProductCategory);
        }
        public JsonResult OnPostEdit(EditProductCategory productCategory)
        {
            var result = _productCategoryApplication.Edit(productCategory);
            return new JsonResult(result);
        }
    }
}
