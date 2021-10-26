using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        public ProductPictureSerachModel SearchModel;
        public List<ProductPictureViewModel> productViewModel;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;
        public SelectList listProduct;
        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {

            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }


        public void OnGet(ProductPictureSerachModel searchModel)
        {
            listProduct = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            productViewModel = _productPictureApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var cmd = new CreateProductPicture();
            cmd.Products = _productApplication.GetProducts();
            return Partial("./Create", cmd);
        }
        public JsonResult OnPostCreate(CreateProductPicture product)
        {
            var result = _productPictureApplication.Create(product);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editProduct = _productPictureApplication.GetDetails(id);
            _editProduct.Products = _productApplication.GetProducts();
            return Partial("./Edit", _editProduct);
        }
        public JsonResult OnPostEdit(EditProductPicture product)
        {
            var result = _productPictureApplication.Edit(product);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var res = _productPictureApplication.Remove(id);
            if (res.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }
            ViewData["ResultMessage"] = "خطایی در عملیات رخ داده است";
            return RedirectToPage("./Index");

        }


        public IActionResult OnGetRestore(long id)
        {
            var res = _productPictureApplication.Restore(id);
            if (res.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }
            ViewData["ResultMessage"] = "خطایی در عملیات رخ داده است";
            return RedirectToPage("./Index");

        }

    }
}
