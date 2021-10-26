using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        
        public List<SlideViewModel> slideViewModel;
        private readonly ISlideApplication _slideApplication;
        
        public SelectList listProduct;
        public IndexModel(ISlideApplication slideApplication)
        {

            _slideApplication = slideApplication;
        }


        public void OnGet()
        {
            slideViewModel = _slideApplication.GetList();

        }

        public IActionResult OnGetCreate()
        {
            var cmd = new CreateSlide();
            return Partial("./Create", cmd);
        }
        public JsonResult OnPostCreate(CreateSlide slide)
        {
            var result = _slideApplication.Create(slide);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editSlide = _slideApplication.GetDetails(id);
            return Partial("./Edit", _editSlide);
        }
        public JsonResult OnPostEdit(EditSlide slide)
        {
            var result = _slideApplication.Edit(slide);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var res = _slideApplication.Remove(id);
            if (res.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }
            ViewData["ResultMessage"] = "خطایی در عملیات رخ داده است";
            return RedirectToPage("./Index");

        }


        public IActionResult OnGetRestore(long id)
        {
            var res = _slideApplication.Restore(id);
            if (res.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }
            ViewData["ResultMessage"] = "خطایی در عملیات رخ داده است";
            return RedirectToPage("./Index");

        }

    }
}
