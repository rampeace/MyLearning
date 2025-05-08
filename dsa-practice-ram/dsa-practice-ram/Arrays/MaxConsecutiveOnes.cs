using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    public class MaxConsecutiveOnes
    {
        public void GetMaxConsecutiveOnes()
        {
            int[] array = { 0, 2, 3, 1, 1, 5, 7, 1, 1, 1, 67, 1, 1 };

            int count = 0;
            int max = int.MinValue;

            foreach (var num in array)
            {
                if (num == 1)
                    count++;
                else
                    count = 0;

                max = Math.Max(max, count);                
            }

            Console.WriteLine(max);
        }
    }
}
