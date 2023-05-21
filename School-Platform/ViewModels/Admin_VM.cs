using School_Platform.Commands;
using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Services;
using School_Platform.Views;
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
        private List<Class> classes;
        public List<Class> Classes
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
            Classes = GetClasses();
            selectedList = new List<List<string>>();

            selectedList.Add(new List<string>());
            selectedList.Add(new List<string>());
            selectedList.Add(new List<string>());

            selectedList[0].Add("new");
            selectedList[1].Add("new");
            selectedList[2].Add("new");
        }

        public List<Class> GetClasses()
        {
            return null;
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
            selectedList[0][0] = selected.Content as string;
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
            selectedList[1][0] = selected.Content as string;
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
            selectedList[2][0] = selected.Content as string;
        }


        private ICommand viewStudentsCommand;
        public ICommand ViewStudentsCommand
        {
            get
            {
                if (viewStudentsCommand == null)
                {
                    viewStudentsCommand = new RelayCommandGeneric<List<List<string>>>(GetStudents);
                }
                return viewStudentsCommand;
            }
        }

        public void GetStudents(List<List<string>> informations)
        {
            //informations = selectedList;
            //var result = new ObservableCollection<Student>();
            //Classes = class_Service.GetClasses(informations[0][0], informations[1][0], informations[2][0]);
            //foreach (var index in Classes)
            //{
            //    foreach (var indexStudent in index.Students)
            //    {
            //        result.Add(indexStudent);
            //    }
            //}
            //Students = result;

            Student_Service ss = new Student_Service();
            Students = ss.GetAllStudents();

        }


        private ICommand selectStudentCommand;
        public ICommand SelectStudentCommand
        {
            get
            {
                if (selectStudentCommand == null)
                {
                    selectStudentCommand = new RelayCommandGeneric<Student>(SelectStudent);
                }
                return selectStudentCommand;
            }
        }

        public void SelectStudent(Student item)
        {
            if(item != null)
            {
                selectedStudent = item;
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

        /*
         * functionalitate sa fac asocieri intre ani
         * functionalitate sa setez profesorul la o materie la o clasa
         * de adaugat functionalitate de modificat clasa unui elev
        */
    }
}
