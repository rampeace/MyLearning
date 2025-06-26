using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfPracticeApp
{
    /*
     *  Core Principle:
        Attached properties are always completely new properties, even if they have the same name as an existing one.
        WPF identifies a property not by its name, but by the actual DependencyProperty instance, which is created when 
        you call Register(...) or RegisterAttached(...).

        Value precedence:
        Local > Animation > Style Triggers > Templates > Inheritance > Metadata Default

        ✅ 1. AddOwner — Preferred, Native Extension
        🔹 What it does:
        Shares the same DependencyProperty instance (same key) with a new type

        Lets that new owner supply new metadata (like default value or callbacks)

        Fully respects WPF's value precedence system

       Attached properties generally do not participate in styling, templating, or animation, because WPF styles 
       are based on properties owned by the element type itself, not on external attached ones.
     */

    public static class BackgroundBehavior
    {
        public static Brush GetBackground(DependencyObject obj) => obj.GetValue(BackgroundProperty) as Brush;

        public static void SetBackground(DependencyObject obj, Brush brush) => obj.SetValue(BackgroundProperty, brush); 

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty
            .RegisterAttached("Background", typeof(Brush), typeof(BackgroundBehavior), new PropertyMetadata(new SolidColorBrush(Colors.LightSalmon), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock control)
                control.Background = (Brush)e.NewValue;
        }
    }
}
