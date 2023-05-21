﻿using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Services
{

    public class Student_Service
    {

        Student_Repository _studentRepository;
        public Student_Service() 
        {
        
               _studentRepository = new Student_Repository();
        }

        public List<Admin_GetAllStudents_Result> GetAllStudents()
        {

            return _studentRepository.GetAllStudents();
        }
    }
}
