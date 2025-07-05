using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfPracticeApp.Controls
{
    public class AnimatedButton : Button
    {
        static AnimatedButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatedButton), new FrameworkPropertyMetadata(typeof(AnimatedButton)));

        }
    }
}
