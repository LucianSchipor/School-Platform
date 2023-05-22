using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Admin_GetAllClasses_Result
    {
        public int Class_ID { get; set; }

        public string Class_Name { get; set; }

        public string Specialization { get; set; }

        public int Year_Of_Study { get; set; }
    }
}
