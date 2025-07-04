using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Multithreading
{
    public class DeadLock
    {
        private object _lockOne = new object();
        private object _lockTwo = new object();

        public void Run1()
        {
            lock(_lockOne)
            {
                Console.WriteLine("Waiting for acquiring lockTwo");

                lock(_lockTwo)
                {
                    Console.WriteLine("Run1 successfully acquired lockTwo");
                }
            }

            Console.WriteLine("Run1 method finished.");
        }

        public void Run2()
        {
            lock(_lockTwo)
            {
                Console.WriteLine("Waiting for acquiring lockOne");

                lock (_lockOne)
                {
                    Console.WriteLine("Run1 successfully acquired lockOne");
                }

            }
            Console.WriteLine("Run2 method finished.");
        }

        public async void SimulateDeadLock()
        {
            Task task1 = Task.Run(() => Run1());
            Task task2 = Task.Run(() => Run2());

            await Task.WhenAll(task1, task2);
        }
    }
}
