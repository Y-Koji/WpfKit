using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace WpfKit.ViewKit
{
    public abstract class AttachableCollection<T> : FreezableCollection<T>, IAttachableObject
        where T : DependencyObject, IAttachableObject
    {
        public DependencyObject AssociatedObject { get; private set; } = null;

        public AttachableCollection()
        {
            ((INotifyCollectionChanged)this).CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        OnItemAdded((T)item);
                    }
                    return;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        OnItemRemoved((T)item);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        public void Attach(DependencyObject dependencyObject)
        {
            if (dependencyObject != AssociatedObject)
            {
                if (AssociatedObject != null)
                {
                    throw new InvalidOperationException();
                }

                if (!(bool)base.GetValue(DesignerProperties.IsInDesignModeProperty))
                {
                    base.WritePreamble();
                    AssociatedObject = dependencyObject;
                    base.WritePostscript();
                }

                this.OnAttached();
            }
        }

        public void Detach()
        {
            OnDetaching();
            WritePreamble();
            AssociatedObject = null;
            WritePostscript();
        }

        protected abstract void OnItemAdded(T item);

        protected abstract void OnItemRemoved(T item);

        protected abstract void OnAttached();
        
        protected abstract void OnDetaching();
    }
}
