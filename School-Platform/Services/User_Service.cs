using School_Platform.Models;
using School_Platform.Models.Dbos_Layer;
using School_Platform.Repositories;
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
        User_Repository Repository { get; set; }
        ObservableCollection<User> _users { get; set; }
        public User_Service()
        {
            DB_Context = new DB_Context();
            _users = DB_Context._users;
            Repository = new User_Repository();
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }


        public IEnumerable<GetAllUsers_Result> GetAllUsersDB()
        {
            return Repository.GetAllUsers();
        }
    }

}
