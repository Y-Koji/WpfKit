using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public abstract class Message : Freezable
    {
        public Message(string messageKey)
        {
            MessageKey = messageKey;
        }

        public string MessageKey
        {
            get { return (string)GetValue(MessageKeyProperty); }
            set { SetValue(MessageKeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageKey.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageKeyProperty =
            DependencyProperty.Register("MessageKey", typeof(string), typeof(Message), new PropertyMetadata(string.Empty));
    }
}
