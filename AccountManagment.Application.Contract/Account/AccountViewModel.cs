﻿namespace AccountManagment.Application.Contract.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
