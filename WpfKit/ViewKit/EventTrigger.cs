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
    public class EventTrigger : Trigger
    {
        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

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
        
        protected override Freezable CreateInstanceCore()
        {
            return new EventTrigger();
        }
    }
}
