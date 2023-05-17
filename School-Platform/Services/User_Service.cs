using School_Platform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Services
{

    public class User_Service
    {
        DB_Context DB_Context { get; set; }
        ObservableCollection<User> _users { get; set; }
        public User_Service()
        {
            DB_Context = new DB_Context();
            _users = DB_Context._users;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

    }

}
