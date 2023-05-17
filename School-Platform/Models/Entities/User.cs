using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }   

        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {
            UserName = "new user";
            Password = "password";
        }
    }
}
