namespace AccountManagment.Application.Contract.Account
{
    public class ChangePassword
    {
        public long Id { get; set; }
        public string NewPassword { get; set; }
        public string RePassword { get; set; }
    }
}