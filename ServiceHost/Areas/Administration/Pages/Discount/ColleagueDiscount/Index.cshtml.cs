using System.Collections.Generic;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> colleagueDiscountViewModel;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;
        public SelectList _SearchwithProductList;
        public string _ProductName;
        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {

            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }


        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {

            _SearchwithProductList = new SelectList(_productApplication.GetProducts(), "Id", "Name");

            colleagueDiscountViewModel = _colleagueDiscountApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var cmd = new DefineColleagueDiscount();
            cmd.Products = _productApplication.GetProducts();
            return Partial("./Create", cmd);
        }
        public JsonResult OnPostCreate(DefineColleagueDiscount discount)
        {
            var result = _colleagueDiscountApplication.Define(discount);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editProduct = _colleagueDiscountApplication.GetDetails(id);
            _editProduct.Products = _productApplication.GetProducts();
            return Partial("./Edit", _editProduct);
        }
        public JsonResult OnPostEdit(EditColleagueDiscount discount)
        {
            var result = _colleagueDiscountApplication.Edit(discount);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = _colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
