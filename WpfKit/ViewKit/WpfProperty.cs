using System.ComponentModel;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class WpfProperty
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
            DependencyProperty.RegisterAttached("DataContext", typeof(INotifyPropertyChanged), typeof(WpfProperty),
                new PropertyMetadata(null, (sender, e) =>
                {
                    if (sender is FrameworkElement element)
                    {
                        element.DataContext = WpfReflectionUtil.WrapInstance(e.NewValue);
                    }
                }));
    }
}
