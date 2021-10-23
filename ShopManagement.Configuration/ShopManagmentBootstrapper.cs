﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain;
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

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}