using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.SlidingWindow
{
    internal class ContainsDuplicate
    {
        /*
     *  https://leetcode.com/problems/contains-duplicate-ii/description/
        Given an integer array nums and an integer k, 
        return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
       */

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            // [1, 2, 3, 1, 4, 8, 1]

            int windowStart = 0;
            HashSet<int> seen = [];

            for (int windowEnd = 0;  windowEnd < nums.Length; windowEnd++)
            {
                while(windowEnd - windowStart > k)
                {
                    seen.Remove(nums[windowStart]);
                    windowStart++;
                }

                if (!seen.Add(nums[windowEnd]))
                    return true;
            }

            return false;

        }
    }
}
