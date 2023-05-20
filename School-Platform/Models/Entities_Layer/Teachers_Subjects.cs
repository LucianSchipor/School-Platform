using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.Entities_Layer
{
    public class Teachers_Subjects
    {
        int Teachers_Subjects_ID { get; set; }
        int Teacher_ID { get; set; }    
        string Subject_Name { get; set; }

        public Teachers_Subjects()
        {
            Teachers_Subjects_ID = 0;
            Teacher_ID = 0;
            Subject_Name = "New Subj_TeachersSubj";
        }

    }
}
