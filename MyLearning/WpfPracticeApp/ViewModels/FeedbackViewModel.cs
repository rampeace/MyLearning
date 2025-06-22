using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfPracticeApp.Models;

namespace WpfPracticeApp.ViewModels
{
    public class FeedbackViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        FeedbackModel _productFeedback = new();

        public RelayCommand ClickCommand { get; }

        public RelayCommand<TextBox> TextChangedCommand { get; }

        public FeedbackViewModel()
        {
            ClickCommand = new RelayCommand(Submit, CanSubmit);

            TextChangedCommand = new RelayCommand<TextBox>(TextChanged);
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string ProductName
        {
            get => _productFeedback.ProductName;  
            set  
            {
                _productFeedback.ProductName = value;
                OnPropertyChanged(); 
                ClickCommand.RaiseCanExecuteChanged(); 
            }
        }

        public int Rating
        {
            get => _productFeedback.Rating;
            set { _productFeedback.Rating = value; OnPropertyChanged(); }
        }

        public string Feedback
        {
            get => _productFeedback.Feedback;
            set { _productFeedback.Feedback = value; OnPropertyChanged(); }
        }

        private void Submit() => MessageBox.Show("Feedback successfully submitted.");

        private bool CanSubmit() => !string.IsNullOrWhiteSpace(ProductName);

        private void TextChanged(TextBox textBox) 
        { 
            if (textBox != null)
            {
                Debug.WriteLine($"{textBox.Text}");

                if (textBox.Text.Length % 2 == 0)
                    textBox.Background = Brushes.Red;
                else
                    textBox.Background = Brushes.Green;
            }
        }

    }
}
