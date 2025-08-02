using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPracticeApp.Views;

namespace WpfPracticeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VSCode vSCode = new VSCode();
            vSCode.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductFeedback productFeedback = new ProductFeedback();
            productFeedback.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContactForm o = new();
            o.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ButtonControlTemplate buttonControlTemplate = new ButtonControlTemplate();
            buttonControlTemplate.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Calculator calculator = new Calculator();
            calculator.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            People people = new People();
            people.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
           UserControlHostWindow userControlHostWindow = new UserControlHostWindow();
            userControlHostWindow.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CounterWindow counterWindow = new();
            counterWindow.Show();
        }
    }
}