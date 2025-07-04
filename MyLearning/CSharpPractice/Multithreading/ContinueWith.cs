using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Multithreading
{
    public class ContinueWith
    {
        public async Task Run()
        {
            Task task1 = Task.Run(() => Console.WriteLine("First task running..."));

            await task1.ContinueWith((_) => Console.WriteLine("Continuing first task..."));
        }
    }
}

