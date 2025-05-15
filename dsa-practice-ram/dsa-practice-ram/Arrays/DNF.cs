namespace dsa_practice_ram.Arrays
{
    internal class DNF
    {
        /*
         * 
         * [0...    ][1.....  ][unknown.....][2.......]
                      ^         ^          ^
	                  low      mid        high
        
            0 -> 0 - low - 1
            1 -> low - mid - 1
            2 -> high + 1 - n - 1
        */

        public void DutchNationalFlag()
        {
            int[] array = { 2, 1, 0, 1, 1, 2, 0, 0, 2, 1, 1, 1 };
            int low = 0;
            int mid = 0;
            int high = array.Length - 1;

            while (mid <= high)
            {
                int midValue = array[mid];

                if (midValue == 0)
                {
                    int temp = array[low];
                    array[low] = array[mid];
                    array[mid] = temp;

                    low++;
                    mid++;
                }
                else if (midValue == 1)
                {
                    mid++;
                }
                else
                {
                    int temp = array[high];
                    array[high] = array[mid];
                    array[mid] = temp;
                    high--;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
