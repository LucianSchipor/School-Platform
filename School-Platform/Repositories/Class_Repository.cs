using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Repositories
{

    public class Class_Repository
    {
         SchoolEntities SchoolDataBase { get; set; }

        public Class_Repository()
        { 
            SchoolDataBase = new SchoolEntities();
        }

        public List<Admin_GetAllClasses_Result> GetAllClasses()
        {
            return SchoolDataBase.Admin_GetAllClasses().ToList();
        }

        public void ChangeClassSpecialization(string Class_Letter, int Year_Of_Study, string Specialization)
        {
            SchoolDataBase.Admin_ChangeClassSpecialization(Class_Letter, Year_Of_Study, Specialization);
        }

        public void AddClass(int Year_Of_Study, string Class_Letter, string Specialization)
        {
            SchoolDataBase.Admin_CreateClass(Year_Of_Study, Class_Letter, Specialization);
        }

        public void DeleteClass(int Year_Of_Study, string Class_Letter)
        {
            SchoolDataBase.Admin_DeleteClass(Year_Of_Study, Class_Letter);
        }
    }
}
