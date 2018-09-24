using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfKit;
using WpfKit.ViewKit;
using WpfKit.ViewModelKit;

namespace SyncTextBox
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Bindable properties.
        public virtual string Text1 { get; set; }
        public virtual string Text2 { get; set; }
        public virtual string Text3 { get; set; }
        public virtual Messenger Messenger { get; set; }
        
        public ICommand InitializeCommand => new ActionCommand(_ =>
        {
            // Initialize process.

        });

        public ICommand CombineCommand => new ActionCommand(_ =>
        {
            // Combine command rised process.
            Messenger.Raise(new MessageBoxMessage("Sample")
            {
                Message = "Hello, World!",
                Caption = "Test",
                Button = MessageBoxButton.OKCancel,
                Image = MessageBoxImage.Error,
            });
        });

        public ICommand SetRandomValueCommand => new ActionCommand(_ =>
        {
            // SetRandomValueCommand rised process.
        });
    }
}
