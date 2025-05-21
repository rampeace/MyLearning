using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.OOP
{
    internal class Composition
    {
        public class Engine
        {
            public void Start() => Console.WriteLine("Engine started!");
        }

        public class Car
        {
            private readonly Engine _engine;

            public Car()
            {
                _engine = new Engine(); // Composition: Car "has an" Engine
            }

            public void StartCar()
            {
                _engine.Start(); // Using Engine's functionality
                Console.WriteLine("Car is ready to go!");
            }
        }
    }
}
