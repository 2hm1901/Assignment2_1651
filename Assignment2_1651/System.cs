using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class System
    {
        public string Name { get; set; }
        public string Id { get; set; }
        private User user1;
        private Admin admin1;
        public System() 
        {
            user1 = new User();
            admin1 = new Admin();
        }
        public bool StudentLogin(string id)
        {
            return user1.Login(id);
        }
        public bool AdminLogin(string id,string password)
        {
            return admin1.Login(id,password);
        }
        public void Logout()
        {
            Name = null;
        }
        
    }
}
