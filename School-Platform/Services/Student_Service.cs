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

        public List<Admin_GetAllStudents_Result> GetAllStudents(Nullable<int> year_Of_Study, string class_Letter)
        {
            if(class_Letter == "new")
            {
                throw new ArgumentOutOfRangeException(" ");
            }
            return _studentRepository.GetAllStudents(year_Of_Study, class_Letter);
        }

        public void AddStudent(string Username, string Password, string Name, int Year_Of_Study, string Class_Letter, int Student_ID)
        {
            _studentRepository.AddStudent( Username, Password, Name, Year_Of_Study, Class_Letter, Student_ID);
        }

        public void ChangeStudentClass(int YearOfStudy, string CLassLetter, int StudentID)
        {
            _studentRepository.ChangeStudentClass(YearOfStudy, CLassLetter, StudentID);
        }
    }
}
