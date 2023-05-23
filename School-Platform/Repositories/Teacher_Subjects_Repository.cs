using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Repositories
{
    public  class Teacher_Subjects_Repository
    {
        SchoolEntities SchoolDataBase { get; set; } 

        public Teacher_Subjects_Repository() 
        {
            SchoolDataBase = new SchoolEntities();
        }

        public List<Admin_GetTeacherSubjects_Result> ImportSubjects(int teacher_ID)
        {
            return SchoolDataBase.Admin_GetTeacherSubjects(teacher_ID).ToList();
        }
    }
}
