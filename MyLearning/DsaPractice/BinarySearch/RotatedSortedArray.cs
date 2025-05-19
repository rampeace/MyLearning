using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.BinarySearch
{
    internal class RotatedSortedArray
    {
        public void SearchElementRotatedSortedArray()
        {
            /*
             *  -> Right rotation  
               [ 7, 8, 9, 1, 2, 3, 4, 5, 6 ]
                 ^           ^
               target

                <- Left rotation
                [ 3, 4, 5, 6, 7, 8, 9,  10, 1, 2 ]
                              ^             ^
                                          target
            */

            int[] nums = { 3, 4, 5, 6, 7, 8, 9, 10, 1, 2 };
            int target = 1;

            int left = 0;
            int right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    result = mid;
                    break;
                }

                if (nums[left] <= nums[mid]) // left is the sorted half
                {

                    if (target < nums[mid] && target >= nums[left])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (target > nums[mid] && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            Console.WriteLine(result);
        }

        public void IsNumberRotated()
        {
            int[] nums = { 3, 4, 5, 6, 7, 8, 9, 10, 1, 2 };
            int target = 8;

            Console.WriteLine(IsNumberRotated(nums, 4));
        }

        private bool IsNumberRotated(int[] nums, int  target)
        {
            /*
             * [1, 2, 3, 4, 5, 6, 7, 8, 9]
             * 
               -> Right rotation  
               [ 7, 8, 9, 1, 2, 3, 4, 5, 6 ]
                 ^           ^
               target

            <- Left rotation
            [ 3, 4, 5, 6, 7, 8, 9,  10, 1, 2 ]
                          ^             ^
                                       target
            */

            int left = 0;
            int right = nums.Length - 1;
            int mid = left + (right - left) / 2;

            if (nums[left] <= nums[mid]) // left is the sorted half
            {
                return target < nums[left];
            }
            else
            {
                return target > nums[right];
            }
        }

        public bool IsRotated(int[] nums) => nums[0] > nums[nums.Length - 1];

        public bool IsLeftRotatated(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = left + (right - left) / 2;

            return nums[left] <= nums[mid];
        }

        public void SearchElementRotatedSortedArrayWithDuplicates()
        {
            int[] nums = { 3, 1, 2, 3, 3, 3, 3 };

            int target = 1;

            int left = 0;
            int right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    result = mid;
                    break;
                }
                if (nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                    continue;
                }

                if (nums[left] <= nums[mid]) // left is the sorted half
                {

                    if (target < nums[mid] && target >= nums[left])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (target > nums[mid] && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            Console.WriteLine(result);
        }
    }
}
