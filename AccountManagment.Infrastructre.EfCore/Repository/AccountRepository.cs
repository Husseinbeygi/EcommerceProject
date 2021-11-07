using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infastructure;
using AccountManagment.Application.Contract.Account;
using AccountManagment.Domain.AccountAgg;

namespace AccountManagment.Infrastructre.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(long id)
        {
            return _context.account.Select(x => new EditAccount {
                FullName = x.FullName,
                Id = x.Id,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Sreach(AccountSearchModel accountSearchModel)
        {

            var query = _context.account.Select(x => new AccountViewModel {
                ProfilePhoto = x.ProfilePhoto,
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,

            }).ToList();

            return query;

        }
    }
}
