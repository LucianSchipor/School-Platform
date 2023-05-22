using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Services;
using School_Platform.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class ViewStudents_Result_VM : BaseVM
    {
        private Class classForStudent;
        public Class ClassForStudent
        {
            get
            {
                return classForStudent;
            }
            set
            {
                if (classForStudent != value)
                {
                    classForStudent = value;
                    NotifyPropertyChanged(nameof(classForStudent));
                }
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                if (selectedStudent != value)
                {
                    selectedStudent = value;
                    NotifyPropertyChanged(nameof(selectedStudent));
                }
            }
        }

        public int Class_ID;
        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        private List<Admin_GetAllStudents_Result> students;
        public List<Admin_GetAllStudents_Result> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                NotifyPropertyChanged(nameof(Students));
            }
        }

        public ViewStudents_Result_VM()
        {
            IsButtonEnabled = false;
            Class_ID = 0;
        }


        private ICommand selectStudentCommand;
        public ICommand SelectStudentCommand
        {
            get
            {
                if (selectStudentCommand == null)
                {
                    selectStudentCommand = new RelayCommandGeneric<Admin_GetAllStudents_Result>(SelectStudent);
                }
                return selectStudentCommand;
            }
        }

        public void SelectStudent(Admin_GetAllStudents_Result item)
        {
            var Student = new Student();
            Student.Name = item.Name;
            Student.Student_ID = item.User_ID;
            Student.Class_ID = item.Class_ID;
            Student.AbsencesCount = item.AbsencesCount;

            if (item != null)
            {
                SelectedStudent = Student;
                IsButtonEnabled = true;
            }

        }


        private ICommand addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommandGeneric<Admin_GetAllStudents_Result>(AddStudent);
                }
                return addStudentCommand;
            }
        }

        private void AddStudent(Admin_GetAllStudents_Result e)
        {
            var ss = new Student_Service();
            var us = new User_Service();
            int count = us.GetAllUsers().ToList().Count();

            var window = new AddStudent_Dialog();
            if(window.ShowDialog() == true)
            {
                var context = window.DataContext as AddStudentDialog_VM;
                if (context != null)
                {
                    ss.AddStudent(context.Username, context.Password, context.Name, classForStudent.Year_Of_Study,classForStudent.Class_Name, count);
                }
            }
        }

        private ICommand changeStudentClassCommand;
        public ICommand ChangeStudentClassCommand
        {
            get
            {
                if (changeStudentClassCommand == null)
                {
                    changeStudentClassCommand = new RelayCommandGeneric<Admin_GetAllStudents_Result>(ChangeStudentClass);

                }
                return changeStudentClassCommand;
            }
        }

        public void ChangeStudentClass(Admin_GetAllStudents_Result item)
        {
            var ss = new Student_Service();
            var cs = new Class_Service();
            var window = new ChangeStudentClassDialog();
            var classes = cs.GetAllClasses();

            var context = window.DataContext as AddStudentDialog_VM;
            context.Classes = classes;
            window.DataContext = context;

            if (window.ShowDialog() == true)
            {
                Class theClass = new Class();
                var ctx = window.DataContext as AddStudentDialog_VM;

                theClass.Class_ID = ctx.SelectedClass.Class_ID;
                theClass.Class_Name = ctx.SelectedClass.Class_Name;
                theClass.Year_Of_Study = ctx.SelectedClass.Year_Of_Study;

                ss.ChangeStudentClass(theClass.Year_Of_Study, theClass.Class_Name, SelectedStudent.Student_ID);
            }
        }
    }
}
