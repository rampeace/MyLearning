using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DelegatesEvents
{
    internal class Events
    {
        public void Test()
        {
            Button button = new Button();
            button.Clicked += Button_Clicked;
            button.Click();
        }

        private void Button_Clicked(object? sender, EventArgs e)
        {
            Console.WriteLine("Button is clicked.");
        }

        public class Button
        {
            public event EventHandler Clicked;
            public void Click()
            {
                this.Clicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
