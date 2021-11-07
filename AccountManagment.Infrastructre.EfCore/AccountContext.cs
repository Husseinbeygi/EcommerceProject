using AccountManagment.Domain.AccountAgg;
using AccountManagment.Infrastructre.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagment.Infrastructre.EfCore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> account { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var assambly = typeof(AccountMap).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);

            base.OnModelCreating(modelBuilder);
        }

    }
}