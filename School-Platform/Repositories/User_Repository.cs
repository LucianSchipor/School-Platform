using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Models.Dbos_Layer;
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

        public IEnumerable<GetAllUsers_Result> GetAllUsers()
        {
            return schoolContext.GetAllUsers(); 
        }
    }

}
