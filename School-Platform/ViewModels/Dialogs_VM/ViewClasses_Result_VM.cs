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
    public class ViewClasses_Result_VM: BaseVM
    {

        private Class selectedClass;
        public Class SelectedClass
        {
            get
            {
                return selectedClass;
            }
            set
            {
                if (selectedClass != value)
                {
                    selectedClass = value;
                    NotifyPropertyChanged(nameof(selectedClass));
                }
            }
        }

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
        public ViewClasses_Result_VM()
        {
            Classes = new List<Admin_GetAllClasses_Result>();
            IsButtonEnabled = false;
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

        public void SelectClass(Admin_GetAllClasses_Result item)
        {
            var Class = new Class();
            Class.Class_ID = item.Class_ID;
            Class.Class_Name = item.Class_Name;
            Class.Year_Of_Study = item.Year_Of_Study;

            if (item != null)
            {
                SelectedClass = Class;
                IsButtonEnabled = true;
            }

        }
    }
}
