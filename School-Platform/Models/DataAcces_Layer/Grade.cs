using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Grade
    {
        public int Grade_ID { get; set; }
        public int Student_ID { get; set; }
        public int Teacher_ID { get; set; }
        public float Grade_Value { get; set; }
        public string Subject_Name { get; set; }
        public string Grade_Date { get; set; }

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
