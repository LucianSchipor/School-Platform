using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Teacher_ViewAbsences_Result
    {
        public Int32 Absence_ID { get; set; }
        public Int32 Student_ID { get; set; }
        public String Is_Motivated { get; set; }
        public String Subject_Name { get; set; }
        public DateTime Absence_Date { get; set; }
    }
}

