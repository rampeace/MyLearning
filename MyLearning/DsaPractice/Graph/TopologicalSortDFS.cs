using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /* Provides functionality to find the shortest path in a Directed Acyclic Graph (DAG).
     *
     * Given a Directed Acyclic Graph of V vertices from 0 to n-1 and a 2D integer array edges[ ][ ] of length E,
     * where there is a directed edge from edge[i][0] to edge[i][1] with a distance of edge[i][2] for all i.
     *
     * Find the shortest path from src(0) vertex to all the vertices and if it is impossible to reach any vertex,
     * then return -1 for that vertex.
     *
     * Example:
     * Input: V = 4, E = 2, edges = [[0,1,2], [0,2,1]]
     * Output: [0, 2, 1, -1]
     * Explanation: Shortest path from 0 to 1 is 0->1 with edge weight 2.
     * Shortest path from 0 to 2 is 0->2 with edge weight 1.
     * There is no way we can reach 3, so it's -1 for 3.
     */
    internal class TopologicalSortDFS
    {
        public int[] DoTopologicalSortDFS(int V, int[][] edges)
        {
            // 0 - V-1 -> Nodes , [from, to] -> edges

            List<List<int>> adjacencyList = [.. Enumerable.Range(0, V).Select(_ => new List<int>())];

            foreach (var edge in edges)
            {
                int from = edge[0];
                int to = edge[1];

                adjacencyList[from].Add(to);
            }

            bool[] visited = new bool[V];
            Stack<int> stack = new();

            for (int node = 0; node < V; node++)
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    DFS(adjacencyList, stack, node, visited);
                }
            }

            return [.. Enumerable.Range(0, stack.Count).Select(_ => stack.Pop())];
        }

        private void DFS(List<List<int>> adjacencyList, Stack<int> stack, int node, bool[] visited)
        {
            foreach (var edge in adjacencyList[node])
            {
                if (!visited[edge])
                {
                    visited[edge] = true;
                    DFS(adjacencyList, stack, edge, visited);
                }
            }
            stack.Push(node);
        }

        public void Test()
        {
            int v = 6;

            int[][] edges =
            [
                [2, 3], [3, 1],
                [4, 0], [4, 1],
                [5, 0], [5, 2]
            ];

            int[] ans = DoTopologicalSortDFS(v, edges);

            Console.WriteLine(string.Join(" ", ans));
        }
    }
}
