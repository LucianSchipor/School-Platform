using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Platform.Services
{
    public class Class_Service
    {

        Class_Repository classRepository { get; set; }
        public Class_Service() 
        {
            classRepository = new Class_Repository();
        } 

        public List<Admin_GetAllClasses_Result> GetAllClasses()
        {
           return classRepository.GetAllClasses();
        }

        public void ChangeClassSpecialization(string Class_Letter, int Year_Of_Study, string Specialization)
        {
            classRepository.ChangeClassSpecialization(Class_Letter, Year_Of_Study, Specialization);
        }

        public void AddClass(int Year_Of_Study, string Class_Letter, string Specialization)
        {
            classRepository.AddClass(Year_Of_Study, Class_Letter ,Specialization);
        }
        public void DeleteClass(int Year_Of_Study, string Class_Letter)
        {
            classRepository.DeleteClass(Year_Of_Study, Class_Letter);
        }
    }
}
