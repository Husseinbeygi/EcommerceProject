using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPicureAggregation;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductsPicture.Select(x => new EditProductPicture {

                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
               
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSerachModel command)
        {

            var query = _context.ProductsPicture.Include(x => x.Product).Select(x => new ProductPictureViewModel() {

                Id = x.Id,
                DateCreation = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                ProductName = x.Product.Name,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved,
            });

            if (command.ProductId != 0)
            {
                query = query.Where(x => x.ProductId == command.ProductId);
            } 

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
