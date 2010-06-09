using System.Windows;
using System.Windows.Input;
using CodeTest.Controllers;
using CodeTest.Views;

namespace CodeTest.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainController _mainController = new MainController();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;            
            var mainView = _mainController.DoTextMatch(txtText.Text, txtSubtext.Text);            
            applyView(mainView);
            Cursor = Cursors.Arrow;
        }

        private void applyView(MainView mainView)
        {
            txtMatches.Text = mainView.Matches;
            txtSubtext.Text = mainView.Subtext;
            txtText.Text = mainView.Text;
        }
    }
}
