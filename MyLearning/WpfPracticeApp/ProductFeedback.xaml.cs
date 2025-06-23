using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfPracticeApp.ViewModels;

namespace WpfPracticeApp
{
    /// <summary>
    /// Interaction logic for ProductFeedback.xaml
    /// </summary>
    public partial class ProductFeedback : Window
    {
        public ProductFeedback()
        {
            InitializeComponent();
            ProductTextBox.Focus();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
