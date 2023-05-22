using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class AddStudentDialog_VM : BaseVM
    {
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
                    NotifyPropertyChanged(nameof(classes));
                }
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged(nameof(username));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(password));
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
                selectedClass = value;
                NotifyPropertyChanged(nameof(selectedClass));
            }
        }


        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(name));
            }
        }

        private ICommand selectClassCommand;
        public ICommand SelectClassCommand
        {
            get
            {
                if (selectClassCommand == null)
                {
                    selectClassCommand = new RelayCommandGeneric<Admin_GetAllClasses_Result>(SelectClass);
                }
                return selectClassCommand;
            }
        }

        private void SelectClass(Admin_GetAllClasses_Result selected)
        {
            this.SelectedClass = selected; 
        }
        public AddStudentDialog_VM()
        {
        Classes = new List<Admin_GetAllClasses_Result>();
        }


    }

}
