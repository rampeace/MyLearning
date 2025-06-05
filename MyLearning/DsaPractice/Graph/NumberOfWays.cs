using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Graph
{
    /*
/*
 * Problem: Number of Ways to Arrive at Destination
 * Source: https://leetcode.com/problems/number-of-ways-to-arrive-at-destination/
 * 
 * Description:
 * You are given a city with 'n' intersections, labeled from 0 to n - 1. The city has bi-directional roads, each connecting two intersections.
 * Each road is represented as [ui, vi, timei], indicating a road between intersections ui and vi that takes timei minutes to travel.
 * It is guaranteed that you can reach any intersection from any other intersection, and there is at most one road between any two intersections.
 * 
 * Task:
 * Find the number of different ways to travel from intersection 0 to intersection n - 1 in the shortest possible time.
 * Since the answer can be large, return it modulo 10^9 + 7.
 * 
 * Example:
 * Input: n = 7, roads = [[0,6,7],[0,1,2],[1,2,3],[1,3,3],[6,3,3],[3,5,1],[6,5,1],[2,5,1],[0,4,5],[4,6,2]]
 * Output: 4
 * Explanation: The shortest time from intersection 0 to 6 is 7 minutes.
 * The four shortest paths are:
 * - 0 ➝ 6
 * - 0 ➝ 4 ➝ 6
 * - 0 ➝ 1 ➝ 2 ➝ 5 ➝ 6
 * - 0 ➝ 1 ➝ 3 ➝ 5 ➝ 6
 */
    internal class NumberOfWays
    {
        public int CountPaths(int n, int[][] roads)
        {
            List<List<(int to, int time)>> adjacencyList = [.. Enumerable.Range(0, n).Select(_ => new List<(int to, int time)>())];

            foreach (var edge in roads)
            {
                int from = edge[0];
                int to = edge[1];
                int time = edge[2];

                adjacencyList[from].Add((to, time));
                adjacencyList[to].Add((from, time));
            }

            int[] shortestTime = [..Enumerable.Range(0, n).Select(i => i == 0 ? 0 : int.MaxValue)];

            int[] ways = [.. Enumerable.Range(0, n).Select(i => i == 0 ? 1 : 0)];

            PriorityQueue<(int from,int time), int> priorityQueue = new();
            priorityQueue.Enqueue((0, 0), 0);

            while(priorityQueue.Count > 0)
            {
                var (from, timeSoFor)  = priorityQueue.Dequeue();

                if (timeSoFor > shortestTime[from])
                    continue;

                foreach (var (to, time) in adjacencyList[from])
                {
                    int newTime = timeSoFor + time;

                    if (newTime < shortestTime[to])
                    {
                        shortestTime[to] = newTime;
                        ways[to] = ways[from];

                        priorityQueue.Enqueue((to, newTime), newTime);
                    }
                    else if (newTime == shortestTime[to])
                    {
                        ways[to] += ways[from];
                    }
                }
            }

            return ways[n - 1];
        }

        public void Test()
        {
            int n = 7;
            int[][] roads =

  [[0, 6, 7], [0, 1, 2], [1, 2, 3], [1, 3, 3], [6, 3, 3], [3, 5, 1], [6, 5, 1], [2, 5, 1], [0, 4, 5], [4, 6, 2]];
            int result = CountPaths(n, roads);
            Console.WriteLine($"Number of ways: {result}");
        }
    }
}
