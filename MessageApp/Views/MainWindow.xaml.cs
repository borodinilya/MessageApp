using System.Windows;
using MessageApp.ViewModels;

namespace MessageApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(App.GetBusinessLogicPresenter().MessageControl);
        }
    }
}
