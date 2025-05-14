namespace dsa_practice_ram.Arrays
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
    }
}
