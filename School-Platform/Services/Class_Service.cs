using School_Platform.Models.DataAcces_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Services
{
    public class Class_Service
    {

        SchoolEntities SchoolDataBase { get; set; }
        public Class_Service() 
        {
            SchoolDataBase = new SchoolEntities();  
        } 

     
    }
}
