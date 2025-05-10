using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class SecondLargestThirdLargest
    {
        public void FindSecondLargest()
        {
            int[] array = { 10, 20, 4, 45, 99, 99 };

            int firstLargest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (var num in array)
            {
                if (num > firstLargest)
                {
                    secondLargest = firstLargest;
                    firstLargest = num;
                }
                else if (num > secondLargest && num != firstLargest)
                {
                    secondLargest = num;
                }
            }

            Console.WriteLine(secondLargest);
        }

        public void FindThirdLargest()
        {
            int[] array = { 10, 20, 4, 45, 99, 99 };

            int firstLargest = int.MinValue;
            int secondLargest = int.MinValue;
            int thirdLargest = int.MinValue;

            foreach (var num in array)
            {
                if (num > firstLargest)
                {
                    thirdLargest = secondLargest;
                    secondLargest = firstLargest;
                    firstLargest = num;
                }
                else if (num > secondLargest && num < firstLargest) // handles if num == firstLargest
                {
                    thirdLargest = secondLargest;
                    secondLargest = num;
                }
                else if (num > thirdLargest && num < secondLargest)
                {
                    thirdLargest = num;
                }
            }

            if (thirdLargest == int.MinValue)
                Console.WriteLine("Third largest element not found (not enough distinct elements).");
            else
                Console.WriteLine(thirdLargest);
        }

        public void SecondSmallestElement()
        {
            int[] array = { 10, 2, 4, 20, 4, 45, 99, 99 };

            int firstSmallest = int.MaxValue;
            int secondSmallest = int.MaxValue;

            foreach (var num in array)
            {
                if (num < firstSmallest)
                {
                    secondSmallest = firstSmallest;
                    firstSmallest = num;
                }
                else if (num < secondSmallest && num != firstSmallest)
                {
                    secondSmallest = num;
                }
            }
            if (secondSmallest == int.MaxValue)
                Console.WriteLine("Second smallest element not found (not enough distinct elements).");
            else
                Console.WriteLine(secondSmallest);
        }

        public void FindThirdSmallest()
        {
            int[] array = { 10, 20, 4, 45, 2, 99, 99 };

            int firstSmallest = int.MaxValue;
            int secondSmallest = int.MaxValue;
            int thirdSmallest = int.MaxValue;

            foreach (var num in array)
            {
                if (num < firstSmallest)
                {
                    thirdSmallest = secondSmallest;
                    secondSmallest = firstSmallest;
                    firstSmallest = num;
                }
                else if (num < secondSmallest && num > firstSmallest) // handles if num == firstSmallest
                {
                    thirdSmallest = secondSmallest;
                    secondSmallest = num;
                }
                else if (num < thirdSmallest && num > secondSmallest)
                {
                    thirdSmallest = num;
                }
            }

            if (thirdSmallest == int.MaxValue)
                Console.WriteLine("Third smallest element not found (not enough distinct elements).");
            else
                Console.WriteLine(thirdSmallest);
        }
    }
}
