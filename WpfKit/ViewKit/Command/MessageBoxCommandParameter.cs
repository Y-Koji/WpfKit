using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfKit.ViewKit.Command
{
    public class MessageBoxCommandParameter : Freezable
    {
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MessageBoxCommandParameter), new PropertyMetadata(string.Empty));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(MessageBoxCommandParameter), new PropertyMetadata(string.Empty));

        public MessageBoxButton Button
        {
            get { return (MessageBoxButton)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Button.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("Button", typeof(MessageBoxButton), typeof(MessageBoxCommandParameter), new PropertyMetadata(MessageBoxButton.OK));

        public ICommand OkCommand
        {
            get { return (ICommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OkCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(ICommand), typeof(MessageBoxCommandParameter), new PropertyMetadata(null));
        
        public object OkCommandParameter
        {
            get { return (object)GetValue(OkCommandParameterProperty); }
            set { SetValue(OkCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OkCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OkCommandParameterProperty =
            DependencyProperty.Register("OkCommandParameter", typeof(object), typeof(MessageBoxCommandParameter), new PropertyMetadata(null));
        
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(MessageBoxCommandParameter), new PropertyMetadata(null));
        
        public object CancelCommandParameter
        {
            get { return (object)GetValue(CancelCommandParameterProperty); }
            set { SetValue(CancelCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelCommandParameterProperty =
            DependencyProperty.Register("CancelCommandParameter", typeof(object), typeof(MessageBoxCommandParameter), new PropertyMetadata(null));
        
        protected override Freezable CreateInstanceCore()
        {
            return new MessageBoxCommandParameter();
        }
    }
}
