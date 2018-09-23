using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfKit.ViewKit.Command
{
    public static class CommandFactory
    {
        public static ICommand MessageBoxCommand { get; } = new MessageBoxCommand();
    }
}
