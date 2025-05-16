namespace DsaPractice.Arrays
{
    internal class CreateAllSubArrays
    {
        public void CreateAllSubArrayss()
        {
            int[] input = { 1, 2, 3, 4, 5 };
            List<List<int>> subArrays = new List<List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                List<int> current = new List<int>();

                for (int j = i; j < input.Length; j++)
                {
                    current.Add(input[j]);
                    subArrays.Add(new List<int>(current));
                }
            }

            foreach (var subArray in subArrays)
            {
                Console.WriteLine(string.Join(", ", subArray));
            }
        }
    }
}
