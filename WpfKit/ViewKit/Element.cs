using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class Element 
    {
        public static object GetDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(DataContextProperty);
        }

        public static void SetDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(DataContextProperty, value);
        }

        // Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.RegisterAttached("DataContext", typeof(INotifyPropertyChanged), typeof(Element),
                new PropertyMetadata(null, (sender, e) =>
                {
                    if (sender is FrameworkElement element)
                    {
                        element.DataContext = Reflect.WrapInstance(e.NewValue);
                    }
                }));

        public static FreezableCollection<Trigger> GetTriggers(DependencyObject obj)
        {
            var collection = (TriggerCollection)obj.GetValue(TriggersProperty);
            if (null == collection)
            {
                collection = new TriggerCollection();
                obj.SetValue(TriggersProperty, collection);
            }

            return collection;
        }

        public static void SetTriggers(DependencyObject obj, FreezableCollection<Trigger> value)
        {
            obj.SetValue(TriggersProperty, value);
        }

        // Using a DependencyProperty as the backing store for Triggers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TriggersProperty =
            DependencyProperty.RegisterAttached("ShadowTriggers", typeof(TriggerCollection), typeof(Element), new FrameworkPropertyMetadata(null, (sender, e) =>
            {
                TriggerCollection triggerCollection = e.OldValue as TriggerCollection;
                TriggerCollection triggerCollection2 = e.NewValue as TriggerCollection;
                if (triggerCollection != triggerCollection2)
                {
                    if (triggerCollection != null && ((IAttachableObject)triggerCollection).AssociatedObject != null)
                    {
                        triggerCollection.Detach();
                    }
                    if (triggerCollection2 != null && sender != null)
                    {
                        if (((IAttachableObject)triggerCollection2).AssociatedObject != null)
                        {
                            throw new InvalidOperationException("CannotHostTriggerCollectionMultipleTimesExceptionMessage");
                        }
                        triggerCollection2.Attach(sender);
                    }
                }
            }));
    }
}
