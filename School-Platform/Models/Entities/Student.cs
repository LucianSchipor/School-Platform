using School_Platform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class Student : User
    {
        public Class studentAssociatedClass;
        public Class StudentAssociatedClass
        {
            get
            {
                return studentAssociatedClass;
            }
            set
            {
                if (studentAssociatedClass != value)
                {
                    studentAssociatedClass = value;
                }
            }
        }
        public Student()
        : base()
        {
            this.studentAssociatedClass = new Class();
            this.UserRole = "Student";
        }

        public Class GetAssociatedClass()
        {
            return this.studentAssociatedClass;
        }

        public void ChangeAssociatedClass(Class newClass)
        {
            this.studentAssociatedClass = newClass;
        }
    }
}
