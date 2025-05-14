namespace dsa_practice_ram.Arrays
{
    internal class ContiguousSubsequence
    {
        public void LongestContigousIncreasingSubsequence()
        {
            int[] array = { 1, 3, 5, 4, 7, 9, 12, 18, 19, 2, 2, 2, 2, 2, 2, 2, 2 };

            int windowStart = 0;
            int maxLength = 0;

            Range range = default;

            for (int windowEnd = 1; windowEnd < array.Length; windowEnd++)
            {
                if (array[windowEnd] <= array[windowEnd - 1])
                {
                    windowStart = windowEnd;
                }

                int windowLength = windowEnd - windowStart + 1;
                if (windowLength > maxLength)
                {
                    range = windowStart..(windowEnd + 1);
                    maxLength = windowLength;
                }
            }

            Console.WriteLine(string.Join(", ", array[range]));
        }
        public void LengthLongestContigousIncreasingSubsequence()
        {
            int[] array = { 1, 3, 5, 4, 7, 9, 12, 18, 19, 2, 2, 2, 2, 2, 2, 2, 2 };

            int maxLength = 1;
            int count = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] <= array[i - 1])
                    count = 0;

                count++;

                maxLength = Math.Max(maxLength, count);
            }

            Console.WriteLine(maxLength);
        }

    }
}
