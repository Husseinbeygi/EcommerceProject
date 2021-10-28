using System;
using DiscountManagment.Application;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using DiscountManagment.Infrastructure.EFCore;
using DiscountManagment.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagment.Configuration
{
    public class DicountManagmentBootstrapper
    {

        public static void Configure(IServiceCollection services,string ConnectionString)
        {

            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();

            DiscountContextFactory.DatabaseConnectionString = ConnectionString;
            
            services.AddDbContext<DiscountContext>();
        }
    }
}
