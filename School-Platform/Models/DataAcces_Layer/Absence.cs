using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Absence
    {
        public int Absence_ID { get; set; }
        public int Student_ID { get; set; }
        public string isMotivated { get; set; }
        public string Subject_Name { get; set; }
        public DateTime Absence_Date { get; set; }

        public Absence()
        {
            Absence_ID = 0;
            Student_ID = 0;
            isMotivated = "no";
            Absence_Date = DateTime.Now;
            Subject_Name = " ";
        }
    }
}
