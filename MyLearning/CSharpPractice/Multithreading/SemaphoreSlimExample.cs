using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Multithreading
{
    internal class SemaphoreSlimExample
    {
        SemaphoreSlim semaphore = new SemaphoreSlim(2);

        public void DoWork()
        {
            Task[] tasks = new Task[5];

            for (int i = 1; i <= 5; ++i)
            {
                int taskId = i;
                tasks[i - 1] = Task.Run(() => Work(taskId));
            }

            Task.WhenAll(tasks);
        }

        private async Task Work(int taskId)
        {
            Console.WriteLine($"Taskid: {taskId} waiting...");
            await semaphore.WaitAsync();

            try
            {
                Console.Write($"TaskId: {taskId} entered...");
                await Task.Delay(2000);
                Console.Write($"TaskId: {taskId} finished task...");
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
