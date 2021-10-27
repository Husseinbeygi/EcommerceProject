using System;
using _01_Queries.ProductCategories.Contract;
using _01_Queries.ProductCategories.Query;
using _01_Queries.Slider.Contract;
using _01_Queries.Slider.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain;
using ShopManagement.Domain.ProductAggregation;
using ShopManagement.Domain.ProductPicureAggregation;
using ShopManagement.Domain.SliderAggregation;
using ShopManagment.Infrastructure.EfCore;
using ShopManagment.Infrastructure.EfCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagmentBootstrapper
    {

        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideRepository, SlideRepository>();
            services.AddTransient<ISlideApplication, SlideApplication>();

            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();


            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
