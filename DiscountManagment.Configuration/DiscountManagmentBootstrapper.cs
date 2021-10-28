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
    public class DiscountManagmentBootstrapper
    {

        public static void Configure(IServiceCollection services,string ConnectionString)
        {

            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            DiscountContextFactory.DatabaseConnectionString = ConnectionString;
            
            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
