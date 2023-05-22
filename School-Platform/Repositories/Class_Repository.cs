﻿using School_Platform.Models;
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
    }
}