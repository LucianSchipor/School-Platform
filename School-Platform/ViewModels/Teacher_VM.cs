using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using School_Platform.ViewModels.Dialogs_VM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    public class Teacher_VM : BaseVM
    {

        private User loggedUser;
        public User LoggedUser
        {
            get
            {
                return loggedUser;
            }
            set
            {
                loggedUser = value;
                NotifyPropertyChanged(nameof(loggedUser));
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

        //verific la comanda de view, pt ca de acolo stiu ce tip are lista
      
        private List<Admin_GetAllClasses_Result> classes;
        public List<Admin_GetAllClasses_Result> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                classes = value;
                NotifyPropertyChanged(nameof(Classes));
            }
        }

        private List<Admin_GetTeacherSubjects_Result> subjects;
        public List<Admin_GetTeacherSubjects_Result> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                NotifyPropertyChanged(nameof(subjects));
            }
        }

        private Admin_GetAllClasses_Result selectedClass;
        public Admin_GetAllClasses_Result SelectedClass
        {
            get
            {
                return selectedClass;
            }
            set
            {
                if(selectedClass != value)
                {
                    selectedClass = value;
                }
                NotifyPropertyChanged(nameof(selectedClass));
            }
        }

        private Admin_GetAllStudents_Result selectedStudent;
        public Admin_GetAllStudents_Result SelectedStudent
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
                }
                NotifyPropertyChanged(nameof(selectedStudent));
            }
        }

        private List<Absence> absences;
        public List<Absence> Absences
        {
            get { return absences; }
            set
            {
                absences = value;
                NotifyPropertyChanged(nameof(Absences));
            }
        }

        private ComboBoxItem selectedYear;
        public ComboBoxItem SelectedYear
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                NotifyPropertyChanged(nameof(SelectedYear));
            }
        }

        private Admin_GetTeacherSubjects_Result selectedSubject;
        public Admin_GetTeacherSubjects_Result SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                NotifyPropertyChanged(nameof(SelectedSubject));
            }
        }

        private List<Grade> grades;
        public List<Grade> Grades
        {
            get { return grades; }
            set
            {
                grades = value;
                NotifyPropertyChanged(nameof(Grades));
            }
        }

        private bool isButtonEnabled_Absences;
        public bool IsButtonEnabled_Absences
        {
            get
            {
                return isButtonEnabled_Absences;
            }
            set
            {
                isButtonEnabled_Absences = value;
                NotifyPropertyChanged(nameof(isButtonEnabled_Absences));
            }
        }
        private bool isButtonEnabled_Grades;
        public bool IsButtonEnabled_Grades
        {
            get
            {
                return isButtonEnabled_Grades;
            }
            set
            {
                isButtonEnabled_Grades = value;
                NotifyPropertyChanged(nameof(isButtonEnabled_Grades));
            }
        }
        public Teacher_VM()
        {
            IsButtonEnabled_Grades = true;
            IsButtonEnabled_Absences = false;

            var cr = new Class_Repository();
            SelectedClass = new Admin_GetAllClasses_Result();
            Classes = cr.GetAllClasses();

        }


        private ICommand viewAbsencesCommand;
        public ICommand ViewAbsencesCommand
        {
            get
            {
                if (viewAbsencesCommand == null)
                {
                    viewAbsencesCommand = new RelayCommandGeneric<ListBox>(ViewAbsences);
                }
                return viewAbsencesCommand;
            }
        }

       
        public void ViewAbsences(ListBox currentListBox)
        {
            var sr = new Student_Repository();

            Absences = sr.GetAbsences(SelectedStudent.User_ID, SelectedSubject.Subject_Name);

            currentListBox.ItemsSource = Absences;
            IsButtonEnabled_Absences = true;
            IsButtonEnabled_Grades = false;
        }

        private ICommand importSubjectsCommand;
        public ICommand ImportSubjectsCommand
        {
            get
            {
                if (importSubjectsCommand == null)
                {
                    importSubjectsCommand = new RelayCommandGeneric<ListBox>(ImportSubjects);
                }
                return importSubjectsCommand;
            }
        }
        
        public void ImportSubjects(ListBox e)
        {
            var tsr = new Teacher_Subjects_Repository();
           Subjects =  tsr.ImportSubjects(LoggedUser.User_ID);
        }

        private ICommand viewStudentsCommand;
        public ICommand ViewStudentsCommand
        {
            get
            {
                if (viewStudentsCommand == null)
                {
                    viewStudentsCommand = new RelayCommandGeneric<ListBox>(ViewStudents);
                }
                return viewStudentsCommand;
            }
        }

        private void ViewStudents(ListBox currentListBox)
        {
            var sr = new Student_Repository();
            if (SelectedYear == null)
            {
                MessageBox.Show("Selecteaza intai criterii.");
                return;
            }
            else
            {
                if (SelectedClass.Class_Name == null)
                {
                    MessageBox.Show("Selecteaza intai criterii.");
                }
                else
                {
                    int a = int.Parse(SelectedYear.Content.ToString());
                    Students = sr.GetAllStudents(a, SelectedClass.Class_Name);
                }
            }
            currentListBox.ItemsSource = Students;
        }

    }
}
