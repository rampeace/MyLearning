using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPracticeApp.Controls
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : UserControl
    {
        public Feedback()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommentsProperty =
            DependencyProperty.Register("Comments", typeof(string), typeof(Feedback));

        public static readonly DependencyProperty SaveProperty = 
            DependencyProperty.Register("Save", typeof(ICommand), typeof(Feedback));

        public string Comments
        {
            get => (string)GetValue(CommentsProperty);
            set => SetValue(CommentsProperty, value);
        }

        public ICommand Save
        {
            get => (ICommand)GetValue(SaveProperty);
            set => SetValue(SaveProperty, value);
        }
    }
}
