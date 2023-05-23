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


        private string listType;
        public string ListType
        {
            get
            {
                return listType;
            }
            set
            {
                listType = value;
                NotifyPropertyChanged(nameof(listType));
            }
        }

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
      
        private List<Admin_GetTeacherClasses_Result> classes;
        public List<Admin_GetTeacherClasses_Result> Classes
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

        private Admin_GetTeacherClasses_Result selectedClass;
        public Admin_GetTeacherClasses_Result SelectedClass
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

        private List<Teacher_ViewAbsences_Result> absences;
        public List<Teacher_ViewAbsences_Result> Absences
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
            IsButtonEnabled_Grades = false;
            IsButtonEnabled_Absences = false;

            SelectedClass = new Admin_GetTeacherClasses_Result();
          
        }

        public Teacher_VM(User LoggedUser)
            :base()
        {
            var tr = new Teacher_Repository();
            this.LoggedUser = LoggedUser;
            try
            {
                Classes = tr.GetTeacherClasses(LoggedUser.User_ID);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Niciun user logat. ");
            }
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
            if(SelectedSubject != null)
            {

            try
            {
                Absences = sr.GetAbsences(SelectedStudent.User_ID, SelectedSubject.Subject_Name);
                currentListBox.ItemsSource = Absences;
                IsButtonEnabled_Absences = true;
                IsButtonEnabled_Grades = false;
                    ListType = "Absence";
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("O optiune nu a fost selectata.");
            }
            }

            else
            {
                MessageBox.Show("Selecteaza materia la care vrei sa-i vezi absentele.");
            }
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
                    ListType = "Student";
                    currentListBox.ItemsSource = Students;
                }

            }
            currentListBox.ItemsSource = Students;
        }

        private ICommand selectItemCommand;
        public ICommand SelectItemCommand
        {
            get
            {
                if (selectItemCommand == null)
                {
                    selectItemCommand = new RelayCommandGeneric<ListBox>(SelectItem);
                }
                return selectItemCommand;
            }
        }

        public void SelectItem(ListBox StudentListBox)
        {
            IsButtonEnabled_Absences = true;
            if(ListType == "Student")
            {
                SelectedStudent = StudentListBox.SelectedItem as Admin_GetAllStudents_Result;
            }
            else
            {
                if(ListType == "Absences")
                {
                    StudentListBox.ItemsSource = Absences;
                }
                else
                {
                    if(ListType == "Grade")
                    {
                        StudentListBox.ItemsSource = Grades;
                    }
                }
            }
        }
    }
}
