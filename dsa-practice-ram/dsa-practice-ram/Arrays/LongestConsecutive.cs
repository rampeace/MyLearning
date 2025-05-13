using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class LongestConsecutive
    {
        public void LongestConsecutiveSequenceSlidingWindow()
        {
            int[] nums = { 102, 4, 4, 4, 4, 4, 4, 44, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 100, 1, 101, 3, 2, 1, 1 };
            // sorted: 1, 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 44, 100, 101, 102
            // Time complexity: nLog(n)

            Array.Sort(nums);

            int maxLength = 1;
            Range range = default;

            int windowStart = 0;

            for (int windowEnd = 1; windowEnd < nums.Length; windowEnd++)
            {
                int curr = nums[windowEnd];
                int previous = nums[windowEnd - 1];

                if (curr - previous != 1)
                {
                    windowStart = windowEnd;
                }

                int windowLength = windowEnd - windowStart + 1;
                if (windowLength > maxLength)
                {
                    maxLength = windowLength;
                    range = windowStart..(windowEnd + 1);
                }
            }

            Console.WriteLine(string.Join(", ", nums[range]));
        }
        
        public void LongestConsecutiveSequenceHashsetApproach()
        {
            int[] nums = { 102, 4, 4, 4, 4, 4, 4, 44, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 100, 1, 101, 3, 2, 1, 1 };
            // sorted: 1, 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 44, 100, 101, 102
            // Time complexity: O(n)

            HashSet<int> seen = new HashSet<int>(nums);

            int maxLength = 0;

            foreach (var num in nums)
            {
                if (!seen.Contains(num - 1))
                {
                    int current = num;
                    int count = 0;

                    while (seen.Contains(current))
                    {
                        current++;
                        count++;
                    }
                    maxLength = Math.Max(maxLength, count);
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
