using School_Platform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Models
{
    public class Admin : User
    {
        public Admin_View view;
        public Admin()
        : base()
        {
            this.UserRole = "Admin";
            view = new Admin_View();
        }

        public void ViewClass(string YearOfStudy, string Specialization, string Class)
        {

        }

        public void AfterLogin()
        {
            view.Show();
        }
    }
}
