using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class SafeStates
    {
        /*
         * https://leetcode.com/problems/find-eventual-safe-states/
         * Find Eventual Safe States
         * There is a directed graph of n nodes labeled from 0 to n - 1. The graph is represented by 
         * a 0-indexed 2D integer array graph where graph[i] is an array of nodes adjacent to node i.
         * A node is a terminal node if there are no outgoing edges. A node is a safe node if every possible
         * path starting from that node leads to a terminal node (or another safe node).
         * Return an array containing all the safe nodes of the graph, sorted in ascending order.
         * 
         * Idea: Reverse the graph. Jump only to safe states and see who can reach them.
         * A safe node is defined as:
         *   A node from which all paths lead to a terminal node (or other safe nodes that eventually lead to terminal nodes).
         */
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            // graph = [[1,2],[2,3],[5],[0],[5],[],[]]

            // Reverse the graph
            List<List<int>> reversed = [.. Enumerable.Range(0, graph.Length).Select(_ => new List<int>())];

            int[] outdegree = new int[graph.Length];

            for (int from  = 0; from < graph.Length; from++)
            {
                foreach (var to in graph[from])
                {
                    reversed[to].Add(from);
                    outdegree[from]++;
                }
            }

            // start from the terminal nodes
            Queue<int> queue = new();

            for (int node = 0; node < outdegree.Length; node++)
            {
                if (outdegree[node] == 0)
                    queue.Enqueue(node);
            }

            List<int> safeNodes = [];

            while(queue.Count > 0)
            {
                int current = queue.Dequeue();

                safeNodes.Add(current);

                foreach (var neighbour in reversed[current])
                {
                    outdegree[neighbour]--;

                    if (outdegree[neighbour] == 0)
                        queue.Enqueue(neighbour);
                }
            }

            safeNodes.Sort();

            return safeNodes;
        }

        public void Test()
        {
            int[][] graph = [[1, 2], [2, 3], [5], [0], [5], [], []];

            Console.WriteLine(string.Join(", ", EventualSafeNodes(graph)));
        }
    }
}
