namespace DsaPractice.Arrays
{
    internal class Leader
    {
        public void FindLeader()
        {
            int[] input = { 10, 22, 12, 3, 0, 6 };

            int max = input.Last();

            LinkedList<int> result = new();

            for (int i = input.Length - 2; i >= 0; i--)
            {
                int curr = input[i];

                if (curr > max)
                    result.AddFirst(curr);

                max = Math.Max(curr, max);
            }
        }
    }
}
