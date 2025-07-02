using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WpfPracticeApp.Models;

namespace WpfPracticeApp.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // fetch from database
        List<Person> _people = new()
        {
            new Person { Age = 12, BirthDate = DateTime.Now.Date, Name = "Shiva" },
            new Person { Age = 25, BirthDate = new DateTime(1999, 5, 15), Name = "Ava" },
            new Person { Age = 34, BirthDate = new DateTime(1990, 2, 20), Name = "Liam" },
            new Person { Age = 45, BirthDate = new DateTime(1979, 11, 3), Name = "Olivia" },
            new Person { Age = 29, BirthDate = new DateTime(1995, 8, 27), Name = "Noah" }
        };

        public List<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(People)));
            }
        }
    }
}
