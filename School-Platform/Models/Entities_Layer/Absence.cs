using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.Entities_Layer
{
    public class Absence
    {
        int Absence_ID { get; set; }
        int Student_ID { get; set; }
        int Teacher_ID { get; set; }
        bool isMotivated { get; set; }
        string Absence_Date { get; set; }

        Absence()
        {
            Absence_ID = 0;
            Student_ID = 0;
            Teacher_ID = 0;
            isMotivated = false;
            Absence_Date = "0/0/0";
        }
    }
}
