using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.DataAcces_Layer
{
    public class Admin_GetAllStudents_Result
    {
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public int Class_ID { get; set; }
        public int AbsencesCount { get; set; }


        Admin_GetAllStudents_Result()
        {
            Class_ID = 0;
        }
    }
}
