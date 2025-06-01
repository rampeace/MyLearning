using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
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
