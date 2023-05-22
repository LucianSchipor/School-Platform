using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    public class Teacher_VM: BaseVM
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
                classes = value;
                NotifyPropertyChanged(nameof(Classes));
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
                NotifyPropertyChanged(nameof(SelectedClass));
            }
        }

        private List<Absence> absences;
        public List<Absence> Absences
        {
            get { return absences; }
            set { absences = value; 
            NotifyPropertyChanged(nameof(Absences));
            }
        }

        private string selectedYear;
        public string SelectedYear
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                NotifyPropertyChanged(nameof(SelectedYear));
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
            Classes = cr.GetAllClasses();
        }


        private ICommand viewAbsencesCommand;
        public ICommand ViewAbsencesCommand
        {
            get
            {
                if(viewAbsencesCommand == null)
                {
                    viewAbsencesCommand = new RelayCommandGeneric<ListBox>(ViewAbsences);
                }
                return viewAbsencesCommand;
            }
        }

        public void ViewAbsences(ListBox currentListBox)
        {
            currentListBox.ItemsSource = Absences;
            IsButtonEnabled_Absences = true;
            IsButtonEnabled_Grades = false;
        }
    }

}
