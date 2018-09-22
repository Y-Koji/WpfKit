using System.ComponentModel;
using System.Windows.Input;
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
        
        public ICommand InitializeCommand => new ActionCommand(_ =>
        {
            // Initialize process.
        });

        public ICommand CombineCommand => new ActionCommand(_ =>
        {
            // Combine command rised process.
        });

        public ICommand SetRandomValueCommand => new ActionCommand(_ =>
        {
            // SetRandomValueCommand rised process.
        });
    }
}
