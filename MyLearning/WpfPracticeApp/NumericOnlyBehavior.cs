using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfPracticeApp
{
    public static class NumericOnlyBehavior
    {
        public static bool GetEnable(DependencyObject obj) => (bool)obj.GetValue(EnableProperty);

        public static void SetEnable(DependencyObject obj, bool value) => obj.SetValue(EnableProperty, value);

        public static readonly DependencyProperty EnableProperty =
            DependencyProperty.RegisterAttached("Enable", typeof(bool), typeof(NumericOnlyBehavior), new UIPropertyMetadata(false, OnEnableChanged));

        private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += OnPreviewTextInput;
                    DataObject.AddPastingHandler(textBox, OnPaste);
                }
                else
                {
                    textBox.PreviewTextInput -= OnPreviewTextInput;
                    DataObject.RemovePastingHandler(textBox, OnPaste);
                }
            }
        }

        private static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!text.All(char.IsDigit))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
