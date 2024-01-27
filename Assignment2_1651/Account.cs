using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class Account
    {
        private static Account instance;
        private List<User> listAccount;
        private Account()
        {
            listAccount = new List<User>();
        }
        public static Account GetInstance()
        {
            if (instance == null)
            {
                lock(typeof(Account))
                {
                    if(instance == null)
                    {
                        instance = new Account();
                    }
                }
            }
            return instance;
        }
        public List<User> ListAccount { get { return listAccount; } }
        public void Register(User user)
        {
            listAccount.Add(user);
        }
        public User FindUser(string id)
        {
            foreach(User user in listAccount)
            {
                if(user.Id == id) 
                {
                    return user;
                }
            }
            return null;
        }
        public void DisplayAccount()
        {
            foreach(var user in listAccount)
            {
                Console.WriteLine($"Name: {user.Name}, ID: {user.Id}");
            }
        }
        
    }
}
