using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfKit.ViewKit.Command
{
    public class MessageBoxCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MessageBoxCommandParameter param)
            {
                var result =
                    MessageBox.Show(
                        param?.Message ?? string.Empty,
                        param.Caption ?? string.Empty,
                        param.Button);

                switch (result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:
                        if (param?.OkCommand?.CanExecute(null) ?? false)
                        {
                            param?.OkCommand?.Execute(param.OkCommandParameter);
                        }
                        break;
                    case MessageBoxResult.Cancel:
                        if (param?.CancelCommand?.CanExecute(null) ?? false)
                        {
                            param?.CancelCommand?.Execute(param.CancelCommandParameter);
                        }
                        break;
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show(parameter?.ToString() ?? string.Empty);
            }
        }
    }
}
