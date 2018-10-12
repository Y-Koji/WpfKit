using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class ModalWindowMessage : Message
    {
        public ModalWindowMessage(string messageKey) : base(messageKey) { }
        
        protected override Freezable CreateInstanceCore()
        {
            return new ModalWindowMessage(string.Empty);
        }
    }
}
