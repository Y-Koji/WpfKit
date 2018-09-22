using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfKit;

namespace SyncTextBox
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string Text1 { get; set; }
        public virtual string Text2 { get; set; }
        public virtual string Text3 { get; set; }

        public ICommand CombineCommand => new ActionCommand(_ =>
        {
            Text3 = Text1 + Text2;
        });

        public ICommand SetRandomValueCommand => new ActionCommand(_ =>
        {
            Random random = new Random();

            StringBuilder sb = new StringBuilder();
            var alphabets = Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => (char)x).ToArray();
            var numbers = Enumerable.Range('0', '9' - '0' + 1).Select(x => (char)x).ToArray();

            foreach (var i in Enumerable.Range(0, 10))
            {
                var value = random.Next(0, 26);
                sb.Append(alphabets[value]);
            }

            Text1 = sb.ToString();
            sb.Clear();

            foreach (var i in Enumerable.Range(0, 10))
            {
                var value = random.Next(0, 10);
                sb.Append(numbers[value]);
            }

            Text2 = sb.ToString();
            sb.Clear();
        });
    }
}
