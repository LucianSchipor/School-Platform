using School_Platform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace School_Platform.Services
{
    public class Class_Service
    {
        Class _class { get; set; }
        DB_Context DB_Context { get; set; }
        Student_Service student_Service { get; set; }

        public Class_Service(Class _class)
        :base()
        {   
            this._class = _class;
        }

        public Class_Service()
        {
            DB_Context = new DB_Context();
            student_Service = new Student_Service();
        }
        public void AssociateStudentWithClass(string name, string classID, string classYearOfStudy)
        {
            student_Service.GetStudent(name);
        }

        public ObservableCollection<Class> GetClasses(string YearOfStudy, string Specialization, string ID = null)
        {
            if (YearOfStudy != null)
            {
                    if (ID != null)
                    {
                        return DB_Context.classes
                            .Where(classToFind =>
                            classToFind.YearOfStudy == YearOfStudy
                        && classToFind.ID == ID) as ObservableCollection<Class>;
                    }
                    else
                    {
                        return DB_Context.classes
                            .Where(classToFind =>
                            classToFind.YearOfStudy == YearOfStudy
                        && classToFind.ID == ID) as ObservableCollection<Class>;
                    }
            }
            else
            {
                MessageBox.Show("You didn't selected anything. There are all classes");
                return DB_Context.classes;
            }
        }
    }
}
