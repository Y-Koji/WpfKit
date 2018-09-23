using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace WpfKit.ViewKit
{
    [ContentProperty("Actions")]
    public abstract class Trigger : Animatable, IAttachableObject
    {
        public Trigger()
        {
            base.SetValue(ActionsPropertyKey, new TriggerActionCollection());
        }

        // Token: 0x04000015 RID: 21
        private static readonly DependencyPropertyKey ActionsPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "Actions",
                typeof(TriggerActionCollection),
                typeof(Trigger),
                new FrameworkPropertyMetadata((sender, e) =>
                {
                    TriggerActionCollection triggerActionCollection = e.OldValue as TriggerActionCollection;
                    TriggerActionCollection triggerActionCollection2 = e.NewValue as TriggerActionCollection;
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

        public TriggerActionCollection Actions
        {
            get { return (TriggerActionCollection)GetValue(ActionsProperty); }
        }

        // Using a DependencyProperty as the backing store for Methods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionsProperty = ActionsPropertyKey.DependencyProperty;

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject dependencyObject)
        {
            if (dependencyObject != this.AssociatedObject)
            {
                if (this.AssociatedObject != null)
                {
                    throw new InvalidOperationException("CannotHostTriggerMultipleTimesExceptionMessage");
                }
                
                WritePreamble();
                AssociatedObject = dependencyObject;
                WritePostscript();
                Actions.Attach(AssociatedObject);
                OnAttached();
            }
        }
        
        public void Detach()
        {
            OnDetaching();
            WritePreamble();
            AssociatedObject = null;
            WritePostscript();
        }

        protected virtual void OnAttached() { }

        protected virtual void OnDetaching() { }
    }
}
