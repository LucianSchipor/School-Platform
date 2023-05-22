using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class ViewStudents_Result_VM : BaseVM
    {
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
    }
}
