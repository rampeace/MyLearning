using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Hashing
{
    internal class DifferenceTwoArrays   
    {
        /*
            Leetcode 2215. Find the Difference of Two Arrays

        */
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            return
            Enumerable.Range(0, 2)
            .Select(i => i == 0 ? 
            (IList<int>)nums1.Except(nums2).ToList() :
            (IList<int>)nums2.Except(nums1).ToList())
            .ToList();
        }

        public void Test()
        {
            int[] nums1 = [1, 2, 3];
            int[] nums2 = [2, 4, 6];

            var result = FindDifference(nums1, nums2);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }
    }
}
