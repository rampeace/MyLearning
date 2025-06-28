using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfPracticeApp.Models;

namespace WpfPracticeApp.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Calculator _calculator = new Calculator();

        public RelayCommand AddCommand { get; }
        public RelayCommand SubtractCommand { get; }
        public RelayCommand MultiplyCommand { get; }
        public RelayCommand DivideCommand { get; }

        public CalculatorViewModel()
        {
            AddCommand = new RelayCommand(Add, CanExecute);
            SubtractCommand = new RelayCommand(Subtract, CanExecute);
            MultiplyCommand = new RelayCommand(Multiply, CanExecute);
            DivideCommand = new RelayCommand(Divide, CanExecute);
        }

        public double? Value1
        {
            get => _calculator.Value1;
            set  {  _calculator.Value1 = value; OnPropertyChanged(nameof(Value1)); RaiseCanExecute(); }
        }

        public double? Value2
        {
            get => _calculator.Value2;
            set  { _calculator.Value2 = value; OnPropertyChanged(nameof(Value2)); RaiseCanExecute(); }
        }

        public double? Result
        {
            get => _calculator.Result;
            set  { _calculator.Result = value; OnPropertyChanged(nameof(Result)); }
        }

        private void OnPropertyChanged(string type)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(type));
        }

        private void Add()
        {
            Result = Value1 + Value2;
        }

        private void  Subtract()
        {
            Result = Value1 - Value2;
        }

        private void Multiply()
        {
            Result = Value1 * Value2;
        }

        private void Divide()
        {
            Result = Value1 / Value2;
        }

        private void RaiseCanExecute()
        {
            AddCommand.RaiseCanExecuteChanged();
            SubtractCommand.RaiseCanExecuteChanged();
            MultiplyCommand.RaiseCanExecuteChanged();
            DivideCommand.RaiseCanExecuteChanged();
        }

        private bool CanExecute() => true;  
    }
}
