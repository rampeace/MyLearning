using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Multithreading
{
    internal class PrintEvenOdd
    {
        public async Task PrintEvenOddNumbers()
        {
            await Task.Run(() => 
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine(i);
                }
            });

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                        Console.WriteLine(i);
                }
            });
        }

        public async Task PrintEvenOddNumbersParallel()
        {
            Task even = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine(i);
                }
            });

            Task odd = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                        Console.WriteLine(i);
                }
            });

            await Task.WhenAll(even, odd);
        }
    }
}
