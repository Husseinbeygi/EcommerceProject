using AccountManagment.Application;
using AccountManagment.Application.Contract.Account;
using AccountManagment.Domain.AccountAgg;
using AccountManagment.Infrastructre.EfCore;
using AccountManagment.Infrastructre.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AcountManagment.Configuration
{
    public class AccountManagmentBootstrapper
    {

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();


            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }


    }



}
