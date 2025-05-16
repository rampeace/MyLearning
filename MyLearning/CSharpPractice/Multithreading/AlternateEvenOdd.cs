using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Multithreading
{
    internal class AlternateEvenOdd
    {
        SemaphoreSlim _evenTurn = new SemaphoreSlim(1, 1); // allow 1 initially, also all maximum of 1 thread in total
        SemaphoreSlim _oddTurn = new SemaphoreSlim(0, 1);

        public async Task PrintAlternatively()
        {
            Task even = Task.Run(() => PrintEvenNumbers());
            Task odd = Task.Run(() => PrintOddNumbers());

            await Task.WhenAll(even, odd);
        }

        private async Task PrintEvenNumbers()
        {
            for (int i = 0; i <= 20; i+= 2)
            {
                await _evenTurn.WaitAsync(); // this will reduce the semaphore count by 1; if 0, it waits (hangs)
                Console.WriteLine($"Even thread prints...{i}");
                _oddTurn.Release();
            }
        }

        private async Task PrintOddNumbers()
        {
            for (int i = 1; i <= 20; i += 2)
            {
                await _oddTurn.WaitAsync();
                Console.WriteLine($"Odd thread prints...{i}");
                _evenTurn.Release();
            }
        }
    }
}
