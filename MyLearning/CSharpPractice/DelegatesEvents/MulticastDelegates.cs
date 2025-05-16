using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DelegatesEvents
{
    public delegate void SayGreeting();
    internal class MulticastDelegates
    {
        public void Test()
        {
            SayGreeting greeting = SayGoodMorning;
            greeting += SayGoodAfternoon;
            greeting += SayGoodNight;

            greeting.Invoke();
        }

        private void SayGoodMorning()
        {
            Console.WriteLine("Good morning");
        }

        private void SayGoodAfternoon()
        {
            Console.WriteLine("Good Afternoon");
        }

        private void SayGoodNight()
        {
            Console.WriteLine("Good night");
        }
    }
}
