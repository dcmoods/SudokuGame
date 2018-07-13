using Sudoku.Client.ViewModels;
using System.Windows;

namespace Sudoku.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
         
        }

    }
}
