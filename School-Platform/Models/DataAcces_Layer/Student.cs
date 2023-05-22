using School_Platform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public partial class Student : User
    {

        public int Student_ID { get; set; }

        public int Class_ID { get; set; }

        public int AbsencesCount { get; set; }

        public Student()
            :base()
        {
            Role = "Student";
        }
    }
}