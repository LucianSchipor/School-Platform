﻿using School_Platform.Models;
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

        public void CreateTeacher(string name, string username, string password)
        {
            SchoolDataBase.Admin_CreateTeacher(name, username, password);
        }

        public List<Admin_GetTeacherClasses_Result> GetTeacherClasses(int Teacher_ID)
        {
           return SchoolDataBase.Admin_GetTeacherClasses(Teacher_ID).ToList();
        }

        public List<Admin_GetAllMasters_Result> GetAllMasters()
        {
            return SchoolDataBase.Admin_GetAllMasters().ToList();
        }
    }
}
