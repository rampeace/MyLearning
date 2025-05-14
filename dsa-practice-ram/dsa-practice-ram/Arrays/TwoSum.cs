namespace dsa_practice_ram.Arrays
{
    internal class TwoSum
    {
        public void FindTwoSum()
        {
            int[] array = { 2, 6, 4, 6, 8, 5, 8, 1, 1, 10 };
            int target = 14;
            var pairs = new List<(int x, int y)>();
            var seen = new HashSet<int>();

            foreach (var x in array)
            {
                int y = target - x;

                if (seen.Contains(y))
                {
                    if (!pairs.Contains((y, x)) && !pairs.Contains((x, y)))
                        pairs.Add((x, y));
                }
                seen.Add(x);
            }

            foreach (var pair in pairs)
            {
                Console.WriteLine($"({pair.x}, {pair.y})");
            }
        }

        public void TwoSumOpimal()
        {
            int[] array = { 2, 6, 4, 6, 8, 5, 8, 1, 1, 10 };
            // sorted: { 1, 1, 2, 4, 5, 6, 8, 8, 10 }
            Array.Sort(array);

            int target = 14;

            int left = 0;
            int right = array.Length - 1;
            List<(int x, int y)> pairs = new List<(int x, int y)>();

            while (left < right)
            {
                int x = array[left];
                int y = array[right];

                if (x + y == target)
                {
                    pairs.Add((x, y));
                    left++;
                    right--;
                }
                else if (x + y < target)
                {
                    left++;
                }
                else
                    right--;
            }

            foreach (var pair in pairs)
            {
                Console.WriteLine($"({pair.x}, {pair.y})");
            }
        }
    }
}
