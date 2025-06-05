using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /*
     * There are n cities connected by some number of flights.
     * You are given an array flights where flights[i] = [fromi, toi, pricei]
     * indicates that there is a flight from city fromi to city toi with cost pricei.
     *
     * You are also given three integers src, dst, and k.
     * Return the cheapest price from src to dst with at most k stops.
     * If there is no such route, return -1.
     *
     * Example:
     * Input: n = 4,
     *        flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]],
     *        src = 0, dst = 3, k = 1
     * Output: 700
     * Explanation:
     * The optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.
     * Note that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.
     */
    internal class CheapestFlightsWithinKStops
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            List<List<(int to, int price)>> adjacencyList = 
                [..Enumerable.Range(0, n).Select(_ => new List<(int to, int price)>())];


            foreach (var edge in flights)
            {
                int from = edge[0];
                int to = edge[1];
                int price = edge[2];

                adjacencyList[from].Add((to, price));
            }

            Dictionary<(int city, int stops), int> seen = new(); 

            PriorityQueue<(int city, int cost, int stops), int> priorityQueue = new();
            priorityQueue.Enqueue((src, 0, 0), 0);
            
            int[] costs = [..Enumerable.Range(0, n).Select((_, i) => i == 0 ? 0 : int.MaxValue)];

            while(priorityQueue.Count > 0)
            {
                var (from, cost, stops) = priorityQueue.Dequeue();

                if (from == dst)
                    return cost;

                if (stops <= k)
                {
                    foreach (var (to, price) in adjacencyList[from])
                    {
                        int newCost = cost + price;
                        int stopsSoFor = stops + 1;

                        if (!seen.TryGetValue((to, stopsSoFor), out int existingCost) || newCost < existingCost)
                        {
                            seen[(to, stopsSoFor)] = newCost;
                            priorityQueue.Enqueue((to, newCost, stopsSoFor), newCost);
                        }
                    }
                }
            }

            return -1;
        }

        public void Test()
        {
            int n = 4;
            int[][] flights = [
                [0,1,100],
                [1,2,100],
                [2,0,100],
                [1,3,600],
                [2,3,200]
            ];
            int src = 0;
            int dst = 3;
            int k = 1;

            int result = FindCheapestPrice(n, flights, src, dst, k);
            Console.WriteLine($"Cheapest price from {src} to {dst} with at most {k} stops: {result}");
        }
    }
}
