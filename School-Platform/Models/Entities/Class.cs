using School_Platform.Helpers;
using School_Platform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class Class : BaseVM
    {
        private string yearOfStudy;
        public string YearOfStudy
        {
            get
            {
                return yearOfStudy;
            }
            set
            {
                if (yearOfStudy != value)
                {
                    yearOfStudy = value;
                    NotifyPropertyChanged(nameof(YearOfStudy));
                }
            }
        }

        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                if (specialization != value)
                {
                    specialization= value;
                    NotifyPropertyChanged(nameof(YearOfStudy));
                }
            }
        }
        private string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged(nameof(YearOfStudy));
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
                if(students != value)
                {
                    students = value;
                    NotifyPropertyChanged(nameof(students));
                }
            }
        }

        private Professor master;
        public Professor Master
        {
            get
            {
                return master;
            }
            set
            {
                if(master != value)
                {
                    master = value;
                    NotifyPropertyChanged(nameof(Master));
                }
            }
        }
        public Class()
        {
            YearOfStudy = "New Class Created";
            Specialization = "New Class Created";
            ID = "New Class Created";
            Students = new ObservableCollection<Student>();
            Master = new Professor();
        }

        public ObservableCollection<Student> GetStudents()
        {
            return Students;
        }
    }
}
