namespace dsa_practice_ram.Arrays
{
    internal class ArrayRotation
    {
        public void RotateArrayUsingReverse()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;

            k %= nums.Length; // In case k > length

            Console.WriteLine(k);

            Reverse(nums, 0, nums.Length - 1);        // Step 1: Reverse entire array
            Reverse(nums, 0, k - 1);                  // Step 2: Reverse first k elements
            Reverse(nums, k, nums.Length - 1);        // Step 3: Reverse remaining elements

            Console.WriteLine(string.Join(", ", nums));
        }

        private void Reverse(int[] arr, int left, int right)
        {
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }
    }
}
