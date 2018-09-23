using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public interface IAttachableObject
    {
        DependencyObject AssociatedObject { get; }

        void Attach(DependencyObject dependencyObject);

        void Detach();
    }
}
