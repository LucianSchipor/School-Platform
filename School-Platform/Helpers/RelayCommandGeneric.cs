using School_Platform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.Helpers
{
    public class RelayCommandGeneric<T> : ICommand
    {
        private Action<T> commandTask;

        public RelayCommandGeneric(Action<T> workToDo)
        {
            commandTask = workToDo;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandTask((T)parameter);
        }

    }
}
