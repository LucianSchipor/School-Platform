using School_Platform.Commands;
using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using School_Platform.Services;
using School_Platform.ViewModels.Dialogs_VM;
using School_Platform.Views;
using School_Platform.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    public class Admin_VM : BaseVM
    {

        public User_Service user_service;
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
        public List<List<string>> selectedList { get; set; }
        Class_Service class_Service { get; set; }

        private List<Admin_GetAllClasses_Result> classes;
        public List<Admin_GetAllClasses_Result> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                if (classes != value)
                {
                    classes = value;
                    NotifyPropertyChanged(nameof(Classes));
                }

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
                if (students != value)
                {
                    students = value;
                    NotifyPropertyChanged(nameof(students));
                }
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

      
        private List<Admin_GetAllTeachers_Result> teachers;
        public List<Admin_GetAllTeachers_Result> Teachers
        {
            get
            {
                return teachers;
            }
            set
            {
                if (teachers != value)
                {
                    teachers = value;
                    NotifyPropertyChanged(nameof(teachers));
                }
            }
        }

        private List<User> users;
        public List<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                if (users != value)
                {
                    users = value;
                    NotifyPropertyChanged(nameof(Users));
                }
            }
        }

        private List<object> currentEntities;
        public List<object> CurrentEntities
        {
            get { return currentEntities; }
            set
            {
                currentEntities = value;
                NotifyPropertyChanged(nameof(CurrentEntities));
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
        public Admin_VM()
        {
            user_service = new User_Service();
            IsButtonEnabled = false;
            selectedStudent = new Student();
            Students = new List<Admin_GetAllStudents_Result>();
            Users = new List<User>();
            class_Service = new Class_Service();
            selectedList = new List<List<string>>();
            selectedList.Add(new List<string>());
            selectedList.Add(new List<string>());
            selectedList.Add(new List<string>());
            selectedList[0].Add("new");
            selectedList[1].Add("new");
            selectedList[2].Add("new");
        }

        private ICommand selectYearCommand;
        public ICommand SelectYearCommand
        {
            get
            {
                if (selectYearCommand == null)
                {
                    selectYearCommand = new RelayCommandGeneric<ComboBoxItem>(SelectYear);
                }
                return selectYearCommand;
            }
        }

        private void SelectYear(ComboBoxItem selected)
        {
            selectedList[0][0] = (selected.Content as string);
        }

        private ICommand selectSpecializationCommand;
        public ICommand SelectSpecializationCommand
        {
            get
            {
                if (selectSpecializationCommand == null)
                {
                    selectSpecializationCommand = new RelayCommandGeneric<ComboBoxItem>(SelectSpecialization);
                }
                return selectSpecializationCommand;
            }
        }

        private void SelectSpecialization(ComboBoxItem selected)
        {
            selectedList[1][0] = (selected.Content as string);
        }

        private ICommand selectIDCommand;
        public ICommand SelectIDCommand
        {
            get
            {
                if (selectIDCommand == null)
                {
                    selectIDCommand = new RelayCommandGeneric<ComboBoxItem>(SelectID);
                }
                return selectIDCommand;
            }
        }

        private void SelectID(ComboBoxItem selected)
        {
            selectedList[2][0] = (selected.Content as string);
        }


        private ICommand viewStudentsCommand;
        public ICommand ViewStudentsCommand
        {
            get
            {
                if (viewStudentsCommand == null)
                {
                    viewStudentsCommand = new RelayCommandGeneric<List<List<string>>>(GetAllStudents);
                }
                return viewStudentsCommand;
            }
        }

        public void GetAllStudents(List<List<string>> informations)
        {
            informations = selectedList;
            Student_Service ss = new Student_Service();
            int year = -1;

            try
            {

                try
                {
                    year = int.Parse(informations[0][0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Nu ai selectat criteriul 'Year' ");
                    return;
                }
                Students = ss.GetAllStudents(year, informations[2][0]);
                var window = new ViewStudents_Result();
                (window.DataContext as ViewStudents_Result_VM).Students = Students;
                window.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nu ai selectat criterii de cautare.");
                return;
            }
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

            Student student_cast = new Student();
            student_cast.Student_ID = item.User_ID;
            student_cast.Class_ID = item.Class_ID;
            student_cast.AbsencesCount = item.AbsencesCount;

            if (item != null)
            {
                selectedStudent = student_cast;
                IsButtonEnabled = true;
            }

        }

        private ICommand associationsCommand;
        public ICommand AssociationsCommand
        {
            get
            {
                if (associationsCommand == null)
                {
                    associationsCommand = new RelayCommandGeneric<Window>(Associations);
                }
                return associationsCommand;
            }
        }

        public void Associations(Window window)
        {
            var associations_window = new Associations_Student_View();
            var context = new Associations_Student_VM();
            associations_window.DataContext = context;
            associations_window.Show();
            window.Close();
        }

        private ICommand viewClassesCommand;
        public ICommand ViewClassesCommand
        {
            get
            {
                if (viewClassesCommand == null)
                {
                    viewClassesCommand = new RelayCommandGeneric<ListBox>(GetAllClasses);
                }
                return viewClassesCommand;
            }
        }

        private void GetAllClasses(ListBox c)
        {
            var cs = new Class_Service();
            Classes = cs.GetAllClasses();

            var window = new ViewClasses_Result();
            var context = (window.DataContext as ViewClasses_Result_VM);
            context.Classes = Classes;
            window.Show();
        }
        /*
         * functionalitate sa fac asocieri intre ani
         * functionalitate sa setez profesorul la o materie la o clasa
         * de adaugat functionalitate de modificat clasa unui elev
        */


        private ICommand viewTeachersCommand;
        public ICommand ViewTeachersCommand
        {
            get
            {
                if (viewTeachersCommand == null)
                {
                    viewTeachersCommand = new RelayCommandGeneric<Admin_GetAllTeachers_Result>(GetAllTeachers);
                }
                return viewTeachersCommand;
            }
        }

        public void GetAllTeachers(Admin_GetAllTeachers_Result e)
        {
            var tr = new Teacher_Repository();
            var window = new GetAllTeachers_Result();
            var ctx = new GetAllTeachers_Result_VM();
            ctx.TeachersList = tr.GetAllTeachers();

            window.DataContext = ctx;
            window.Show();
        }
    }
}
