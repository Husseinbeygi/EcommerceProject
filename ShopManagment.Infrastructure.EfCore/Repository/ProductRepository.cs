using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAggregation;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {

        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.products.Select(x => new EditProduct() {
                Id = x.Id,
                CaegoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PicutreTitle = x.PicutreTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.products.Select(x => new ProductViewModel {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            var query =  _context.products.Include(x =>x.Category).Select(x => new ProductViewModel() { 
            CategoryName = x.Category.Name,
            Code = x.Code,
            Id = x.Id,
            Name = x.Name,
            Picture = x.Picture,
            CategoryId = x.CategoryId,
            CreationDate = x.CreationDate.ToFarsi(),
            });

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }
            if (!string.IsNullOrWhiteSpace(command.Code))
            {
                query = query.Where(x => x.Code.Contains(command.Code));
            }

            if (command.CaregoryId != 0)
            {
                query = query.Where(x => x.CategoryId == command.CaregoryId);
            }

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
