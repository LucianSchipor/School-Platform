using School_Platform.Helpers;
using School_Platform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace School_Platform.Models
{
    public class Class 
    {
       public  int Class_ID { get; set; }
       
       public  string Class_Name { get; set; } 
       
       public  string Specialization { get; set; }
       
       public  int Year_Of_Study { get; set; } 
    }
}
