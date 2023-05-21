using School_Platform.Commands;
using School_Platform.Helpers;
using School_Platform.Models;
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

        User userToLogIn;
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
            userToLogIn = new User();
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
            var view1 = new Admin_View();
            var service = users_service;
            (view1.DataContext as Admin_VM).user_service = service;
            view1.Show();
            window.Close();
            if (Username != null && Password != null)
            {
                userToLogIn.SetUsername(Username);
                userToLogIn.SetPassword(Password.ToString());
            }
            else
            {
                MessageBox.Show("Trebuie sa introduci valorile pentru username si password.");
            }

        }
    }
}
