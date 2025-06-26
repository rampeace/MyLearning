using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfPracticeApp.Controls
{
    public class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown),
                new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(NumericUpDown), 
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(int), typeof(NumericUpDown),
                new PropertyMetadata(0));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(int), typeof(NumericUpDown),
                new PropertyMetadata(100));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public int Minimum
        {
            get => (int)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public int Maximum
        {
            get => (int)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        /*
         * When WPF applies a control’s template (usually from Generic.xaml), it instantiates the visual elements like PART_IncreaseButton, 
         * PART_DecreaseButton, etc. But those elements don’t exist until the template is applied—so you can’t access them in the constructor
         * or Loaded event.
            That’s where OnApplyTemplate() comes in:
            - It’s called after the template is applied.
            - You use GetTemplateChild("PART_Name") to grab the elements.
            - Then you can attach event handlers, set properties, or initialize state.

        Constructor

            Only the logic object (your control) is created.
            No visual elements (template parts) exist yet.
            Generic.xaml is not parsed or applied yet.
            ❌ You cannot access sub-controls here.

        Added to visual tree / measured for layout

            WPF calls ApplyTemplate() (automatically).
            This triggers parsing of Generic.xaml, and builds the visual tree.

        OnApplyTemplate() is called

            ✅ Now you can access sub-controls using GetTemplateChild("PART_Name").
        */

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("IncreaseButton") is  RepeatButton upButton)
            {
                upButton.Click += (_, _) => Value = Math.Max(Value + 1, Maximum);
            }

            if (GetTemplateChild("IncreaseButton") is RepeatButton downButton)
            {
                downButton.Click += (_, _) => Value = Math.Max(Value - 1, Minimum);
            }
        }
    }
}
