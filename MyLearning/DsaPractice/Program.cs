using DsaPractice.Arrays;
using DsaPractice.Arrays._2D;
using DsaPractice.BinarySearch;
using DsaPractice.BitManipulation;
using DsaPractice.Graph;
using DsaPractice.Hashing;
using DsaPractice.LinkedList;
using DsaPractice.Maths;
using DsaPractice.MinHeap;
using DsaPractice.Queue;
using DsaPractice.Recursion;
using DsaPractice.Trees;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace DsaPractice
{
    internal class Program
    {
        static void Main()
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
                
            /*
             * Monotonic predicate (True/False) over a range
             * 
             */

            int[] piles = { 3, 6, 7, 11 };
            int hours = 5;

            /*
             *      [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
             *      
             */

            // Brute force

            var result = Enumerable.Range(1, piles.Max())
                .First(bananaPerHour => Math.Ceiling(piles.Sum(pile => (double)(pile / bananaPerHour))) <= hours);

            // Binary search

            int left = 1;
            int right = piles.Max();
            int bananaPerHour = 0;

            while(left < right)
            {
                int mid = (left + right) / 2;

                int totalHours = (int)Math.Ceiling(piles.Sum(pile => (double)(pile / mid)));

                if (totalHours <= hours)
                {
                    bananaPerHour = mid;
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }
        }
    }
}
