using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WpfKit.ViewKit
{
    [ContentProperty("Actions")]
    public class MessageTrigger : Trigger
    {
        public MessageTrigger()
        {
            MessageAction action = new MessageBoxAction();

            base.SetValue(ActionsPropertyKey, new MessageTriggerActionCollection());
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            Messenger.OnMessage += message =>
            {
                foreach (var action in Actions)
                {
                    if (action.MessageKey == message.MessageKey)
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

        private static readonly DependencyPropertyKey ActionsPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "Actions",
                typeof(MessageTriggerActionCollection),
                typeof(MessageTrigger),
                new FrameworkPropertyMetadata((sender, e) =>
                {
                    EventTriggerActionCollection triggerActionCollection = e.OldValue as EventTriggerActionCollection;
                    EventTriggerActionCollection triggerActionCollection2 = e.NewValue as EventTriggerActionCollection;
                    if (triggerActionCollection != triggerActionCollection2)
                    {
                        if (triggerActionCollection != null && ((IAttachableObject)triggerActionCollection).AssociatedObject != null)
                        {
                            triggerActionCollection.Detach();
                        }
                        if (triggerActionCollection2 != null && sender != null)
                        {
                            if (((IAttachableObject)triggerActionCollection2).AssociatedObject != null)
                            {
                                throw new InvalidOperationException("CannotHostTriggerActionCollectionMultipleTimesExceptionMessage");
                            }
                        }
                    }
                }));

        public virtual MessageTriggerActionCollection Actions
        {
            get { return (MessageTriggerActionCollection)GetValue(ActionsProperty); }
        }

        // Using a DependencyProperty as the backing store for Methods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionsProperty = ActionsPropertyKey.DependencyProperty;

        protected override Freezable CreateInstanceCore()
        {
            return new MessageTrigger();
        }
    }
}
