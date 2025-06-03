using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DsaPractice.Graph
{
    /*
     *        0
             /  \
            1    3
             \    \
              2    4
               \   |
                6--5
               / \
              7---8
     * 
     * Do BFS and count the level
     * 
     * Function to find the shortest path from source to all other nodes
     * 
     * When designing a graph make sure every node has a unique index or ID in the adjacency list (like 0, 1, 2, …).
     * 
     * */

    internal class ShortestPathUndirectedGraph
    {
        public List<int> ShortestPath(List<List<int>> adj, int src) => BFS(adj, src);

        private List<int> BFS(List<List<int>> adjacencyList, int source)
        {
            int nodes = adjacencyList.Count;

            List<int> levels = [..Enumerable.Repeat(-1, nodes)];

            levels[0] = source;

            Queue<int> queue = new();

            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (var to in adjacencyList[node])
                {
                    if (levels[to] == -1)
                    {
                        levels[to] = levels[node] + 1;
                        queue.Enqueue(to);
                    }
                }
            }

            return levels;
        }

        public void Test()
        {
            List<List<int>> adjacencyList = new List<List<int>>
            {
                new List<int>{1,3},             // 0
                new List<int>{0,2},             // 1
                new List<int>{1,6},             // 2
                new List<int>{0,4},             // 3
                new List<int>{3,5},             // 4
                new List<int>{4,6},             // 5
                new List<int>{2,5,7,8},         // 6
                new List<int>{6,8},             // 7
                new List<int>{7,6}              // 8
            };

            int src = 0;
            List<int> shortestDistances = ShortestPath(adjacencyList, src);

            for (int i = 0; i < shortestDistances.Count; i++)
            {
                Console.WriteLine($"Distance from {src} to {i} = {shortestDistances[i]}");
            }
        }
    }
}
