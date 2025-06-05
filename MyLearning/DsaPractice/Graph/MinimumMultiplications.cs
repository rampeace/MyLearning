using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DsaPractice.Graph
{

    /*
     * https://www.geeksforgeeks.org/problems/minimum-multiplications-to-reach-end/1
     * 
     * Given start, end and an array arr of n numbers. At each step, start is multiplied with any number in the array 
     * and then mod operation with 100000 is done to get the new start.
     *
     * Your task is to find the minimum steps in which end can be achieved starting from start. 
     * If it is not possible to reach end, then return -1.
     *
     * Example 1:
     * Input:
     *   arr[] = {2, 5, 7}
     *   start = 3, end = 30
     * Output:
     *   2
     * Explanation:
     *   Step 1: 3 * 2 = 6 % 100000 = 6 
     *   Step 2: 6 * 5 = 30 % 100000 = 30
     *
     * Nodes: 0 - 99999
     * Edges: u to (u * x) % 100000
     * 
     *  Each number 0 to 99999 is a node.
        Edges are defined by multiplying and taking % 100000.
        BFS ensures shortest path — since all neighbors at a given level are explored before moving deeper.
        Early return on enqueue is safe because of immediate marking as visited.
        visited ensures no duplicate processing.
     */
    internal class MinimumMultiplications
    {
        public int MinimumMultiplicationsToReachEnd(List<int> arr, int start, int end)
        {
            if (start == end)
                return 0;

            const int MOD = 100000;
            HashSet<int> visited = [];

            Queue<(int node, int steps)> queue = new();
            queue.Enqueue((start, 0));


            while(queue.Any())
            {
                var (from, steps) = queue.Dequeue();

                var edges = arr.Select(num => from * num % MOD);

                foreach (var to in edges)
                {
                    if (!visited.Contains(to))
                    {
                        visited.Add(to);

                        if (to == end)
                            return steps + 1;

                        queue.Enqueue((to, steps + 1));
                    }
                }
            }

            return -1;
        }

        public void Test()
        {
            List<int> arr = [ 2, 5, 7 ];

            int start = 3, end = 30;

            int steps = MinimumMultiplicationsToReachEnd(arr, start, end);

            Console.WriteLine(steps);
        }
    }
}
