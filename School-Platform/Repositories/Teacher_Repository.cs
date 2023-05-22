using School_Platform.Models.DataAcces_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Repositories
{
    public class Teacher_Repository
    {

        SchoolEntities SchoolDataBase { get; set; }

        public Teacher_Repository()
        {
            SchoolDataBase = new SchoolEntities();
        }

        public List<Admin_GetAllTeachers_Result> GetAllTeachers()
        {
           return SchoolDataBase.Admin_GetAllTeachers().ToList();
        }
    }
}
