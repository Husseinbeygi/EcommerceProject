using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace AccountManagment.Application.Contract.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount create);
        OperationResult Edit(EditAccount create);
        OperationResult ChangePassword(ChangePassword create);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Sreach(AccountSearchModel accountSearchModel);
    }
}
