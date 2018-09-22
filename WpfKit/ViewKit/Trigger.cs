using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class Trigger 
    {
        public static EventTrigger GetEventTrigger(DependencyObject obj)
        {
            return (EventTrigger)obj.GetValue(EventTriggerProperty);
        }

        public static void SetEventTrigger(DependencyObject obj, EventTrigger value)
        {
            obj.SetValue(EventTriggerProperty, value);
        }


        // Using a DependencyProperty as the backing store for EventTrigger.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventTriggerProperty =
            DependencyProperty.RegisterAttached("EventTrigger", typeof(EventTrigger), typeof(Trigger), new PropertyMetadata(null, (sender, e) =>
            {
                if (e.NewValue is EventTrigger trigger)
                {
                    WpfReflectionUtil.FindEvent(sender.GetType(), trigger.EventName, (BindingFlags)0xFF)
                        .AddEventHandler(sender, new RoutedEventHandler((_, __) =>
                    {
                        if (trigger.Command?.CanExecute(trigger.CommandParameter) ?? false)
                        {
                            trigger.Command.Execute(trigger.CommandParameter);
                        }
                    }));
                }
            }));
    }
}
