using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Samples.RedditWpfLCARS
{
    internal class MainWindowVM
    {
        public ObservableCollection<ListBoxItem> Posts { get; set; }
        public ListBoxItem SelectedPost { get; set; }
        public string URL { get; set; }
    }
}
