namespace AccountManagment.Application.Contract.Account
{
    public class AccountSearchModel
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
    }
}
