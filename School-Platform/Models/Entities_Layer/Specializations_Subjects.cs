using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.Entities_Layer
{
    public class Specializations_Subjects
    {
        int Specializations_Subjects_ID { get; set; }
        string Specialization_Name { get; set; }
        int Year_Of_Study { get; set; }
        string Subject_Name { get; set; }

        public Specializations_Subjects()
        {
            Specializations_Subjects_ID = 0;
            Specialization_Name = "New";
            Year_Of_Study = 0;
            Subject_Name = "New specialization_SpecSubjc";
        }

    }
}
