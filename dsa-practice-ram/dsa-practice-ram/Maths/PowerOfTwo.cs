using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Maths
{
    internal class PowerOfTwo
    {
        // This is the bruteforce solution to check if a number is power of two
        /*
         * 2^1 -> 2
         * 2^2 -> 4
         * 2^3 -> 8         
         * 
         * */
        public bool CheckPowerOfTwo(int n)
        {
            int power = 1;

            while (power <= n)
            {
                if (power == n)
                    return true;

                power *= 2;  
            }
            return false;
        }
    }
}
