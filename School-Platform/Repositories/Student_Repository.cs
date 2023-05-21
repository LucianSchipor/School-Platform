using School_Platform.Models.DataAcces_Layer;
using School_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Repositories
{
    public class Student_Repository
    {

        private readonly SchoolEntities schoolContext;

        public Student_Repository()
        {
            schoolContext = new SchoolEntities();
        }

        public List<Admin_GetAllStudents_Result> GetAllStudents()
        {
            return schoolContext.Admin_GetAllStudents().ToList();
        }
    }

}
