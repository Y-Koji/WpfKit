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
    public abstract class Trigger : Animatable, IAttachableObject
    {
        public Trigger()
        {
        }

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
