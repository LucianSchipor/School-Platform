﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Admin_GetAllTeachers_Result
    {

        public Int32 User_ID { get; set; }
        public String Name { get; set; }
        public String Username { get; set;}
        public Int32 Mastered_Class_ID { get; set; }
    }
}
