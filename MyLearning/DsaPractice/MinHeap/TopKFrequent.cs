using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.MinHeap
{
    internal class TopKFrequent
    {
        /*
         *  Time: O(N log k) — where N is the number of unique elements.
            Space: O(N) — for the frequency dictionary and heap.

            LINQ w/ Sorting -> O(N log N)
                - Not ideal when performance matters for huge datasets (since sorting all groups can be expensive).
         * */
        public int[] GetTopKFrequent(int[] nums, int k)
        {
            var dict = nums
                .GroupBy(num => num)
                .ToDictionary(g => g.Key, g => g.Count());

            PriorityQueue<int, int> minHeap = new();

            foreach (var kvp in dict)
            {
                minHeap.Enqueue(kvp.Key, kvp.Value);

                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }

            return Enumerable.Range(0, k)
                .Select(_ => minHeap.Dequeue())
                .Reverse()
                .ToArray();
        }

        public void Test()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int k = 2;

            var result = GetTopKFrequent(nums, k); // Output: [1, 2]

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
