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
        : base()
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

        public List<Class> GetClasses(string YearOfStudy = "new", string Specialization = "new", string ID = "new")
        {

            var result = new List<Class>();

            if (YearOfStudy != "new")
            {
                result = DB_Context.classes
                           .Where(classToFind =>
                           classToFind.YearOfStudy == YearOfStudy).ToList();
                if (Specialization != "new")
                {
                    result = result.Where(classToFind =>
                    classToFind.Specialization == Specialization).ToList();

                    if (ID != "new")
                    {
                        result = result.Where(classToFind =>
                        classToFind.ID == ID).ToList();
                    }
                }
            }
            else
            {
                if (Specialization != "new")
                {
                   var resultAUX = DB_Context.classes
                           .Where(classToFind =>
                       classToFind.Specialization == Specialization);
                    result = resultAUX.ToList();
                    if (ID != "new")
                    {
                        result = (result.Where(classToFind =>
                        classToFind.ID == ID)).ToList();
                    }
                }
                else
                {
                    if (ID == "new")
                    {
                        result = DB_Context.classes.Where(classToFind =>
                        classToFind.ID == ID).ToList();
                    }
                }
            }
            return result;
        }
    }
}
