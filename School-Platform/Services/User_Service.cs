using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Services
{
    public class User_Service
    {

        User_Repository _userRepository {  get; set; }
        public User_Service()
        {
            _userRepository = new User_Repository();
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers().ToList();
        }
    }


}
