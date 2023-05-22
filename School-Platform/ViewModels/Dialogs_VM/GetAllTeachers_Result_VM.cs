using School_Platform.Helpers;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using School_Platform.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class GetAllTeachers_Result_VM : BaseVM
    {

        private List<Admin_GetAllTeachers_Result> teachersList;
        public List<Admin_GetAllTeachers_Result> TeachersList
        {
            get { 
                return teachersList; 
            }
            set 
            { 
                teachersList = value;
                NotifyPropertyChanged(nameof(teachersList));
            }
        }


        public GetAllTeachers_Result_VM()
        {
            TeachersList = new List<Admin_GetAllTeachers_Result>();
        }

        private ICommand createTeacherCommand;
        public ICommand CreateTeacherCommand
        {
            get
            {
                if (createTeacherCommand == null)
                {
                    createTeacherCommand = new RelayCommandGeneric<Window>(AddTeacher);
                }
                return createTeacherCommand;
            }
        }

        public void AddTeacher(Window w)
        {

            var tr = new Teacher_Repository();
            var window = new AddStudent_Dialog();
            if(window.ShowDialog() == true)
            {
                var ctx = window.DataContext as AddStudentDialog_VM;
                if(ctx != null)
                {
                    tr.CreateTeacher(ctx.Name, ctx.Username, ctx.Password);
                    TeachersList = tr.GetAllTeachers();
                }
            }
        }
    }
}
