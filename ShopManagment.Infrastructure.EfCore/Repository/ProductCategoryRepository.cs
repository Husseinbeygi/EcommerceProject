using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain;
using ShopManagement.Domain.ProductCategoryAggregation;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory() {
                Id = x.Id,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDiscription,
                Name = x.Name,
               // Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategoriesList()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel { 
             Id = x.Id,
             Name = x.Name
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel() {

                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
                


            });

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name == command.Name);
            }

            return query.OrderByDescending(x => x.Id).OrderBy(x => x.IsRemoved == true).ToList();
        }
    }
}
