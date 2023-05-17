using School_Platform.Models;
using School_Platform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace School_Platform.Services
{
    
    public class Student_Service
    {
        DB_Context DB_Context { get; set; }

        public Student_Service() 
        {
            DB_Context = new DB_Context();
        }

        public Student GetStudent(string StudentName)
        {
            return DB_Context._students.Where(student => student.Name == StudentName).FirstOrDefault();
        }
        public ObservableCollection<Student> GetStudentsWithYear(string YearOfStudy)
        {
            return DB_Context._students.Where(student => student.GetAssociatedClass().YearOfStudy == YearOfStudy) as ObservableCollection<Student>; 
        }

        public ObservableCollection<Student> GetAllStudents()
        {
            return DB_Context._students;
        }

        public void ChangeStudentAssociatedClass(string name, string YearOfStudy, string ID)
        {
            var class_Service = new Class_Service();
            var student = GetStudent(name);
            student.ChangeAssociatedClass(class_Service.GetClasses(YearOfStudy, ID)[0]);
        }
    }

}
