using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.BinarySearch
{
    internal class LowerBound
    {
        public int GetLowerBound(int[] nums, int target)
        {
            // Return the smallest index i such that nums[i] >= target 
            // Time complexity: O(log2(n))

            int left = 0;
            int right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // prevents integer overflow

                if (nums[mid] >= target)
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return result;
        }

        public int GetUpperBound(int[] nums, int target)
        {
            // Return the smallest index i such that nums[i] > target 
            // Time complexity: O(log2(n))
            int left = 0;
            int right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // prevents integer overflow

                if (nums[mid] > target)
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return result;
        }

        public int SearchInsertPosition(int[] nums, int target)
        {
            /*
               * Given a sorted array of distinct integers and a target value, return the index if the target is found.
               * If not, return the index where it would be if it were inserted in order.
                  You must write an algorithm with O(log n) runtime complexity.
                https://leetcode.com/problems/search-insert-position/description/
               */

            int left = 0;
            int right = nums.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }
            return left;
        }

        public void Ceiling()
        {
           // GetLowerBound();
        }

        public void GetFloor()
        {
            int[] nums = { 2, 3, 5, 7, 8, 12, 98 };
            int target = 8;

            int left = 0, right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] <= target)
                {
                    result = mid; // Possible floor
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            Console.WriteLine(result); // Will print 4 (nums[4] = 8)
        }

        public void Test()
        {
            /*
             * left = 0, right = 7
             * 
             * 1 -> mid = 3 => left = 0, right = 2
             * 2 -> mid = 1 => left = 2, right = 2
             * 3 -> mid = 2 => left = 3, right = 2 => Violates left <= right)
             * 
             * */
            int[] nums = [ 2, 4, 6, 8, 14, 16, 22, 28 ]; 
            Console.WriteLine(SearchInsertPosition(nums, 7)); // output should be 3
            Console.WriteLine(SearchInsertPosition(nums, 6)); // output should be 2
        }
    }
}
