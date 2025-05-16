using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.OOP
{
    internal class Abstraction
    {
        /*
         * 
         * Hiding the complex implementation details and showing only the essential features to the user.
         * In C#, Abstraction Can Be Achieved Using:
            1. Abstract classes
            2. Interfaces
            3. Virtual methods (optional customization in base class)

         * */
        public abstract class Animal
        {
            // Abstract method - no implementation here
            public abstract void MakeSound();

            // Concrete method - shared behavior
            public void Sleep()
            {
                Console.WriteLine("Sleeping...");
            }
        }

        public class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Bark!");
            }
        }

        public class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Meow!");
            }
        }
    }
}
