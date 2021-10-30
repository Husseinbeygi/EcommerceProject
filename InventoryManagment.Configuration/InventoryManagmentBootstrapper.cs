using System;
using InventorManagment.Contract.Application.Inventory;
using InventoryApplication.Aplication;
using InventoryManagment.Domain.InventoryAggregation;
using InventoryManagment.Infrastructure.EFCore;
using InventoryManagment.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagment.Configuration
{
    public class InventoryManagmentBootstrapper 

    {

        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IInventoryManagmentRepository, InventoryManagmentRepository>();
            services.AddTransient<IInventoryManagmentApplication, InventoryManagmentApplication>();


            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
