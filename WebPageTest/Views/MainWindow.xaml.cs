using System.Windows;
using WebPageTest.ViewModels;

namespace WebPageTest
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var vm = new MainViewModel();
            DataContext = vm;
            InitializeComponent();
        }
    }
}