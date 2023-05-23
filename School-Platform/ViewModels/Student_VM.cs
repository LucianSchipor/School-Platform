using School_Platform.Helpers;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using School_Platform.Models;

namespace School_Platform.ViewModels
{
    public class Student_VM : BaseVM
    {
        private List<Subject> subjects;
        public List<Subject> Subjects
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

        private List<Student_ViewGrades_Result> grades;
        public List<Student_ViewGrades_Result> Grades
        {
            get { return grades; }
            set
            {
                grades = value;
                NotifyPropertyChanged(nameof(Grades));
            }
        }

        private ICommand viewGradesCommand;
        public ICommand ViewGradesCommand
        {
            get
            {
                if (viewGradesCommand == null)
                {
                    viewGradesCommand = new RelayCommandGeneric<ListBox>(GetGrades);
                }
                return viewGradesCommand;
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

        public void GetGrades(ListBox currentListBox)
        {
            if (SelectedSubject == null)
            {
                MessageBox.Show("Nu ai selectat materia!.");
                return;
            }
            var sr = new Student_Repository();
            Grades = sr.GetStudentGrades(LoggedUser.User_ID, SelectedSubject.Subject_Name);
            currentListBox.ItemsSource = Grades;
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

        public Student_VM()
        {

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
            if (SelectedSubject != null)
            {
                var name = currentListBox.Name;
                if (LoggedUser != null)
                {

                    try
                    {
                        Absences = sr.GetAbsences(LoggedUser.User_ID, SelectedSubject.Subject_Name);
                        currentListBox.ItemsSource = Absences;
                        ListType = "Absence";
                    }
                    catch (System.NullReferenceException)
                    {
                        MessageBox.Show("O optiune nu a fost selectata.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecteaza un student inainte");
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
            var sr = new Student_Repository();
            Subjects = sr.ImportSubjects(LoggedUser.User_ID);
        }


    }
}
