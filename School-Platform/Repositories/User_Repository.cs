﻿using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Repositories
{
    public class User_Repository
    {

        private readonly SchoolEntities schoolContext;

        public User_Repository()
        {
            schoolContext = new SchoolEntities();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return schoolContext.Admin_GetAllUsers(); 
        }
    }

}
