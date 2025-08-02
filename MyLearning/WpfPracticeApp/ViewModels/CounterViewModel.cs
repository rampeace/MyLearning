using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPracticeApp.ViewModels
{
    public partial class CounterViewModel : ObservableObject
    {
        [ObservableProperty]
        private int count;

        [RelayCommand]
        public void Increment()
        {
            Count++;
        }
    }
}
