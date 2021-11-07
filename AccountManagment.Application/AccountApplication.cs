using System;
using System.Collections.Generic;
using _0_Framework.Application;
using AccountManagment.Application.Contract.Account;
using AccountManagment.Domain.AccountAgg;

namespace AccountManagment.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _reposiotry;
        private readonly IPasswordHasher _passwordToolBox;

        public AccountApplication()
        {
        }

        public AccountApplication(IAccountRepository reposiotry, IPasswordHasher password)
        {
            _reposiotry = reposiotry;
            _passwordToolBox = password;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var _operationResult = new OperationResult();
            var _accountForEdit = _reposiotry.Get(command.Id);
            if (_accountForEdit == null)
            {
                return _operationResult.Failed(Messages.FailedOpration_Null);
            }
            if (!IsPasswordMatch(command))
            {
                return _operationResult.Failed(Messages.FailedOpration_PasswordNotMatch);
            }

            _accountForEdit.ChangePassword(_passwordToolBox.Hash(command.NewPassword));
            _reposiotry.SaveChanges();
            return _operationResult.Succeeded();
        }

        private static bool IsPasswordMatch(ChangePassword command)
        {
            return command.NewPassword != command.RePassword;
        }

        public OperationResult Create(CreateAccount create)
        {
            var _operationResult = new OperationResult();
            if (_reposiotry.Exist(x => x.UserName == create.UserName || x.Mobile == create.Mobile))
            {
                return _operationResult.Failed(Messages.FailedOpration_UserDuplicate);
            }
            string hashedPassword = _passwordToolBox.Hash(create.Password);
            var _cerate = new Account(create.FullName, create.UserName, hashedPassword,
                create.Mobile, create.RoleId, create.ProfilePhoto);
            _reposiotry.Create(_cerate);
            _reposiotry.SaveChanges();
            return _operationResult.Succeeded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var _operationResult = new OperationResult();
            var _accountForEdit = _reposiotry.Get(command.Id);
            if (_accountForEdit == null)
            {
                return _operationResult.Failed(Messages.FailedOpration_Null);
            }
            if (_reposiotry.Exist(x => x.UserName == command.UserName || x.Mobile == command.Mobile && x.Id != command.Id))
            {
                return _operationResult.Failed(Messages.FailedOpration_UserDuplicate);
            }

            _accountForEdit.Edit(command.FullName, command.UserName,
                command.Mobile, command.RoleId, command.ProfilePhoto);

            _reposiotry.SaveChanges();
            return _operationResult.Succeeded();
        }

        public EditAccount GetDetails(long id)
        {

            return _reposiotry.GetDetails(id);

        }

        public List<AccountViewModel> Sreach(AccountSearchModel accountSearchModel)
        {
            return _reposiotry.Sreach(accountSearchModel);


        }
    }
}
