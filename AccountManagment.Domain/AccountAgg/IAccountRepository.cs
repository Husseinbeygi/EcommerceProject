using System.Collections.Generic;
using _0_Framework.Domin;
using AccountManagment.Application.Contract.Account;

namespace AccountManagment.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        EditAccount GetDetails(long id);
        List<AccountViewModel> Sreach(AccountSearchModel accountSearchModel);


    }
}
