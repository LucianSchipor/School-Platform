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

        public string UserRole { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User()
        {
            UserName = "new user";
            Password = "password";
            Name = "New User";
            Email = "new_user@student.unitbv.ro";
        }

        public void SetUsername(string username)
        {
            this.UserName = username;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public string GetUsername()
        {
            return this.UserName;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public void MakeAdmin()
        {
            this.UserRole = "admin";
        }
    }
}
