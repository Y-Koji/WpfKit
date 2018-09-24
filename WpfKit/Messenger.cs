using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKit.ViewKit;

namespace WpfKit
{
    public class Messenger
    {
        public event Action<Message> OnMessage;

        public void Raise(Message message)
        {
            OnMessage?.Invoke(message);
        }
    }
}
