namespace DsaPractice.Arrays
{
    internal class MissingNumbers
    {
        public void FindMissingNumbers()
        {
            int[] input = { 4, 3, 2, 7, 8, 2, 3, 1, 10, 13 };

            Array.Sort(input);

            // 1, 2, 2, 3, 3, 4, 7, 8
            List<int> result = new List<int>();

            for (int i = 1; i < input.Length; i++)
            {
                int curr = input[i];
                int previous = input[i - 1];

                for (int j = previous + 1; j < curr; j++)
                {
                    result.Add(j);
                }
            }
            Console.WriteLine(string.Join(",  ", result));
        }

        public void FindMissingNumbersOptimalInplace()
        {
            // To find missing elements between 1 to n, the array should have n number of elements
            // Also the array range should be between 1 to n
            // Does not work if the array have negative numbers
            // Floating point numbers or strings

            int[] input = { 4, 3, 2, 7, 8, 2, 3, 1, 9, 9, 9 };

            for (int i = 0; i < input.Length; i++)
            {
                int index = Math.Abs(input[i]) - 1;

                if (input[index] > 0)
                    input[index] = -input[index];
            }

            var missingNumbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 0)
                    missingNumbers.Add(i + 1);
            }

            Console.WriteLine(string.Join(", ", missingNumbers));
        }
    }
}
