using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Services;
using School_Platform.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class ViewClasses_Result_VM : BaseVM
    {

        public Class_Service classService { get; set; }

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


        private ICommand changeSpecializationCommand;
        public ICommand ChangeSpecializationCommand
        {
            get
            {
                if (changeSpecializationCommand == null)
                {
                    changeSpecializationCommand = new RelayCommandGeneric<Window>(ChangeClassSpecialization);
                }
                return changeSpecializationCommand;
            }

        }

        public void ChangeClassSpecialization(Window w)
        {
            var year = SelectedClass.Year_Of_Study;
            string Spec = " ";
            var Letter = SelectedClass.Class_Name;

            var nameDialog = new InputDialog("Salut");
            nameDialog.label.Content = "Specialization name: ";

            if (nameDialog.ShowDialog() == true)
            {
                Spec = nameDialog.Answer;
                NotifyPropertyChanged(nameof(SelectedClass));
            }

            classService = new Class_Service();
            classService.ChangeClassSpecialization(Letter, year, Spec);
        }

        private ICommand deleteClassCommand;
        public ICommand DeleteClassCommand
        {
            get
            {
                if (deleteClassCommand == null)
                {
                    deleteClassCommand = new RelayCommandGeneric<Admin_GetAllClasses_Result>(DeleteClass);
                }
                return deleteClassCommand;
            }
        }

        public void DeleteClass(Admin_GetAllClasses_Result e)
        {
            var cs = new Class_Service();
            cs.DeleteClass(SelectedClass.Year_Of_Study, selectedClass.Class_Name);
        }

        private ICommand addClassCommand;
        public ICommand AddClassCommand
        {
            get
            {
                if (addClassCommand == null)
                {
                    addClassCommand = new RelayCommandGeneric<Admin_GetAllClasses_Result>(AddClass);
                }
                return addClassCommand;
            }
        }

        public void AddClass(Admin_GetAllClasses_Result e)
        {
            var cs = new Class_Service();

            string Spec= " ";
            int Year = 0;
            string Letter = " ";

            var window = new Add_Dialog();
            if (window.ShowDialog() == true)
            {
                var context = window.DataContext as AddClass_Dialog_VM;
                if (context != null)
                {
                    Year = int.Parse(context.SelectedYear);
                    Letter = context.SelectedLetter;
                    Spec = context.SelectedSpec;
                }
            }

            try
            {
                cs.AddClass(Year, Letter, Spec);

            }
            catch(SqlException){
                MessageBox.Show("Ai adaugat deja aceasta clasa.");
            }


        }
    }
}
