using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class MessageTrigger : Trigger
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            Messenger.OnMessage += message =>
            {
                foreach (var action in Actions)
                {
                    var actionType = typeof(MessageAction<>).MakeGenericType(message.GetType());
                    if (actionType.IsAssignableFrom(action.GetType()))
                    {
                        action.Invoke(message);
                    }
                }
            };
        }

        public Messenger Messenger
        {
            get { return (Messenger)GetValue(MessengerProperty); }
            set { SetValue(MessengerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Messenger.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessengerProperty =
            DependencyProperty.Register("Messenger", typeof(Messenger), typeof(MessageTrigger), new PropertyMetadata(null));
        
        protected override Freezable CreateInstanceCore()
        {
            return new MessageTrigger();
        }
    }
}
