using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Graph
{
    /* 
     *  Bellman-Ford technically revisits all edges each time.
        But distances to nodes with the shortest path using k edges are effectively “finalized” after the k-th iteration.
        Further relaxations don’t change those distances unless there’s a negative cycle 
       (which Bellman-Ford would catch in the final pass).
     */
    internal class BellmanFordAlgorithm
    {
        public int[] BellmanFord(int V, int[,] edges, int src)
        {
            int nodes = V;

            int[] distances = [.. Enumerable.Range(0, nodes).Select(i => i == src ? 0 : int.MaxValue)];

            int rows = edges.GetLength(0);

            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    int from = edges[j, 0];
                    int to = edges[j, 1];
                    int weight = edges[j, 2];

                    int newDistance = distances[from] + weight;
                    int existingDistance = distances[to];

                    if (distances[from] != int.MaxValue && newDistance < existingDistance)
                    {
                        if (i == nodes - 1) // negative cycle detected
                            return [];

                        distances[to] = newDistance;

                    }
                }
            }

            return distances;
        }

        public void Test()
        {
            // Number of vertices in the graph
            int V = 5;

            int[,] edges = 
                {
                { 1, 3, 2 },
                { 4, 3, -1 },
                { 2, 4, 1 },
                { 1, 2, 1 },
                { 0, 1, 5 }
                };

            int src = 0;

            int[] ans = BellmanFord(V, edges, src);

            foreach (var d in ans)
            {
                Console.Write(d == int.MaxValue ? "INF, " : d + ", ");
            }
        }
    }
}
