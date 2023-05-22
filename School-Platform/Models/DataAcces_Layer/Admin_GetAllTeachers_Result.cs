using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Admin_GetAllTeachers_Result
    {

        public int User_ID { get; set; }
        public string Name{ get; set; }
        public string Username { get; set;}
        public int Mastered_Class_ID { get; set; }
    }
}
