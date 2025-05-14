namespace dsa_practice_ram.Arrays
{
    internal class Leader
    {
        public void FindLeader()
        {
            // This is based on the idea current element < max of right elements
            int[] input = { 10, 22, 12, 3, 0, 6 };
            int max = int.MinValue;
            LinkedList<int> result = new LinkedList<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (i == input.Length - 1)
                {
                    result.AddFirst(input[i]); // Add in the same order not reverse 
                }
                else if (input[i] > max)
                {
                    result.AddFirst(input[i]);
                }
                max = Math.Max(max, input[i]);
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
