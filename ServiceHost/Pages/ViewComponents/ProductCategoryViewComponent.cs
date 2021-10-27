using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Queries.ProductCategories.Contract;
using Microsoft.AspNetCore.Mvc;
using ShopManagment.Infrastructure.EfCore;

namespace ServiceHost.Pages.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {

        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(_productCategoryQuery.GetAll());
        }

    }


}
