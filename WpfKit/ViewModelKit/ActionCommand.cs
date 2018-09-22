using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfKit.ViewModelKit
{
    public class ActionCommand : ICommand
    {
        private Func<object, bool> _canExecute = null;
        private Action<object> _execute = null;

        public ActionCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
            => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)
            => _execute?.Invoke(parameter);
    }
}
