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
        Class studentAssociatedClass;
        Class StudentAssociatedClass
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
        public Student(Class studentAssociatedClass)
        : base()
        {
            this.studentAssociatedClass = studentAssociatedClass;
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
