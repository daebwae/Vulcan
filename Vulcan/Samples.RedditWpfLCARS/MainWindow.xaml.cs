using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Samples.RedditBayes;

namespace Samples.RedditWpfLCARS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var answer = new Reddit("programming", 100).GetPosts();

            var vm = new MainWindowVM();

            DataContext = vm;

            InitializeComponent();

            vm.Posts = new ObservableCollection<ListBoxItem>(answer.Select(post => new ListBoxItem { Content = post.Title, Tag = post.ID }));

//            Posts.ItemsSource = posts;
            
        }
    }
}
