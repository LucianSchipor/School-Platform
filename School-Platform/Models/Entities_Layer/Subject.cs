using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.Entities_Layer
{
    public class Subject
    {

        string Subject_Name { get; set; }

        public Subject() 
        {
            Subject_Name = "New Subject";
        }
    }
}
