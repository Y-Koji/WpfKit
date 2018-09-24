using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfKit.ViewKit
{
    public class InvokeCommandAction : TriggerAction
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            var self = this;
        }

        public override void Invoke(object parameter)
        {
            base.Invoke(parameter);

            if (null != AssociatedObject && (Command?.CanExecute(CommandParameter) ?? false))
            {
                Command.Execute(CommandParameter);
            }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(InvokeCommandAction), new PropertyMetadata(null));
        
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(InvokeCommandAction), new PropertyMetadata(null));
    }
}
