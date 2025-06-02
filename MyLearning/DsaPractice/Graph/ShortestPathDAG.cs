using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /* Provides functionality to find the shortest path in a Directed Acyclic Graph (DAG).
    
     Given a Directed Acyclic Graph of V vertices from 0 to n-1 and a 2D integer array edges[ ][ ] of length E,
     where there is a directed edge from edge[i][0] to edge[i][1] with a distance of edge[i][2] for all i.
    
     Find the shortest path from src(0) vertex to all the vertices and if it is impossible to reach any vertex,
     then return -1 for that vertex.
    
     Example:
     Input: V = 4, E = 2, edges = [[0,1,2], [0,2,1]]
     Output: [0, 2, 1, -1]
     Explanation: Shortest path from 0 to 1 is 0->1 with edge weight 2.
     Shortest path from 0 to 2 is 0->2 with edge weight 1.
     There is no way we can reach 3, so it's -1 for 3.
     
     Algorithm:
     Keep track of best distance of each node as we explore the graph
     A(best distance x) -> B(best distance y) -> C(best distance z)
    Relaxation is the process of updating our best guess for a node’s shortest distance IF we find a better (shorter) way to reach it
    
             (S) 
             | \
             |  \
            2|   4|
             |    \
            (v1)  (v2)
              \     /
               \   /
                1\ /3
                 (v3)
   
     S v1 v2 v3
    
    DSF stack -> v3, v1, v2 , S
    stack pop -> 
   
    Any edge that ends at v3 can only start from S, v1, or v2—not from v3 or any later node.
    
    When I process node u and relax all its outgoing edges (u → v1, u → v2, etc.), 
    is there a guarantee that the target nodes v1, v2 will appear later in the topological ordering — but not necessarily immediately next?
    
    **/
    internal class ShortestPathDAG
    {
        public class Edge(int to, int weight)
        {
            public int To { get; } = to;

            public int Weight { get; } = weight;
        }

        public void FindShortestPath()
        {
            int nodes = 6;

            List<List<Edge>> adjacencyList = [..Enumerable.Range(0, nodes).Select(_ => new List<Edge>())];

            /*
             *           0
             *        /    \
             *       1      2 
             *     /   \   /
             *    3    4   5 
             */

            adjacencyList[0].Add(new Edge(1, 3));
            adjacencyList[0].Add(new Edge(2, 3));
            adjacencyList[1].Add(new Edge(3, 5));
            adjacencyList[1].Add(new Edge(4, 6));
            adjacencyList[2].Add(new Edge(5, 7));

            bool[] visited = new bool[nodes];
            Stack<int> stack = new();

            for (int node = 0; node < nodes; node++)
            {
                if (!visited[node])
                {
                    DFS(adjacencyList, stack, node, visited);
                }
            }

            int[] orderedNodes = [.. Enumerable.Range(0, stack.Count).Select(_ => stack.Pop())];

            int[] shortestPath = [..Enumerable.Range(0, nodes).Select(i => i == 0 ? 0 : int.MaxValue)];

            foreach(var node in orderedNodes)
            {
                /*
                 *      (S)
                        /  \
                      (A)  (B)
                        \
                        (C)

                      (D)   (E) 

                D and E are not reachable from source
                But S have no incoming edges too, like D and E, we don't ignore S

                 */
                if (shortestPath[node] != int.MaxValue)
                {
                    foreach (var edge in adjacencyList[node])
                    {
                        int currentWeight = shortestPath[node] + edge.Weight;
                        int existingWeight = shortestPath[edge.To];

                        shortestPath[edge.To] = Math.Min(currentWeight, existingWeight);
                    }
                }
            }

            for (int node = 0; node < nodes; node++)
            {
                Console.WriteLine($"{(shortestPath[node] == int.MaxValue ? "INF" : shortestPath[node].ToString())}");
            }
        }

        private void DFS(List<List<Edge>> adjacencyList, Stack<int> stack, int node, bool[] visited)
        {
            visited[node] = true;

            foreach (var to in adjacencyList[node])
            {
                if (!visited[to.To])
                    DFS(adjacencyList, stack, to.To, visited);
            }

            stack.Push(node);
        }
    }
}
