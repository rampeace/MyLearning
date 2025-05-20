using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.BinarySearch
{
    internal class KokoEatingBananas
    {
        /*
      * 
      * Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. 
      * The guards have gone and will come back in h hours.
        Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas 
        and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead 
        and will not eat any more bananas during this hour.

        Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

        Return the minimum integer k such that she can eat all the bananas within h hours.
      * */

        public int BruteForce(int[] piles, int hours)
        {
            return Enumerable.Range(1, piles.Max())
                             .First(k => piles.Sum(pile => (int)Math.Ceiling((double)pile / k)) <= hours);
        }

        public void BruteForceApproach()
        {
            int[] piles = { 3, 6, 7, 11 };
            int result = BruteForce(piles, 8);
            Console.WriteLine(result);
        }

        public void BinarySearchApproach()
        {
            int[] piles = { 3, 6, 7, 11 };
            int result = BinarySearchApproach(piles, 8);
            Console.WriteLine(result);
        }

        public int BinarySearchApproach(int[] piles, int hours)
        {
            /*
             * [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 ]           
             *                  6 hours
             */

            int left = 1;
            int right = piles.Max();
            int result = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int totalHours = piles.Sum(pile => (int)Math.Ceiling((double)pile / mid));

                if (totalHours <= hours)
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }
            return result;
        }
    }
}
