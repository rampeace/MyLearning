using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Maths
{
    internal class Prime
    {
        public bool IsPrimeNumber(int number)
        {

            /*
             *  A prime number is a number greater than 1 that has only two divisors: 1 and itself.
                All other even numbers (4, 6, 8, 10, …) are divisible by 2, so they have more than two divisors, 
                and hence they are not prime.
                You only need to test divisibility up to the square root of the number, because:
                If a number n has a factor greater than √n,
                then it must also have a corresponding factor smaller than √n.
                So if no number between 2 and √n divides n, then n is prime.
             * */

            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)System.Math.Sqrt(number);

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
