using School_Platform.Commands;
using School_Platform.Helpers;
using School_Platform.Models;
using School_Platform.Models.DataAcces_Layer;
using School_Platform.Repositories;
using School_Platform.Services;
using School_Platform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    public class LogIN_VM : BaseVM
    {
        private User loggedUser;
        public User LoggedUser
        {
            get
            {
                return loggedUser;
            }
            set
            {
                loggedUser = value;
                NotifyPropertyChanged(nameof(loggedUser));
            }
        }
        User_Service users_service;

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged(nameof(username));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(password));
            }
        }

        public LogIN_VM()
        {
            LoggedUser = new User();
            users_service = new User_Service();

        }

        private ICommand logInCommand;
        public ICommand LogInCommand
        {
            get
            {
                if (logInCommand == null)
                {
                    logInCommand = new RelayCommandGeneric<Window>(LogInVerification);
                }
                return logInCommand;
            }
        }
        public void LogInVerification(Window window)
        {
            var ur = new User_Repository();
            var list = ur.GetAllUsers();

            //User user = list.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
            //if(user != null)
            //{
            LoggedUser.SetUsername("teacher1");
            LoggedUser.SetPassword("pass");
            LoggedUser.Role = "Teacher";
            LoggedUser.User_ID = 73;

            if (LoggedUser.Role == "Admin")
            {
                var newWindow = new Admin_View();
                var context = (newWindow.DataContext as Admin_VM);
                context.LoggedUser = LoggedUser;
                newWindow.DataContext = context;
                newWindow.Show();
                window.Close();
            }
            else
            {
                if (LoggedUser.Role == "Teacher")
                {
                    var newWindow = new Teacher_View();
                    var context = new Teacher_VM();
                    context.LoggedUser = LoggedUser;
                    newWindow.DataContext = context;

                    newWindow.Show();
                    window.Close();
                }
                else
                {
                    //student
                }
            }
        }
        //}
    }
}
