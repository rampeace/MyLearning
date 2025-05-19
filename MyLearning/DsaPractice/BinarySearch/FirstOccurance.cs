using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.BinarySearch
{
    internal class FirstOccurance
    {
        int FindFirstOccurrence(int[] arr, int target)
        {
            // [ 1, 3, 5, 7, 8, 8, 9, 10]
            // target = 8
            int left = 0, right = arr.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    result = mid;
                    right = mid - 1; // keep searching in the left half
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        int FindLastOccurrence(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    result = mid;
                    left = mid + 1; // keep searching in the right half
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

    }
}
