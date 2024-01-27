using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class Admin : User
    {
        private string _password = "admin";
        public string Password
        {
            get {return _password; }
        }
        public Admin() { }
        public Admin(string name, string id) : base(name, id) { }
        public bool Login(string id, string password)
        {
            Account account = Account.GetInstance();
            foreach(User user in account.ListAccount)
            {
                if(user is Admin)
                {
                    Admin admin = (Admin)user;
                    if(admin.Id == id && admin.Password.Equals(password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
