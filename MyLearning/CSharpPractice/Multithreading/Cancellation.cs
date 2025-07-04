using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Multithreading
{
    public class Cancellation
    {
        public async Task LongRunningTask(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Task is running...");
                token.ThrowIfCancellationRequested();

                await Task.Delay(1000, token);
            }
        }

        public async Task Run()
        {
            using CancellationTokenSource cts = new();

            Task task = LongRunningTask(cts.Token);
            
            await Task.Delay(2000);

            try
            {
                cts.Cancel();
                await task;
                Console.WriteLine("Task cancelled successfully.");
            }
            catch(OperationCanceledException e)
            {
                Console.WriteLine("Task cancelled.");
            }
        }
    }
}
