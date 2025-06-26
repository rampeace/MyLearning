using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfPracticeApp.Controls
{
    public class CustomButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty =
      Border.CornerRadiusProperty.AddOwner(typeof(CustomButton), new PropertyMetadata() { DefaultValue = 10 });

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
