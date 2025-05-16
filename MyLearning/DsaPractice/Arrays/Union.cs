namespace DsaPractice.Arrays
{
    public class Union
    {
        public void FindUnion()
        {
            int[] array1 = { 1, 1, 2, 3, 4, 5 };
            int[] array2 = { 2, 3, 4, 4, 5, 5, 6, 7, 8 };

            int i = 0, j = 0;
            List<int> result = new List<int>();

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] <= array2[j])
                {
                    if (!result.Any() || result.Last() != array1[i])
                    {
                        result.Add(array1[i]);
                    }
                    i++;
                }
                else
                {
                    if (!result.Any() || result.Last() != array2[j])
                    {
                        result.Add(array2[j]);
                    }
                    j++;
                }
            }

            while (i < array1.Length)
            {
                if (result.Last() != array1[i])
                    result.Add(array1[i]);

                i++;
            }

            while (j < array2.Length)
            {
                if (result.Last() != array2[j])
                    result.Add(array2[j]);

                j++;
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
