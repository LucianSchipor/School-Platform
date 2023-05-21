using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class Grade
    {
        int Grade_ID { get; set; }
        int Student_ID { get; set; }
        int Teacher_ID { get; set; }
        float Grade_Value { get; set; }
        string Grade_Date { get; set; }

        public Grade()
        {
            Grade_ID = 0;
            Student_ID = 0;
            Teacher_ID = 0;
            Grade_Value = 0;
            Grade_Date = "0/0/0";
        }

    }
}
