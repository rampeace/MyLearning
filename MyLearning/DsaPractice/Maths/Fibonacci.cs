using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Maths
{
    public class Fibonacci
    {
        public void GenerateFibonacciSeries(int n)
        {
            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{a} ");

                int next = a + b;
                a = b;
                b = next;
            }
        }
    }
}
