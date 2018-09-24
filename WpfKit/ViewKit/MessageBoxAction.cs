using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class MessageBoxAction : MessageAction
    {
        public override void Invoke(object parameter)
        {
            MessageBoxMessage msg = (MessageBoxMessage)parameter;

            msg.Response = MessageBox.Show(msg.Message, msg.Caption, msg.Button, msg.Image);
        }
    }
}
