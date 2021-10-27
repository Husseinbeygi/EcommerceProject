using System.Collections.Generic;
using System.Linq;
using _01_Queries.ProductCategories.Contract;
using ShopManagment.Infrastructure.EfCore;

namespace _01_Queries.ProductCategories.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryModel> GetAll()
        {
            return _context.ProductCategories.Where(x => x.IsRemoved == false )
                                            .Select(x => new ProductCategoryModel {
                                                            Name = x.Name,
                                                            Picture = x.Picture,
                                                            PictureAlt = x.PictureAlt,
                                                            PictureTitle = x.PictureTitle,
                                                            Slug = x.Slug,
                                                        }).ToList();
        }
    }
}
