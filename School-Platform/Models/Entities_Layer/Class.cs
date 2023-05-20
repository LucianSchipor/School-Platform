using School_Platform.Helpers;
using School_Platform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            private set
            {
                if(students != value)
                {
                    students = value;
                    NotifyPropertyChanged(nameof(Students));
                }
            }
        }

        private Teacher master;
        public Teacher Master
        {
            get
            {
                return master;
            }
            private set
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
            Master = new Teacher();
        }

        public ObservableCollection<Student> GetStudents()
        {
            return Students;
        }

        public void AddStudent(Student newStudent)
        {
            if(students != null)
            {
                newStudent.ChangeAssociatedClass(this);
                students.Add(newStudent);
            }
            else
            {
                MessageBox.Show("newStudent a fost null!");
                return;
            }
        }
    }
}
