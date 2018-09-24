using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WpfKit.ViewKit
{
    [ContentProperty("Actions")]
    public class EventTrigger : Trigger
    {
        public EventTrigger()
        {
            base.SetValue(ActionsPropertyKey, new EventTriggerActionCollection());
        }

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            Actions.Attach(AssociatedObject);

            var @event = Reflect.FindEvent(AssociatedObject.GetType(), EventName, (BindingFlags)0xFF);
            if (null == @event)
            {
                throw new InvalidOperationException($"{AssociatedObject.ToString()}には{EventName}イベントがありません");
            }

            @event.AddEventHandler(
                AssociatedObject,
                Delegate.CreateDelegate(@event.EventHandlerType,
                this, this.GetType().GetMethod(nameof(OnEvent))));
        }

        public void OnEvent(object sender, EventArgs eventArgs)
        {
            foreach (var action in Actions)
            {
                action.Invoke(null);
            }
        }

        // Using a DependencyProperty as the backing store for EventName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventNameProperty =
            DependencyProperty.Register("EventName", typeof(string), typeof(EventTrigger), new PropertyMetadata(string.Empty));
        
        private static readonly DependencyPropertyKey ActionsPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "Actions",
                typeof(EventTriggerActionCollection),
                typeof(EventTrigger),
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

        public virtual EventTriggerActionCollection Actions
        {
            get { return (EventTriggerActionCollection)GetValue(ActionsProperty); }
        }

        // Using a DependencyProperty as the backing store for Methods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionsProperty = ActionsPropertyKey.DependencyProperty;

        protected override Freezable CreateInstanceCore()
        {
            return new EventTrigger();
        }
    }
}
