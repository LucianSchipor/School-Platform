using School_Platform.Commands;
using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    public class Admin_VM : BaseVM
    {
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

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
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

        public Admin_VM()
        {

            Students = new ObservableCollection<Student>();
            class_Service = new Class_Service();
            classes = GetClasses();
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
            return class_Service.GetClasses();
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
            informations = selectedList;
            var result = new ObservableCollection<Student>();
            Classes = class_Service.GetClasses(informations[0][0], informations[1][0], informations[2][0]);
            foreach(var index in Classes)
            {
                foreach(var indexStudent in index.Students)
                {
                    result.Add(indexStudent);
                }
            }
            Students = result;
        }
    }
}
