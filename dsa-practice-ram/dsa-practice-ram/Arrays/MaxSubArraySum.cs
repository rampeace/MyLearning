using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class MaxSubArraySum
    {
        public void MaxSubArraySumFixedSlidingWindow()
        {
            // This approach  works for both negative and non negative integers
            int[] array = { 1, 4, 5, 6, 1, 2, -3, 6, 8, -9, 7, 6, 3, 3 };
            int k = 3;

            Range range = ..k;
            int windowSum = 0;

            windowSum = array[..k].Sum();
            int maxSum = windowSum;

            for (int i = k; i < array.Length; i++)
            {
                windowSum += array[i] - array[i - k];
                if (windowSum > maxSum)
                {
                    range = new Range(i - k + 1, i + 1);
                    maxSum = windowSum;
                }
            }
            int[] subArray = array[range];
            Console.WriteLine($"{string.Join(", ", subArray)} -> {maxSum}");
        }

        public void KadanesAlgorithmGetSubArray()
        {
            // You restart the subarray from the current element only when the ongoing total (currentSum) isn’t worth carrying forward.
            // Return the contiguous subarray of any length that has maximum sum
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            int sum = 0;
            int maxSum = int.MinValue;
            Range range = ..1;
            int tempStart = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (sum <= 0)
                {
                    sum = nums[i];
                    tempStart = i;
                }
                else
                {
                    sum += nums[i];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    range = tempStart..(i + 1);
                }
            }

            Console.WriteLine($"{string.Join(", ", nums[range])} -> {maxSum}");
        }

        public void KadanesAlgorithmGetMaxSumAnotherApproach()
        {
            // Given an array of integers (which may include negative numbers), 
            // find the contiguous sub array that has the maxumum sum
            int[] nums = { 2, -3, 4, -1, -2, 1, 5, -3 };
            int maxSum = int.MinValue;
            int sum = 0;

            foreach (var num in nums)
            {
                sum += num;
                maxSum = Math.Max(maxSum, sum);

                if (sum < 0)
                    sum = 0;
            }

            Console.WriteLine(maxSum);
        }

        public void KadanesAlgorithmGetMaxSumAnotherApproachSubArray()
        {
            // int[] nums = { 2, -3, 4, -1, -2, 1, 5, -3 };
            int[] nums = { -4, -3, -2, -1 };
            int maxSum = int.MinValue;
            int sum = 0;
            Range range = ..1;
            int tempStart = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    range = tempStart..(i + 1);
                }

                if (sum < 0)
                {
                    sum = 0;
                    tempStart = i + 1;
                }
            }

            Console.WriteLine($"{string.Join(", ", nums[range])} -> {maxSum}");
        }
    }
}
