using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class LongestSubArraySum
    {
        public void FindLongestSubArraySum()
        {
            // Find the longest subarray whose sum is equal to k
            // This only works if the numbers are all positive 
            int[] array = { 1, 2, 3, 0, 0, 0, 1, 1, 1, 1, 4, 2, 3 };
            const int k = 3;
            int sum = 0;
            int windowStart = 0;
            (int start, int end) subArray = default;

            for (int windowEnd = 0; windowEnd < array.Length; windowEnd++)
            {
                sum += array[windowEnd];

                while (sum > k)
                {
                    sum -= array[windowStart];
                    windowStart++;
                }

                if (sum == k)
                {
                    int currentLength = windowEnd - windowStart + 1;

                    if (currentLength > subArray.end - subArray.start + 1)
                        subArray = (windowStart, windowEnd);
                }
            }

            Console.WriteLine(subArray);
        }
    }
}
