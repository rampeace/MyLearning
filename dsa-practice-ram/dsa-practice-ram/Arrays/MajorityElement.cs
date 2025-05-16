namespace DsaPractice.Arrays
{
    internal class MajorityElement
    {
        public void GetMajorityElement()
        {
            int[] array = { 1, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 1, 2, 8, 99, 2, 4 };

            var result = array
                .GroupBy(num => num)
                .Select(g => new
                {
                    Number = g.Key,
                    Count = g.Count(),
                })
                .MaxBy(o => o.Count);

            // majority means more than n / 2 times
            if (result?.Count > array.Length / 2)
                Console.WriteLine($"The majority element is {result.Number} -> {result.Count} times");
            else
                Console.WriteLine("The array doesn't have a majority element.");
        }

        public void MoorsVotingAlgorithm()
        {
            // If an element is the majority, it will survive all cancellations when we pair each different element with it.
            // majority means more than n / 2 times
            //int[] array = { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1, 2, 8, 99, 9, 4 };
            int[] array = { 1, 2, 1, 1, 1, 1, 1, 3, 5, 4, 5 };

            int count = 0;
            int candidate = 0;

            foreach (int i in array)
            {
                if (count == 0)
                {
                    candidate = i;
                }

                if (i == candidate)
                    count++;
                else
                    count--;
            }
            if (array.Count(num => num == candidate) > array.Length / 2)
                Console.WriteLine($"The majority element is {candidate}");
            else
                Console.WriteLine("The array doesn't have a majority element.");
        }
    }
}
