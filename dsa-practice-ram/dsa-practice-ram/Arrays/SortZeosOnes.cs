namespace dsa_practice_ram.Arrays
{
    public class SortZeosOnes
    {
        public void SortZeosOness()
        {
            int[] array = { 1, 0, 0, 1, 1, 1, 0, 0, 1 };
            int zerosTotal = 0;

            foreach (var item in array)
            {
                if (item == 0)
                    zerosTotal++;
            }

            for (int i = 0; i < zerosTotal; i++)
            {
                array[i] = 0;
            }
            for (int i = zerosTotal; i < array.Length; i++)
            {
                array[i] = 1;
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
