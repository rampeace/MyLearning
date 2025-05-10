using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class ReArrangeBySign
    {
        public void ReArrangeBySignEqualNumbersOfPositiveAndNegative()
        {
            // This code will only work if it has equal numbers of positives and negatives
            int[] nums = { 1, -2, -3, 5, -3, 8 };

            int evenIndex = 0;
            int oddIndex = 1;

            int[] result = new int[nums.Length];

            foreach (var num in nums)
            {
                if (num > 0)
                {
                    result[evenIndex] = num;
                    evenIndex += 2;
                }
                else
                {
                    result[oddIndex] = num;
                    oddIndex += 2;
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
