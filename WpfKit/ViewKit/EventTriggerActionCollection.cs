using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKit.ViewKit
{
    public class EventTriggerActionCollection : AttachableCollection<EventTriggerAction>
    {
        protected override void OnAttached()
        {
            foreach (var item in this)
            {
                item.Attach(AssociatedObject);
            }
        }

        protected override void OnDetaching()
        {
            foreach (var item in this)
            {
                item.Detach();
            }
        }

        protected override void OnItemAdded(EventTriggerAction item)
        {
            if (base.AssociatedObject != null)
            {
                item.Attach(base.AssociatedObject);
            }
        }

        protected override void OnItemRemoved(EventTriggerAction item)
        {
            if (((IAttachableObject)item).AssociatedObject != null)
            {
                item.Detach();
            }
        }
    }
}
