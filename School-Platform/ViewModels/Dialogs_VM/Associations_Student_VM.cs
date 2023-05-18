using School_Platform.Commands;
using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    public class Associations_Student_VM : BaseVM
    {

        List<List<string>> info;
        private ObservableCollection<Student> student;
        public ObservableCollection<Student> Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                NotifyPropertyChanged(nameof(Student));
            }
        }
        Class_Service class_Service { get; set; }
        public Student SelectedUser { get; set; }
        public Associations_Student_VM()
        {

            SelectedUser = new Student();
            class_Service = new Class_Service(SelectedUser.studentAssociatedClass);
            info = new List<List<string>>();
            info.Add(new List<string>());
            info.Add(new List<string>());
            info.Add(new List<string>());
            info[0] = new List<string>();
            info[1] = new List<string>();
            info[2] = new List<string>();

            info[0].Add("new");
            info[1].Add("new");
            info[2].Add("new");
        }

        private ICommand moveToClassCommand;
        public ICommand MoveToClassCommand
        {
            get
            {
                if (moveToClassCommand == null)
                {
                    moveToClassCommand = new RelayCommand(Associate);
                }
                return moveToClassCommand;

            }
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

        private ICommand selectClassCommand;
        public ICommand SelectClassCommand
        {
            get
            {
                if (selectClassCommand == null)
                {
                    selectClassCommand = new RelayCommandGeneric<ComboBoxItem>(SelectClass);
                }
                return selectClassCommand;

            }
        }
        private void Associate(object obj)
        {
            var newClass = class_Service.GetClasses(info[0][0], info[1][0], info[2][0])[0];

            class_Service.AssociateStudentWithClass(SelectedUser, info[0][0], info[2][0]);
        }
        private void SelectYear(ComboBoxItem year)
        {

            info[0][0] = year.Content as string;
        }

        private void SelectClass(ComboBoxItem newClassItem)
        {
            var newClass = newClassItem.Content as string;
            var result = newClass.Split(' ');
            info[2][0] = result[0];
            info[1][0] = result[1];
        }
    }
}
