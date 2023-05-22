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

        public List<Admin_GetAllStudents_Result> GetAllStudents(Nullable<int> year_Of_Study, string class_Letter)
        {
            return schoolContext.Admin_GetAllStudentsFromClass(year_Of_Study, class_Letter).ToList();
        }
    }

}
