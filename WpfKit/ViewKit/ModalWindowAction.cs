using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfKit.ViewKit
{
    public class ModalWindowAction : MessageAction
    {
        public override void Invoke(object parameter)
        {
            if (parameter is ModalWindowMessage msg && Type is Type type)
            {
                var window = Activator.CreateInstance(type) as Window;
                window.DataContext = DataContext;

                window.ShowDialog();
            }
        }

        public Type Type
        {
            get { return (Type)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Type), typeof(ModalWindowAction), new PropertyMetadata(null));

        public object DataContext
        {
            get { return (object)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(object), typeof(ModalWindowAction), new PropertyMetadata(null));

    }
}
