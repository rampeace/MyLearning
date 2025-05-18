using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.BinarySearch
{
    internal class Search
    {
        public void BinarySearch()
        {
            int[] nums = { 2, 3, 5, 7, 8, 9, 98, 104 };

            int left = 0;
            int right = nums.Length - 1;
            int target = 8;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // prevents integer overflow

                if (nums[mid] == target)
                {
                    Console.WriteLine("found");
                    break;
                }
                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
        }

        public void BinarySearchRecursive()
        {
            int[] nums = { 2, 3, 5, 7, 8, 9, 98, 104 };

            bool found = BinarySearchRecursive(nums, 0, nums.Length - 1, 12);

            Console.WriteLine(found);
        }

        private bool BinarySearchRecursive(int[] nums, int left, int right, int target)
        {
            if (left > right)
                return false;

            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return true;

            if (nums[mid] > target)
                return BinarySearchRecursive(nums, left, mid - 1, target);
            else
                return BinarySearchRecursive(nums, mid + 1, right, target);
        }
    }
}
