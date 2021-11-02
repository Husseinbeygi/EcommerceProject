using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Queries.ProductCategories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Pages.ViewComponents
{
    public class LastArrivalProductsViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public LastArrivalProductsViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        { 

            return View(_productCategoryQuery.GetLastesArrivals());
        }
    }
}
