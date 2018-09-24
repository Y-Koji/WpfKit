using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class MessageBoxAction : MessageAction<MessageBoxMessage>
    {
        public override void Invoke(object parameter)
        {
            base.Invoke(parameter);

            if (parameter is MessageBoxMessage message)
            {
                MessageBox.Show(message.Message, message.Caption, message.Button, message.Image);
            }
            else
            {
                throw new InvalidOperationException("MessageBoxActionにMessageBoxMessage以外のパラメタを与えることはできません");
            }
        }
    }
}
