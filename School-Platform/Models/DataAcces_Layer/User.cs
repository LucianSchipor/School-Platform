using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class User
    {
        public int User_ID { get; set; }

        public string Name { get; set; }    

        public string Password { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }


        public User()
        {
            User_ID = 0;
            Username = "newuser";
            Password = "password";
            Name = "New User";
            Role = "User";
        }

        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public string GetUsername()
        {
            return this.Username;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public void MakeAdmin()
        {
            this.Role = "admin";
        }
    }
}
