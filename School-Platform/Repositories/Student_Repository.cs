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
          /*!!!!!!!!*/  return schoolContext.Admin_GetAllStudentsFromClass(year_Of_Study, class_Letter).ToList();
        }

        public void AddStudent(string Username, string Password, string Name, int Year_Of_Study, string Class_Letter, int Student_ID)
        {
            schoolContext.Admin_CreateStudent(Name, Username, Password);
            schoolContext.Admin_ChangeStudentClass(Year_Of_Study, Class_Letter, Student_ID);
        }

        public void ChangeStudentClass(int Year_Of_Study, string Class_Letter, int Student_ID)
        {
            schoolContext.Admin_ChangeStudentClass(Year_Of_Study, Class_Letter, Student_ID);
        }

        public List<Teacher_ViewAbsences_Result> GetAbsences(int Student_ID, string Subject_Name)
        {
            return schoolContext.Teacher_ViewAbsences(Student_ID, Subject_Name).ToList();
        }

        public List<Student_ViewGrades_Result> GetStudentGrades(int Student_ID, string Subject_Name)
        {
            return schoolContext.Student_ViewGrades(Student_ID, Subject_Name).ToList();
        }

        public void AddGradeForStudent(string SubjectName, int Student_ID, double value)
        {
            schoolContext.Teacher_AddGrade(SubjectName, Student_ID, value);
        }
    }

}
