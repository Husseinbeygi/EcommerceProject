using System.Collections.Generic;
using DiscountManagment.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> customerDiscountViewModel;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;
        public SelectList _SearchwithProductList;
        public string _ProductName;
        public IndexModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {

            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }


        public void OnGet(CustomerDiscountSearchModel searchModel)
        {

            _SearchwithProductList = new SelectList(_productApplication.GetProducts(), "Id", "Name");

            customerDiscountViewModel = _customerDiscountApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var cmd = new DefineCustomerDiscount();
            cmd.Products = _productApplication.GetProducts();
            return Partial("./Create", cmd);
        }
        public JsonResult OnPostCreate(DefineCustomerDiscount discount)
        {
            var result = _customerDiscountApplication.Define(discount);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editProduct = _customerDiscountApplication.GetDetails(id);
            _editProduct.Products = _productApplication.GetProducts();
            return Partial("./Edit", _editProduct);
        }
        public JsonResult OnPostEdit(EditCustomerDiscount discount)
        {
            var result = _customerDiscountApplication.Edit(discount);
            return new JsonResult(result);
        }

    }
}
