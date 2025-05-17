using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Maths
{
    internal class AllDivisors
    {
        public List<(int a, int b)> FindAllDivisors(int n)
        {
            // This optimization is based on the mathematical property that:
            // If a × b = target, then both a and b are divisors of target.
            // The same same concept can be used to find prime numbers
            // Time complexity Sqrt(n)

            List<(int a, int b)> result = new List<(int a, int b)>();

            for (int i = 1; i <= Math.Sqrt(n); i++) // Math.Sqrt will avoid duplicate pairs
            {
                if (n % i == 0)
                    result.Add((i, n / i));
            }
            return result;
        }

        public void ConvertToAlmostSquareMatrix()
        {
            int[] array = { 2, 1, 4, 3, 5, 5, 8, 3, 2, 5, 8, 9, 4, 4, 2, 3, 4, 5, 7, 8, 8, 4, 5, 6 , 5};

            var almostSquare = FindAllDivisors(array.Length).MinBy(d => Math.Abs(d.a -  d.b));

            Console.WriteLine(almostSquare);
        }
    }
}
