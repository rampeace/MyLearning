using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Multithreading
{
    /*
     ReadLargeFile(token)
     └── awaits Task.Delay(1000, token)
          └── token is cancelled -> throws OperationCanceledException
               └── Task becomes Canceled (or Faulted)
                    └── await task   <-- rethrows OperationCanceledException

    */
    public class ReadFile
    {
        // This is also correct
        //public async Task LongRunningTask(CancellationToken token)
        //{
        //    int totalFilesToRead = 20;

        //    await Task.Run(async () =>
        //    {
        //        for (int file = 1; file < totalFilesToRead; file++)
        //        {
        //            token.ThrowIfCancellationRequested();

        //            await ReadLargeFile(file, token); // simulate a background task
        //        }
        //    }, token);
        //}

        private async Task ReadLargeFile(CancellationToken token, int totalFilesToRead = 20)
        {
            for (int file = 1; file < totalFilesToRead; file++)
            {
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Reading file from disk -> {file} completed...");

                await Task.Delay(1000, token); // simulate reading a large file approximately 1 GB
            }
        }

        public async Task SimulateTaskCancellation()
        {
            Console.WriteLine("Press enter to cancel file reading\n");

            CancellationTokenSource cts = new();

            Task task = ReadLargeFile(cts.Token);

            //await Task.Delay(3000);

            Console.ReadLine();

            try
            {
                cts.Cancel();

                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Task cancelled successfully");
            }
        }
    }
}
