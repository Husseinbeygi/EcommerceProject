using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Queries.ProductCategories.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public _01_Queries.ProductCategories.Contract.ProductCategoryModel Productcategory;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id)
        {
            Productcategory = _productCategoryQuery.GetProdctsInCategoryby(id);
        }
    }
}
