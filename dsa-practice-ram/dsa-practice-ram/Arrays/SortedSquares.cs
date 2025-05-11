using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class SortedSquares
    {
        public void FindSortedSquares()
        {
            // Leetcode 977. Squares of a Sorted Array
            int[] nums = { -4, -1, 0, 2, 3 };

            int[] result = new int[nums.Length];
            int left = 0;
            int right = nums.Length - 1;
            int index = nums.Length - 1;

            while (left <= right)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    result[index] = (int)Math.Pow(nums[left], 2);
                    index--;
                    left++;
                }
                else
                {
                    result[index] = (int)Math.Pow(nums[right], 2);
                    index--;
                    right--;
                }
            }
            Console.WriteLine(string.Join(", ", result));   
        }
    }
}
