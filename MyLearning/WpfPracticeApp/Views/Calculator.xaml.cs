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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfPracticeApp.Views
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        private TextBox? _focusedTextBox;
        public Calculator()
        {
            InitializeComponent();

            textBox1.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                string number = button.Content.ToString();

                if (_focusedTextBox != null)
                {
                    int caret = _focusedTextBox.CaretIndex;
                    _focusedTextBox.Text = _focusedTextBox.Text.Insert(caret, number);
                    _focusedTextBox.CaretIndex = caret + number.Length;

                    _focusedTextBox.Focus();
                }
            }
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _focusedTextBox = Keyboard.FocusedElement as TextBox;
        }
    }
}
