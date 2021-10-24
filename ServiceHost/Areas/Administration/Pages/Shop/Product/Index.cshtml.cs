using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> productViewModel;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public SelectList listProductCategories;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {

            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductSearchModel searchModel)
        {
            listProductCategories = new SelectList(_productCategoryApplication.GetProductCategoriesList(), "Id","Name");
            productViewModel = _productApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var cmd = new CreateProduct();
            cmd.Categories = _productCategoryApplication.GetProductCategoriesList();
            return Partial("./Create", cmd);
        }
        public JsonResult OnPostCreate(CreateProduct product)
        {
            var result = _productApplication.Create(product);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editProduct = _productApplication.GetDetails(id);
            _editProduct.Categories = _productCategoryApplication.GetProductCategoriesList();
            return Partial("./Edit", _editProduct);
        }
        public JsonResult OnPostEdit(EditProduct product)
        {
            var result = _productApplication.Edit(product);
            return new JsonResult(result);
        }
    }
}
