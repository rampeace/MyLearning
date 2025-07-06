using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Multithreading
{
    public class PauseThread
    {
        SemaphoreSlim _semaphore = new(1, 1);

        public async Task RunTask()
        {
            await Task.Run(async () => 
            {
                for (int i = 1; i <= 20; i++)
                {
                    await _semaphore.WaitAsync();
                    _semaphore.Release();

                    Console.WriteLine($"Running task no -> {i}");

                    await Task.Delay(2000);

                }
            });
        }

        public void Pause()
        {
            _semaphore.Wait();
            Console.WriteLine("Paused");
        }

        public void Resume()
        {
            _semaphore.Release();
            Console.WriteLine("Resumed");
        }
    }
}
