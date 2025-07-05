using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Multithreading
{
    public class ProducerConsumerQueue
    {
        BlockingCollection<Func<Task>> _queue = new();

        public Task Worker { get; }

        public ProducerConsumerQueue()
        {
            Worker = Task.Run(ProcessQueue);
        }

        public void AddTask(Func<Task> task)
        {
            if (!_queue.IsAddingCompleted)
                _queue.Add(task);
        }

        public void ShutDown() => _queue.CompleteAdding();

        private async Task ProcessQueue()
        {
            foreach (var task in _queue.GetConsumingEnumerable())
            {
                try
                {
                    Console.WriteLine("Consumer running task...");
                    await task?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception happened {ex.Message}");
                }
            }
        }

        public static async Task Test()
        {
            ProducerConsumerQueue queue = new();

            for (int i = 0; i < 5; i++)
            {
                int copy = i; // new variable created so that lambda will look for new memory address each time

                Func<Task> action = async () =>
                {
                    Console.WriteLine($"Running task {copy}");

                    await Task.Delay(1000);
                };

                queue.AddTask(action);
            }

            await queue.Worker;
        }
    }
}
