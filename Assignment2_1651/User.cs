using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class User
    {
        private string _name;
        private string _id;
        public string Name 
        {
            get { return _name; }
            set 
            {
                string pattern = @"^[a-zA-Z]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(value))
                {
                    _name = value;
                }
                else
                {
                    throw new InvalidNameException("Invalid name!");
                }
            }
        }
        public string Id
        {
            get { return _id; }
            set 
            {
                string pattern = @"^S\d{3}$";
                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(value))
                {
                    throw new InvalidIdException("Invalid ID!");
                }
                else
                {
                    Account account = Account.GetInstance();
                    if(account.ListAccount != null) 
                    { 
                        foreach (User user in account.ListAccount)
                        {
                            if (user.Id == value)
                            {
                                throw new DuplicateIdException("Duplicate id!");
                            }
                        }
                        _id = value;
                    }
                }
            }
        }
        public User() { }
        public User(string name, string id)
        {
            Name = name;
            Id = id;
        }
        public bool Login(string id) 
        {
            Account account = Account.GetInstance();
            foreach(User user in account.ListAccount)
            {
                if (user.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
