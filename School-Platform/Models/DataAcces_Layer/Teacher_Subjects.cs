using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class Teacher_Subjects
    {
        int Teachers_Subjects_ID { get; set; }
        int Teacher_ID { get; set; }    
        string Subject_Name { get; set; }

        public Teacher_Subjects()
        {
            Teachers_Subjects_ID = 0;
            Teacher_ID = 0;
            Subject_Name = "New Subj_TeachersSubj";
        }

    }
}
