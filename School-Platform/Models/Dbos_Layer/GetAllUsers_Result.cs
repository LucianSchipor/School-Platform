using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models.Dbos_Layer
{
    public class GetAllUsers_Result
    {
        public int User_ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }
    }
}
