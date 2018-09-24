using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class MessageBoxMessage : Message
    {
        public string Message { get; set; }
        public string Caption { get; set; }
        public MessageBoxButton Button { get; set; }
        public MessageBoxImage Image { get; set; }
        public MessageBoxResult Response { get; set; }

        public MessageBoxMessage(string messageKey) : base(messageKey)
        {
        }

        protected override Freezable CreateInstanceCore()
        {
            return new MessageBoxMessage(string.Empty);
        }
    }
}
