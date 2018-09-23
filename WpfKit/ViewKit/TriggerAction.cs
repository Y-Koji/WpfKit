using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class TriggerAction : Freezable, IAttachableObject
    {
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject dependencyObject)
        {
            if (dependencyObject != this.AssociatedObject)
            {
                if (this.AssociatedObject != null)
                {
                    throw new InvalidOperationException("CannotHostTriggerActionMultipleTimesExceptionMessage");
                }

                WritePreamble();
                AssociatedObject = dependencyObject;
                WritePostscript();
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

        protected virtual void OnAttached()
        {

        }

        protected virtual void OnDetaching()
        {

        }

        public virtual void Invoke(object parameter) { }

        protected override Freezable CreateInstanceCore()
        {
            return new TriggerAction();
        }
    }
}
