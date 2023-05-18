using School_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.ViewModels
{
    public class Associations_Student_VM
    {
        public Student SelectedUser { get; set; }
        public Associations_Student_VM() 
        {
            SelectedUser = new Student();  
        }

    }
}
