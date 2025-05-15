namespace dsa_practice_ram.Arrays
{
    /*
     *
    - Common Approaches for "Subarrays with Sum K" Problems
    - Prefix Sum + HashMap (O(N)) ->
          Best for handling negative numbers & unordered elements
          This method efficiently tracks cumulative sums and finds subarrays in linear time.
          Works universally even with negatives or when numbers appear in a non-contiguous manner.

    - Sliding Window (O(N) ->
        Only for Positive Numbers) -> Works only for positive numbers
        The sum always increases, so adjusting the window optimally is possible.
        Fails with negatives because shrinking the window may miss valid subarrays.

    - Brute Force (O(N^2)) -> Simple but slow
        Generates all subarrays and checks sums.
        Not efficient for large arrays.

    - Kadane's Algorithm (For Largest Sum Subarray) -> Not directly relevant here but useful for maximum sum problems
    - Helps find the largest sum contiguous subarray efficiently

     * */
    internal class SubArraySum
    {
        public void FindLongestSubArraySum()
        {
            // Find the longest subarray whose sum is equal to k
            // Sliding window works only for positive numbers. For negative numbers use prefix sum
            int[] array = { 1, 2, 3, 0, 0, 0, 1, 1, 1, 1, 4, 2, 3 };
            const int k = 3;
            int sum = 0;
            int windowStart = 0;
            (int start, int end) subArray = default;

            for (int windowEnd = 0; windowEnd < array.Length; windowEnd++)
            {
                sum += array[windowEnd];

                while (sum > k)
                {
                    sum -= array[windowStart];
                    windowStart++;
                }

                if (sum == k)
                {
                    int currentLength = windowEnd - windowStart + 1;

                    if (currentLength > subArray.end - subArray.start + 1)
                        subArray = (windowStart, windowEnd);
                }
            }

            Console.WriteLine(subArray);
        }

        public void CountSubArraysWithSum()
        {
            // Count the number of subarrays whose sum equal to k
            // Sliding window works only for positive numbers. For negagive numbers use prefix sum
            int[] array = { 1, 2, 3, 3, 1, 1, 1, 4, 3, 2, 3 };

            const int k = 3;

            int windowStart = 0;
            int windowSum = 0;
            int count = 0;

            for (int windowEnd = 0; windowEnd < array.Length; windowEnd++)
            {
                windowSum += array[windowEnd];

                while (windowSum > k)
                {
                    windowSum -= array[windowStart];
                    windowStart++;
                }

                if (windowSum == k)
                {
                    count++;
                    Console.WriteLine($"{windowStart}, {windowEnd}");
                }
            }
            Console.WriteLine(count);
        }

        public void CountSubArraysWithNegativeNumbers()
        {
            // Count the number of subarrays whose sum equal to k
            // Prefix sum method

            int[] array = { 1, 2, 0, 0, 3, -3, 1, 1, 1, 4, 3, 2, -3 };

            const int k = 3;

            Dictionary<int, int> prefixSumCount = new();

            // If a prefix sum ever becomes exactly k, then the subarray from index 0 to current index should be counted."
            // To account the  beginning of the array, when prefixsum == k
            prefixSumCount[0] = 1;
            int prefixSum = 0;
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                prefixSum += array[i];

                int target = prefixSum - k;

                if (prefixSumCount.ContainsKey(target))
                {
                    count += prefixSumCount[target];
                }

                if (!prefixSumCount.ContainsKey(prefixSum))
                    prefixSumCount[prefixSum] = 0;

                prefixSumCount[prefixSum]++;
            }

            Console.WriteLine(count);
        }

        public void CalculateSumBetweenTwoIndices()
        {
            int[] nums = { 10, 20, 5, 15 };

            int[] prefixSum = new int[nums.Length];

            prefixSum[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i];
            }

            int start = 0;
            int end = 2;
            int sum = 0;

            if (start == 0)
                sum = prefixSum[end];
            else
                sum = prefixSum[end] - prefixSum[start - 1];

            Console.WriteLine($"Sum between index 0 and 1 is: {prefixSum[2] - prefixSum[0]}");
        }

        public void PrintSubArraysWhichSumK()
        {
            // Print all the subarrays whose sum equal to k
            // Prefix sum method

            int[] array = { 1, 2, 0, 0, 3, -3, 1, 1, 1, 4, 3, 2, -3 };

            const int k = 3;

            Dictionary<int, List<int>> prefixSumMap = new();

            // If a prefix sum ever becomes exactly k, then the subarray from index 0 to current index should be counted."
            // To account the  beginning of the array, when prefixsum == k
            prefixSumMap[0] = new List<int> { -1 };
            int prefixSum = 0;
            List<Range> subArrays = new();

            for (int i = 0; i < array.Length; i++)
            {
                prefixSum += array[i];

                int target = prefixSum - k;

                if (prefixSumMap.ContainsKey(target))
                {
                    foreach (var start in prefixSumMap[target])
                    {
                        subArrays.Add((start + 1)..(i + 1));
                    }
                }

                if (!prefixSumMap.ContainsKey(prefixSum))
                {
                    prefixSumMap[prefixSum] = new List<int>();
                }
                prefixSumMap[prefixSum].Add(i);
            }

            foreach (var range in subArrays)
            {
                Console.WriteLine(string.Join(", ", array[range]));
            }
        }
    }
}
