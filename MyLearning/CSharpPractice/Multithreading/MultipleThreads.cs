using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Multithreading
{
    public class MultipleThreads
    {
        public void Run()
        {
            Console.WriteLine("Task running...");
        }

        public async void RunMultipleThreads()
        {
            Task[] tasks = new Task[5];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => Run());
            }

            await Task.WhenAll(tasks);
        }
    }
}
