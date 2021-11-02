using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Queries.ProductCategories.Contract;
using DiscountManagment.Infrastructure.EFCore;
using InventoryManagment.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAggregation;
using ShopManagment.Infrastructure.EfCore;

namespace _01_Queries.ProductCategories.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        public ProductCategoryQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryModel> GetAll()
        {
            return _context.ProductCategories.Where(x => x.IsRemoved == false)
                                            .Select(x => new ProductCategoryModel {
                                                Name = x.Name,
                                                Picture = x.Picture,
                                                PictureAlt = x.PictureAlt,
                                                PictureTitle = x.PictureTitle,
                                                Slug = x.Slug,
                                            }).ToList();
        }

        public List<ProductCategoryModel> GettproductCategoriesWithProduct()
        {
            var _inventory = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice });
            var _discount = _discountContext.customerDiscounts.Where(x => x.StartDate <= System.DateTime.Now && x.EndDate >= System.DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId });
            var _productWithCategories = _context.ProductCategories.Where(x => x.IsRemoved == false).Include(x => x.Products).ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryModel {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products),



                }).ToList();


            foreach (var catgories in _productWithCategories)
            {
                foreach (var product in catgories.Products)
                {
                    var price = _inventory.FirstOrDefault(x => x.ProductId == product.Id)?.UnitPrice;
                    product.Price = price.ToMoney();
                    product.DiscountRate = _discount.FirstOrDefault(x => x.ProductId == product.Id)?.DiscountRate;
                    product.HasDiscount = product.DiscountRate > 0;
                    product.PriceWithDicount = (price - (price * product.DiscountRate) / 100).ToMoney();

                }
            }


            return _productWithCategories;
        }


        public List<ProductCategoryModel> GetLastesArrivals()
        {
            var _inventory = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice });
            var _discount = _discountContext.customerDiscounts.Where(x => x.StartDate <= System.DateTime.Now && x.EndDate >= System.DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId });
            var _productWithCategories = _context.ProductCategories.Where(x => x.IsRemoved == false).Include(x => x.Products).ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryModel {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products),



                }).OrderByDescending(x => x.Id).Take(6).ToList();


            foreach (var catgories in _productWithCategories)
            {
                foreach (var product in catgories.Products)
                {
                    var price = _inventory.FirstOrDefault(x => x.ProductId == product.Id)?.UnitPrice;
                    product.Price = price.ToMoney();
                    product.DiscountRate = _discount.FirstOrDefault(x => x.ProductId == product.Id)?.DiscountRate;
                    product.HasDiscount = product.DiscountRate > 0;
                    product.PriceWithDicount = (price - (price * product.DiscountRate) / 100).ToMoney();

                }
            }


            return _productWithCategories;
        }

        public ProductCategoryModel GetProdctsInCategoryby(string slug)
        {
            var _inventory = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice });
            var _discount = _discountContext.customerDiscounts
                .Where(x => x.StartDate <= System.DateTime.Now && x.EndDate >= System.DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId,x.EndDate });
            var _productWithCategories = _context.ProductCategories.Where(x => x.IsRemoved == false)
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryModel {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products),
                    Slug = x.Slug,


                }).FirstOrDefault(x => x.Slug == slug);


            foreach (var product in _productWithCategories.Products)
            {
                var price = _inventory.FirstOrDefault(x => x.ProductId == product.Id)?.UnitPrice;
                var discount = _discount.FirstOrDefault(x => x.ProductId == product.Id); 
                product.Price = price.ToMoney();
                product.DiscountRate = discount?.DiscountRate;
                product.HasDiscount = product.DiscountRate > 0;
                product.PriceWithDicount = (price - (price * product.DiscountRate) / 100).ToMoney();
                product.DateOfExpire = discount?.EndDate.ToDiscountFormat();
            }

            return _productWithCategories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {

            return products.Select(i => new ProductQueryModel {

                Id = i.Id,
                Category = i.Category.Name,
                Name = i.Name,
                Picture = i.Picture,
                PictureAlt = i.PictureAlt,
                PictureTitle = i.PictureAlt,
                Slug = i.Slug,
                

            }).ToList();

        }

    }
}
